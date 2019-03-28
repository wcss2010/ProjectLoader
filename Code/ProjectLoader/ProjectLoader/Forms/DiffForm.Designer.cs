namespace ProjectLoader.Forms
{
    partial class DiffForm
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
            this.dgvDiff = new System.Windows.Forms.DataGridView();
            this.plButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.colStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOldContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiff)).BeginInit();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDiff
            // 
            this.dgvDiff.AllowUserToAddRows = false;
            this.dgvDiff.AllowUserToDeleteRows = false;
            this.dgvDiff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colProjectName,
            this.colTypeB,
            this.colOldContent,
            this.colNewContent});
            this.dgvDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiff.Location = new System.Drawing.Point(0, 0);
            this.dgvDiff.MultiSelect = false;
            this.dgvDiff.Name = "dgvDiff";
            this.dgvDiff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiff.Size = new System.Drawing.Size(898, 456);
            this.dgvDiff.TabIndex = 0;
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnCancel);
            this.plButtons.Controls.Add(this.btnOK);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(0, 456);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(898, 56);
            this.plButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(623, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(201, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStatus.HeaderText = "是否需要更新";
            this.colStatus.Name = "colStatus";
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStatus.Width = 72;
            // 
            // colProjectName
            // 
            this.colProjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProjectName.HeaderText = "工程名称";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.ReadOnly = true;
            this.colProjectName.Width = 61;
            // 
            // colTypeB
            // 
            this.colTypeB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTypeB.HeaderText = "类别";
            this.colTypeB.Name = "colTypeB";
            this.colTypeB.ReadOnly = true;
            this.colTypeB.Width = 51;
            // 
            // colOldContent
            // 
            this.colOldContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colOldContent.HeaderText = "原始的内容";
            this.colOldContent.Name = "colOldContent";
            this.colOldContent.ReadOnly = true;
            this.colOldContent.Width = 72;
            // 
            // colNewContent
            // 
            this.colNewContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNewContent.HeaderText = "要更新的内容";
            this.colNewContent.Name = "colNewContent";
            this.colNewContent.ReadOnly = true;
            this.colNewContent.Width = 72;
            // 
            // DiffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 512);
            this.Controls.Add(this.dgvDiff);
            this.Controls.Add(this.plButtons);
            this.Name = "DiffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "是否确认覆盖？";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiff)).EndInit();
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDiff;
        private System.Windows.Forms.Panel plButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewContent;
    }
}