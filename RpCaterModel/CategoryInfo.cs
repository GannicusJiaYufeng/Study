using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class CategoryInfo
    {
        //CId, CName, CNum, CRemark, DelFlag, SubTime, SubBy
        private int _cId;

        public int CId
        {
            get { return _cId; }
            set { _cId = value; }
        }
        private string _cName;

        public string CName
        {
            get { return _cName; }
            set { _cName = value; }
        }
        private string _cNum;

        public string CNum
        {
            get { return _cNum; }
            set { _cNum = value; }
        }
        private string _cRemark;

        public string CRemark
        {
            get { return _cRemark; }
            set { _cRemark = value; }
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
