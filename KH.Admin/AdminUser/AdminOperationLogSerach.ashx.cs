using KH.BLL;
using KH.Model;
using KHCommons;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.SqlClient;
using System.Web.SessionState;

namespace KH.Admin.AdminUser
{
    /// <summary>
    /// AdminOperationLogSerach 的摘要说明
    /// </summary>
    public class AdminOperationLogSerach : BaseHandler
    {
           //AdminHelper.CheckAccess(context);//检查是否登录，是否有权限
           // AdminHelper.CheckPower("查看系统操作日志");//检查登录用户的权限
        public void page(HttpContext context)
        {
            AdminHelper.CheckAccess(context);//检查是否登录，是否有权限
            AdminHelper.CheckPower("查看系统操作日志");//检查登录用户的权限
            KHHelper.OutputRazor(context, "~/AdminUser/AdminOperationLogSearch.cshtml", "");
        }
        public void search(HttpContext context)
        {
            AdminHelper.CheckPower("查看系统操作日志");
           
            /*
            AdminOperationLogsBLL bll = new AdminOperationLogsBLL();
            var logs = bll.GetModelList("");//join 效率高！
            List<object> list = new List<object>();
            foreach(var log in logs)
            {
                long userId = log.UserId;
                AdminUsersBLL ub = new AdminUsersBLL();
                string uname =  ub.GetModel(userId).UserName;
                list.Add(new
                {
                    UserName = uname,
                    CreateDateTime = log.CreateDateTime.ToString()
                    , Description=log.Description });
            }*/

            /*
            string where = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (context.Request["cbByUserName"] == "on")
            {
                string username = context.Request["username"];
                where = where + "\r\nand u.UserName=@UserName";
                parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = username });
            }

            if (context.Request["cbByOpDateTime"] == "on")
            {
                string strOpStartTime = context.Request["opStartTime"];
                DateTime opStartTime = DateTime.Parse(strOpStartTime);
                string strOpEndTime = context.Request["opEndTime"];
                DateTime opEndTime = DateTime.Parse(strOpEndTime);
                where = where + "\r\nand (log.CreateDateTime>=@StartTime and log.CreateDateTime<=@EndTime)";
                parameters.Add(new SqlParameter() { ParameterName = "@StartTime", Value = opStartTime });
                parameters.Add(new SqlParameter() { ParameterName = "@EndTime", Value = opEndTime });
            }

            if (context.Request["cbByDesc"] == "on")
            {
                string desc = context.Request["desc"];
                where = where + "\r\nand log.Description like @Desc";//like '%@Desc%'→"%"+desc+"%" 
                parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = "%"+desc+"%" });
            }*/
            AdminOperationLogSearchOption option = new AdminOperationLogSearchOption(); //这种方法 把sql语句拼接放在了DAL层了
            if (context.Request["cbByUserName"] == "on")
            {
                option.SearchByUserName = true;
                option.UserName = context.Request["username"];
            }

            if (context.Request["cbByOpDateTime"] == "on")
            {
                option.SearchByCreateDateTime = true;
                string strOpStartTime = context.Request["opStartTime"];
                DateTime opStartTime = DateTime.Parse(strOpStartTime);
                string strOpEndTime = context.Request["opEndTime"];
                DateTime opEndTime = DateTime.Parse(strOpEndTime);
                option.CreateDateTimeStart = opStartTime;
                option.CreateDateTimeEnd = opEndTime;
            }

            if (context.Request["cbByDesc"] == "on")
            {
                option.SearchByDesc = true;
                string desc = context.Request["desc"];
                option.Description = desc;
            }

            AdminOperationLogsBLL bll = new AdminOperationLogsBLL();
            // var logs = bll.Search(where,parameters);
            var logs = bll.Search2(option);

            List<object> list = new List<object>();
            foreach (var log in logs)
            {
                //ViewModel
                list.Add(new
                {
                    UserName = log.UserName,
                    CreateDateTime = log.CreateDateTime.ToString(),
                    Description = log.Description
                });
            }

            AjaxHelper.WriteJson(context.Response, "ok", "", list);
        }

    }
}