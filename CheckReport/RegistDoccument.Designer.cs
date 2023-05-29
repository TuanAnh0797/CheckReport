namespace CheckReport
{
    partial class RegistDoccument
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmb_namelinedoc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_Idmaindoc = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_chossefile = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_adddoc = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_Iddoc = new System.Windows.Forms.TextBox();
            this.txb_namedoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmb_namelinedoc);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.cmb_Idmaindoc);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.btn_chossefile);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.btn_adddoc);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.txb_Iddoc);
            this.panel5.Controls.Add(this.txb_namedoc);
            this.panel5.Location = new System.Drawing.Point(13, 47);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(697, 291);
            this.panel5.TabIndex = 4;
            // 
            // cmb_namelinedoc
            // 
            this.cmb_namelinedoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_namelinedoc.FormattingEnabled = true;
            this.cmb_namelinedoc.Location = new System.Drawing.Point(132, 198);
            this.cmb_namelinedoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_namelinedoc.Name = "cmb_namelinedoc";
            this.cmb_namelinedoc.Size = new System.Drawing.Size(398, 28);
            this.cmb_namelinedoc.TabIndex = 21;
            this.cmb_namelinedoc.SelectedIndexChanged += new System.EventHandler(this.cmb_namelinedoc_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 202);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tên Line";
            // 
            // cmb_Idmaindoc
            // 
            this.cmb_Idmaindoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Idmaindoc.FormattingEnabled = true;
            this.cmb_Idmaindoc.Location = new System.Drawing.Point(132, 244);
            this.cmb_Idmaindoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Idmaindoc.Name = "cmb_Idmaindoc";
            this.cmb_Idmaindoc.Size = new System.Drawing.Size(398, 28);
            this.cmb_Idmaindoc.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 244);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Mã tài liệu chính";
            // 
            // btn_chossefile
            // 
            this.btn_chossefile.BackColor = System.Drawing.Color.Yellow;
            this.btn_chossefile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chossefile.Location = new System.Drawing.Point(538, 14);
            this.btn_chossefile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_chossefile.Name = "btn_chossefile";
            this.btn_chossefile.Size = new System.Drawing.Size(142, 74);
            this.btn_chossefile.TabIndex = 11;
            this.btn_chossefile.Text = "Chọn tài liệu cần thêm";
            this.btn_chossefile.UseVisualStyleBackColor = false;
            this.btn_chossefile.Click += new System.EventHandler(this.btn_chossefile_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tên CheckSheet";
            // 
            // btn_adddoc
            // 
            this.btn_adddoc.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_adddoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adddoc.Location = new System.Drawing.Point(538, 193);
            this.btn_adddoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_adddoc.Name = "btn_adddoc";
            this.btn_adddoc.Size = new System.Drawing.Size(142, 79);
            this.btn_adddoc.TabIndex = 10;
            this.btn_adddoc.Text = "Thêm";
            this.btn_adddoc.UseVisualStyleBackColor = false;
            this.btn_adddoc.Click += new System.EventHandler(this.btn_adddoc_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Mã tài liệu";
            // 
            // txb_Iddoc
            // 
            this.txb_Iddoc.Location = new System.Drawing.Point(132, 14);
            this.txb_Iddoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txb_Iddoc.Name = "txb_Iddoc";
            this.txb_Iddoc.ReadOnly = true;
            this.txb_Iddoc.Size = new System.Drawing.Size(398, 26);
            this.txb_Iddoc.TabIndex = 8;
            // 
            // txb_namedoc
            // 
            this.txb_namedoc.Location = new System.Drawing.Point(132, 62);
            this.txb_namedoc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txb_namedoc.Multiline = true;
            this.txb_namedoc.Name = "txb_namedoc";
            this.txb_namedoc.ReadOnly = true;
            this.txb_namedoc.Size = new System.Drawing.Size(398, 119);
            this.txb_namedoc.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(259, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 33);
            this.label5.TabIndex = 18;
            this.label5.Text = "Thêm tài liệu mới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(14, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "*Định dạng tên file tài liệu: Tên line-Mã tài liệu_Tên tài liệu ";
            // 
            // RegistDoccument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 384);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegistDoccument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistDoccument";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_Idmaindoc;
        private System.Windows.Forms.Button btn_chossefile;
        private System.Windows.Forms.Button btn_adddoc;
        private System.Windows.Forms.TextBox txb_namedoc;
        private System.Windows.Forms.TextBox txb_Iddoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_namelinedoc;
        private System.Windows.Forms.Label label1;
    }
}