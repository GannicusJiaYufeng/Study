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
    public partial class FrmCategoryAndProduct : Form
    {
        private FrmCategoryAndProduct()
        {
            InitializeComponent();
        }
        private static FrmCategoryAndProduct instance;

        public static FrmCategoryAndProduct Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new FrmCategoryAndProduct();
                return instance;
            }

        }
        private void FrmCategoryAndProduct_Load(object sender, EventArgs e)
        {
            //类别信息和产品信息显示
            LoadAllCategoryInfoByDelFlag(0);//显示类别信息的方法
            LoadAllProductInfoByDelFlag(0);//显示产品信息的方法
        }
       //显示产品信息的方法
        private void LoadAllProductInfoByDelFlag(int p)
        {
            ProductInfoBll proBll = new ProductInfoBll();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = proBll.GetAllProductInfoByDelFlag(p);
            dgvProduct.ClearSelection();
        }
        //显示类别信息的方法
        private void LoadAllCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBll cBll = new CategoryInfoBll();
            dgvCategory.AutoGenerateColumns = false;//禁止自动生成列
            dgvCategory.DataSource = cBll.GetAllCategoryInfoByDelFlag(p);
            dgvCategory.ClearSelection();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ShowFrmCategoryAddOrModify(1, null);
        }
        //修改类别
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请选中要修改的商品类别", 1);
                return;
            }
            CategoryInfo c = (CategoryInfo)dgvCategory.SelectedRows[0].DataBoundItem;
            ShowFrmCategoryAddOrModify(2, c);
        }
        private void ShowFrmCategoryAddOrModify(int temp, CategoryInfo c)
        {
            this.Hide();
            FrmCategoryAddOrModify fcam = FrmCategoryAddOrModify.Single(temp, c);
            fcam.FormClosed += new FormClosedEventHandler(fcam_FormClosed);
            fcam.Show();//显示商品类别信息新增或者修改的窗体
        }
        void fcam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            LoadAllCategoryInfoByDelFlag(0);//刷新
            LoadAllProductInfoByDelFlag(0);//刷新
        }
        //新增产品信息
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ShowFrmProductAddOrModify(1, null);
        }
        //修改产品信息
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count <= 0)
            {
                md1.MsgDivShow("请选中要修改的产品信息", 1);
                return;
            }
            ProductInfo pro = (ProductInfo)dgvProduct.SelectedRows[0].DataBoundItem;
            ShowFrmProductAddOrModify(2, pro);
        }

        private void ShowFrmProductAddOrModify(int temp, ProductInfo pro)
        {
            this.Hide();//当前窗体隐藏
            FrmProductAddOrModify fpam = FrmProductAddOrModify.Single(temp, pro);
            fpam.FormClosed += new FormClosedEventHandler(fcam_FormClosed);
            fpam.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //注销产品
            if (dgvProduct.SelectedRows.Count <= 0)
            {
                md1.MsgDivShow("请选中要删除的产品", 1);
                return;
            }
            if (MessageBox.Show("确实要删除该产品?", "删除产品", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                //获取选中产品的ID
                int proId = ((ProductInfo)dgvProduct.SelectedRows[0].DataBoundItem).ProId;
                ProductInfoBll proBll = new ProductInfoBll();
                md1.MsgDivShow(proBll.SoftDeleteByProId(proId) ? "操作成功" : "操作失败", 1);
                LoadAllProductInfoByDelFlag(0);//刷新！！！！！！！！
                return;
            }
            md1.MsgDivShow("你已经取消了注销该产品", 1);
            return;
        }

        //注销商品类别
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请选择要注销的商品类别");
                return;
            }
            if (MessageBox.Show("确定删除该类别吗", "删除商品类别", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                //获取类别ID
                int cId = ((CategoryInfo)dgvCategory.SelectedRows[0].DataBoundItem).CId;
                ProductInfoBll proBll = new ProductInfoBll();
                if (proBll.GetProductInfoCountByCId(cId) > 0)
                {

                    md.MsgDivShow("抱歉，该类别下有产品，不能删除");
                    return;

                }
                CategoryInfoBll cBll = new CategoryInfoBll();
                md.MsgDivShow(cBll.SoftDeleteCategoryByCId(cId) ? "操作成功" : "操作失败", 1);
                LoadAllCategoryInfoByDelFlag(0);
                return;
            }
            md.MsgDivShow("取消了", 1);
        }
    }
}

