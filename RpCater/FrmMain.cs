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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            FrmMember fm = FrmMember.Instance;
            fm.Show();
        }

        private void btnCategoryOrProduct_Click(object sender, EventArgs e)
        {
            FrmCategoryAndProduct fcp = FrmCategoryAndProduct.Instance;
            fcp.Show();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            //显示房间和餐桌的窗体
            FrmRoomOrDesk frod = FrmRoomOrDesk.Instance;
            frod.FormClosed += new FormClosedEventHandler(frod_FormClosed);
            frod.Show();
        }

        private void frod_FormClosed(object sender, FormClosedEventArgs e)
        {
            tabMain.TabPages.Clear();//!!!!!!!!!!
            LoadRoomInfoByDelFlag(0);
            LoadDeakInfoByTabpageSelect(tabMain.SelectedTab);
        }


        //窗体加载的时候
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //加载所有的房间
            LoadRoomInfoByDelFlag(0);
            //根据选中的房间加载该房间下的餐桌！！！！！
            tabMain.SelectedIndexChanged += new EventHandler(tabMain_SelectedIndexChanged);
           //加载默认的房间里面的餐桌
            LoadDeakInfoByTabpageSelect(tabMain.SelectedTab);
        }
        //根据选中的房间加载该房间下的餐桌
        void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab != null)
            {
                //加载餐桌的方法
                LoadDeakInfoByTabpageSelect(tabMain.SelectedTab);
            }

        }
        //根据房间的id显示里面的餐桌
        private void LoadDeakInfoByTabpageSelect(TabPage tp)
        {
            RoomInfo room = (RoomInfo)tp.Tag;//获取房间对象
            //获取tabpage控件中的listview控件
            ListView lv = (ListView)tp.Controls[0];//获取包含在控件内的控件
            lv.Clear();//清除
            //根据房间Id查询该房间下所有的餐桌
            DeskInfoBLL dkBll = new DeskInfoBLL();
            List<DeskInfo> listDesk = dkBll.GetAllDeskInfoByRoomId(room.RoomId);
            for (int i = 0; i < listDesk.Count; i++)
            {
                lv.Items.Add(listDesk[i].DeskName, listDesk[i].DeskState);//用指定的文本和图像创建一个项并添加到集合中
                lv.Items[i].Tag = listDesk[i];//餐桌对象存起来
            }
        }
        //动态加载所有的房间
        private void LoadRoomInfoByDelFlag(int p)
        {
            //坑==========================================
            //加载所有的房间
            RoomInfoBLL rBll = new RoomInfoBLL();
            List<RoomInfo> listRoom = rBll.GetAllRoomInfoByDelFlag(p);
            for (int i = listRoom.Count - 1; i >= 0; i--)
            {
                TabPage tp = new TabPage();
                tp.Text = listRoom[i].RoomName;//显示房间的名字
                tp.Tag = listRoom[i];//把房间对象存储到每个tabpage控件的tag属性
                ListView lv = new ListView();//餐桌 listview这个控件可以放图片也可以放文字                lv.LargeImageList = imageList1;//设置该控件中显示图片控件
                lv.LargeImageList = imageList1;//设置该控件中显示图片控件
                lv.View = View.LargeIcon;//设置控件中的图片显示的方式
                lv.Dock = DockStyle.Fill;//设置该控件的显示方式
                lv.BackColor = Color.SeaGreen;//设置该控件的背景颜色
                lv.MultiSelect = false;//禁止多选
                //把lv添加到tabpage控件中
                tp.Controls.Add(lv);
                tabMain.TabPages.Add(tp);
            }
        }
        //顾客开单
        private void button1_Click(object sender, EventArgs e)
        {
            //显示开单窗体
           // TabPage tp=tabMain.SelectedTab;//.Control[0];
           // ListView lv=(ListView)tp.Controls[0];
            ListView lv=(ListView)(tabMain.SelectedTab.Controls[0]);
            //房间的对象
            RoomInfo room=(RoomInfo)tabMain.SelectedTab.Tag;
            //餐桌的对象
            if(lv.SelectedItems.Count<=0)//没选中餐桌 
            {
                md.MsgDivShow("请选中要点餐的餐桌", 1);
                return;
            
            }
            DeskInfo dk=(lv.SelectedItems[0].Tag as DeskInfo);
            if (dk.DeskState==1)
            {
                md.MsgDivShow("请选择其余没在就餐的餐桌", 1);
                return;
            }
            FrmBilling fbi = FrmBilling.Single(dk.DeskId, dk.DeskName, room);
            fbi.FormClosed += new FormClosedEventHandler(fbi_FormClosed);
            fbi.Show();//显示开单窗体

        }
        //刷新当前选中的房间里面的餐桌状态
        private void fbi_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadDeakInfoByTabpageSelect(tabMain.SelectedTab);
        }
        //增加消费
        private void btnAddConsumption_Click(object sender, EventArgs e)
        {
            //
            ListView lv = (ListView)(tabMain.SelectedTab.Controls[0]);
            //房间的对象
            RoomInfo room = (RoomInfo)(tabMain.SelectedTab.Tag);
            //餐桌的对象
            if (lv.SelectedItems.Count <= 0)//没选中餐桌
            {
                md.MsgDivShow("请选中要增加消费的餐桌", 1);
                return;
            }
          
            DeskInfo dk = (lv.SelectedItems[0].Tag as DeskInfo);   
            if (dk.DeskState == 0)
            {
                md.MsgDivShow("请选择开单后的餐桌进行增加消费", 1);
                return;
            }
            //根据餐桌的id查询该餐桌对应的订单的id
            OrderInfoBll orderBll = new OrderInfoBll();
            object objOrderId = orderBll.GetOrderIdByDeskId(dk.DeskId);
            FrmAddConsumption fac = FrmAddConsumption.Single(dk.DeskName, Convert.ToInt32(objOrderId));
            //增加消费之后=======刷新
            fac.FormClosed += new FormClosedEventHandler(fbi_FormClosed);//！！！！！！！！！必须刷新
            fac.Show();//显示增加消费的窗体
        }
        //上帝结账
        private void btnGuestPay_Click(object sender, EventArgs e)
        {
            ListView lv = (ListView)(tabMain.SelectedTab.Controls[0]);
            //房间的对象
            RoomInfo room = (RoomInfo)(tabMain.SelectedTab.Tag);
            //餐桌的对象
            if (lv.SelectedItems.Count <= 0)//没选中餐桌
            {
                md.MsgDivShow("请选中要结账的餐桌", 1);
                return;
            }
            DeskInfo dk = (lv.SelectedItems[0].Tag as DeskInfo);
            if (dk.DeskState == 0)//没有选中就餐的餐桌
            {
                md.MsgDivShow("请选择就餐的餐桌进行结账", 1);
                return;
            }
            //结账了--显示窗体
            //获取订单的id
            OrderInfoBll orderBll = new OrderInfoBll();
            object objOrderId = orderBll.GetOrderIdByDeskId(dk.DeskId);
            FrmGuestPay fgp = FrmGuestPay.Single(Convert.ToInt32(objOrderId), dk.DeskId, dk.DeskName);
            fgp.FormClosed += new FormClosedEventHandler(fbi_FormClosed);//刷新
            fgp.Show();//结账的窗体就显示出来
        }
    }
}
