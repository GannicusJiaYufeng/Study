using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpCater.Model
{
    public class UserInfo
    {
        private int userId;
             
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string loginUserName;

        public string LoginUserName
        {
            get { return loginUserName; }
            set { loginUserName = value; }
        }
        private string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        //private int delFlag;

        //public int DelFlag
        //{
        //    get { return delFlag; }
        //    set { delFlag = value; }
        //}
        private int delFlag;
        public int DelFlag
        {
            get { return delFlag; }
            set { delFlag = value;  }
        }
    }
}
