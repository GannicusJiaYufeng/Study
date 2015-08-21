using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{

    //订单和菜的中间表
    public class R_Order_Product
    {
  
        private int _count;
        /// <summary>
        /// 菜的总数量
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private decimal _money;
        /// <summary>
        /// 消费的总金额
        /// </summary>
        public decimal Money
        {
            get { return _money; }
            set { _money = value; }
        }

        //ROrderProId, OrderId, ProId, DelFlag, SubTime, UnitCount
        //添加冗余属性

        //ROrderProId,ProName,ProPrice,UnitCount,ProUnit,CName,R_Order_Product.SubTime 
        private string _proName;

        public string ProName
        {
            get { return _proName; }
            set { _proName = value; }
        }
        private double _proPrice;

        public double ProPrice
        {
            get { return _proPrice; }
            set { _proPrice = value; }
        }
        private string _proUnit;

        public string ProUnit
        {
            get { return _proUnit; }
            set { _proUnit = value; }
        }
        private string _cName;

        public string CName
        {
            get { return _cName; }
            set { _cName = value; }
        }
        private double _proMoney;
        /// <summary>
        /// 这个菜数量乘以价格的金额
        /// </summary>
        public double ProMoney
        {
            get { return _proMoney; }
            set { _proMoney = value; }
        }

        //上面是冗余属性
        private int _rOrderProId;
        public int ROrderProId
        {
            get { return _rOrderProId; }
            set { _rOrderProId = value; }
        }
        private int _orderId;

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        private int _proId;

        public int ProId
        {
            get { return _proId; }
            set { _proId = value; }
        }
        private int _delFlag;

        public int DelFlag
        {
            get { return _delFlag; }
            set { _delFlag = value; }
        }
        private DateTime _subTime;

        public DateTime SubTime
        {
            get { return _subTime; }
            set { _subTime = value; }
        }
        private int _unitCount;

        public int UnitCount
        {
            get { return _unitCount; }
            set { _unitCount = value; }
        }
    }
}
