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
    public partial class UserCoursesDAL
    {
        public List<UserCourses> GetUsableCourses(long userId)
        {
            //ExpireDateTime>=GetDate()要在有效期内，GetDate()SQLServer中获得当前时间的函数
            //select * from T_UserCourses where UserId=@UserId and ExpireDateTime>=GetDate()
            DataSet ds = DbHelperSQL.Query("select * from T_UserCourses where UserId=@UserId and ExpireDateTime>=GetDate()",
                new SqlParameter("@UserId", userId));
            DataTable dt = ds.Tables[0];
            List<UserCourses> list = new List<UserCourses>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(this.DataRowToModel(row));
            }
            return list;
        }
    }
}
