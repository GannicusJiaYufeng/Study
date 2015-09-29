using KH.BLL;
using KH.Model;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KH.Admin.CourseMgr
{
    /// <summary>
    /// ChapterController 的摘要说明
    /// </summary>
    public class ChapterController : BaseHandler
    {

        //面向对象中继承的优点：把通用的工作交给父类完成
        public void list(HttpContext context)
        {
            AdminHelper.CheckPower("章节管理");//检查登录用户的权限
            long courseId = Convert.ToInt64(context.Request["id"]);//哪个课程的章节
            var chapters = new ChaptersBLL().GetModelList("CourseId=" + courseId + " order by seqno ASC");
            KHHelper.OutputRazor(context, "~/CourseMgr/ChapterList.cshtml", new
            {
                courseId = courseId,
                Chapters = chapters
            });
        }

        public void addnew(HttpContext context)
        {
            long courseId = Convert.ToInt64(context.Request["courseId"]);
            KHHelper.OutputRazor(context, "~/CourseMgr/ChapterAddNewEdit.cshtml", new { courseId = courseId, action = "addnewSave", id = "", name = "", oldSeqNo = "" });
        }

        public void addnewSave(HttpContext context)
        {
            string name = context.Request["Name"];
            if (new ChaptersBLL().IsHaveName(name))
            {
                context.Response.Write("章节名字不可以重复"); return;
            }
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(context.Request["SeqNo"]))
            {
                context.Response.Write("章节名字和seqno不能为空"); return;
            }
            long courseId = Convert.ToInt64(context.Request["courseId"]);
            Chapters chapter = new Chapters();
            chapter.CourseId = courseId;
            chapter.Name = name;
            chapter.SeqNo = Convert.ToInt32(context.Request["SeqNo"]);
            new ChaptersBLL().AddNewChapterSeqNo(Convert.ToInt32(context.Request["SeqNo"]));
            new ChaptersBLL().Add(chapter);
            context.Response.Redirect("ChapterController.ashx?action=list&id=" + courseId);
            AdminHelper.RecordOperationLog("增加了章节" + name);//写日志
        }
        public void edit(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            long courseId = Convert.ToInt64(context.Request["courseId"]);
            string name = (new ChaptersBLL().GetModel(chapterId)).Name;
            int oldSeqNo = (new ChaptersBLL().GetModel(chapterId)).SeqNo;
            KHHelper.OutputRazor(context, "~/CourseMgr/ChapterAddNewEdit.cshtml", new { action = "editSave", id = chapterId, name = name, courseId = courseId, oldSeqNo = oldSeqNo });

        }
        public void editSave(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            long courseId = Convert.ToInt64(context.Request["courseId"]);
            string name = context.Request["Name"]; string oldname = context.Request["oldname"];
            if (new ChaptersBLL().IsHaveName(name) && oldname != name)
            {
                context.Response.Write("章节名字不可以重复"); return;
            }
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(context.Request["SeqNo"]))
            {
                context.Response.Write("章节名字和seqno不能为空"); return;
            }
            int seqno = Convert.ToInt32(context.Request["SeqNo"]);
            int oldseqno = Convert.ToInt32(context.Request["oldSeqNo"]);
            new ChaptersBLL().EditChapterSeqNo(seqno, oldseqno);
            Chapters chapter = new Chapters();
            chapter = new ChaptersBLL().GetModel(chapterId);
            chapter.Name = name; chapter.SeqNo = seqno;
            new ChaptersBLL().Update(chapter);
            context.Response.Redirect("ChapterController.ashx?action=list&id=" + courseId);
            AdminHelper.RecordOperationLog("修改了章节" + name);//写日志
        }
        public void delete(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            int seqno=(new ChaptersBLL().GetModel(chapterId)).SeqNo;
            string name=(new ChaptersBLL().GetModel(chapterId)).Name;
            long courseId = Convert.ToInt64(context.Request["courseId"]);
            if ( new SegmentsBLL().IsHaveChapterId(chapterId))
            {
                context.Response.Write("删除失败：为了安全，已经有段落属于这个章节,请先删除段落"); return;
            }
            new ChaptersBLL().Delete(chapterId);
            new ChaptersBLL().DeleteChapterSeqNo(seqno);//
            context.Response.Redirect("ChapterController.ashx?action=list&id=" + courseId);
            AdminHelper.RecordOperationLog("删除了章节" + name);//写日志
        }
    }
}