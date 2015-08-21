namespace RpCater
{
    partial class FrmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.bthlogin = new System.Windows.Forms.Button();
            this.btnesc = new System.Windows.Forms.Button();
            this.md = new MsgDiv();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtname.Location = new System.Drawing.Point(195, 123);
            this.txtname.Multiline = true;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(86, 25);
            this.txtname.TabIndex = 0;
            this.txtname.Text = "admin";
            // 
            // txtpwd
            // 
            this.txtpwd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpwd.Location = new System.Drawing.Point(195, 154);
            this.txtpwd.Multiline = true;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(86, 27);
            this.txtpwd.TabIndex = 1;
            this.txtpwd.Text = "admin";
            // 
            // bthlogin
            // 
            this.bthlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.bthlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bthlogin.Location = new System.Drawing.Point(176, 206);
            this.bthlogin.Name = "bthlogin";
            this.bthlogin.Size = new System.Drawing.Size(63, 23);
            this.bthlogin.TabIndex = 2;
            this.bthlogin.Text = "登录";
            this.bthlogin.UseVisualStyleBackColor = false;
            this.bthlogin.Click += new System.EventHandler(this.bthlogin_Click);
            // 
            // btnesc
            // 
            this.btnesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.btnesc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnesc.Location = new System.Drawing.Point(241, 206);
            this.btnesc.Name = "btnesc";
            this.btnesc.Size = new System.Drawing.Size(60, 23);
            this.btnesc.TabIndex = 3;
            this.btnesc.Text = "取消";
            this.btnesc.UseVisualStyleBackColor = false;
            this.btnesc.Click += new System.EventHandler(this.btnesc_Click);
            // 
            // md
            // 
            this.md.AutoSize = true;
            this.md.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.md.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.md.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.md.ForeColor = System.Drawing.Color.Red;
            this.md.Location = new System.Drawing.Point(367, 237);
            this.md.MaximumSize = new System.Drawing.Size(980, 525);
            this.md.Name = "md";
            this.md.Padding = new System.Windows.Forms.Padding(7);
            this.md.Size = new System.Drawing.Size(86, 31);
            this.md.TabIndex = 1;
            this.md.Text = "msgDiv1";
            this.md.Visible = false;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.bthlogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RpCater.Properties.Resources.RuPengLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnesc;
            this.ClientSize = new System.Drawing.Size(464, 343);
            this.Controls.Add(this.md);
            this.Controls.Add(this.btnesc);
            this.Controls.Add(this.bthlogin);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Text = "餐饮系统登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Button bthlogin;
        private System.Windows.Forms.Button btnesc;
        private MsgDiv md;
    }
}

