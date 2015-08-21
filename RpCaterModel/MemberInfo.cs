using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class MemberInfo
    {
        private int memberId;

        public int MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }
        private string memName;

        public string MemName
        {
            get { return memName; }
            set { memName = value; }
        }
        private string memMobilePhone;

        public string MemMobilePhone
        {
            get { return memMobilePhone; }
            set { memMobilePhone = value; }
        }
        private string memAddress;

        public string MemAddress
        {
            get { return memAddress; }
            set { memAddress = value; }
        }
        private int memType;

        public int MemType
        {
            get { return memType; }
            set { memType = value; }
        }
        private string memNum;
        
        public string MemNum
        {
            get { return memNum; }
            set { memNum = value; }
        }
        private string memGender;

        public string MemGender
        {
            get { return memGender; }
            set { memGender = value; }
        }
        private double memDiscount;

        public double MemDiscount
        {
            get { return memDiscount; }
            set { memDiscount = value; }
        }
        private double memMoney;

        public double MemMoney
        {
            get { return memMoney; }
            set { memMoney = value; }
        }
        private int delFlag;

        public int DelFlag
        {
            get { return delFlag; }
            set { delFlag = value; }
        }
        private DateTime subTime;

        public DateTime SubTime
        {
            get { return subTime; }
            set { subTime = value; }
        }
        private int memIntegral;

        public int MemIntegral
        {
            get { return memIntegral; }
            set { memIntegral = value; }
        }
        private DateTime memEndTime;
        public DateTime MemEndTime
        {
            get { return memEndTime; }
            set { memEndTime = value; }
        }
        private DateTime memBirthday;

        public DateTime MemBirthday
        {
            get { return memBirthday; }
            set { memBirthday = value; }
        }
    }
}
