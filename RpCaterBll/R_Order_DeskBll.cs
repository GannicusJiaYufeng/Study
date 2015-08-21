using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;
namespace RpCater.Bll
{
     public class R_Order_DeskBll
    {
        R_Order_DeskDAL rodDal = new R_Order_DeskDAL();
        /// <summary>
        /// 添加一个餐桌和订单的中间表的一条数据
        /// </summary>
        /// <param name="rod">中间表的对象</param>
        /// <returns>受影响的行数</returns>
        public bool AddR_Order_Desk(R_Order_Desk rod)
        {
            return rodDal.AddR_Order_Desk(rod) > 0;
        }
    }
}
