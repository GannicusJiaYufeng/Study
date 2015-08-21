namespace RpCater
{
    partial class FrmRoomAddOrModify
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
            this.md = new MsgDiv();
            this.btnEsc = new System.Windows.Forms.Button();
            this.labId = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtIsDefault = new System.Windows.Forms.TextBox();
            this.txtRPerNum = new System.Windows.Forms.TextBox();
            this.txtRMinMoney = new System.Windows.Forms.TextBox();
            this.txtRType = new System.Windows.Forms.TextBox();
            this.txtRName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // md
            // 
            this.md.AutoSize = true;
            this.md.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.md.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.md.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.md.ForeColor = System.Drawing.Color.Red;
            this.md.Location = new System.Drawing.Point(74, 276);
            this.md.MaximumSize = new System.Drawing.Size(980, 525);
            this.md.Name = "md";
            this.md.Padding = new System.Windows.Forms.Padding(7);
            this.md.Size = new System.Drawing.Size(86, 31);
            this.md.TabIndex = 79;
            this.md.Text = "msgDiv1";
            this.md.Visible = false;
            // 
            // btnEsc
            // 
            this.btnEsc.Location = new System.Drawing.Point(198, 250);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(75, 23);
            this.btnEsc.TabIndex = 92;
            this.btnEsc.Text = "取消";
            this.btnEsc.UseVisualStyleBackColor = true;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Location = new System.Drawing.Point(95, 255);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(0, 12);
            this.labId.TabIndex = 91;
            this.labId.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(101, 250);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 90;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtIsDefault
            // 
            this.txtIsDefault.Location = new System.Drawing.Point(173, 208);
            this.txtIsDefault.Name = "txtIsDefault";
            this.txtIsDefault.Size = new System.Drawing.Size(100, 21);
            this.txtIsDefault.TabIndex = 87;
            // 
            // txtRPerNum
            // 
            this.txtRPerNum.Location = new System.Drawing.Point(173, 165);
            this.txtRPerNum.Name = "txtRPerNum";
            this.txtRPerNum.Size = new System.Drawing.Size(100, 21);
            this.txtRPerNum.TabIndex = 86;
            // 
            // txtRMinMoney
            // 
            this.txtRMinMoney.Location = new System.Drawing.Point(173, 121);
            this.txtRMinMoney.Name = "txtRMinMoney";
            this.txtRMinMoney.Size = new System.Drawing.Size(100, 21);
            this.txtRMinMoney.TabIndex = 89;
            // 
            // txtRType
            // 
            this.txtRType.Location = new System.Drawing.Point(173, 83);
            this.txtRType.Name = "txtRType";
            this.txtRType.Size = new System.Drawing.Size(100, 21);
            this.txtRType.TabIndex = 88;
            // 
            // txtRName
            // 
            this.txtRName.Location = new System.Drawing.Point(173, 39);
            this.txtRName.Name = "txtRName";
            this.txtRName.Size = new System.Drawing.Size(100, 21);
            this.txtRName.TabIndex = 85;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 81;
            this.label5.Text = "默认编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 80;
            this.label4.Text = "房间人数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "最低消费";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 84;
            this.label2.Text = "房间类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 83;
            this.label1.Text = "房间名字";
            // 
            // FrmRoomAddOrModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(349, 339);
            this.Controls.Add(this.md);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.labId);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtIsDefault);
            this.Controls.Add(this.txtRPerNum);
            this.Controls.Add(this.txtRMinMoney);
            this.Controls.Add(this.txtRType);
            this.Controls.Add(this.txtRName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRoomAddOrModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MsgDiv md;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtIsDefault;
        private System.Windows.Forms.TextBox txtRPerNum;
        private System.Windows.Forms.TextBox txtRMinMoney;
        private System.Windows.Forms.TextBox txtRType;
        private System.Windows.Forms.TextBox txtRName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}