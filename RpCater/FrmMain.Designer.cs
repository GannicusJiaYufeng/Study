namespace RpCater
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCategoryOrProduct = new System.Windows.Forms.Button();
            this.btnRoom = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnGuestPay = new System.Windows.Forms.Button();
            this.btnAddConsumption = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.md = new MsgDiv();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::RpCater.Properties.Resources.btnbgimage;
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCategoryOrProduct);
            this.splitContainer1.Panel1.Controls.Add(this.btnRoom);
            this.splitContainer1.Panel1.Controls.Add(this.btnMember);
            this.splitContainer1.Panel1.Controls.Add(this.btnGuestPay);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddConsumption);
            this.splitContainer1.Panel1.Controls.Add(this.btnBilling);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(946, 587);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(12, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 78);
            this.button1.TabIndex = 19;
            this.button1.Text = "顾客开单";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCategoryOrProduct
            // 
            this.btnCategoryOrProduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCategoryOrProduct.BackgroundImage")));
            this.btnCategoryOrProduct.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCategoryOrProduct.Location = new System.Drawing.Point(12, 463);
            this.btnCategoryOrProduct.Name = "btnCategoryOrProduct";
            this.btnCategoryOrProduct.Size = new System.Drawing.Size(118, 78);
            this.btnCategoryOrProduct.TabIndex = 18;
            this.btnCategoryOrProduct.Text = "商品管理";
            this.btnCategoryOrProduct.UseVisualStyleBackColor = true;
            this.btnCategoryOrProduct.Click += new System.EventHandler(this.btnCategoryOrProduct_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRoom.BackgroundImage")));
            this.btnRoom.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRoom.Location = new System.Drawing.Point(12, 379);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(118, 78);
            this.btnRoom.TabIndex = 17;
            this.btnRoom.Text = "房间设置";
            this.btnRoom.UseVisualStyleBackColor = true;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnMember
            // 
            this.btnMember.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMember.BackgroundImage")));
            this.btnMember.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMember.Location = new System.Drawing.Point(12, 295);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(118, 78);
            this.btnMember.TabIndex = 16;
            this.btnMember.Text = "会员管理";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnGuestPay
            // 
            this.btnGuestPay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuestPay.BackgroundImage")));
            this.btnGuestPay.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGuestPay.Location = new System.Drawing.Point(12, 211);
            this.btnGuestPay.Name = "btnGuestPay";
            this.btnGuestPay.Size = new System.Drawing.Size(118, 78);
            this.btnGuestPay.TabIndex = 15;
            this.btnGuestPay.Text = "上帝结账";
            this.btnGuestPay.UseVisualStyleBackColor = true;
            this.btnGuestPay.Click += new System.EventHandler(this.btnGuestPay_Click);
            // 
            // btnAddConsumption
            // 
            this.btnAddConsumption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddConsumption.BackgroundImage")));
            this.btnAddConsumption.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddConsumption.Location = new System.Drawing.Point(12, 127);
            this.btnAddConsumption.Name = "btnAddConsumption";
            this.btnAddConsumption.Size = new System.Drawing.Size(118, 78);
            this.btnAddConsumption.TabIndex = 14;
            this.btnAddConsumption.Text = "增加消费";
            this.btnAddConsumption.UseVisualStyleBackColor = true;
            this.btnAddConsumption.Click += new System.EventHandler(this.btnAddConsumption_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBilling.BackgroundImage")));
            this.btnBilling.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBilling.Location = new System.Drawing.Point(1, -98);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(118, 78);
            this.btnBilling.TabIndex = 13;
            this.btnBilling.Text = "顾客开单";
            this.btnBilling.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImage = global::RpCater.Properties.Resources.QQ截图20150413212219;
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel1.Controls.Add(this.md);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabMain);
            this.splitContainer2.Size = new System.Drawing.Size(809, 587);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.TabIndex = 0;
            // 
            // md
            // 
            this.md.AutoSize = true;
            this.md.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.md.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.md.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.md.ForeColor = System.Drawing.Color.Red;
            this.md.Location = new System.Drawing.Point(177, 74);
            this.md.MaximumSize = new System.Drawing.Size(980, 525);
            this.md.Name = "md";
            this.md.Padding = new System.Windows.Forms.Padding(7);
            this.md.Size = new System.Drawing.Size(102, 36);
            this.md.TabIndex = 1;
            this.md.Text = "msgDiv1";
            this.md.Visible = false;
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(809, 381);
            this.tabMain.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "空闲.png");
            this.imageList1.Images.SetKeyName(1, "就餐.png");
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 587);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "餐饮管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCategoryOrProduct;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnGuestPay;
        private System.Windows.Forms.Button btnAddConsumption;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.ImageList imageList1;
        private MsgDiv md;
    }
}