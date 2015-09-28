using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.DAL
{
    public partial class AdminUserRolesDAL
    {
        /// <summary>
        /// 清除指定id的用户的所有角色
        /// </summary>
        public void ClearRoles(long id)
        {
            DbHelperSQL.ExecuteSql("delete from T_AdminUserRoles where AdminUserId=@Id", new SqlParameter("@Id", id));
        }

        /// <summary>
        /// 判断用户角色表是否含有这个角色
        /// </summary>
        /// <param name="id"></param>
        public int IsHaveUser(long id)
        {
            return (int)DbHelperSQL.GetSingle("select count(*) from T_AdminUserRoles where AdminUserId=@id", new SqlParameter("@id", id));
        }
        /// <summary>
        /// 判断用户角色表是否含有这个角色
        /// </summary>
        /// <param name="id"></param>
        public int IsHaveRole(long id)
        {
            return (int)DbHelperSQL.GetSingle("select count(*) from T_AdminUserRoles where RoleId=@id", new SqlParameter("@id", id));
        }
    }
}
