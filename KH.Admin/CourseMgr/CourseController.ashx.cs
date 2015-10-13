using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KH.BLL;
using KHRazor;
using KH.Model;
using KHCommons;
namespace KH.Admin.CourseMgr
{
    /// <summary>
    /// CourseController 的摘要说明
    /// </summary>
        public class CourseController : BaseHandler
        {
            //面向对象中继承的优点：把通用的工作交给父类完成
            public void list(HttpContext context)
            {
                var courses = new CoursesBLL().GetModelList("");
                KHHelper.OutputRazor(context, "~/CourseMgr/CourseList.cshtml", courses);
            }
            public void addnew(HttpContext context)
            {
                AdminHelper.CheckPower("新增课程");//检查登录用户的权限
                KHHelper.OutputRazor(context, "~/CourseMgr/CourseAddNewEdit.cshtml", new {action="addnewSave",name="",id=""});
            }
            public void addnewSave(HttpContext context)
            {
                AdminHelper.CheckPower("新增课程");//检查登录用户的权限
                string name = context.Request["Name"];
                if (string.IsNullOrWhiteSpace(name))
                {
                    context.Response.Write("课程名字不能为空"); return;
                }
                if (new CoursesBLL().IsHaveName(name))
                {
                    context.Response.Write("课程名字重复"); return;
                }
                Courses course = new Courses();
                course.Name = name;
                new CoursesBLL().Add(course);
                context.Response.Redirect("CourseController.ashx?action=list");
                AdminHelper.RecordOperationLog("增加了课程" + name);//写日志
            }
            public void edit(HttpContext context)
            {
                AdminHelper.CheckPower("修改课程");//检查登录用户的权限
                long courseId = Convert.ToInt64(context.Request["id"]);
                string name=(new CoursesBLL().GetModel(courseId)).Name;
                KHHelper.OutputRazor(context, "~/CourseMgr/CourseAddNewEdit.cshtml", new {action="editSave",name=name,id=courseId});
            }
            public void editSave(HttpContext context)
            {
                AdminHelper.CheckPower("修改课程");//检查登录用户的权限
                long courseId = Convert.ToInt64(context.Request["Id"]);
                string name = context.Request["Name"]; string oldname = context.Request["oldname"];
                if (new CoursesBLL().IsHaveName(name)&&name!=oldname)
                {
                    context.Response.Write("课程名重复了"); return;
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    context.Response.Write("课程名字不能为空"); return;
                }
                Courses course = new CoursesBLL().GetModel(courseId);
                course.Name = name;
                new CoursesBLL().Update(course);
                context.Response.Redirect("CourseController.ashx?action=list");
                AdminHelper.RecordOperationLog("修改了课程" + name);//写日志
            }
            public void delete(HttpContext context)
            {
                long courseId = Convert.ToInt64(context.Request["Id"]);
                string name = (new CoursesBLL().GetModel(courseId)).Name;
                if (new ChaptersBLL().IsHaveCourseId(courseId))
                {
                    context.Response.Write("为了安全，该课程下有章节，请先删除章节"); return;
                }
                new CoursesBLL().Delete(courseId);
                context.Response.Redirect("CourseController.ashx?action=list");
                AdminHelper.RecordOperationLog("删除了课程" + name);//写日志
            }
            public  void CreatLearnCards(HttpContext context)
            {
                CoursesBLL courseBll = new CoursesBLL();
                var courses= courseBll.GetModelList("");
                KHHelper.OutputRazor(context, "~/CourseMgr/CreatLearnCards.cshtml", new { Courses=courses});
            }
            public void CreateLearnCardsSubmit(HttpContext context)
            {
                if (string.IsNullOrEmpty(context.Request["courseId"]) || string.IsNullOrEmpty(context.Request["prefix"]) || string.IsNullOrEmpty(context.Request["expireDays"]) || string.IsNullOrEmpty(context.Request["startNo"]) || string.IsNullOrEmpty(context.Request["endNo"]))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "生成失败,所有项都必须填写，不能有空");
                }
                long courseId = Convert.ToInt64(context.Request["courseId"]);
                string prefix = context.Request["prefix"];
                int expireDays = Convert.ToInt32(context.Request["expireDays"]);
                int startNo = Convert.ToInt32(context.Request["startNo"]);
                int endNo = Convert.ToInt32(context.Request["endNo"]);
                LearnCardsBLL learnCardBll = new LearnCardsBLL();
                List<LearnCards> cards = new List<LearnCards>();
                bool success = learnCardBll.GenerateCards(courseId, prefix, expireDays, startNo, endNo, cards);
                if (success)
                {
                    AjaxHelper.WriteJson(context.Response, "ok", "", cards);
                    AdminHelper.RecordOperationLog("生成了学习卡" );//写日志
                }
                else
                {
                    AjaxHelper.WriteJson(context.Response, "error", "生成失败，可能是卡号冲突造成的");
                }            

            }
        }
}