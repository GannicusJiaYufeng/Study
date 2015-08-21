using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class MemberType
    {

        //MemType, MemTypeName, MemTypeDesc, DelFlag, SubBy
        private int _memType;

        public int MemType
        {
            get { return _memType; }
            set { _memType = value; }
        }
        private string _memTypeName;

        public string MemTypeName
        {
            get { return _memTypeName; }
            set { _memTypeName = value; }
        }
        private string _memTypeDesc;

        public string MemTypeDesc
        {
            get { return _memTypeDesc; }
            set { _memTypeDesc = value; }
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
    }
}
