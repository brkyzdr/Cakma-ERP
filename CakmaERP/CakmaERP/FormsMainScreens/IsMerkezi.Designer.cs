namespace CakmaERP.FormsMainScreens
{
    partial class IsMerkezi
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIsMerkeziKodu = new System.Windows.Forms.TextBox();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaliyetMerkeziKodu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAnaIsMerkeziKodu = new System.Windows.Forms.TextBox();
            this.txtAnaIsMerkeziTipi = new System.Windows.Forms.TextBox();
            this.txtGunlukCalismaSatti = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxSilindimi = new System.Windows.Forms.CheckBox();
            this.checkBoxPasifmi = new System.Windows.Forms.CheckBox();
            this.txtOperasyonKodu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIsAciklamasi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbFirma = new System.Windows.Forms.ComboBox();
            this.cbIsMerkeziTipi = new System.Windows.Forms.ComboBox();
            this.cbMaliyetMerkeziTipi = new System.Windows.Forms.ComboBox();
            this.cbDilKodu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "İş Merkezi Tipi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Firma Kodu";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(314, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(1558, 982);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::CakmaERP.Properties.Resources.icons8_delete_48;
            this.btnDelete.Location = new System.Drawing.Point(223, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 55);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::CakmaERP.Properties.Resources.icons8_pencil_48;
            this.btnUpdate.Location = new System.Drawing.Point(115, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(55, 55);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::CakmaERP.Properties.Resources.icons8_add_50;
            this.btnCreate.Location = new System.Drawing.Point(12, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(55, 55);
            this.btnCreate.TabIndex = 19;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "İş Merkezi Kodu";
            // 
            // txtIsMerkeziKodu
            // 
            this.txtIsMerkeziKodu.Location = new System.Drawing.Point(12, 179);
            this.txtIsMerkeziKodu.Name = "txtIsMerkeziKodu";
            this.txtIsMerkeziKodu.Size = new System.Drawing.Size(216, 20);
            this.txtIsMerkeziKodu.TabIndex = 26;
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(12, 224);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBaslangic.TabIndex = 28;
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Location = new System.Drawing.Point(12, 268);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBitis.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Geçerlilik Başlangıç Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Geçerlilik Bitiş Tarihi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Günlük Çalışma Saati";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 434);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Maliyet Merkezi Kodu";
            // 
            // txtMaliyetMerkeziKodu
            // 
            this.txtMaliyetMerkeziKodu.Location = new System.Drawing.Point(12, 450);
            this.txtMaliyetMerkeziKodu.Name = "txtMaliyetMerkeziKodu";
            this.txtMaliyetMerkeziKodu.Size = new System.Drawing.Size(216, 20);
            this.txtMaliyetMerkeziKodu.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Ana İş Merkezi Kodu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Ana İş Merkezi Tipi";
            // 
            // txtAnaIsMerkeziKodu
            // 
            this.txtAnaIsMerkeziKodu.Location = new System.Drawing.Point(12, 360);
            this.txtAnaIsMerkeziKodu.Name = "txtAnaIsMerkeziKodu";
            this.txtAnaIsMerkeziKodu.Size = new System.Drawing.Size(216, 20);
            this.txtAnaIsMerkeziKodu.TabIndex = 33;
            // 
            // txtAnaIsMerkeziTipi
            // 
            this.txtAnaIsMerkeziTipi.Location = new System.Drawing.Point(12, 315);
            this.txtAnaIsMerkeziTipi.Name = "txtAnaIsMerkeziTipi";
            this.txtAnaIsMerkeziTipi.Size = new System.Drawing.Size(216, 20);
            this.txtAnaIsMerkeziTipi.TabIndex = 32;
            // 
            // txtGunlukCalismaSatti
            // 
            this.txtGunlukCalismaSatti.Location = new System.Drawing.Point(12, 495);
            this.txtGunlukCalismaSatti.Name = "txtGunlukCalismaSatti";
            this.txtGunlukCalismaSatti.Size = new System.Drawing.Size(216, 20);
            this.txtGunlukCalismaSatti.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 528);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Silindi mi?";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 551);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Pasif mi?";
            // 
            // checkBoxSilindimi
            // 
            this.checkBoxSilindimi.AutoSize = true;
            this.checkBoxSilindimi.Location = new System.Drawing.Point(72, 527);
            this.checkBoxSilindimi.Name = "checkBoxSilindimi";
            this.checkBoxSilindimi.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSilindimi.TabIndex = 42;
            this.checkBoxSilindimi.UseVisualStyleBackColor = true;
            // 
            // checkBoxPasifmi
            // 
            this.checkBoxPasifmi.AutoSize = true;
            this.checkBoxPasifmi.Location = new System.Drawing.Point(72, 551);
            this.checkBoxPasifmi.Name = "checkBoxPasifmi";
            this.checkBoxPasifmi.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPasifmi.TabIndex = 43;
            this.checkBoxPasifmi.UseVisualStyleBackColor = true;
            // 
            // txtOperasyonKodu
            // 
            this.txtOperasyonKodu.Location = new System.Drawing.Point(12, 636);
            this.txtOperasyonKodu.Name = "txtOperasyonKodu";
            this.txtOperasyonKodu.Size = new System.Drawing.Size(216, 20);
            this.txtOperasyonKodu.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 620);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "Operasyon Kodu";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 666);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "İş Açıklaması";
            // 
            // txtIsAciklamasi
            // 
            this.txtIsAciklamasi.Location = new System.Drawing.Point(12, 682);
            this.txtIsAciklamasi.Multiline = true;
            this.txtIsAciklamasi.Name = "txtIsAciklamasi";
            this.txtIsAciklamasi.Size = new System.Drawing.Size(216, 80);
            this.txtIsAciklamasi.TabIndex = 46;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 572);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Dil Kodu";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 389);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Maliyet Merkezi Tipi";
            // 
            // cbFirma
            // 
            this.cbFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFirma.FormattingEnabled = true;
            this.cbFirma.Location = new System.Drawing.Point(12, 91);
            this.cbFirma.Name = "cbFirma";
            this.cbFirma.Size = new System.Drawing.Size(216, 21);
            this.cbFirma.TabIndex = 52;
            this.cbFirma.SelectedIndexChanged += new System.EventHandler(this.cbFirma_SelectedIndexChanged);
            // 
            // cbIsMerkeziTipi
            // 
            this.cbIsMerkeziTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsMerkeziTipi.FormattingEnabled = true;
            this.cbIsMerkeziTipi.Location = new System.Drawing.Point(13, 136);
            this.cbIsMerkeziTipi.Name = "cbIsMerkeziTipi";
            this.cbIsMerkeziTipi.Size = new System.Drawing.Size(215, 21);
            this.cbIsMerkeziTipi.TabIndex = 53;
            // 
            // cbMaliyetMerkeziTipi
            // 
            this.cbMaliyetMerkeziTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaliyetMerkeziTipi.FormattingEnabled = true;
            this.cbMaliyetMerkeziTipi.Location = new System.Drawing.Point(12, 406);
            this.cbMaliyetMerkeziTipi.Name = "cbMaliyetMerkeziTipi";
            this.cbMaliyetMerkeziTipi.Size = new System.Drawing.Size(216, 21);
            this.cbMaliyetMerkeziTipi.TabIndex = 54;
            // 
            // cbDilKodu
            // 
            this.cbDilKodu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDilKodu.FormattingEnabled = true;
            this.cbDilKodu.Location = new System.Drawing.Point(12, 589);
            this.cbDilKodu.Name = "cbDilKodu";
            this.cbDilKodu.Size = new System.Drawing.Size(216, 21);
            this.cbDilKodu.TabIndex = 55;
            // 
            // IsMerkezi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1884, 1006);
            this.Controls.Add(this.cbDilKodu);
            this.Controls.Add(this.cbMaliyetMerkeziTipi);
            this.Controls.Add(this.cbIsMerkeziTipi);
            this.Controls.Add(this.cbFirma);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtOperasyonKodu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtIsAciklamasi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.checkBoxPasifmi);
            this.Controls.Add(this.checkBoxSilindimi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtGunlukCalismaSatti);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaliyetMerkeziKodu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAnaIsMerkeziKodu);
            this.Controls.Add(this.txtAnaIsMerkeziTipi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerBitis);
            this.Controls.Add(this.dateTimePickerBaslangic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIsMerkeziKodu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "IsMerkezi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İş Merkezi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIsMerkeziKodu;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaliyetMerkeziKodu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAnaIsMerkeziKodu;
        private System.Windows.Forms.TextBox txtAnaIsMerkeziTipi;
        private System.Windows.Forms.TextBox txtGunlukCalismaSatti;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxSilindimi;
        private System.Windows.Forms.CheckBox checkBoxPasifmi;
        private System.Windows.Forms.TextBox txtOperasyonKodu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIsAciklamasi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbFirma;
        private System.Windows.Forms.ComboBox cbIsMerkeziTipi;
        private System.Windows.Forms.ComboBox cbMaliyetMerkeziTipi;
        private System.Windows.Forms.ComboBox cbDilKodu;
    }
}