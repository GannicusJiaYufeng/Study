using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.Model
{
    //类如果没有标注public，则表示只能在当前程序集（当前项目）访问
    public class AdminOperationLogsSearch
    {
        public string UserName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Description { get; set; }
    }
}
