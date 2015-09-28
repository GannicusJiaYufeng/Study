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
    public class AdminOperationLogSerach : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            AdminHelper.CheckAccess(context);//检查是否登录，是否有权限
            AdminHelper.CheckPower("查看系统操作日志");//检查登录用户的权限
            string action = context.Request["action"];
            if (action == "page")//主页面中点击查询
            {
                KHHelper.OutputRazor(context, "~/AdminUser/AdminOperationLogSerach.html");
                return;
            }
            if (action == "log")  //写完了查询条件后查询
            {
                string username = context.Request["username"];
                string txttime1 = context.Request["txttime1"];
                string txttime2 = context.Request["txttime2"];
                string describe = context.Request["describe"];
                if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(describe) && String.IsNullOrEmpty(txttime1) && String.IsNullOrEmpty(txttime2))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "必须选填一个或多个");
                    return;
                }
                if ((String.IsNullOrEmpty(txttime1) && (!String.IsNullOrEmpty(txttime2))) || ((!String.IsNullOrEmpty(txttime1) && String.IsNullOrEmpty(txttime2))))
                {
                    AjaxHelper.WriteJson(context.Response, "error", "时间段必须填写完整");
                    return;
                }
                string sb = "Select *from T_AdminOperationLogs where";
                List<string> list1 = new List<string>();
                List<SqlParameter> list2 = new List<SqlParameter>();
                if (!String.IsNullOrEmpty(username))
                {
                    AdminUsers user = new AdminUsersBLL().GetByUserName(username);
                    long userid = user.Id;
                    list1.Add(" userid=@userid");
                    SqlParameter sp1 = new SqlParameter();
                    sp1.ParameterName = "@userid";
                    sp1.Value = userid;
                    list2.Add(sp1);
                }
                if (!String.IsNullOrEmpty(txttime1) && !String.IsNullOrEmpty(txttime2))
                {
                    list1.Add(" creatdatetime between @txttime1 and @txttime2");
                    SqlParameter sp1 = new SqlParameter();
                    sp1.ParameterName = "@txttime1";
                    sp1.Value = txttime1;
                    SqlParameter sp2 = new SqlParameter();
                    sp2.ParameterName = "@txttime2";
                    sp2.Value = txttime2;
                    list2.Add(sp1);
                    list2.Add(sp2);
                }
                if (!String.IsNullOrEmpty(describe))
                {
                    //list1.Add(" description like '%@describe%'");//错误！！！浪费老子一抹多时间
                    list1.Add(" description like  @describe");
                    SqlParameter sp1 = new SqlParameter();
                    sp1.ParameterName = "@describe";
                    sp1.Value = "%"+describe+"%";
                    list2.Add(sp1);
                }
                string sb1 = string.Join(" and", list1.ToArray());
                sb = sb + sb1;
                SqlParameter[] sp = list2.ToArray();
                DataSet ds = AdminOperationLogsBLL.Query(sb, sp);
                DataTable dt = ds.Tables[0];
                List<AdminOperationLogs> list = new List<AdminOperationLogs>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(CommonHelper.RowToLogs(row));
                }
                AjaxHelper.WriteJson(context.Response, "ok", "", list);
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