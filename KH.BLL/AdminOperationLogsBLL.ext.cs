using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KH.DAL;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;
using KH.Model;

namespace KH.BLL
{
    public partial  class AdminOperationLogsBLL
    {
           /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            return DbHelperSQL.Query(SQLString, cmdParms);
        }
        /// <summary>
        /// 查看用户文档表中是否有该用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public bool IsHaveAdmin(long id)
        {
            return dal.IsHaveAdmin(id) > 0;
        }

       public List<AdminOperationLogsSearch> Search(string where, List<SqlParameter> parameters)
       {
           return dal.Search(where, parameters);
       }

       public List<AdminOperationLogsSearch> Search2(AdminOperationLogSearchOption option)
       {
           return dal.Search2(option);
       }

    }
}
