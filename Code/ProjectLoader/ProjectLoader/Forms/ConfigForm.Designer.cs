namespace ProjectLoader.Forms
{
    partial class ConfigForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFileDir = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.fbdDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库IP：";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(101, 17);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(284, 21);
            this.tbIP.TabIndex = 1;
            this.tbIP.Text = "192.168.8.151";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(391, 125);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(35, 21);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据库帐号：";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(101, 44);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(284, 21);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "root";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据库密码：";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(101, 71);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '#';
            this.tbPwd.Size = new System.Drawing.Size(284, 21);
            this.tbPwd.TabIndex = 1;
            this.tbPwd.Text = "123456";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "数据库名称：";
            // 
            // tbDBName
            // 
            this.tbDBName.Location = new System.Drawing.Point(101, 98);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(284, 21);
            this.tbDBName.TabIndex = 1;
            this.tbDBName.Text = "shenbaoDB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "附件文件路径：";
            // 
            // tbFileDir
            // 
            this.tbFileDir.Location = new System.Drawing.Point(101, 125);
            this.tbFileDir.Name = "tbFileDir";
            this.tbFileDir.Size = new System.Drawing.Size(284, 21);
            this.tbFileDir.TabIndex = 1;
            this.tbFileDir.Text = "c:\\\\FuJianMuLu";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(101, 159);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(61, 32);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "保存";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(217, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(324, 159);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(61, 32);
            this.btnTestConnection.TabIndex = 2;
            this.btnTestConnection.Text = "测试连接";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 202);
            this.Controls.Add(this.tbFileDir);
            this.Controls.Add(this.tbDBName);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFileDir;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog fbdDialog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTestConnection;
    }
}