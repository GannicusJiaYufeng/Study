using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Text;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Web;
using KH.BLL;
using KHRazor;
using KH.Model;
using KHCommons;
namespace KH.Admin.CourseMgr
{
    /// <summary>
    /// SegmentController 的摘要说明
    /// </summary>
    public class SegmentController : BaseHandler
    {
        public void list(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            var segments = new SegmentsBLL().GetModelList("ChapterId=" + chapterId + " order by seqno ASC");
            KHHelper.OutputRazor(context, "~/CourseMgr/SegmentList.cshtml", new
            {
                chapterId = chapterId,
                segments = segments
            });
        }
        public void addnew(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            KHHelper.OutputRazor(context, "~/CourseMgr/SegmentAddNewEdit.cshtml",
                new { action = "addnewSave", oldSeqNo = "", name = "", chapterId = chapterId,id="", oldVideoCode="",oldNote="" });
        }
        public void addnewSave(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            string name = context.Request["Name"];
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(context.Request["SeqNo"]))
            {
                AjaxHelper.WriteJson(context.Response, "error", "段落名字和seqno不能为空"); return;
            }
            int seqNo = Convert.ToInt32(context.Request["SeqNo"]);
            string videoCode = context.Request["VideoCode"];
            string note = context.Request["Note"];
            if (new SegmentsBLL().IsHaveName(name))
            {
                AjaxHelper.WriteJson(context.Response, "error", "段落名重复了"); return;
            }
            new SegmentsBLL().AddNewChapterSeqNo(seqNo);//
            Segments segment = new Segments();
            segment.ChapterId = chapterId;
            segment.Name = name;
            segment.Note = note;
            segment.SeqNo = seqNo;
            segment.VideoCode = videoCode;
            new SegmentsBLL().Add(segment);
            AjaxHelper.WriteJson(context.Response, "ok", " 保存成功");
            AdminHelper.RecordOperationLog("增加了段落" + name);//写日志
        }
        public void edit(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            long id = Convert.ToInt64(context.Request["id"]);
            string name = (new SegmentsBLL().GetModel(id)).Name;
            int oldSeqNo = (new SegmentsBLL().GetModel(id)).SeqNo;
            string oldVideoCode = (new SegmentsBLL().GetModel(id)).VideoCode;
            string oldNoteRaw = (new SegmentsBLL().GetModel(id)).Note;
            RawString oldNote = KHHelper.Raw(oldNoteRaw);
            KHHelper.OutputRazor(context, "~/CourseMgr/SegmentAddNewEdit.cshtml", new { oldNote = oldNote, oldVideoCode = oldVideoCode, action = "editSave", oldSeqNo = oldSeqNo, name = name, id = id, chapterId = chapterId });
        }

        public void editSave(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            long id = Convert.ToInt64(context.Request["id"]); string oldname = (new SegmentsBLL().GetModel(id)).Name;
            string name = context.Request["Name"]; int oldseqno=Convert.ToInt32((new SegmentsBLL().GetModel(id)).SeqNo); 
            int seqNo = Convert.ToInt32(context.Request["SeqNo"]);
            string videoCode = context.Request["VideoCode"];
            string note = context.Request["Note"];
            if (name!=oldname&&new SegmentsBLL().IsHaveName(name))
            {
                AjaxHelper.WriteJson(context.Response, "error", "段落名重复了"); return;
            }
            if (string.IsNullOrWhiteSpace(name)||string.IsNullOrWhiteSpace(context.Request["SeqNo"]))
            {
                AjaxHelper.WriteJson(context.Response, "error", "段落名字和seqno不能为空"); return;
            }
            new SegmentsBLL().EditChapterSeqNo(seqNo,oldseqno);//
            Segments segments = new SegmentsBLL().GetModel(id);
            segments.Name = name; segments.Note = note; segments.SeqNo = seqNo; segments.VideoCode = videoCode;
            new SegmentsBLL().Update(segments);
            AjaxHelper.WriteJson(context.Response, "ok", "修改成功");
            AdminHelper.RecordOperationLog("修改了段落" + name);//写日志
        }
        public void delete(HttpContext context)
        {
            long chapterId = Convert.ToInt64(context.Request["chapterId"]);
            long id = Convert.ToInt64(context.Request["id"]);
            string name= (new SegmentsBLL().GetModel(id)).Name;
            int seqno = (new SegmentsBLL().GetModel(id)).SeqNo;
            new SegmentsBLL().Delete(id);
            new SegmentsBLL().DeleteChapterSeqNo(seqno); //修改seqno  
            AdminHelper.RecordOperationLog("删除了段落" +name);//写日志
            context.Response.Redirect("SegmentController.ashx?action=list&chapterId=" + chapterId);
        }
    }
}