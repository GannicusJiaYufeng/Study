using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpCater.Model;
using RpCater.Bll;

namespace RpCater
{
    public partial class FrmCategoryAddOrModify : Form
    {
        private FrmCategoryAddOrModify(CategoryInfo c)
        {
            InitializeComponent();

            //为文本框赋值
            if (c != null)//修改
            {
                txtCName.Text = c.CName;//名字
                txtCNum.Text = c.CNum;//编号
                txtCRemark.Text = c.CRemark;//备注
                labId.Text = c.CId.ToString();//类别的id
            }
        }
        private static int Temp;//存标识
        private static FrmCategoryAddOrModify _instance;
        public static FrmCategoryAddOrModify Single(int temp, CategoryInfo c)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmCategoryAddOrModify(c);
                Temp = temp;
            }
            return _instance;
        }
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (CheckEmpty())//判断所有的文本框不为空
            {
                CategoryInfoBll cBll = new CategoryInfoBll();
                CategoryInfo c = new CategoryInfo();
                c.CName = txtCName.Text;//名字
                c.CNum = txtCNum.Text;//编号
                c.CRemark = txtCRemark.Text;//备注

                //判断是新增还是修改
                if (Temp == 1)//新增
                {
                    c.DelFlag = 0;
                    c.SubBy = 1;
                    c.SubTime = System.DateTime.Now;//提交时间
                }//修改
                else if (Temp == 2)
                {
                    c.CId = Convert.ToInt32(labId.Text);//id类别
                }
                string msg = cBll.AddOrUpdateCategoryInfo(c, Temp) ? "操作成功" : "操作失败";
                md.MsgDivShow(msg, 1, Bind);
               // md.MsgDivShow(msg, 1);
            }
        }
        private void Bind()
        {
            this.Close();
        }
        //判断文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCName.Text))
            {
                md.MsgDivShow("名字不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtCNum.Text))
            {
                md.MsgDivShow("编号不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtCRemark.Text))
            {
                md.MsgDivShow("备注不能为空");
                return false;
            }
            return true;
        }

       

    }
}
