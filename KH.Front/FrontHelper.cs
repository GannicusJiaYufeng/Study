using KH.BLL;
using KH.Model;
using KHRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KH.Front
{
    public class FrontHelper
    {
        public static void OutPutError(string msg)
        {
            KHHelper.OutputRazor(HttpContext.Current, "~/Error.cshtml", msg);
        }

        public static List<Segments> GetSegment(long chapterId)
        {
            return new SegmentsBLL().GetModelListByCache("ChapterId=" + chapterId + " order by seqno ASC");
        }
    }
}