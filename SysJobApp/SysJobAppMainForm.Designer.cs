namespace SysJobApp
{
    partial class SysJobAppMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.processes_refreshBtn = new System.Windows.Forms.Button();
            this.main_threadProtectionChecbox = new System.Windows.Forms.CheckBox();
            this.thread_listView = new System.Windows.Forms.ListBox();
            this.process_listView = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.threads_resumeSelectedBtn = new System.Windows.Forms.Button();
            this.threads_pauseSelectedBtn = new System.Windows.Forms.Button();
            this.threads_resumeAllBtn = new System.Windows.Forms.Button();
            this.threads_pauseAllBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.mockThread_valueLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mockThread_infoLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.thread_listView, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.process_listView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 101);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.90909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(797, 508);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.processes_refreshBtn);
            this.flowLayoutPanel2.Controls.Add(this.main_threadProtectionChecbox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 464);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(392, 41);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // processes_refreshBtn
            // 
            this.processes_refreshBtn.AutoSize = true;
            this.processes_refreshBtn.Location = new System.Drawing.Point(3, 3);
            this.processes_refreshBtn.Name = "processes_refreshBtn";
            this.processes_refreshBtn.Size = new System.Drawing.Size(75, 25);
            this.processes_refreshBtn.TabIndex = 0;
            this.processes_refreshBtn.Text = "Refresh";
            this.processes_refreshBtn.UseVisualStyleBackColor = true;
            this.processes_refreshBtn.Click += new System.EventHandler(this.processes_refreshBtn_Click);
            // 
            // main_threadProtectionChecbox
            // 
            this.main_threadProtectionChecbox.AutoSize = true;
            this.main_threadProtectionChecbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_threadProtectionChecbox.Location = new System.Drawing.Point(84, 3);
            this.main_threadProtectionChecbox.Name = "main_threadProtectionChecbox";
            this.main_threadProtectionChecbox.Size = new System.Drawing.Size(207, 25);
            this.main_threadProtectionChecbox.TabIndex = 1;
            this.main_threadProtectionChecbox.Text = "Block app main thread suspension";
            this.main_threadProtectionChecbox.UseVisualStyleBackColor = true;
            this.main_threadProtectionChecbox.CheckedChanged += new System.EventHandler(this.main_threadProtectionChecbox_CheckedChanged);
            // 
            // thread_listView
            // 
            this.thread_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thread_listView.FormattingEnabled = true;
            this.thread_listView.ItemHeight = 15;
            this.thread_listView.Location = new System.Drawing.Point(401, 3);
            this.thread_listView.Name = "thread_listView";
            this.thread_listView.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.thread_listView.Size = new System.Drawing.Size(393, 455);
            this.thread_listView.TabIndex = 2;
            // 
            // process_listView
            // 
            this.process_listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.process_listView.FormattingEnabled = true;
            this.process_listView.ItemHeight = 15;
            this.process_listView.Location = new System.Drawing.Point(3, 3);
            this.process_listView.Name = "process_listView";
            this.process_listView.Size = new System.Drawing.Size(392, 455);
            this.process_listView.TabIndex = 3;
            this.process_listView.SelectedIndexChanged += new System.EventHandler(this.process_listView_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.threads_resumeSelectedBtn);
            this.flowLayoutPanel1.Controls.Add(this.threads_pauseSelectedBtn);
            this.flowLayoutPanel1.Controls.Add(this.threads_resumeAllBtn);
            this.flowLayoutPanel1.Controls.Add(this.threads_pauseAllBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(401, 464);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(393, 41);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // threads_resumeSelectedBtn
            // 
            this.threads_resumeSelectedBtn.AutoSize = true;
            this.threads_resumeSelectedBtn.Location = new System.Drawing.Point(3, 3);
            this.threads_resumeSelectedBtn.Name = "threads_resumeSelectedBtn";
            this.threads_resumeSelectedBtn.Size = new System.Drawing.Size(105, 25);
            this.threads_resumeSelectedBtn.TabIndex = 1;
            this.threads_resumeSelectedBtn.Text = "Resume selected";
            this.threads_resumeSelectedBtn.UseVisualStyleBackColor = true;
            this.threads_resumeSelectedBtn.Click += new System.EventHandler(this.threads_resumeSelectedBtn_Click);
            // 
            // threads_pauseSelectedBtn
            // 
            this.threads_pauseSelectedBtn.AutoSize = true;
            this.threads_pauseSelectedBtn.Location = new System.Drawing.Point(114, 3);
            this.threads_pauseSelectedBtn.Name = "threads_pauseSelectedBtn";
            this.threads_pauseSelectedBtn.Size = new System.Drawing.Size(94, 25);
            this.threads_pauseSelectedBtn.TabIndex = 3;
            this.threads_pauseSelectedBtn.Text = "Pause selected";
            this.threads_pauseSelectedBtn.UseVisualStyleBackColor = true;
            this.threads_pauseSelectedBtn.Click += new System.EventHandler(this.threads_pauseSelectedBtn_Click);
            // 
            // threads_resumeAllBtn
            // 
            this.threads_resumeAllBtn.AutoSize = true;
            this.threads_resumeAllBtn.Location = new System.Drawing.Point(214, 3);
            this.threads_resumeAllBtn.Name = "threads_resumeAllBtn";
            this.threads_resumeAllBtn.Size = new System.Drawing.Size(75, 25);
            this.threads_resumeAllBtn.TabIndex = 0;
            this.threads_resumeAllBtn.Text = "Resume all";
            this.threads_resumeAllBtn.UseVisualStyleBackColor = true;
            this.threads_resumeAllBtn.Click += new System.EventHandler(this.threads_resumeAllBtn_Click);
            // 
            // threads_pauseAllBtn
            // 
            this.threads_pauseAllBtn.AutoSize = true;
            this.threads_pauseAllBtn.Location = new System.Drawing.Point(295, 3);
            this.threads_pauseAllBtn.Name = "threads_pauseAllBtn";
            this.threads_pauseAllBtn.Size = new System.Drawing.Size(75, 25);
            this.threads_pauseAllBtn.TabIndex = 2;
            this.threads_pauseAllBtn.Text = "Pause all";
            this.threads_pauseAllBtn.UseVisualStyleBackColor = true;
            this.threads_pauseAllBtn.Click += new System.EventHandler(this.threads_pauseAllBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.141F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.859F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(803, 612);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.mockThread_valueLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.mockThread_infoLabel, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(797, 92);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // mockThread_valueLabel
            // 
            this.mockThread_valueLabel.AutoSize = true;
            this.mockThread_valueLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mockThread_valueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mockThread_valueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mockThread_valueLabel.Location = new System.Drawing.Point(3, 44);
            this.mockThread_valueLabel.Name = "mockThread_valueLabel";
            this.mockThread_valueLabel.Size = new System.Drawing.Size(791, 18);
            this.mockThread_valueLabel.TabIndex = 1;
            this.mockThread_valueLabel.Text = "0";
            this.mockThread_valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "SysJobApp";
            // 
            // mockThread_infoLabel
            // 
            this.mockThread_infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mockThread_infoLabel.AutoSize = true;
            this.mockThread_infoLabel.Location = new System.Drawing.Point(3, 62);
            this.mockThread_infoLabel.Name = "mockThread_infoLabel";
            this.mockThread_infoLabel.Size = new System.Drawing.Size(791, 30);
            this.mockThread_infoLabel.TabIndex = 2;
            this.mockThread_infoLabel.Text = "{mockThreadInfo}";
            this.mockThread_infoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SysJobAppMainForm
            // 
            this.ClientSize = new System.Drawing.Size(803, 612);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "SysJobAppMainForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button processes_refreshBtn;
        private ListBox thread_listView;
        private ListBox process_listView;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button threads_resumeAllBtn;
        private Button threads_resumeSelectedBtn;
        private Button threads_pauseAllBtn;
        private Button threads_pauseSelectedBtn;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label1;
        private Label mockThread_valueLabel;
        private Label mockThread_infoLabel;
        private CheckBox main_threadProtectionChecbox;
    }
}