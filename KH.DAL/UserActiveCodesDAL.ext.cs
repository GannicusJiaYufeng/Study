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
    public partial class UserActiveCodesDAL
    {
        public UserActiveCodes GetByUserName(string username)
        {
            DataSet ds = DbHelperSQL.Query("select * from T_UserActiveCodes where UserName=@un",
                new SqlParameter("@un", username));
            DataTable table = ds.Tables[0];
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return DataRowToModel(table.Rows[0]);
            }
        }
    }
}
