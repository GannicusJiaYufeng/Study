using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpCater.Model;
using RpCater.DAL;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace RpCater.Bll
{
    public class MemberInfoBl
    {



        MemberInfoDAL memDal = new MemberInfoDAL();
        //导入操作
        //读取excel文件
        public void ReadExcel(string path)
        { 
            //流
            using (FileStream fsRead=new FileStream(path,FileMode.Open,FileAccess.Read)) 
            {
              List<MemberInfo> list = new List<MemberInfo>();
              
             //获取工作表
              IWorkbook wookbook=WorkbookFactory.Create(fsRead);
             //获取页
              ISheet sheet = wookbook.GetSheetAt(0);
                //遍历该页的所有行
              for (int i = 0; i <= sheet.LastRowNum; i++)
              {
                  MemberInfo member = new MemberInfo();
                  //获取行
                  IRow row=sheet.GetRow(i);
                  //第一行是id   =======0
                  member.MemName = row.GetCell(1).StringCellValue;//名字
                  member.MemMobilePhone = row.GetCell(2).StringCellValue;//电话
                  member.DelFlag = Convert.ToInt32(row.GetCell(3).NumericCellValue);//删除标识   注意转换。把表格数据看成string（实际有string和numeric），不是string的member属性全部要转换


                  list.Add(member);
                  //把Excel文件的数据插入到数据库中
                  
              }//end for
                //循环结束---list集合中有很多会员对象了---传到DAL中
              memDal.AddMemberInfo(list);
            }  //end using
        }
        
        
        //导出操作
        public void WriteExcel(string path)
        { 
            //文件流
            using (FileStream fsWrite=new FileStream(path,FileMode.Create,FileAccess.Write))
            {
                //创建工作表
                XSSFWorkbook work = new XSSFWorkbook();
                //创建页
                ISheet sheet = work.CreateSheet();
                //读取会员信息
                List<MemberInfo> list = memDal.GetAllMemberInfoByDelFlag(0);
                //创建行
                for (int i = 0; i <list.Count ; i++)
                {
                    //创建行
                    IRow row = sheet.CreateRow(i);
                    //只要名字和电话
                    row.CreateCell(0, CellType.String).SetCellValue(list[i].MemName);
                    row.CreateCell(1, CellType.String).SetCellValue(list[i].MemMobilePhone);
                }
                work.Write(fsWrite);//写入文件
            }
        }








        /// <summary>
        /// 根据会员的id更新会员的金额
        /// </summary>
        /// <param name="memId">会员的id</param>
        /// <param name="money">会员的金额</param>
        /// <returns></returns>
        public bool UpdateMemberMoneyById(int memId, double money)
        {
            return memDal.UpdateMemberMoneyById(memId, money) > 0;
        }



        /// <summary>
        /// 新增或修改的方法
        /// </summary>
        /// <param name="member">会员的对象</param>
        /// <param name="temp">标识:1---新增:2----修改</param>
        /// <returns>成功还是失败</returns>
        public bool AddOrUpdateMemberInfo(MemberInfo member, int temp)
        {
            if (temp == 1)//新增
            {
                return memDal.AddMemberInfo(member) > 0;
            }
            else if (temp == 2)//修改
            {
                return memDal.UpdateMemberInfo(member) > 0;
            }
            return false;
        }


          /// <summary>
        /// 根据ID改变会员删除标识
        /// </summary>
        /// <param name="memberId">会员ID</param>
        /// <param name="delFlag">删除标识：0---未删除，1---删除，2---回收站中删除</param>
        /// <returns>受影响行数</returns>

        public bool SoftDeleteMemberByMemberId(int memberId, int delFlag)
        {

            return memDal.SoftDeleteMemberByMemberId(memberId, delFlag) > 0;
        }




        
        /// <summary>
        /// 根据会员名字做模糊查询
        /// </summary>
        /// <param name="name">名字</param>
        /// <returns>会员信息集合</returns>
        public List<MemberInfo> GetMenmberInfoByLikeMemName(string name)
        {

            return memDal.GetMenmberInfoByLikeMemName(name);
        
        }



        /// <summary>
        /// 根据删除标志查询所有会员信息
        /// </summary>
        /// <param name="delFlag">1：已删除  0：没删除</param>
        /// <returns>会员对象信息集合</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            return memDal.GetAllMemberInfoByDelFlag(delFlag);

        }
    }
}
