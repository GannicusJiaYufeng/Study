using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class R_Order_Desk
    {
        //RID, OrderId, DeskId
        private int _rID;

        public int RID
        {
            get { return _rID; }
            set { _rID = value; }
        }
        private int _orderId;

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        private int _deskId;

        public int DeskId
        {
            get { return _deskId; }
            set { _deskId = value; }
        }
    }
}
