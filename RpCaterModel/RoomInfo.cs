using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class RoomInfo
    {
        //RoomId, RoomName, RoomType, RoomMinMoney, RoomMaxNum, IsDefault, DelFlag, SubTime, SubBy

        private int _roomId;

        public int RoomId
        {
            get { return _roomId; }
            set { _roomId = value; }
        }
        private string _roomName;

        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }
        private int _roomType;

        public int RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }
        private double _roomMinMoney;

        public double RoomMinMoney
        {
            get { return _roomMinMoney; }
            set { _roomMinMoney = value; }
        }
        private int _roomMaxNum;

        public int RoomMaxNum
        {
            get { return _roomMaxNum; }
            set { _roomMaxNum = value; }
        }
        private string _isDefault;

        public string IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; }
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
        private int _subBy;

        public int SubBy
        {
            get { return _subBy; }
            set { _subBy = value; }
        }
    }
}
