using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RpCater.Model;
namespace RpCater.DAL
{
    public class OrderInfoDAL
    {

        /// <summary>
        /// 更新订单中的数据
        /// </summary>
        /// <param name="order">订单的对象</param>
        /// <returns></returns>
        public int UpdateOrderInfo(OrderInfo order)
        {
            string sql = "update OrderInfo set OrderState=@OrderState,OrderMemberId=@OrderMemberId,EndTime=@EndTime,OrderMoney=@OrderMoney,DisCount=@DisCount where OrderId=@OrderId";

            SqlParameter[] ps = {
              new SqlParameter("@OrderState",order.OrderState),
              new SqlParameter("@OrderMemberId",order.OrderMemberId),
              new SqlParameter("@EndTime",order.EndTime),
              new SqlParameter("@OrderMoney",order.OrderMoney),
              new SqlParameter("@DisCount",order.DisCount),
              new SqlParameter("@OrderId",order.OrderId)
                               };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }

        /// <summary>
        /// 根据订单的id查询该订单消费的金额
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <returns></returns>
        public object GetMoneyByOrderId(int orderId)
        {
            string sql = "select OrderMoney from OrderInfo where DelFlag=0 and OrderState=1 and OrderId=" + orderId;
            return SqlHelper.ExecuteScalar(sql);
        }


        /// <summary>
        /// 根据订单的id更新订单的消费金额和点菜时间
        /// </summary>
        /// <param name="order">订单的对象</param>
        /// <returns></returns>
        public int UpdateMoneyAndTime(OrderInfo order)
        {
            string sql = "update OrderInfo set BeginTime=@BeginTime,OrderMoney=@OrderMoney where DelFlag=0 and OrderId=@OrderId";
            SqlParameter[] ps = {
                      new SqlParameter("@BeginTime",order.BeginTime),
                      new SqlParameter("@OrderMoney",order.OrderMoney),
                      new SqlParameter("@OrderId",order.OrderId)
                               
                               };
            return SqlHelper.ExecuteNonQuery(sql, ps);

        }
        /// <summary>
        /// 根据餐桌的id查询该餐桌对应的订单的id
        /// </summary>
        /// <param name="deskId">餐桌的id</param>
        /// <returns>订单的id</returns>
        public object GetOrderIdByDeskId(int deskId)
        {
            string sql = "select OrderInfo.OrderId from OrderInfo inner join R_Order_Desk on R_Order_Desk.OrderId=OrderInfo.OrderId where OrderState=1 and DelFlag=0 and DeskId=" + deskId;
            return SqlHelper.ExecuteScalar(sql);
        }
        //添加一个订单
        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order">订单的对象</param>
        /// <returns>添加一个订单后返回的是该订单的主键的id</returns>
        public  object AddOrderInfo(OrderInfo order)
        {
            string sql = "insert into OrderInfo (SubTime,Remark,OrderState,DelFlag,SubBy,BeginTime,OrderMoney,DisCount) values(@SubTime,@Remark,@OrderState,@DelFlag,@SubBy,@BeginTime,@OrderMoney,@DisCount);select @@identity";

            //注意这个sql语句！！！！！！！！！！！！！！1是两个语句，还有一个select语句//select @@Identity 返回自动递增字段的值
            //准备参数
            SqlParameter[] ps = {
                   new SqlParameter("@SubTime",order.SubTime),
                   new SqlParameter("@Remark",order.Remark),
                   new SqlParameter("@OrderState",order.OrderState),
                   new SqlParameter("@DelFlag",order.DelFlag),
                   new SqlParameter("@SubBy",order.SubBy),
                   new SqlParameter("@BeginTime",order.BeginTime),
                   new SqlParameter("@OrderMoney",order.OrderMoney),
                   new SqlParameter("@DisCount",order.DisCount)
                               };
            return SqlHelper.ExecuteScalar(sql, ps);
        }
    }
}
