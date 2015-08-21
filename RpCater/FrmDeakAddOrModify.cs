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
    public partial class FrmDeakAddOrModify : Form
    {
        private FrmDeakAddOrModify(DeskInfo dk)
        {
            InitializeComponent();
            LoadRoomInfoByDelFlag(0);
            if (dk != null)
            {
                //修改
                txtDeskName.Text = dk.DeskName;//餐桌的名字
                txtDeskRegion.Text = dk.DeskRegion;//描述
                txtDeskRemark.Text = dk.DeskRemark;//备注
                labId.Text = dk.DeskId.ToString();//餐桌的id
                //显示该餐桌的房间
                cmbRoom.SelectedValue = dk.RoomId;
            }
        }

        private void LoadRoomInfoByDelFlag(int p)
        {
            RoomInfoBLL rBll = new RoomInfoBLL();
            List<RoomInfo> list = rBll.GetAllRoomInfoByDelFlag(p);
            list.Insert(0, new RoomInfo() { RoomName = "请选择", RoomId = -1 });
            cmbRoom.DataSource = list;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
             
        }
        private static FrmDeakAddOrModify instance;
        private static int Temp;
        public static FrmDeakAddOrModify Single(DeskInfo dk, int temp)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmDeakAddOrModify(dk);
                Temp = temp;
            }
            return instance;
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                DeskInfoBLL dkBll = new DeskInfoBLL();
                DeskInfo dk = new DeskInfo();
                dk.DeskName = txtDeskName.Text;
                dk.DeskRegion = txtDeskRegion.Text;//描述信息
                dk.DeskRemark = txtDeskRemark.Text;//备注
                dk.RoomId = Convert.ToInt32(cmbRoom.SelectedValue);//房间的id

                if (Temp == 1)//新增
                {
                    dk.DelFlag = 0;
                    dk.DeskState = 0;//空闲===1===就餐
                    dk.SubBy = 1;
                    dk.SubTime = System.DateTime.Now;
                }
                else if (Temp == 2)//修改操作
                {
                    dk.DeskId = Convert.ToInt32(labId.Text);
                }
                md.MsgDivShow(dkBll.AddOrUpdateDeskInfo(dk, Temp) ? "操作成功" : "操作失败", 1, Bind);
            }

        }
        private void Bind()
        {
            this.Close();
        }
        //验证文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtDeskName.Text))
            {
                md.MsgDivShow("名字不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRegion.Text))
            {
                md.MsgDivShow("描述信息不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtDeskRemark.Text))
            {
                md.MsgDivShow("备注不能为空", 1);
                return false;
            }
            if (cmbRoom.SelectedIndex == 0)
            {
                md.MsgDivShow("请选中房间");
                return false;
            }
            return true;
        }
    }
}
