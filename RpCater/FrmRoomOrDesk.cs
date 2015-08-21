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
    public partial class FrmRoomOrDesk : Form
    {
        private FrmRoomOrDesk()
        {
            InitializeComponent();
        }
        private static FrmRoomOrDesk _instance;

        public static FrmRoomOrDesk Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmRoomOrDesk();
                }
                return _instance;
            }

        }

        private void FrmRoomOrDesk_Load(object sender, EventArgs e)
        {
            //窗体加载的时候显示所有房间和餐桌信息
            LoadAllRoomInfoByDelFlag(0);
            LoadAllDeskInfoByDelFlag(0);
        }
        //加载餐桌
        private void LoadAllDeskInfoByDelFlag(int p)
        {
            DeskInfoBLL dkBll = new DeskInfoBLL();
            dgvDesk.AutoGenerateColumns = false;
            dgvDesk.DataSource = dkBll.GetAllDeskInfoByDelFlag(p);
            dgvDesk.ClearSelection();//清楚默认选中的行
        }
        //加载房间
        private void LoadAllRoomInfoByDelFlag(int p)
        {
            RoomInfoBLL rBll = new RoomInfoBLL();
            dgvRoom.AutoGenerateColumns = false;//禁止自动生成列
            dgvRoom.DataSource = rBll.GetAllRoomInfoByDelFlag(p);
            dgvRoom.ClearSelection();//清楚默认选中的行
        }

        private void btnARoom_Click(object sender, EventArgs e)
        {
            ShowFrmRoomAddOrModify(1, null);
        }   //增加房间
        //修改房间
        private void btnURoom_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请选中要修改的房间", 1);
                return;
            }
            RoomInfo room = (RoomInfo)dgvRoom.SelectedRows[0].DataBoundItem;
            ShowFrmRoomAddOrModify(2, room);
        }
        private void ShowFrmRoomAddOrModify(int temp, RoomInfo room)
        {
            this.Hide();//不是关闭是隐藏  不是close！！
            FrmRoomAddOrModify fram = FrmRoomAddOrModify.Single(temp, room);
            //     fram.Show();  不是写在这里
            fram.FormClosed += new FormClosedEventHandler(fram_FormClose);
            fram.Show();
        }

        private void fram_FormClose(object sender, FormClosedEventArgs e)
        {
            this.Show();
            LoadAllRoomInfoByDelFlag(0);//刷新房间信息
        }

        private void btnADesk_Click(object sender, EventArgs e)
        {
            AddOrUdDeak(null, 1);
        }

        private void btnUDesk_Click(object sender, EventArgs e)
        {
            if (dgvDesk.SelectedRows.Count <= 0)
            {
                md1.MsgDivShow("选中要修改的行", 1);
            }
            DeskInfo dk = (DeskInfo)dgvDesk.SelectedRows[0].DataBoundItem;
            AddOrUdDeak(dk, 2);

        }
        private void AddOrUdDeak(DeskInfo dk, int temp)
        {
            this.Hide();
            FrmDeakAddOrModify fdam = FrmDeakAddOrModify.Single(dk, temp);
            fdam.FormClosed += new FormClosedEventHandler(fdam_FormClose);
            fdam.Show();
        }

        private void fdam_FormClose(object sender, FormClosedEventArgs e)
        {
            this.Show();
            LoadAllDeskInfoByDelFlag(0);
        }

        private void btnDDesk_Click(object sender, EventArgs e)
        {
            //判断是否选中的要删除的餐桌
            if (dgvDesk.SelectedRows.Count <= 0)
            {
                md1.MsgDivShow("请选中要删除的餐桌", 1);
                return;
            }
            if (MessageBox.Show("确定要删除该餐桌吗?", "删除餐桌", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int id = ((DeskInfo)dgvDesk.SelectedRows[0].DataBoundItem).DeskId;
                DeskInfoBLL dkBll = new DeskInfoBLL();
                md1.MsgDivShow(dkBll.SoftDeleteDeskByDeskId(id) ? "操作成功" : "操作失败", 1);
                LoadAllDeskInfoByDelFlag(0);
                return;
            }
            md1.MsgDivShow("您已经取消了删除该餐桌的操作", 1);
        }

        private void btnDRoom_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请选中要删除的房间", 1);
                return;
            }
            if (MessageBox.Show("确认删除该房间吗?", "删除房间", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int id = ((RoomInfo)dgvRoom.SelectedRows[0].DataBoundItem).RoomId;

                //判断该房间下是否有餐桌,有餐桌就不删除该房间
                DeskInfoBLL dkBll = new DeskInfoBLL();
                if (dkBll.GetDeskInfoCountByRoomId(id)>0)
                {
                    md.MsgDivShow("对不起,该房间下有餐桌", 1);
                    return;
                }
                //该房间下没有餐桌--可以删除选中的房间
                RoomInfoBLL rBll = new RoomInfoBLL();
                md.MsgDivShow(rBll.SoftDeleteRoomInfoByRoomId(id) ? "操作成功" : "操作失败", 1);
                LoadAllRoomInfoByDelFlag(0);//刷新
                return;
            }
            md.MsgDivShow("您已经取消了删除该房间");
        }
    }
}
