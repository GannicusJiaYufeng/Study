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
    public partial class FrmBilling : Form
    {
        private FrmBilling(int deskId, string deakName, RoomInfo room)
        {
            InitializeComponent();
            //还没有把值存起来
            labDeskName.Text = deakName;//餐桌的编号
            labRoomName.Text = room.RoomName;//房间
            labLittleMoney.Text = room.RoomMinMoney.ToString();//最低消费
            labId.Text = deskId.ToString();//餐桌的id
        }
        private static FrmBilling _instance;
        public static FrmBilling Single(int deskId,string deakName,RoomInfo room)
        { 
           //餐桌id  名字  房间id  最低消费
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmBilling(deskId, deakName, room);
            }
            return _instance;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //首先改变餐桌状态
            DeskInfoBLL dkBll = new DeskInfoBLL();
            bool dkFlag = dkBll.UpdateDeskInfoStateByDeskId(Convert.ToInt32(labId.Text), 1);
            //添加一个订单 返回该订单ID
            OrderInfo order =new  OrderInfo();
            order.BeginTime = System.DateTime.Now;//订单的开始时间
            order.DelFlag = 0;//删除标识
            order.DisCount = 0;//折扣==针对会员
            order.OrderMoney = 0;//订单消费的金额默认值为0
            order.OrderState = 1;//订单状态1===使用
            order.Remark = txtPersonCount.Text + "个" + txtDescription.Text;//备注
            order.SubBy = 1;//提交人默认1
            order.SubTime = System.DateTime.Now;
            OrderInfoBll oBll = new OrderInfoBll();
            //获得订单的id
            object orderIdObj = oBll.AddOrderInfo(order);
            //为餐桌和订单的中间表添加一条记录
            R_Order_Desk rod = new R_Order_Desk();
            rod.DeskId = Convert.ToInt32(labId.Text);//餐桌的id
            rod.OrderId = Convert.ToInt32(orderIdObj);//订单的id
            ordId = rod.OrderId;//存储订单的id
            R_Order_DeskBll rodBll = new R_Order_DeskBll();
            bool rodFlag = rodBll.AddR_Order_Desk(rod);
            if (dkFlag && rodFlag)
            {
                md.MsgDivShow("开单成功", 1, Bind);
            }
            else
            {
                md.MsgDivShow("开单失败,请联系程序员", 1);
                return;
            }

        }
        private int ordId;//用来存储订单的id
        private void Bind()
        {
            if (ckbMeal.Checked)
            {
                this.Hide();
                //增加消费的窗体显示出来----传订单的id--根据订单的id--查菜单--消费数量--金额
                //-- 传餐桌的编号
                FrmAddConsumption fac = FrmAddConsumption.Single(labDeskName.Text, ordId);
                //FrmAddConsumption fac = new FrmAddConsumption();
                fac.FormClosed += new FormClosedEventHandler(fac_FormClosed);
                fac.Show();
                return;
            }
            this.Close();//开单的窗体关闭
        }
        void fac_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
