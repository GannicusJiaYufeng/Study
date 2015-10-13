using KH.Model;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.DAL
{
    public partial class AdminOperationLogsDAL
    {
        /// <summary>
        /// 查看用户文档表中是否有该用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IsHaveAdmin(long id)
        {
            return (int)DbHelperSQL.GetSingle("select count(*) from T_AdminOperationLogs where UserId=@id", new SqlParameter("@id", id));
        }

        public List<AdminOperationLogsSearch> Search(string where, List<SqlParameter> parameters)
        {
            string sql = @"select u.UserName UserName,log.CreatDateTime CreateDateTime,
  log.Description Description
   from T_AdminOperationLogs log 
  left join T_AdminUsers u on log.UserId=u.Id";
            if (!string.IsNullOrEmpty(where))
            {
                sql = sql + "\r\nwhere 1=1 " + where;//u.UserName='yzk' and (log.CreateDateTime>@)   //1=1 ！！！永远为true 就省去了加sql语句and的处理
            }
            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(sql, parameters.ToArray());
            //DataSet->DataTable->DataRow
            DataTable dt = ds.Tables[0];
            List<AdminOperationLogsSearch> list = new List<AdminOperationLogsSearch>();
            foreach (DataRow row in dt.Rows)
            {
                AdminOperationLogsSearch item = new AdminOperationLogsSearch();
                item.UserName = (string)row["UserName"];//row["UserName"].ToString()
                item.CreateDateTime = (DateTime)row["CreateDateTime"];
                item.Description = (string)row["Description"];
                list.Add(item);
            }
            return list;
        }

        public List<AdminOperationLogsSearch> Search2(AdminOperationLogSearchOption option)
        {
            string where = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (option.SearchByUserName)
            {
                where = where + "\r\nand u.UserName=@UserName";
                parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = option.UserName });
            }

            if (option.SearchByCreateDateTime)
            {
                where = where + "\r\nand (log.CreatDateTime>=@StartTime and log.CreatDateTime<=@EndTime)";
                parameters.Add(new SqlParameter() { ParameterName = "@StartTime", Value = option.CreateDateTimeStart });
                parameters.Add(new SqlParameter() { ParameterName = "@EndTime", Value = option.CreateDateTimeEnd });
            }

            if (option.SearchByDesc)
            {
                where = where + "\r\nand log.Description like @Desc";//like '%@Desc%'→"%"+desc+"%" 
                parameters.Add(new SqlParameter() { ParameterName = "@Desc", Value = "%" + option.Description + "%" });
            }
            return Search(where, parameters);
        }
    }
}
