using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.DAL
{
    public partial class RolesDAL
    {
        /// <summary>
        /// 判断是否存在这个名字的Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IsHaveRole(string name)
        {
            return  (int)DbHelperSQL.GetSingle("Select count(*) from T_Roles where name=@name", new SqlParameter("@name", name));
        }
    }
}
