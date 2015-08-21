using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class OrderInfo
    {
        //OrderId, SubTime, Remark, OrderState, OrderMemberId, DelFlag, SubBy, BeginTime, EndTime, OrderMoney, DisCount

        private int _orderId;

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        private DateTime _subTime;

        public DateTime SubTime
        {
            get { return _subTime; }
            set { _subTime = value; }
        }
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private int _orderState;

        public int OrderState
        {
            get { return _orderState; }
            set { _orderState = value; }
        }
        private int _orderMemberId;

        public int OrderMemberId
        {
            get { return _orderMemberId; }
            set { _orderMemberId = value; }
        }
        private int _delFlag;

        public int DelFlag
        {
            get { return _delFlag; }
            set { _delFlag = value; }
        }
        private int _subBy;

        public int SubBy
        {
            get { return _subBy; }
            set { _subBy = value; }
        }
        private DateTime _beginTime;

        public DateTime BeginTime
        {
            get { return _beginTime; }
            set { _beginTime = value; }
        }
        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        private double _orderMoney;

        public double OrderMoney
        {
            get { return _orderMoney; }
            set { _orderMoney = value; }
        }
        private double _disCount;

        public double DisCount
        {
            get { return _disCount; }
            set { _disCount = value; }
        }
    }
}
