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
    public partial class FrmAddConsumption : Form
    {
        private FrmAddConsumption(string deskName, int orderId)
        {
            InitializeComponent();
            //显示餐桌的编号
            labDeskName.Text = deskName;//
            //存储订单的id
            labOrderId.Text = orderId.ToString();
        }
        private static FrmAddConsumption _instance;
        //传餐桌的编号--传订单的id--查点的菜--数量--金额
        public static FrmAddConsumption Single(string deskName, int orderId)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAddConsumption(deskName, orderId);
            }
            return _instance;
        }

        private void FrmAddConsumption_Load(object sender, EventArgs e)
        {
            //显示所有产品
            LoadProductInfoByDelFlag(0);
            //绑定节点树
            LoadTvCategoryByDelFlag(0);
            //窗体一开始加载就应该显示点的菜
            LoadR_Order_ProductByOrdrtId(Convert.ToInt32(labOrderId.Text));
        }
        //节点树绑定数据
        private void LoadTvCategoryByDelFlag(int p)
        {
            CategoryInfoBll cbll = new CategoryInfoBll();
            List<CategoryInfo> list = cbll.GetAllCategoryInfoByDelFlag(p);
            for (int i = 0; i < list.Count; i++)
            {
                TreeNode tn = tvCategory.Nodes.Add(list[i].CName);
                //根据商品类别id查找该类别下的所有产品
                LoadProductInfoByCId(tn.Nodes, list[i].CId);
            }
        }
        //根据商品类别id查找该类别下的所有产品
        private void LoadProductInfoByCId(TreeNodeCollection tnc, int p)
        {
            ProductInfoBll proBll = new ProductInfoBll();

            List<ProductInfo> listProduct = proBll.GetProductInfoByCId(p);
            for (int i = 0; i < listProduct.Count; i++)
            {
                tnc.Add(listProduct[i].ProName + "==" + listProduct[i].ProPrice + "元");
            }
        }


        //显示所有产品
        private void LoadProductInfoByDelFlag(int p)
        {
            ProductInfoBll proBll = new ProductInfoBll();
            dgvProduct.AutoGenerateColumns = false;//禁止自动生成列
            dgvProduct.DataSource = proBll.GetAllProductInfoByDelFlag(p);
            dgvProduct.ClearSelection();//清除默认第一行选中
        }

        //用户双击该控件发生
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //判断是都选中了菜
            if (dgvProduct.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请先选中要添加的菜", 1);
                return;
            }
            int tCount;
            if (string.IsNullOrEmpty(txtCount.Text) || txtCount.Text == "1" || txtCount.Text == "0")
            {
                //txtCount.Text = "1";
                tCount = 1;
            }
            //判断文本框中输入的数量
            else if (!int.TryParse(txtCount.Text, out tCount))//转换不成功  说明txtCount没有值
            {

                md.MsgDivShow("请输入正确个数", 1);
                return;
            }
            //文本框的数量转换成功了
            //获取选中菜的Id====添加到中间表（订单和菜的中间表）
            //int proId=((ProductInfo)dgvProduct.SelectedRows[0].DataBoundItem).ProId;//菜的Id
            R_Order_Product rop = new R_Order_Product();//中间表对象
            rop.DelFlag = 0;
            rop.OrderId = Convert.ToInt32(labOrderId.Text);//订单的id
            // rop.ProId=proId;//菜的Id
            rop.ProId = ((ProductInfo)dgvProduct.SelectedRows[0].DataBoundItem).ProId;//菜的Id
            rop.SubTime = System.DateTime.Now;
            rop.UnitCount = tCount;
            R_Order_ProductBll ropBll = new R_Order_ProductBll();
            md.MsgDivShow(ropBll.AddR_Order_Product(rop) ? "操作成功" : "操作失败", 1);
            //刷新
            //显示点的菜
            //=============坑
            LoadR_Order_ProductByOrdrtId(Convert.ToInt32(labOrderId.Text));


        }
        //显示点的菜
        private void LoadR_Order_ProductByOrdrtId(int p)
        {
            R_Order_ProductBll ropBll = new R_Order_ProductBll();
            dgvROrderProduct.AutoGenerateColumns = false;
            dgvROrderProduct.DataSource = ropBll.GetR_Order_ProductByOrderId(p);
            dgvROrderProduct.ClearSelection();//清除默认选中项
            //显示总金额和总数量
            R_Order_Product rop = ropBll.GetCountAndSumMoney(Convert.ToInt32(labOrderId.Text));
            //总金额
            labSumMoney.Text = rop.Money.ToString();
            labCount.Text = rop.Count.ToString();
            //总数量
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //int temp = 0;
            //if (string.IsNullOrEmpty(txtSearch.Text))//空
            //{

            //}
            //else
            //{ 
            ////搜索
            //if (char.IsLetter(txtSearch.Text[0]))//字母
            //{
            //    temp = 1;
            //}
            //else
            //{
            //    temp = 2;
            //}
            //}
            int temp = string.IsNullOrEmpty(txtSearch.Text) ? 0 : char.IsLetter(txtSearch.Text[0]) ? 1 : 2;

            ProductInfoBll proBll = new ProductInfoBll();
            dgvProduct.AutoGenerateColumns = false;//禁止自动生成列
            dgvProduct.DataSource = proBll.GetProductByProSpellOrProNum(temp, txtSearch.Text);
            dgvProduct.ClearSelection();
        }
        //退菜操作
        private void btnDeleteRorderPro_Click(object sender, EventArgs e)
        {
            if (dgvROrderProduct.SelectedRows.Count <= 0)
            {
                md.MsgDivShow("请先选中要退的菜");
                return;
            }
            else
            {
                int rOrderProId = ((R_Order_Product)dgvROrderProduct.SelectedRows[0].DataBoundItem).ROrderProId;
                R_Order_ProductBll ropBll = new R_Order_ProductBll();
                md.MsgDivShow(ropBll.SoftDeleteR_Order_ProductByROrderProId(rOrderProId) ? "成功" : "失败", 1);
                LoadR_Order_ProductByOrdrtId(Convert.ToInt32(labOrderId.Text));  //刷新

            }
        }
        //窗体关闭的时候更新消费总金额到订单表
        private void FrmAddConsumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(labSumMoney.Text))
            {
                OrderInfoBll oBll = new OrderInfoBll();
                OrderInfo order = new OrderInfo();
                order.BeginTime = System.DateTime.Now;
                order.OrderMoney = Convert.ToDouble(labSumMoney.Text);//消费金额
                order.OrderId = Convert.ToInt32(labOrderId.Text);//订单Id
                bool result = oBll.UpdateMoneyAndTime(order);
                //上面就没有必要显示什么消息了。
            }
        }
    }
}
