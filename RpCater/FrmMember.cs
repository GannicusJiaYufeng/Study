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
    public partial class FrmMember : Form
    {
        private FrmMember()
        {
            InitializeComponent();
        }
        private static FrmMember instance;

        public static FrmMember Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)//为空或者被释放
                {
                    instance = new FrmMember();
                }
                return instance;
            }


        }
        //窗体加载的时候
        private void FrmMember_Load(object sender, EventArgs e)
        {
            LoadMemberInfoByDelFlag(0);
            cmbmember.SelectedIndex = 0;//下拉框索引设置，让他直接显示请选择
        }

        private void LoadMemberInfoByDelFlag(int p)
        {
            //查询会员
            MemberInfoBl memBll = new MemberInfoBl();
            dgvmember.AutoGenerateColumns = false;//禁止自动生成列
            dgvmember.DataSource = memBll.GetAllMemberInfoByDelFlag(p);
            dgvmember.ClearSelection();
        }

        private void cmbmember_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMemberInfoByDelFlag(cmbmember.SelectedIndex);
        }

        //模糊查询
        private void btnsearch_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtsearch.Text))
            //{
            //    mds.MsgDivShow("姓名为空，不能查询", 1);
            //    return;
            //}
            //按照用户输入的名字模糊查询
            MemberInfoBl memBll = new MemberInfoBl();
            dgvmember.AutoGenerateColumns = false;
            dgvmember.DataSource = memBll.GetMenmberInfoByLikeMemName(txtsearch.Text);
            dgvmember.ClearSelection();//清除选中内容,
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //判断是否选中
            if (dgvmember.SelectedRows.Count <= 0)
            {
                mds.MsgDivShow("请选中要注销的会员", 1);
                return;
            }
            if (MessageBox.Show("真的要注销吗", "注销会员", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                //在哪里删除的会员
                int index = cmbmember.SelectedIndex == 0 ? 1 : 2;

                MemberInfoBl memBll = new MemberInfoBl();
                int memId = ((MemberInfo)dgvmember.SelectedRows[0].DataBoundItem).MemberId;
                string msg = memBll.SoftDeleteMemberByMemberId(memId, index) ? "操作成功" : "操作失败";

                mds.MsgDivShow(msg, 1);//显示消息
                //刷新
                int delFlag = index == 1 ? 0 : 1;
                LoadMemberInfoByDelFlag(delFlag);//刷新操作
                return;

            }
            mds.MsgDivShow("你已经取消了注销");
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //新增， 标识：1

            ShowFrmMemberOrModify(1, null);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            
            if (dgvmember.SelectedRows.Count <= 0)
            {
                mds.MsgDivShow("请选中要修改的会员", 1);
                return;
            }
            //获取选中会员的对象
            MemberInfo member = (MemberInfo)dgvmember.SelectedRows[0].DataBoundItem;
            //修改，标识：2，会员对象
            ShowFrmMemberOrModify(2, member);
        }
        private void ShowFrmMemberOrModify(int temp, MemberInfo member)
        {
            this.Hide();//当前窗体隐藏
            //显示新增或修改窗体
            FrmMemberAddOrModify fmam = FrmMemberAddOrModify.Single(temp, member);//单例模式下的new新窗体并且传递了数据,新增就没有对象传过去，修改就有
            fmam.FormClosed += new FormClosedEventHandler(fmam_FormClosed);//事件
            fmam.Show();
        }

        private void fmam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            //刷新
            LoadMemberInfoByDelFlag(0);
        }

        //导出操作
        private void btnWrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();//new一个对话框
            sfd.Filter = "Excel文件(*.xlsx)|*.xlsx";
            sfd.Title = "Excel文件操作";
            if (sfd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                //文件名=========sfd.FileName
                //NPOI操作Excel文件
                MemberInfoBl bll = new MemberInfoBl();
                bll.WriteExcel(sfd.FileName);
                mds.MsgDivShow("成功了", 1);
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //弹出对话框  让用户选择xlsx文件
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Execl文件操作";
            ofd.Filter="Excel文件(*.xlsx;*xls)|*.xlsx;*.xls";
            if (ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                //获取文件
                //读取excel文件
                MemberInfoBl mblll = new MemberInfoBl();
                mblll.ReadExcel(ofd.FileName);
                mds.MsgDivShow("成功");
                //刷新
                LoadMemberInfoByDelFlag(0);
            }
            //读取Excel文件

            //把Excel文件的数据插入到数据库中
        }
    }
}
