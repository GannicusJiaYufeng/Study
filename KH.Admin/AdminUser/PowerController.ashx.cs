using KH.BLL;
using KH.Model;
using KHCommons;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace KH.Admin.AdminUser
{
    /// <summary>
    /// PowerController 的摘要说明
    /// </summary>
    public class PowerController : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            AdminHelper.CheckAccess(context);//检查是否登录，是否有权限
            string action = context.Request["action"];
            if (action == "list")
            {
                PowersBLL powerBll = new PowersBLL();
                List<Powers> powers = powerBll.GetModelList("");
                KHHelper.OutputRazor(context, "~/AdminUser/PowerList.cshtml", powers);
            }
            else if (action == "addnew")
            {
                KHHelper.OutputRazor(context, "~/AdminUser/PowerAddNewEdit.cshtml", new { action = "addnewsave", id = "", name = "" });
            }
            else if (action == "addnewsave")
            {
                string powername = context.Request["powername"];
                if (string.IsNullOrWhiteSpace(powername))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "你没输东西或者是输入了连续空格，你乱点什么？");
                    return;
                }
                if (new PowersBLL().IsPowerExists(powername))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "权限名已经存在了，小伙子");
                    return;
                }
                else
                {
                    Powers p = new Powers();
                    p.Name = powername;
                    new PowersBLL().Add(p);
                    AjaxHelper.WriteJson(context.Response, "ok", "");
                    AdminHelper.RecordOperationLog("新增了权限" + powername);//写日志
                }

            }
            else if (action == "edit")
            {
                long id = Convert.ToInt64(context.Request["id"]);
                Powers p = new Powers();
                p = new PowersBLL().GetModel(id);
                string oldname = p.Name;
                KHHelper.OutputRazor(context, "~/AdminUser/PowerAddNewEdit.cshtml", new { action = "editsave", id = id, name = oldname });
            }
            else if (action == "editsave")
            {
                long id = Convert.ToInt64(context.Request["id"]);
                string powername = context.Request["powername"];
                Powers p = new Powers();
                p = new PowersBLL().GetModel(id);
                string oldname = p.Name;
                p.Name = powername;
                new PowersBLL().Update(p);
                AjaxHelper.WriteJson(context.Response, "ok", "");
                AdminHelper.RecordOperationLog("修改了了权限" + oldname + "为" + powername);//写日志

            }
            else if (action == "delete")
            {
                //权限也要判断是不是在别的表
                long id = Convert.ToInt64(context.Request["id"]);
                Powers p = new Powers();
                p = new PowersBLL().GetModel(id);
                string name = p.Name;
                if (new RolePowersBLL().IsHavePower(id))
                {
                    context.Response.Write("弹出为了安全性考虑，拒绝直接删除，请先修改角色权限，直到他没有被引用才支持删除");
                  //  context.Response.Redirect("PowerController.ashx?action=list");
                   // return;
                }
                else
                {
                    new PowersBLL().Delete(id);
                    context.Response.Redirect("PowerController.ashx?action=list");
                }
                AdminHelper.RecordOperationLog("删除了权限" + name);
            }
            else
            {
                throw new Exception("action错误");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}