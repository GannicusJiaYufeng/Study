using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.Model
{
    public class AdminOperationLogSearchOption
    {
        public bool SearchByUserName { get; set; }
        public bool SearchByCreateDateTime { get; set; }
        public bool SearchByDesc { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDateTimeStart { get; set; }
        public DateTime CreateDateTimeEnd { get; set; }
        public string Description { get; set; }
    }
}
