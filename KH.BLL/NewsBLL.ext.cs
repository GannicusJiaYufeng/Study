using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class NewsBLL
    {
        public List<News> GetPagedNews(long categoryId, long startRowNum, long endRowNum)
        {
            return dal.GetPagedNews(categoryId, startRowNum, endRowNum);
        }
    }
}
