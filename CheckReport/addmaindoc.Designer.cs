namespace CheckReport
{
    partial class addmaindoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_delmaindoc = new System.Windows.Forms.Button();
            this.btn_addmaindoc = new System.Windows.Forms.Button();
            this.txb_IdDocMain = new System.Windows.Forms.TextBox();
            this.txb_NameLineMain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtg_data = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_nameline = new System.Windows.Forms.ComboBox();
            this.btn_filter = new System.Windows.Forms.Button();
            this.btn_loadall = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_addmaindoc);
            this.panel1.Controls.Add(this.txb_IdDocMain);
            this.panel1.Controls.Add(this.btn_delmaindoc);
            this.panel1.Controls.Add(this.txb_NameLineMain);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(15, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 97);
            this.panel1.TabIndex = 18;
            // 
            // btn_delmaindoc
            // 
            this.btn_delmaindoc.BackColor = System.Drawing.Color.Red;
            this.btn_delmaindoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delmaindoc.Location = new System.Drawing.Point(486, 8);
            this.btn_delmaindoc.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_delmaindoc.Name = "btn_delmaindoc";
            this.btn_delmaindoc.Size = new System.Drawing.Size(176, 69);
            this.btn_delmaindoc.TabIndex = 19;
            this.btn_delmaindoc.Text = "Xóa";
            this.btn_delmaindoc.UseVisualStyleBackColor = false;
            this.btn_delmaindoc.Click += new System.EventHandler(this.btn_delmaindoc_Click);
            // 
            // btn_addmaindoc
            // 
            this.btn_addmaindoc.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_addmaindoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addmaindoc.Location = new System.Drawing.Point(699, 8);
            this.btn_addmaindoc.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_addmaindoc.Name = "btn_addmaindoc";
            this.btn_addmaindoc.Size = new System.Drawing.Size(175, 69);
            this.btn_addmaindoc.TabIndex = 17;
            this.btn_addmaindoc.Text = "Thêm";
            this.btn_addmaindoc.UseVisualStyleBackColor = false;
            this.btn_addmaindoc.Click += new System.EventHandler(this.btn_addmaindoc_Click);
            // 
            // txb_IdDocMain
            // 
            this.txb_IdDocMain.Location = new System.Drawing.Point(128, 51);
            this.txb_IdDocMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txb_IdDocMain.Name = "txb_IdDocMain";
            this.txb_IdDocMain.Size = new System.Drawing.Size(328, 26);
            this.txb_IdDocMain.TabIndex = 18;
            // 
            // txb_NameLineMain
            // 
            this.txb_NameLineMain.Location = new System.Drawing.Point(128, 9);
            this.txb_NameLineMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txb_NameLineMain.Name = "txb_NameLineMain";
            this.txb_NameLineMain.Size = new System.Drawing.Size(326, 26);
            this.txb_NameLineMain.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tên Line";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mã tài liệu chính";
            // 
            // dtg_data
            // 
            this.dtg_data.AllowUserToAddRows = false;
            this.dtg_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_data.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_data.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtg_data.Location = new System.Drawing.Point(12, 168);
            this.dtg_data.MultiSelect = false;
            this.dtg_data.Name = "dtg_data";
            this.dtg_data.ReadOnly = true;
            this.dtg_data.Size = new System.Drawing.Size(996, 365);
            this.dtg_data.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(608, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(176, 35);
            this.label16.TabIndex = 24;
            this.label16.Text = "Bảng dữ liệu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tên Line";
            // 
            // cmb_nameline
            // 
            this.cmb_nameline.FormattingEnabled = true;
            this.cmb_nameline.Location = new System.Drawing.Point(103, 129);
            this.cmb_nameline.Name = "cmb_nameline";
            this.cmb_nameline.Size = new System.Drawing.Size(237, 28);
            this.cmb_nameline.TabIndex = 25;
            // 
            // btn_filter
            // 
            this.btn_filter.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filter.Location = new System.Drawing.Point(349, 121);
            this.btn_filter.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(106, 42);
            this.btn_filter.TabIndex = 20;
            this.btn_filter.Text = "Lọc";
            this.btn_filter.UseVisualStyleBackColor = false;
            this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
            // 
            // btn_loadall
            // 
            this.btn_loadall.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_loadall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loadall.Location = new System.Drawing.Point(467, 122);
            this.btn_loadall.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_loadall.Name = "btn_loadall";
            this.btn_loadall.Size = new System.Drawing.Size(106, 42);
            this.btn_loadall.TabIndex = 26;
            this.btn_loadall.Text = "Làm mới";
            this.btn_loadall.UseVisualStyleBackColor = false;
            this.btn_loadall.Click += new System.EventHandler(this.btn_loadall_Click);
            // 
            // addmaindoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 545);
            this.Controls.Add(this.btn_loadall);
            this.Controls.Add(this.btn_filter);
            this.Controls.Add(this.cmb_nameline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dtg_data);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "addmaindoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addmaindoc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_delmaindoc;
        private System.Windows.Forms.Button btn_addmaindoc;
        private System.Windows.Forms.TextBox txb_IdDocMain;
        private System.Windows.Forms.TextBox txb_NameLineMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtg_data;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_nameline;
        private System.Windows.Forms.Button btn_filter;
        private System.Windows.Forms.Button btn_loadall;
    }
}