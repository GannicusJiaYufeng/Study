namespace RpCater
{
    partial class FrmGuestPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGuestPay));
            this.labMoney = new System.Windows.Forms.Label();
            this.labOrderId = new System.Windows.Forms.Label();
            this.labDeskName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.md = new MsgDiv();
            this.labdkId = new System.Windows.Forms.Label();
            this.lblDisCount = new System.Windows.Forms.Label();
            this.labyuMoney = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvROrderProduct = new System.Windows.Forms.DataGridView();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grouBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.lblSpareMoney = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvROrderProduct)).BeginInit();
            this.grouBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labMoney
            // 
            this.labMoney.AutoSize = true;
            this.labMoney.Location = new System.Drawing.Point(519, 22);
            this.labMoney.Name = "labMoney";
            this.labMoney.Size = new System.Drawing.Size(11, 12);
            this.labMoney.TabIndex = 5;
            this.labMoney.Text = "0";
            // 
            // labOrderId
            // 
            this.labOrderId.AutoSize = true;
            this.labOrderId.Location = new System.Drawing.Point(99, 20);
            this.labOrderId.Name = "labOrderId";
            this.labOrderId.Size = new System.Drawing.Size(0, 12);
            this.labOrderId.TabIndex = 4;
            // 
            // labDeskName
            // 
            this.labDeskName.AutoSize = true;
            this.labDeskName.Location = new System.Drawing.Point(330, 20);
            this.labDeskName.Name = "labDeskName";
            this.labDeskName.Size = new System.Drawing.Size(0, 12);
            this.labDeskName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "消费金额";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "结账单号:";
            // 
            // md
            // 
            this.md.AutoSize = true;
            this.md.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.md.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.md.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.md.ForeColor = System.Drawing.Color.Red;
            this.md.Location = new System.Drawing.Point(586, 22);
            this.md.MaximumSize = new System.Drawing.Size(980, 525);
            this.md.Name = "md";
            this.md.Padding = new System.Windows.Forms.Padding(7);
            this.md.Size = new System.Drawing.Size(86, 31);
            this.md.TabIndex = 1;
            this.md.Text = "msgDiv1";
            this.md.Visible = false;
            // 
            // labdkId
            // 
            this.labdkId.AutoSize = true;
            this.labdkId.Location = new System.Drawing.Point(660, 41);
            this.labdkId.Name = "labdkId";
            this.labdkId.Size = new System.Drawing.Size(0, 12);
            this.labdkId.TabIndex = 28;
            this.labdkId.Visible = false;
            // 
            // lblDisCount
            // 
            this.lblDisCount.AutoSize = true;
            this.lblDisCount.Location = new System.Drawing.Point(474, 25);
            this.lblDisCount.Name = "lblDisCount";
            this.lblDisCount.Size = new System.Drawing.Size(11, 12);
            this.lblDisCount.TabIndex = 27;
            this.lblDisCount.Text = "0";
            // 
            // labyuMoney
            // 
            this.labyuMoney.AutoSize = true;
            this.labyuMoney.Location = new System.Drawing.Point(353, 23);
            this.labyuMoney.Name = "labyuMoney";
            this.labyuMoney.Size = new System.Drawing.Size(11, 12);
            this.labyuMoney.TabIndex = 26;
            this.labyuMoney.Text = "0";
            // 
            // cmbMember
            // 
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.FormattingEnabled = true;
            this.cmbMember.Location = new System.Drawing.Point(116, 18);
            this.cmbMember.Name = "cmbMember";
            this.cmbMember.Size = new System.Drawing.Size(121, 20);
            this.cmbMember.TabIndex = 24;
            this.cmbMember.SelectedIndexChanged += new System.EventHandler(this.cmbMember_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "折扣";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "卡内余额";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "会员姓名";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(384, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "找零：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "结账餐台";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Controls.Add(this.dgvROrderProduct);
            this.groupBox3.Location = new System.Drawing.Point(4, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(717, 279);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            // 
            // dgvROrderProduct
            // 
            this.dgvROrderProduct.AllowUserToAddRows = false;
            this.dgvROrderProduct.AllowUserToDeleteRows = false;
            this.dgvROrderProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvROrderProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column14,
            this.dataGridViewTextBoxColumn1,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgvROrderProduct.Location = new System.Drawing.Point(6, 20);
            this.dgvROrderProduct.Name = "dgvROrderProduct";
            this.dgvROrderProduct.ReadOnly = true;
            this.dgvROrderProduct.RowHeadersVisible = false;
            this.dgvROrderProduct.RowTemplate.Height = 23;
            this.dgvROrderProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvROrderProduct.Size = new System.Drawing.Size(705, 229);
            this.dgvROrderProduct.TabIndex = 26;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "ROrderProId";
            this.Column14.HeaderText = "中间表id";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProName";
            this.dataGridViewTextBoxColumn1.HeaderText = "项目名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ProPrice";
            this.Column8.HeaderText = "单价";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "UnitCount";
            this.Column9.HeaderText = "数量";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "ProUnit";
            this.Column10.HeaderText = "单位";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "ProMoney";
            this.Column11.HeaderText = "金额";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "CName";
            this.Column12.HeaderText = "项目类别";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "SubTime";
            this.Column13.HeaderText = "点菜时间";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // grouBox4
            // 
            this.grouBox4.BackColor = System.Drawing.SystemColors.Highlight;
            this.grouBox4.Controls.Add(this.label6);
            this.grouBox4.Controls.Add(this.label4);
            this.grouBox4.Controls.Add(this.label5);
            this.grouBox4.Controls.Add(this.lblMoney);
            this.grouBox4.Controls.Add(this.lblSpareMoney);
            this.grouBox4.Controls.Add(this.txtMoney);
            this.grouBox4.Controls.Add(this.btnAccounts);
            this.grouBox4.Location = new System.Drawing.Point(6, 152);
            this.grouBox4.Name = "grouBox4";
            this.grouBox4.Size = new System.Drawing.Size(715, 69);
            this.grouBox4.TabIndex = 37;
            this.grouBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "结账金额：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(167, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "刷卡付款：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoney.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMoney.Location = new System.Drawing.Point(111, 20);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(17, 16);
            this.lblMoney.TabIndex = 12;
            this.lblMoney.Text = "0";
            // 
            // lblSpareMoney
            // 
            this.lblSpareMoney.AutoSize = true;
            this.lblSpareMoney.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpareMoney.ForeColor = System.Drawing.Color.Red;
            this.lblSpareMoney.Location = new System.Drawing.Point(451, 24);
            this.lblSpareMoney.Name = "lblSpareMoney";
            this.lblSpareMoney.Size = new System.Drawing.Size(17, 16);
            this.lblSpareMoney.TabIndex = 11;
            this.lblSpareMoney.Text = "0";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(266, 19);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(100, 21);
            this.txtMoney.TabIndex = 18;
            // 
            // btnAccounts
            // 
            this.btnAccounts.Location = new System.Drawing.Point(556, 22);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(75, 23);
            this.btnAccounts.TabIndex = 17;
            this.btnAccounts.Text = "结账";
            this.btnAccounts.UseVisualStyleBackColor = true;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Controls.Add(this.labMoney);
            this.groupBox1.Controls.Add(this.labOrderId);
            this.groupBox1.Controls.Add(this.labDeskName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 88);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Controls.Add(this.md);
            this.groupBox2.Controls.Add(this.labdkId);
            this.groupBox2.Controls.Add(this.lblDisCount);
            this.groupBox2.Controls.Add(this.labyuMoney);
            this.groupBox2.Controls.Add(this.cmbMember);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(4, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(717, 79);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            // 
            // FrmGuestPay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(724, 491);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grouBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGuestPay";
            this.Text = "上帝结账";
            this.Load += new System.EventHandler(this.FrmGuestPay_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvROrderProduct)).EndInit();
            this.grouBox4.ResumeLayout(false);
            this.grouBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labMoney;
        private System.Windows.Forms.Label labOrderId;
        private System.Windows.Forms.Label labDeskName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private MsgDiv md;
        private System.Windows.Forms.Label labdkId;
        private System.Windows.Forms.Label lblDisCount;
        private System.Windows.Forms.Label labyuMoney;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvROrderProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.GroupBox grouBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label lblSpareMoney;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}