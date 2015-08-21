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
    public partial class FrmProductAddOrModify : Form
    {
        public FrmProductAddOrModify(ProductInfo pro)
        {
            InitializeComponent();
            LoadCategoryInfoByDelFlag(0);//下拉框绑定数据
            //判断对象不能为空
            if (pro != null)//修改
            {
                txtCost.Text = pro.ProCost.ToString();//进价
                txtName.Text = pro.ProName;//名字
                txtNum.Text = pro.ProNum;//编号
                txtPrice.Text = pro.ProPrice.ToString();//价格
                txtRemark.Text = pro.Remark;//备注
                txtSpell.Text = pro.ProSpell;//拼音
                txtStock.Text = pro.ProStock.ToString();//库存
                txtUnit.Text = pro.ProUnit;//单位
                labId.Text = pro.ProId.ToString();//产品信息的id
                cmbCategory.SelectedValue = pro.CId;//商品类别---显示
            }
        }
        //绑定下拉框的类别数据
        private void LoadCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBll cBll = new CategoryInfoBll();
            List<CategoryInfo> list = cBll.GetAllCategoryInfoByDelFlag(p);
            list.Insert(0, new CategoryInfo() { CName = "请选择", CId = -1 });
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "CName";
            cmbCategory.ValueMember = "CId";

        }

        private static int Temp;//存标识
        private static FrmProductAddOrModify _instance;
        public static FrmProductAddOrModify Single(int temp, ProductInfo pro)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmProductAddOrModify(pro);
                Temp = temp;//标识
            }
            return _instance;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //新增或者修改
            if (CheckEmpty())
            {
                ProductInfoBll proBll = new ProductInfoBll();
                ProductInfo pro = new ProductInfo();
                pro.CId = Convert.ToInt32(cmbCategory.SelectedValue);//获取选择的类别
                pro.ProCost = Convert.ToDouble(txtCost.Text);//价格
                pro.ProName = txtName.Text;//名字
                pro.ProNum = txtNum.Text;//编号
                pro.ProPrice = Convert.ToDouble(txtPrice.Text);//实际的价格
                pro.ProSpell = txtSpell.Text;//拼音
                pro.ProStock = Convert.ToInt32(txtStock.Text);
                pro.ProUnit = txtUnit.Text;//单位
                pro.Remark = txtRemark.Text; ;//备注

                if (Temp == 1)//新增
                {
                    pro.DelFlag = 0;
                    pro.SubBy = 1;
                    pro.SubTime = System.DateTime.Now;//当前时间
                }
                else if (Temp == 2)//修改
                {
                    pro.ProId = Convert.ToInt32(labId.Text);
                }
                md.MsgDivShow(proBll.AddOrUpdateProductInfo(pro, Temp) ? "操作成功" : "操作失败", 1, Bind);

            }
        }
        private void Bind()
        {
            this.Close();
        }
        //判断文本框不能为空
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                md.MsgDivShow("进价不能为空", 1);
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
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                md.MsgDivShow("实际价格不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                md.MsgDivShow("备注不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                md.MsgDivShow("拼音不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                md.MsgDivShow("库存不能为空", 1);
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                md.MsgDivShow("单位不能为空");
                return false;
            }
            if (cmbCategory.SelectedIndex == 0)
            {
                md.MsgDivShow("请选中类别", 1);
                return false;
            }
            return true;
        }
    }
}
