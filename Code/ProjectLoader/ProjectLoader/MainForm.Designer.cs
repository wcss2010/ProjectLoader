namespace ProjectLoader
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnLoadAll = new System.Windows.Forms.ToolStripButton();
            this.btnUploadAll = new System.Windows.Forms.ToolStripButton();
            this.btnStopUploadAll = new System.Windows.Forms.ToolStripButton();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.ofdZip = new System.Windows.Forms.OpenFileDialog();
            this.colProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLianXiRen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLianXiDianHua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuZeRen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuZeRenLianXiDianHua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYanJiuZhouQi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYanJiuJingFei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colButtons = new System.Windows.Forms.DataGridViewImageColumn();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusText});
            this.ssStatus.Location = new System.Drawing.Point(0, 500);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(1056, 22);
            this.ssStatus.TabIndex = 1;
            this.ssStatus.Text = "statusStrip1";
            // 
            // lblStatusText
            // 
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(41, 17);
            this.lblStatusText.Text = "......";
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProjectName,
            this.colUnit,
            this.colAddress,
            this.colLianXiRen,
            this.colLianXiDianHua,
            this.colFuZeRen,
            this.colFuZeRenLianXiDianHua,
            this.colYanJiuZhouQi,
            this.colYanJiuJingFei,
            this.colStatus,
            this.colButtons});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 91);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.Size = new System.Drawing.Size(1056, 409);
            this.dgvDetail.TabIndex = 2;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadAll,
            this.btnUploadAll,
            this.btnStopUploadAll,
            this.btnConfig});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1056, 91);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadAll.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadAll.Image")));
            this.btnLoadAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoadAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(68, 88);
            this.btnLoadAll.Text = "导入";
            this.btnLoadAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // btnUploadAll
            // 
            this.btnUploadAll.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUploadAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadAll.Image")));
            this.btnUploadAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUploadAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUploadAll.Name = "btnUploadAll";
            this.btnUploadAll.Size = new System.Drawing.Size(69, 88);
            this.btnUploadAll.Text = "开始上传";
            this.btnUploadAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUploadAll.Click += new System.EventHandler(this.btnUploadAll_Click);
            // 
            // btnStopUploadAll
            // 
            this.btnStopUploadAll.Enabled = false;
            this.btnStopUploadAll.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopUploadAll.Image = ((System.Drawing.Image)(resources.GetObject("btnStopUploadAll.Image")));
            this.btnStopUploadAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStopUploadAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopUploadAll.Name = "btnStopUploadAll";
            this.btnStopUploadAll.Size = new System.Drawing.Size(69, 88);
            this.btnStopUploadAll.Text = "停止上传";
            this.btnStopUploadAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStopUploadAll.Click += new System.EventHandler(this.btnStopUploadAll_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(69, 88);
            this.btnConfig.Text = "系统配置";
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // ofdZip
            // 
            this.ofdZip.Filter = "ZIP申报数据包|*.zip";
            this.ofdZip.Multiselect = true;
            // 
            // colProjectName
            // 
            this.colProjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProjectName.HeaderText = "项目名称";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.ReadOnly = true;
            // 
            // colUnit
            // 
            this.colUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUnit.HeaderText = "申报单位";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAddress.HeaderText = "通信地址";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colLianXiRen
            // 
            this.colLianXiRen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLianXiRen.HeaderText = "联系人";
            this.colLianXiRen.Name = "colLianXiRen";
            this.colLianXiRen.ReadOnly = true;
            this.colLianXiRen.Width = 66;
            // 
            // colLianXiDianHua
            // 
            this.colLianXiDianHua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLianXiDianHua.HeaderText = "联系电话";
            this.colLianXiDianHua.Name = "colLianXiDianHua";
            this.colLianXiDianHua.ReadOnly = true;
            this.colLianXiDianHua.Width = 78;
            // 
            // colFuZeRen
            // 
            this.colFuZeRen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFuZeRen.HeaderText = "负责人";
            this.colFuZeRen.Name = "colFuZeRen";
            this.colFuZeRen.ReadOnly = true;
            this.colFuZeRen.Width = 66;
            // 
            // colFuZeRenLianXiDianHua
            // 
            this.colFuZeRenLianXiDianHua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFuZeRenLianXiDianHua.HeaderText = "负责人联系电话";
            this.colFuZeRenLianXiDianHua.Name = "colFuZeRenLianXiDianHua";
            this.colFuZeRenLianXiDianHua.ReadOnly = true;
            this.colFuZeRenLianXiDianHua.Width = 83;
            // 
            // colYanJiuZhouQi
            // 
            this.colYanJiuZhouQi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colYanJiuZhouQi.HeaderText = "研究周期（年）";
            this.colYanJiuZhouQi.Name = "colYanJiuZhouQi";
            this.colYanJiuZhouQi.ReadOnly = true;
            this.colYanJiuZhouQi.Width = 83;
            // 
            // colYanJiuJingFei
            // 
            this.colYanJiuJingFei.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colYanJiuJingFei.HeaderText = "研究经费（万）";
            this.colYanJiuJingFei.Name = "colYanJiuJingFei";
            this.colYanJiuJingFei.ReadOnly = true;
            this.colYanJiuJingFei.Width = 83;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colButtons
            // 
            this.colButtons.HeaderText = "";
            this.colButtons.Image = ((System.Drawing.Image)(resources.GetObject("colButtons.Image")));
            this.colButtons.Name = "colButtons";
            this.colButtons.ReadOnly = true;
            this.colButtons.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 522);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.ssStatus);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "汇总导入";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusText;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnUploadAll;
        private System.Windows.Forms.ToolStripButton btnLoadAll;
        private System.Windows.Forms.OpenFileDialog ofdZip;
        private System.Windows.Forms.ToolStripButton btnStopUploadAll;
        private System.Windows.Forms.ToolStripButton btnConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLianXiRen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLianXiDianHua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuZeRen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuZeRenLianXiDianHua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYanJiuZhouQi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYanJiuJingFei;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewImageColumn colButtons;
    }
}

