using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using System.Data;
using System.Data.SqlClient;

namespace RpCater.DAL
{
    public class R_Order_DeskDAL
    {
        /// <summary>
        /// 添加一个餐桌和订单的中间表的一条数据
        /// </summary>
        /// <param name="rod">中间表的对象</param>
        /// <returns>受影响的行数</returns>
        public int AddR_Order_Desk(R_Order_Desk rod)
        {
            string sql = "insert into R_Order_Desk(OrderId,DeskId)values(@OrderId,@DeskId)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@OrderId", rod.OrderId), new SqlParameter("@DeskId", rod.DeskId));
        }
    }
}
