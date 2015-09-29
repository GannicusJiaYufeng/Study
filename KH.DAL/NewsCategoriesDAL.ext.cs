using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KH.DAL
{
    public partial class NewsCategoriesDAL
    {
        /// <summary>
        /// 判断有没有这个名字的类别了
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IsHaveName(string name)
        {
          return  (int)SQLHelperJYF.ExecuteScalar("select count(*) from T_NewsCategories where Name=@name", new SqlParameter("@name", name));
        }
    }
}
