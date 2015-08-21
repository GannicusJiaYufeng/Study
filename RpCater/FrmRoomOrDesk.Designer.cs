namespace RpCater
{
    partial class FrmRoomOrDesk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoomOrDesk));
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnADesk = new System.Windows.Forms.Button();
            this.dgvDesk = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.md1 = new MsgDiv();
            this.btnDDesk = new System.Windows.Forms.Button();
            this.btnUDesk = new System.Windows.Forms.Button();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.md = new MsgDiv();
            this.btnDRoom = new System.Windows.Forms.Button();
            this.btnURoom = new System.Windows.Forms.Button();
            this.btnARoom = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.tabCRoom = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesk)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.tabCRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "SubTime";
            this.Column13.HeaderText = "提交时间";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "DeskRegion";
            this.Column11.HeaderText = "描述";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "DeskRemark";
            this.Column10.HeaderText = "备注";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DeskName";
            this.Column9.HeaderText = "餐桌编号";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DeskId";
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // btnADesk
            // 
            this.btnADesk.Location = new System.Drawing.Point(515, 25);
            this.btnADesk.Name = "btnADesk";
            this.btnADesk.Size = new System.Drawing.Size(75, 36);
            this.btnADesk.TabIndex = 1;
            this.btnADesk.Text = "添加餐桌";
            this.btnADesk.UseVisualStyleBackColor = true;
            this.btnADesk.Click += new System.EventHandler(this.btnADesk_Click);
            // 
            // dgvDesk
            // 
            this.dgvDesk.AllowUserToAddRows = false;
            this.dgvDesk.AllowUserToDeleteRows = false;
            this.dgvDesk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDesk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgvDesk.Location = new System.Drawing.Point(0, 6);
            this.dgvDesk.Name = "dgvDesk";
            this.dgvDesk.ReadOnly = true;
            this.dgvDesk.RowHeadersVisible = false;
            this.dgvDesk.RowTemplate.Height = 23;
            this.dgvDesk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDesk.Size = new System.Drawing.Size(500, 316);
            this.dgvDesk.TabIndex = 0;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "DeskStateString";
            this.Column12.HeaderText = "状态";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SeaGreen;
            this.tabPage2.Controls.Add(this.md1);
            this.tabPage2.Controls.Add(this.btnDDesk);
            this.tabPage2.Controls.Add(this.btnUDesk);
            this.tabPage2.Controls.Add(this.btnADesk);
            this.tabPage2.Controls.Add(this.dgvDesk);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(609, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "餐桌信息";
            // 
            // md1
            // 
            this.md1.AutoSize = true;
            this.md1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.md1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.md1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.md1.ForeColor = System.Drawing.Color.Red;
            this.md1.Location = new System.Drawing.Point(514, 296);
            this.md1.MaximumSize = new System.Drawing.Size(980, 525);
            this.md1.Name = "md1";
            this.md1.Padding = new System.Windows.Forms.Padding(7);
            this.md1.Size = new System.Drawing.Size(86, 31);
            this.md1.TabIndex = 1;
            this.md1.Text = "msgDiv1";
            this.md1.Visible = false;
            // 
            // btnDDesk
            // 
            this.btnDDesk.Location = new System.Drawing.Point(515, 152);
            this.btnDDesk.Name = "btnDDesk";
            this.btnDDesk.Size = new System.Drawing.Size(75, 36);
            this.btnDDesk.TabIndex = 1;
            this.btnDDesk.Text = "注销餐桌";
            this.btnDDesk.UseVisualStyleBackColor = true;
            this.btnDDesk.Click += new System.EventHandler(this.btnDDesk_Click);
            // 
            // btnUDesk
            // 
            this.btnUDesk.Location = new System.Drawing.Point(515, 85);
            this.btnUDesk.Name = "btnUDesk";
            this.btnUDesk.Size = new System.Drawing.Size(75, 36);
            this.btnUDesk.TabIndex = 1;
            this.btnUDesk.Text = "修改餐桌";
            this.btnUDesk.UseVisualStyleBackColor = true;
            this.btnUDesk.Click += new System.EventHandler(this.btnUDesk_Click);
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "SubTime";
            this.Column7.HeaderText = "提交时间";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "IsDefault";
            this.Column6.HeaderText = "默认编号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "RoomMaxNum";
            this.Column5.HeaderText = "最多人数";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RoomMinMoney";
            this.Column4.HeaderText = "最低消费";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RoomType";
            this.Column3.HeaderText = "房间的类型";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RoomName";
            this.Column2.HeaderText = "房间的名字";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RoomId";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 30;
            // 
            // md
            // 
            this.md.AutoSize = true;
            this.md.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.md.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.md.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.md.ForeColor = System.Drawing.Color.Red;
            this.md.Location = new System.Drawing.Point(369, 10);
            this.md.MaximumSize = new System.Drawing.Size(980, 525);
            this.md.Name = "md";
            this.md.Padding = new System.Windows.Forms.Padding(7);
            this.md.Size = new System.Drawing.Size(86, 31);
            this.md.TabIndex = 1;
            this.md.Text = "msgDiv1";
            this.md.Visible = false;
            // 
            // btnDRoom
            // 
            this.btnDRoom.Location = new System.Drawing.Point(171, 7);
            this.btnDRoom.Name = "btnDRoom";
            this.btnDRoom.Size = new System.Drawing.Size(75, 34);
            this.btnDRoom.TabIndex = 1;
            this.btnDRoom.Text = "注销房间";
            this.btnDRoom.UseVisualStyleBackColor = true;
            this.btnDRoom.Click += new System.EventHandler(this.btnDRoom_Click);
            // 
            // btnURoom
            // 
            this.btnURoom.Location = new System.Drawing.Point(90, 7);
            this.btnURoom.Name = "btnURoom";
            this.btnURoom.Size = new System.Drawing.Size(75, 34);
            this.btnURoom.TabIndex = 1;
            this.btnURoom.Text = "修改房间";
            this.btnURoom.UseVisualStyleBackColor = true;
            this.btnURoom.Click += new System.EventHandler(this.btnURoom_Click);
            // 
            // btnARoom
            // 
            this.btnARoom.Location = new System.Drawing.Point(9, 7);
            this.btnARoom.Name = "btnARoom";
            this.btnARoom.Size = new System.Drawing.Size(75, 34);
            this.btnARoom.TabIndex = 1;
            this.btnARoom.Text = "添加房间";
            this.btnARoom.UseVisualStyleBackColor = true;
            this.btnARoom.Click += new System.EventHandler(this.btnARoom_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SeaGreen;
            this.tabPage1.Controls.Add(this.md);
            this.tabPage1.Controls.Add(this.btnDRoom);
            this.tabPage1.Controls.Add(this.btnURoom);
            this.tabPage1.Controls.Add(this.btnARoom);
            this.tabPage1.Controls.Add(this.dgvRoom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(609, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "房间信息";
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvRoom.Location = new System.Drawing.Point(3, 47);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            this.dgvRoom.RowHeadersVisible = false;
            this.dgvRoom.RowTemplate.Height = 23;
            this.dgvRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoom.Size = new System.Drawing.Size(554, 270);
            this.dgvRoom.TabIndex = 0;
            // 
            // tabCRoom
            // 
            this.tabCRoom.Controls.Add(this.tabPage1);
            this.tabCRoom.Controls.Add(this.tabPage2);
            this.tabCRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCRoom.Location = new System.Drawing.Point(0, 0);
            this.tabCRoom.Multiline = true;
            this.tabCRoom.Name = "tabCRoom";
            this.tabCRoom.SelectedIndex = 0;
            this.tabCRoom.Size = new System.Drawing.Size(617, 356);
            this.tabCRoom.TabIndex = 2;
            // 
            // FrmRoomOrDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 356);
            this.Controls.Add(this.tabCRoom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRoomOrDesk";
            this.Text = "房间和餐桌的信息";
            this.Load += new System.EventHandler(this.FrmRoomOrDesk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesk)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.tabCRoom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnADesk;
        private System.Windows.Forms.DataGridView dgvDesk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.TabPage tabPage2;
        private MsgDiv md1;
        private System.Windows.Forms.Button btnDDesk;
        private System.Windows.Forms.Button btnUDesk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private MsgDiv md;
        private System.Windows.Forms.Button btnDRoom;
        private System.Windows.Forms.Button btnURoom;
        private System.Windows.Forms.Button btnARoom;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.TabControl tabCRoom;
    }
}