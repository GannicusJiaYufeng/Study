using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RpCater.Bll;
using RpCater.Model;

namespace RpCater
{
    public partial class FrmMemberAddOrModify : Form
    {
        //窗体构造函数--初始化文本框中的值---下拉框--时间控件
        private FrmMemberAddOrModify(MemberInfo member)
        {
            InitializeComponent();//设计窗体
            LoadMemberTypeByDelFlag(0);//绑定下拉框中的值
            //通过会员对象为文本框赋值

            if (member != null)//修改
            {
                txtAddress.Text = member.MemAddress;//地址
                txtBirstday.Value = member.MemBirthday;//生日
                txtDiscount.Text = member.MemDiscount.ToString();//折扣
                txtEndTime.Value = member.MemEndTime;//有效期
                txtIntegral.Text = member.MemIntegral.ToString();//积分
                txtMoney.Text = member.MemMoney.ToString();//金额
                txtName.Text = member.MemName;
                txtNum.Text = member.MemNum;//编号
                txtPhone.Text = member.MemMobilePhone;//电话
                txtSubTime.Value = member.SubTime;//提交时间
                //会员的类型==坑===
                cmbType.SelectedValue = member.MemType;
                rdoMan.Checked = member.MemGender == "男" ? true : false;
                rdoWoman.Checked = member.MemGender == "女" ? true : false;
                labId.Text = member.MemberId.ToString();//存储会员的id--为了修改
            }
            else
            {
                //为空  新增
                //随机生成会员的编号
                Random r = new Random();
                //int num = r.Next(10000, 100000);
                //txtNum.Text = "0" + num.ToString();
                int num = r.Next(100, 1000);
                string strDate = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                txtNum.Text = strDate + num;
            }
        }
        //绑定下拉框数据的方法
        private void LoadMemberTypeByDelFlag(int p)
        {
            MemberTypeBll mtBll = new MemberTypeBll();
            List<MemberType> list = mtBll.GetAllMemberTypeByDelFlag(p);
            list.Insert(0, new MemberType() { MemTypeName = "请选择", MemType = -1 });
            cmbType.DataSource = list;//绑定数据
            cmbType.DisplayMember = "MemTypeName";//显示的值
            cmbType.ValueMember = "MemType";//实际保存的值
        }


        private static int Temp;


        private static FrmMemberAddOrModify instance;
        //单例模式代码
        public static FrmMemberAddOrModify Single(int temp, MemberInfo member)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmMemberAddOrModify(member);
                Temp = temp;//标识存起来
            }
            return instance;
        }
        //确定
        private void btnOk_Click(object sender, EventArgs e)
        {

            //判断所有的数据不能为空
            if (CheckEmpty())
            {
                MemberInfo member = new MemberInfo();
                member.MemAddress = txtAddress.Text;
                member.MemBirthday = txtBirstday.Value;//生日
                member.MemDiscount = Convert.ToDouble(txtDiscount.Text);//折扣
                member.MemEndTime = txtEndTime.Value;//结束时间
                //性别:member.MemGender==坑
                member.MemGender = CheckGender();//性别
                member.MemIntegral = Convert.ToInt32(txtIntegral.Text);//积分
                member.MemMobilePhone = txtPhone.Text;//电话
                member.MemMoney = Convert.ToDouble(txtMoney.Text);//金额
                member.MemName = txtName.Text;//会员的名字
                member.MemNum = txtNum.Text;//编号
                member.MemType = Convert.ToInt32(cmbType.SelectedValue);//会员的类型
                member.SubTime = System.DateTime.Now;
                if (Temp == 1)//新增
                {
                    member.DelFlag = 0;
                }
                else if (Temp == 2)//修改
                {
                    member.MemberId = Convert.ToInt32(labId.Text);//会员的id
                }
                MemberInfoBl memBll = new MemberInfoBl();
                string msg = memBll.AddOrUpdateMemberInfo(member, Temp) ? "操作成功" : "操作失败";
                md.MsgDivShow(msg, 1, Bind);

            }
        }
        private void Bind()
        {
            this.Close();
        }
        private string CheckGender()
        {
            string str = "";
            if (rdoMan.Checked)
            {
                str = "男";
            }
            else if (rdoWoman.Checked)
            {
                str = "女";
            }
            return str;
        }
        //判断每个文本框数据--下拉框--时间控件不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                md.MsgDivShow("地址不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtBirstday.Value.ToString()))
            {
                md.MsgDivShow("生日不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtDiscount.Text))
            {
                md.MsgDivShow("折扣不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtEndTime.Value.ToString()))
            {
                md.MsgDivShow("结束时间不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtIntegral.Text))
            {
                md.MsgDivShow("积分不能为空", 1);
                return false;
            } if (string.IsNullOrEmpty(txtMoney.Text))
            {
                md.MsgDivShow("金额不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                md.MsgDivShow("名字不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                md.MsgDivShow("编号不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                md.MsgDivShow("电话号码不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtSubTime.Value.ToString()))
            {
                md.MsgDivShow("注册时间不能为空", 1);
                return false;
            }
            if (txtEndTime.Value <= txtSubTime.Value)
            {
                md.MsgDivShow("有效期应该大于当前的注册时间");
                return false;
            }
            if (cmbType.SelectedIndex == 0)
            {
                md.MsgDivShow("请选择会员类型", 1);
                return false;
            }
            return true;
        }
        //取消
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
