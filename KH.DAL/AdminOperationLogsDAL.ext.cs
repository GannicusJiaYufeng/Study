using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
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
    }
}
