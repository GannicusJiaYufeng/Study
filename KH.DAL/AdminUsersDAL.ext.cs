﻿using KH.Model;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KH.DAL
{
    public partial class AdminUsersDAL
    {
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public AdminUsers GetByUserName(string username)
        {
            string sql = "select *from T_AdminUsers where UserName=@UserName";
            DataSet ds = 
                DbHelperSQL.Query(sql, new SqlParameter("@UserName", username));
            if (ds.Tables[0].Rows.Count > 0)  //dataset就是表的集合ds.Tables[0]就是返回的第一个表
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 判断userId用户是否有powerName权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="powerName"></param>
        /// <returns></returns>
        public bool HasPower(long userId, string powerName)
        {
            //@两个作用：不让\当转义；声明多行文本，写SQL时很方便
            object obj = DbHelperSQL.GetSingle(@"select COUNT(*) from 
                (
                  select AdminUserId from T_AdminUserRoles where RoleId in(
                  select RoleId from T_RolePowers where PowerId=
                  (select id from T_Powers where Name=@PowerName))
                ) au
                where au.AdminUserId=@AdminUserId", new SqlParameter("@PowerName", powerName)
                                                  , new SqlParameter("@AdminUserId", userId));
            int count = Convert.ToInt32(obj);
            return count > 0;
        }
    }
}
