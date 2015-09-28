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
    public partial class PowersDAL
    {
        /// <summary>
        /// 根据权限名获取权限信息
        /// </summary>
        /// <param name="powername"></param>
        /// <returns></returns>
        public Powers GetByUserName(string powername)
        {
            string sql = "select *from T_Powers where Name=@Name";
            DataSet ds =
                DbHelperSQL.Query(sql, new SqlParameter("@Name", powername));
            if (ds.Tables[0].Rows.Count > 0)  //dataset就是表的集合ds.Tables[0]就是返回的第一个表
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
