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
    public partial class UsersDAL
    {
        public Users GetByUserName(string username)
        {
            DataSet ds = DbHelperSQL.Query("select * from T_Users where UserName=@UserName",
                new SqlParameter("@UserName", username));
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return this.DataRowToModel(ds.Tables[0].Rows[0]);
            }
        }
        public int IsHaveThisEmail(string email)
        {
            return (int)SQLHelperJYF.ExecuteScalar("select * from T_Users where Email=@e", new SqlParameter("@e", email));
        }
    }
}
