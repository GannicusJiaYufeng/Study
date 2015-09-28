using KH.BLL;
using KH.Model;
using KHCommons;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;

namespace KH.Admin.AdminUser
{
    /// <summary>
    /// AdminUserController 的摘要说明
    /// </summary>
    public class AdminUserController : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            AdminHelper.CheckAccess(context);//检查是否登录，是否有权限
            string action = context.Request["action"];
            if (action == "list")//显示所有用户
            {
                List<AdminUsers> users = new AdminUsersBLL().GetModelList("");//调用bll获取用户列表
                KHHelper.OutputRazor(context, "~/AdminUser/AdminUserList.cshtml", users);
            }
            else if (action == "addnew")//新增用户
            {
                AdminHelper.CheckPower("新增管理用户");//检查登录用户的权限
                List<Roles> roles = new RolesBLL().GetModelList("");//用户可以担当的角色列表
                KHHelper.OutputRazor(context, "~/AdminUser/AdminUserAddNew.cshtml", new { roles = roles, selectedRoles = new long[0] { } });
            }
            else if (action == "edit") //修改
            {
                long id = Convert.ToInt64(context.Request["id"]);
                string name = (new AdminUsersBLL().GetModel(id)).UserName;
                AdminUsers user = new AdminUsersBLL().GetModel(id);             //linq
                List<Roles> roles = new RolesBLL().GetModelList("");//用户可以担当的角色列表
                List<AdminUserRoles> userroles = new AdminUserRolesBLL().GetModelList("AdminUserId=" + id);//获得用户的角色
                List<long> listRoles = new List<long>();//用户对应角色id的集合(也就是在编辑页面初始的时候被选中的)
                foreach (var listRole in userroles)
                {
                    listRoles.Add(listRole.RoleId);
                }
                KHHelper.OutputRazor(context, "~/AdminUser/AdminUserEdit.cshtml", new { id = id, roles = roles, selectedRoles = listRoles, name = name });
            }
            else if (action == "editSave")
            {
                long id = Convert.ToInt64(context.Request["id"]);
                string name = context.Request["name"];
                string roleids = context.Request["roleids"];
                if (roleids != "")
                {
                    //新增用户和角色的关系
                    string[] ids = roleids.Split(',');
                    long[] roleid = new long[ids.Length];
                    for (int i = 0; i < ids.Length; i++)
                    {
                        roleid[i] = Convert.ToInt64(ids[i]);
                    }
                    new AdminUserRolesBLL().ClearRoles(id);//把指定用户id下的所有角色全部删除
                    new AdminUserRolesBLL().AddRolePowers(id, roleid);  //添加
                    AjaxHelper.WriteJson(context.Response, "ok", "");
                    AdminHelper.RecordOperationLog("修改了用户" + name + "和角色");//写日志
                }
                else
                {
                    new AdminUserRolesBLL().ClearRoles(id);//把指定用户id下的所有角色全部删除
                    AjaxHelper.WriteJson(context.Response, "ok", "");
                    AdminHelper.RecordOperationLog("修改了用户" + name + "为没有权限");//写日志
                }
            }
            else if (action == "addnewSave")
            {
                AdminHelper.CheckPower("新增管理用户");//进一步检查登录用户的权限  免得有人修改报文头直接提交请求
                string username = context.Request["username"];
                string password = context.Request["password"];
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "用户名密码不能为空"); return;
                }
                if (username.Length < 3 || username.Length > 10)
                {
                    AjaxHelper.WriteJson(context.Response, "error", "用户名的长度必须介于3和10之间"); return;
                }
                AdminUsersBLL bll = new AdminUsersBLL();
                if (bll.IsUserNameExists(username))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "用户名已经存在"); return;
                }
                if (password.Length < 6 || username.Length > 12)
                {
                    AjaxHelper.WriteJson(context.Response, "error", "密码的长度必须介于6和12之间"); return;
                }
                if (!Regex.IsMatch(password, "[a-zA-Z]"))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "密码必须包含字母"); return;
                }
                AdminUsers user = new AdminUsers();
                user.UserName = username; user.Password = CommonHelper.CalcMD5(password); user.IsEnabled = true;
                long userid = bll.Add(user);//存储并获得新数据的Id
                string roleids = context.Request["roleids"];
                string[] strs = roleids.Split(',');
                long[] ids = new long[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    ids[i] = Convert.ToInt64(strs[i]);
                }
                new AdminUserRolesBLL().AddAdminUserRoles(userid, ids);
                AjaxHelper.WriteJson(context.Response, "ok", "");
                AdminHelper.RecordOperationLog("新增了用户" + username);//写日志
            }
            else if (action == "disable")//禁用用户
            {
                AdminHelper.CheckPower("禁用管理用户");//检查登录用户的权限
                long id = Convert.ToInt64(context.Request["id"]);
                AdminUsersBLL bll = new AdminUsersBLL();
                bll.Disable(id);//业务逻辑放到BLL等中。UI少些代码
                context.Response.Redirect("AdminUserController.ashx?action=list");//不用ajax提交  直接重定向就可以了
                AdminHelper.RecordOperationLog("禁用了用户:" + bll.GetModel(id).UserName);//写日志
            }
            else if (action == "delete")
            {
                AdminHelper.CheckPower("删除管理用户");//检查登录用户的权限
                long id = Convert.ToInt64(context.Request["id"]);
                if (new AdminUserRolesBLL().IsHaveUser(id) || new AdminOperationLogsBLL().IsHaveAdmin(id))
                {
                    context.Response.Write("为了数据的安全，请先删除该用户的所有角色和文档，才可以直接删除");
                    return;
                }
                else
                {
                    AdminUsersBLL bll = new AdminUsersBLL();
                    bll.Delete(id);
                    context.Response.Redirect("AdminUserController.ashx?action=list");
                    AdminHelper.RecordOperationLog("删除了用户:" + bll.GetModel(id).UserName);//写日志
                }
            }
            else if (action == "NewPassword")  //重置用户密码
            {
                long id = Convert.ToInt64(context.Request["id"]);
                AdminUsersBLL bll = new AdminUsersBLL();
                AdminUsers user = bll.GetModel(id);
                user.Password = CommonHelper.CalcMD5("a1234567");
                bll.Update(user);
                context.Response.Redirect("AdminUserController.ashx?action=list");
            }
            else if (action == "ChangePassword")//修改密码
            {
                string txt1 = context.Request["txt1"];
                string txt2 = context.Request["txt2"];
                string username = context.Request["username"];
                if (txt1.Length < 6 || txt1.Length > 12)
                {
                    AjaxHelper.WriteJson(context.Response, "error", "密码必须在6-12位"); return;
                }
                if (!Regex.IsMatch(txt1, "[a-zA-Z]"))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "密码必须包含字母"); return;
                }
                if (txt1 != txt2)
                {
                    AjaxHelper.WriteJson(context.Response, "error", "两次输入密码不一致"); return;
                }
                else
                {
                    AdminUsersBLL bll = new AdminUsersBLL();
                    AdminUsers user = bll.GetByUserName(username);
                    user.Password = CommonHelper.CalcMD5(txt1);
                    bll.Update(user);
                    AjaxHelper.WriteJson(context.Response, "ok", "");
                }
            }
            else if (action == "batchDelete")  //批量删除
            {
                AdminHelper.CheckPower("删除管理用户");//检查登录用户的权限
                string ids = context.Request["ids"];//1 2 3
                string[] strs = ids.Split(' ');//{"1","2","3"}，string[] strs = ids.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//{"3","5","8"}string idList=string.Join(",",strs);//"3   delete from T_AdminUsers 5"经过 Convert.ToInt64的处理生成idList中不会有除了数字之外的东西了，比较安全
                long[] idArray = new long[strs.Length];//{1,2,3}
                for (int i = 0; i < idArray.Length; i++)
                {
                    idArray[i] = Convert.ToInt64(strs[i]);
                }
                string idList = string.Join(",", idArray);
                AdminUsersBLL bll = new AdminUsersBLL();
                bll.DeleteList(idList);
                AdminHelper.RecordOperationLog("批量删除了用户:" + idList);
                AjaxHelper.WriteJson(context.Response, "ok", "");
            }
            else if (action == "btnBatchDisable")
            {
                AdminHelper.CheckPower("禁用管理用户");//检查登录用户的权限
                string ids = context.Request["ids"];//1 2 3
                string[] strs = ids.Split(' ');//{"1","2","3"}
                long[] idArray = new long[strs.Length];//{1,2,3}
                AdminUsersBLL bll = new AdminUsersBLL();
                for (int i = 0; i < idArray.Length; i++)
                {
                    idArray[i] = Convert.ToInt64(strs[i]);
                    bll.Disable(idArray[i]);
                } AdminHelper.RecordOperationLog("批量禁用了用户:" + ids);
                AjaxHelper.WriteJson(context.Response, "ok", "");
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