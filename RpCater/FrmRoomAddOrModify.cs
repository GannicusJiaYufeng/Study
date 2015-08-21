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
    public partial class FrmRoomAddOrModify : Form
    {
        private FrmRoomAddOrModify(RoomInfo room)
        {
            InitializeComponent();
            if (room!=null)//修改
            {
                //为所有的文本框赋值
                txtIsDefault.Text = room.IsDefault;//房间的默认编号
                txtRMinMoney.Text = room.RoomMinMoney.ToString();//最低消费
                txtRName.Text = room.RoomName;//房间的名字
                txtRPerNum.Text = room.RoomMaxNum.ToString();//房间的最多容纳人数
                txtRType.Text = room.RoomType.ToString();//房间的类型
                labId.Text = room.RoomId.ToString();//房间的id
            }
        }
        private static FrmRoomAddOrModify instance;
        private static int Temp;//存标识
        public static FrmRoomAddOrModify Single(int temp, RoomInfo room)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmRoomAddOrModify(room);
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
                RoomInfo r = new RoomInfo();
                r.IsDefault = txtIsDefault.Text;//默认的编号
                r.RoomMaxNum = Convert.ToInt32(txtRPerNum.Text);//容纳人数
                r.RoomMinMoney = Convert.ToDouble(txtRMinMoney.Text);//最低消费
                r.RoomName = txtRName.Text;//名字
                r.RoomType = Convert.ToInt32(txtRType.Text);

                //增加或者修改
                if (Temp == 1)//新增
                {
                    r.DelFlag = 0;
                    r.SubBy = 1;
                    r.SubTime = System.DateTime.Now;//当前的时间
                }
                else if (Temp == 2)//修改
                {
                    r.RoomId = Convert.ToInt32(labId.Text);
                }
                RoomInfoBLL rBll = new RoomInfoBLL();
                string msg = rBll.AddOrUpdateRoomInfo(r, Temp) ? "操作成功" : "操作失败";
                md.MsgDivShow(msg, 1, Bind);
            }
        }
        
        private void Bind()
        {
            this.Close();
        }
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtIsDefault.Text))
            {
                md.MsgDivShow("编号不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtRMinMoney.Text))
            {
                md.MsgDivShow("最低消费不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtRName.Text))
            {
                md.MsgDivShow("名字不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtRPerNum.Text))
            {
                md.MsgDivShow("容纳人数不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtRType.Text))
            {
                md.MsgDivShow("类型不能为空,是数字", 1);
                return false;
            }
            return true;
        }
        
    }
}
