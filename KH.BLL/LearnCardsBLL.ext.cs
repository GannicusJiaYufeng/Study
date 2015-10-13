using KH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KH.BLL
{
    public partial class LearnCardsBLL
    {
        /// <summary>
        /// 检查学习卡密是否对，如果对则激活课程，返回值表示是否激活成功
        /// </summary>
        /// <param name="cardNum"></param>
        /// <param name="password"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool Active(string cardNum, string password, long userId)//
        {
            var card = dal.GetByCardNum(cardNum);
            if (password != card.Password)
            {
                return false;
            }
            UserCoursesBLL userCourseBLL = new UserCoursesBLL();
            UserCourses userCourse = new UserCourses();
            userCourse.CourseId = card.CourseId;
            userCourse.ExpireDateTime = DateTime.Now.AddDays(card.ExpireDays);
            userCourse.UserId = userId;
            userCourseBLL.Add(userCourse);
            return true;
        }

        /// <summary>
        /// 返回值表示是否生成成功，learnCards接收生成的学习卡
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="cardNumPrefix"></param>
        /// <param name="expireDays"></param>
        /// <param name="startNo"></param>
        /// <param name="endNo"></param>
        /// <param name="learnCards"></param>
        /// <returns></returns>
        public bool GenerateCards(long courseId, string cardNumPrefix, int expireDays,
             int startNo, int endNo, List<LearnCards> learnCards)
        {
            return dal.GenerateCards(courseId, cardNumPrefix, expireDays, startNo, endNo, learnCards);
        }
    }
}
