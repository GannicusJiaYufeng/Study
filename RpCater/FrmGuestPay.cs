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
    public partial class FrmGuestPay : Form
    {
        private FrmGuestPay(int orderId, int deskId, string deskName)
        {
            InitializeComponent();
            //显示订单的编号
            labOrderId.Text = orderId.ToString();//订单的单号(订单的id)
            labdkId.Text = deskId.ToString();//餐桌的id存储起来
            labDeskName.Text = deskName;//餐桌的编号

            //根据订单的id查询消费的总金额
            OrderInfoBll oBll = new OrderInfoBll();
            labMoney.Text = oBll.GetMoneyByOrderId(orderId).ToString();//显示消费金额
            lblMoney.Text = labMoney.Text;//结账的金额

        }
        private static FrmGuestPay _instance;
        public static FrmGuestPay Single(int orderId, int deskId, string deskName)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmGuestPay(orderId, deskId, deskName);
            }
            return _instance;
        }
        //结账窗体加载的时候
        private void FrmGuestPay_Load(object sender, EventArgs e)
        {
            MemberInfoBl memBll = new MemberInfoBl();
            //获取所有没被删除的会员
            List<MemberInfo> list = memBll.GetAllMemberInfoByDelFlag(0);
            list.Insert(0, new MemberInfo() { MemName = "请选择", MemberId = -1 });
            cmbMember.DataSource = list;
            cmbMember.DisplayMember = "MemName";
            cmbMember.ValueMember = "MemberId";

            //显示该订单的菜
            Load_Order_ProductByOrdrtId(Convert.ToInt32(labOrderId.Text));

        }

        private void Load_Order_ProductByOrdrtId(int p)
        {
            R_Order_ProductBll rop = new R_Order_ProductBll();
            dgvROrderProduct.AutoGenerateColumns = false;//禁止自动生成列
            dgvROrderProduct.DataSource = rop.GetR_Order_ProductByOrderId(p);
            dgvROrderProduct.ClearSelection();//清除选中项
        }
        //会员下拉框
        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex != 0)
            {
                MemberInfo mem = cmbMember.SelectedItem as MemberInfo;
                //选中会员的金额
                labyuMoney.Text = mem.MemMoney.ToString();
                lblDisCount.Text = mem.MemDiscount.ToString();
                //会员的结账金额
                lblMoney.Text = (mem.MemDiscount * (Convert.ToDouble(labMoney.Text)) * 0.1).ToString();
            }
            else
            {
                //没有选中会员
                labyuMoney.Text = "";
                lblDisCount.Text = "";
                lblMoney.Text = labMoney.Text;

            }
        }
        //结账
        private void btnAccounts_Click(object sender, EventArgs e)
        {
            //餐桌状态发生改变
            DeskInfoBLL dkbll = new DeskInfoBLL();
            bool dkResult = dkbll.UpdateDeskInfoStateByDeskId(Convert.ToInt32(labdkId.Text), 0);
            //订单状态发生改变
            OrderInfoBll orderBll = new OrderInfoBll();
            OrderInfo order = new OrderInfo();
            order.EndTime = System.DateTime.Now;//当前的时间
            order.OrderMoney = Convert.ToDouble(lblMoney.Text);//结账后的金额
            order.OrderState = 2;//状态
            order.OrderId = Convert.ToInt32(labOrderId.Text);
            if (cmbMember.SelectedIndex != 0)
            {
                //获取选中的会员对象
                MemberInfo mem = (MemberInfo)cmbMember.SelectedItem;
                order.OrderMemberId = mem.MemberId;//会员的id
                order.DisCount = mem.MemDiscount;//折扣

                //根据会员的id更新该会员的金额
                MemberInfoBl memBll = new MemberInfoBl();
                //得到会员的金额
                double money = Convert.ToDouble(labyuMoney.Text) - Convert.ToDouble(lblMoney.Text);
                //更新会员余额
                memBll.UpdateMemberMoneyById(mem.MemberId, money);//==不接收了
            }

            //更新订单中的金额
            bool orderResult = orderBll.UpdateOrderInfo(order);
            //会员结账----更改会员余额
            //改变订单对应的订单和菜单的中间表中的菜的状态
            R_Order_ProductBll ropBll = new R_Order_ProductBll();
            bool ropResult = ropBll.UpdateR_Order_ProductDelFlagByOrderId(Convert.ToInt32(labOrderId.Text));
            if (dkResult && orderResult & ropResult)
            {
                md.MsgDivShow("顾客结账成功", 1);
            }
            else
            {
                md.MsgDivShow("结账失败了", 1);
            }
        }
    }
}
