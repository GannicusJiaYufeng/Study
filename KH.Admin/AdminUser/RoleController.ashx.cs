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
    /// RoleController 的摘要说明
    /// </summary>
    public class RoleController : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            if (action == "list")
            {
                RolesBLL rolesbll = new RolesBLL();
                List<Roles> roles = rolesbll.GetModelList("");
                KHHelper.OutputRazor(context, "~/AdminUser/RoleList.cshtml", roles);
            }
            else if (action == "addnew")
            {
                var powers = new PowersBLL().GetModelList("");//获得有哪些权限，新增要用
                KHHelper.OutputRazor(context, "~/AdminUser/RoleAddNewEdit.cshtml",
                    new
                    {
                        action = "addnew",
                        id = "",
                        name = "",
                        powers = powers,
                        selectedPowers = new long[0] { }
                    });
            }
            else if (action == "save")//保存
            {
                string saveAction = context.Request["saveAction"];
                if (saveAction == "addnew")//新增保存
                {
                    string name = context.Request["name"];
                    string selectedPIds = context.Request["selectedPIds"];
                    if (new RolesBLL().IsHaveRole(name))
                    {
                        AjaxHelper.WriteJson(context.Response, "error", "已经存在了这个名字的角色");
                        return;
                    }
                    else
                    {
                        RolesBLL roleBll = new RolesBLL();
                        Roles role = new Roles();
                        role.Name = name;
                        long roleid = roleBll.Add(role);//新增一个角色并且他的返回值就是新增数据的id
                        if (selectedPIds != "")
                        {
                            //新增角色、权限对应关系
                            string[] strs = selectedPIds.Split(',');
                            long[] powerids = new long[strs.Length];
                            for (int i = 0; i < strs.Length; i++)
                            {
                                powerids[i] = Convert.ToInt64(strs[i]);
                            }
                            new RolePowersBLL().AddRolePowers(roleid, powerids);//                        
                        }
                        AjaxHelper.WriteJson(context.Response, "ok", "");
                        AdminHelper.RecordOperationLog("新增了角色" + role.Name);//写日志
                      
                    }

                }
                else if (saveAction == "edit")//修改保存
                {
                    string selectedPIds = context.Request["selectedPIds"];
                    string name = context.Request["name"];
                    long roleid = Convert.ToInt64(context.Request["id"]);
                        if (selectedPIds != "")
                        {
                            //新增角色、权限对应关系
                            string[] strs = selectedPIds.Split(',');
                            long[] powerids = new long[strs.Length];
                            for (int i = 0; i < strs.Length; i++)
                            {
                                powerids[i] = Convert.ToInt64(strs[i]);
                            }
                            new RolePowersBLL().CleraRolePowers(roleid);//先清理指定Id的所有powers删掉
                            new RolePowersBLL().AddRolePowers(roleid, powerids);//再进行添加
                            AjaxHelper.WriteJson(context.Response, "ok", "");
                            AdminHelper.RecordOperationLog("修改了角色" + name + "和权限");//写日志
                        }
                        else
                        {
                            new RolePowersBLL().CleraRolePowers(roleid);//指定Id的所有powers删掉
                            Roles role1 = new Roles();
                            role1 = new RolesBLL().GetModel(roleid);
                            role1.Name = name;
                            new RolesBLL().Update(role1);
                            AjaxHelper.WriteJson(context.Response, "ok", "");
                            AdminHelper.RecordOperationLog("修改了角色" + role1.Name + "为没有权限");//写日志
                        }
                    }
                
                else
                {
                    throw new Exception("action错误");
                }

            }
            else if (action == "edit")
            {
                long id = Convert.ToInt64(context.Request["id"]);
                Roles role = new RolesBLL().GetModel(id);
                if (role == null)
                {
                    context.Response.Write("id不存在，别作假");
                    return;
                }
                // linq
                var powers = new PowersBLL().GetModelList("");//获得有哪些权限，修改要用
                List<RolePowers> rolepowers = new RolePowersBLL().GetModelList("RoleId=" + id);//获得角色的权限。这个不用参数化查询也没事
                List<long> selectedPowers = new List<long>();//角色的id的集合
                foreach (var rolePower in rolepowers)
                {
                    selectedPowers.Add(rolePower.PowerId);
                }
                KHHelper.OutputRazor(context, "~/AdminUser/RoleAddNewEdit.cshtml",
                    new
                    {
                        action = "edit",
                        id = id,
                        name = role.Name,
                        powers = powers,
                        selectedPowers = selectedPowers
                    });
            }
            else if (action == "delete")  //角色的删除
            {
                long id = Convert.ToInt64(context.Request["id"]);
                string name = new RolesBLL().GetModel(id).Name;
                if (new RolePowersBLL().IsHaveRole(id)||new AdminUserRolesBLL().IsHaveRole(id))
                {
                    context.Response.Write("为了安全性考虑，拒绝直接删除，请先修改该角色对应的权限和已经有该角色的用户才支持删除");
                    return;
                }
                else
                {
                    new RolesBLL().Delete(id);//已经保证角色没有权限了，再直接删除角色
                    context.Response.Redirect("RoleController.ashx?action=list");
                }
                AdminHelper.RecordOperationLog("删除了角色"+name);
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