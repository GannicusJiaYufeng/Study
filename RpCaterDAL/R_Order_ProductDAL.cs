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
    public class R_Order_ProductDAL
    {

        /// <summary>
        /// 根据订单的id更新该订单中所有的菜删除
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int UpdateR_Order_ProductDelFlagByOrderId(int orderId)
        {
            string sql = "update R_Order_Product set DelFlag=1 where OrderId=" + orderId;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据中间表的主键id删除选中的菜
        /// </summary>
        /// <param name="rOrderProId">中间表的主键的id</param>
        /// <returns>受影响的行数</returns>
        public int SoftDeleteR_Order_ProductByROrderProId(int rOrderProId)
        {
            string sql = "update R_Order_Product set DelFlag=1 where ROrderProId=" + rOrderProId;
            return SqlHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 根据订单的id查询该餐桌点了多少个菜,总金额
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <returns></returns>
        public R_Order_Product GetCountAndSumMoney(int orderId)
        {
            string sql = "select count(*),sum(UnitCount*ProPrice) from R_Order_Product inner join ProductInfo on R_Order_Product.ProId=ProductInfo.ProId where R_Order_Product.DelFlag=0 and OrderId=" + orderId;
            R_Order_Product rop = new R_Order_Product();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rop.Count = Convert.ToInt32(reader[0]);//数量
                        //天坑=========
                        if (DBNull.Value != reader[1]) //避免报异常
                        {
                            rop.Money = Convert.ToDecimal(reader[1]);

                        }// end if

                    }// end while
                }// end if
            }// end using
            return rop;
        }



        /// <summary>
        /// 根据订单的id查询该订单点的菜
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <returns>点的菜的对象的集合</returns>
        public List<R_Order_Product> GetR_Order_ProductByOrderId(int orderId)
        {
            string sql = "select ROrderProId,ProName,ProPrice,UnitCount,ProUnit,CName,R_Order_Product.SubTime from R_Order_product inner join ProductInfo on R_Order_product.ProId=ProductInfo.ProId inner join CategoryInfo on ProductInfo.CId=CategoryInfo.CId where R_Order_product.DelFlag=0 and OrderId=" + orderId;
            DataTable dt = SqlHelper.ExecuteQuery(sql);
            List<R_Order_Product> list = new List<R_Order_Product>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToR_Order_productByRow(dr));
                }
            }
            return list;
        }

        //关系转对象
        private R_Order_Product RowToR_Order_productByRow(DataRow dr)
        {
            R_Order_Product rop = new R_Order_Product();
            rop.ROrderProId = Convert.ToInt32(dr["ROrderProId"]);
            rop.ProName = dr["ProName"].ToString();
            rop.ProPrice = Convert.ToDouble(dr["ProPrice"]);
            rop.UnitCount = Convert.ToInt32(dr["UnitCount"]);
            rop.ProUnit = dr["ProUnit"].ToString();
            rop.ProMoney = rop.ProPrice * rop.UnitCount;//金额！！！！！！！！
            rop.CName = dr["CName"].ToString();
            rop.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return rop;

        }
        /// <summary>
        /// 添加一个菜--中间表的对象
        /// </summary>
        /// <param name="rop">订单和菜的中间表的对象---</param>
        /// <returns>受影响的行数</returns>
        public int AddR_Order_Product(R_Order_Product rop)
        {
            string sql = "insert into R_Order_product(OrderId, ProId, DelFlag, SubTime, UnitCount)values( @OrderId, @ProId, @DelFlag, @SubTime, @UnitCount)";
            SqlParameter[] ps = { 
                 new SqlParameter("@OrderId",rop.OrderId),
                 new SqlParameter("@ProId",rop.ProId),
                 new SqlParameter("@DelFlag",rop.DelFlag),
                 new SqlParameter("@SubTime",rop.SubTime),
                 new SqlParameter("@UnitCount",rop.UnitCount)
                               
                               };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
    }
}
