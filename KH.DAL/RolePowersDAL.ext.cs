using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KH.DAL
{
    public partial class RolePowersDAL
    {
        /// <summary>
        /// 删除指定id的角色的所有权限
        /// </summary>
        /// <param name="roleId"></param>
        public void CleraRolePowers(long roleId)
        {
            DbHelperSQL.ExecuteSql("delete from T_RolePowers where RoleId=@RoleId", new SqlParameter("@RoleId", roleId));
        }

        /// <summary>
        /// 查询角色权限表中是否有该角色
        /// </summary>
        /// <param name="id"></param>
        public int IsHaveRole(long id)
        {
             int i= (int)DbHelperSQL.GetSingle("Select count(*) from T_RolePowers where RoleId=@RoleId", new SqlParameter("@RoleId", id));
            return i;
        }
        /// <summary>
        /// 判断角色权限表中是否有该权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IsHavePower(long id)
        {
            int i = (int)DbHelperSQL.GetSingle("Select count(*) from T_RolePowers where PowerId=@Id", new SqlParameter("@Id", id));
            return i;
        }
    }
}
