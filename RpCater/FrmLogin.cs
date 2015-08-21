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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        //取消
        private void btnesc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bthlogin_Click(object sender, EventArgs e)
        {
            //登录
            if (CheakLoginNameAndPwd())
            { 
             //都不为空
                UserInfoBll userBll = new UserInfoBll();
                LoginStatus result = userBll.GetUserInfoByLoginName(txtname.Text, txtpwd.Text);
                if (result == LoginStatus.LoginNameNotFound)
                {
                    md.MsgDivShow("账号不存在", 1);
                }
                else if (result == LoginStatus.PasswordError)
                {
                    md.MsgDivShow("密码错误了", 1);
                }
                else if (result == LoginStatus.OK)
                {
                    md.MsgDivShow("登录成功", 1,Bind);
                }
            }
        }
        private void Bind()
        {
            //设置当前窗体的对话框的结果
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private bool CheakLoginNameAndPwd()
        {
            if (string.IsNullOrEmpty(txtname.Text))
            {
                md.MsgDivShow("账号不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtpwd.Text))
            {
                md.MsgDivShow("密码不能为空", 1);
                return false;
            }
            return true;
        }
    }
}
