using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KH.DAL
{
    public partial class CoursesDAL
    {
        /// <summary>
        /// 是不是有这个名字的课程了
        /// </summary>
        public int IsHaveName(string name)
        {
            int i = (int)SQLHelperJYF.ExecuteScalar("select count(*) from T_Courses where Name=@name", new SqlParameter("@name", name));
            return i;
        }
    }
}
