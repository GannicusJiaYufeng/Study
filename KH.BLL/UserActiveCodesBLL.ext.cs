using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class UserActiveCodesBLL
    {
        public UserActiveCodes GetByUserName(string username)
        {
            return dal.GetByUserName(username);
        }
    }
}
