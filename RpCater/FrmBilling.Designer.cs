namespace RpCater
{
    partial class FrmBilling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBilling));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labId = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.md = new MsgDiv();
            this.txtPersonCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labDeskName = new System.Windows.Forms.Label();
            this.labRoomName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbMeal = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.wads = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labLittleMoney = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.labId);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.md);
            this.groupBox1.Controls.Add(this.txtPersonCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labDeskName);
            this.groupBox1.Controls.Add(this.labRoomName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckbMeal);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.wads);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labLittleMoney);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 300);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "顾客开单";
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Location = new System.Drawing.Point(247, 102);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(0, 12);
            this.labId.TabIndex = 14;
            this.labId.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(163, 209);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "开单";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // md
            // 
            this.md.AutoSize = true;
            this.md.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.md.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.md.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.md.ForeColor = System.Drawing.Color.Red;
            this.md.Location = new System.Drawing.Point(222, 49);
            this.md.MaximumSize = new System.Drawing.Size(980, 525);
            this.md.Name = "md";
            this.md.Padding = new System.Windows.Forms.Padding(7);
            this.md.Size = new System.Drawing.Size(86, 31);
            this.md.TabIndex = 1;
            this.md.Text = "msgDiv1";
            this.md.Visible = false;
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.Location = new System.Drawing.Point(106, 136);
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.Size = new System.Drawing.Size(100, 21);
            this.txtPersonCount.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "顾客人数";
            // 
            // labDeskName
            // 
            this.labDeskName.AutoSize = true;
            this.labDeskName.Location = new System.Drawing.Point(104, 32);
            this.labDeskName.Name = "labDeskName";
            this.labDeskName.Size = new System.Drawing.Size(29, 12);
            this.labDeskName.TabIndex = 10;
            this.labDeskName.Text = "编号";
            // 
            // labRoomName
            // 
            this.labRoomName.AutoSize = true;
            this.labRoomName.Location = new System.Drawing.Point(104, 68);
            this.labRoomName.Name = "labRoomName";
            this.labRoomName.Size = new System.Drawing.Size(29, 12);
            this.labRoomName.TabIndex = 9;
            this.labRoomName.Text = "名字";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "房间类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "餐桌编号";
            // 
            // ckbMeal
            // 
            this.ckbMeal.AutoSize = true;
            this.ckbMeal.Location = new System.Drawing.Point(247, 141);
            this.ckbMeal.Name = "ckbMeal";
            this.ckbMeal.Size = new System.Drawing.Size(108, 16);
            this.ckbMeal.TabIndex = 6;
            this.ckbMeal.Text = "开单后添加消费";
            this.ckbMeal.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(106, 175);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(272, 23);
            this.txtDescription.TabIndex = 4;
            // 
            // wads
            // 
            this.wads.AutoSize = true;
            this.wads.Location = new System.Drawing.Point(36, 102);
            this.wads.Name = "wads";
            this.wads.Size = new System.Drawing.Size(53, 12);
            this.wads.TabIndex = 3;
            this.wads.Text = "最低消费";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "开单备注";
            // 
            // labLittleMoney
            // 
            this.labLittleMoney.AutoSize = true;
            this.labLittleMoney.Location = new System.Drawing.Point(104, 102);
            this.labLittleMoney.Name = "labLittleMoney";
            this.labLittleMoney.Size = new System.Drawing.Size(53, 12);
            this.labLittleMoney.TabIndex = 3;
            this.labLittleMoney.Text = "消费金额";
            // 
            // FrmBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 300);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmBilling";
            this.Text = "顾客开单";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.Button btnOk;
        private MsgDiv md;
        private System.Windows.Forms.TextBox txtPersonCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labDeskName;
        private System.Windows.Forms.Label labRoomName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbMeal;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label wads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labLittleMoney;

    }
}