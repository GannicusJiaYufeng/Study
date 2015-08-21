using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;

namespace RpCater.Bll
{
   public class OrderInfoBll
    {
       OrderInfoDAL oDal = new OrderInfoDAL();
       /// <summary>
       /// 更新订单中的数据
       /// </summary>
       /// <param name="order">订单的对象</param>
       /// <returns></returns>
       public bool UpdateOrderInfo(OrderInfo order)
       {
           return oDal.UpdateOrderInfo(order) > 0;
       }

       /// <summary>
       /// 根据订单的id查询该订单消费的金额
       /// </summary>
       /// <param name="orderId">订单的id</param>
       /// <returns></returns>
       public object GetMoneyByOrderId(int orderId)
       {
           return oDal.GetMoneyByOrderId(orderId);
       }


       /// <summary>
       /// 根据订单的id更新订单的消费金额和点菜时间
       /// </summary>
       /// <param name="order">订单的对象</param>
       /// <returns></returns>
       public bool UpdateMoneyAndTime(OrderInfo order)
       {
           return oDal.UpdateMoneyAndTime(order) > 0;
       }

       /// <summary>
       /// 根据餐桌的id查询该餐桌对应的订单的id
       /// </summary>
       /// <param name="deskId">餐桌的id</param>
       /// <returns>订单的id</returns>
       public object GetOrderIdByDeskId(int deskId)
       {
           return oDal.GetOrderIdByDeskId(deskId);
       }
       //添加一个订单
       /// <summary>
       /// 添加一个订单
       /// </summary>
       /// <param name="order">订单的对象</param>
       /// <returns>添加一个订单后及时的返回该订单的主键id</returns>
       public object AddOrderInfo(OrderInfo order)
       {
           return oDal.AddOrderInfo(order);
       }
    }
}
