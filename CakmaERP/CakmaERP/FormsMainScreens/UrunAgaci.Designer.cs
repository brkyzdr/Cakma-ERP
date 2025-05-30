﻿namespace CakmaERP.FormsMainScreens
{
    partial class UrunAgaci
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtUrunAgaciKodu = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxPasifmi = new System.Windows.Forms.CheckBox();
            this.checkBoxSilindimi = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCizimNumarasi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTemelMiktar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMalzemeKodu = new System.Windows.Forms.TextBox();
            this.txtBilesenMiktari = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBilesenKodu = new System.Windows.Forms.TextBox();
            this.txtIcerikNumarasi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtKalemUrunAgaciKodu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbFirma = new System.Windows.Forms.ComboBox();
            this.cbUrunAgaci = new System.Windows.Forms.ComboBox();
            this.cbMalzeme = new System.Windows.Forms.ComboBox();
            this.cbKalemUrunAgaci = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::CakmaERP.Properties.Resources.icons8_delete_48;
            this.btnDelete.Location = new System.Drawing.Point(223, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 55);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = global::CakmaERP.Properties.Resources.icons8_pencil_48;
            this.btnUpdate.Location = new System.Drawing.Point(115, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(55, 55);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = global::CakmaERP.Properties.Resources.icons8_add_50;
            this.btnCreate.Location = new System.Drawing.Point(12, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(55, 55);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtUrunAgaciKodu
            // 
            this.txtUrunAgaciKodu.Location = new System.Drawing.Point(12, 180);
            this.txtUrunAgaciKodu.Name = "txtUrunAgaciKodu";
            this.txtUrunAgaciKodu.Size = new System.Drawing.Size(216, 20);
            this.txtUrunAgaciKodu.TabIndex = 139;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 164);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 13);
            this.label17.TabIndex = 138;
            this.label17.Text = "Ürün Ağacı Kodu";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 119);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 13);
            this.label18.TabIndex = 137;
            this.label18.Text = "Ürün Ağacı Tipi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 135;
            this.label5.Text = "Geçerlilik Bitiş Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Geçerlilik Başlangıç Tarihi";
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Location = new System.Drawing.Point(12, 269);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBitis.TabIndex = 133;
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(12, 225);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBaslangic.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "Firma Kodu";
            // 
            // checkBoxPasifmi
            // 
            this.checkBoxPasifmi.AutoSize = true;
            this.checkBoxPasifmi.Location = new System.Drawing.Point(72, 455);
            this.checkBoxPasifmi.Name = "checkBoxPasifmi";
            this.checkBoxPasifmi.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPasifmi.TabIndex = 151;
            this.checkBoxPasifmi.UseVisualStyleBackColor = true;
            // 
            // checkBoxSilindimi
            // 
            this.checkBoxSilindimi.AutoSize = true;
            this.checkBoxSilindimi.Location = new System.Drawing.Point(72, 431);
            this.checkBoxSilindimi.Name = "checkBoxSilindimi";
            this.checkBoxSilindimi.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSilindimi.TabIndex = 150;
            this.checkBoxSilindimi.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 455);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 149;
            this.label11.Text = "Pasif mi?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 148;
            this.label10.Text = "Silindi mi?";
            // 
            // txtCizimNumarasi
            // 
            this.txtCizimNumarasi.Location = new System.Drawing.Point(12, 494);
            this.txtCizimNumarasi.Name = "txtCizimNumarasi";
            this.txtCizimNumarasi.Size = new System.Drawing.Size(216, 20);
            this.txtCizimNumarasi.TabIndex = 147;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 146;
            this.label6.Text = "Çizim Numarası";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 145;
            this.label7.Text = "Temel Miktar";
            // 
            // txtTemelMiktar
            // 
            this.txtTemelMiktar.Location = new System.Drawing.Point(12, 403);
            this.txtTemelMiktar.Name = "txtTemelMiktar";
            this.txtTemelMiktar.Size = new System.Drawing.Size(216, 20);
            this.txtTemelMiktar.TabIndex = 144;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 143;
            this.label8.Text = "Malzeme Kodu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 142;
            this.label9.Text = "Malzeme Tipi";
            // 
            // txtMalzemeKodu
            // 
            this.txtMalzemeKodu.Location = new System.Drawing.Point(12, 359);
            this.txtMalzemeKodu.Name = "txtMalzemeKodu";
            this.txtMalzemeKodu.Size = new System.Drawing.Size(216, 20);
            this.txtMalzemeKodu.TabIndex = 141;
            // 
            // txtBilesenMiktari
            // 
            this.txtBilesenMiktari.Location = new System.Drawing.Point(12, 721);
            this.txtBilesenMiktari.Name = "txtBilesenMiktari";
            this.txtBilesenMiktari.Size = new System.Drawing.Size(216, 20);
            this.txtBilesenMiktari.TabIndex = 161;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 705);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 160;
            this.label2.Text = "Bileşen Miktarı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 571);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 159;
            this.label3.Text = "Bileşen Kodu";
            // 
            // txtBilesenKodu
            // 
            this.txtBilesenKodu.Location = new System.Drawing.Point(12, 587);
            this.txtBilesenKodu.Name = "txtBilesenKodu";
            this.txtBilesenKodu.Size = new System.Drawing.Size(216, 20);
            this.txtBilesenKodu.TabIndex = 158;
            // 
            // txtIcerikNumarasi
            // 
            this.txtIcerikNumarasi.Location = new System.Drawing.Point(12, 542);
            this.txtIcerikNumarasi.Name = "txtIcerikNumarasi";
            this.txtIcerikNumarasi.Size = new System.Drawing.Size(216, 20);
            this.txtIcerikNumarasi.TabIndex = 157;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 526);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 156;
            this.label12.Text = "İçerik Numarası";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 661);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 13);
            this.label13.TabIndex = 165;
            this.label13.Text = "Kalem Ürün Ağacı Kodu";
            // 
            // txtKalemUrunAgaciKodu
            // 
            this.txtKalemUrunAgaciKodu.Location = new System.Drawing.Point(12, 677);
            this.txtKalemUrunAgaciKodu.Name = "txtKalemUrunAgaciKodu";
            this.txtKalemUrunAgaciKodu.Size = new System.Drawing.Size(216, 20);
            this.txtKalemUrunAgaciKodu.TabIndex = 164;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 616);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 13);
            this.label14.TabIndex = 162;
            this.label14.Text = "Kalem Ürün Ağacı Tipi";
            // 
            // cbFirma
            // 
            this.cbFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFirma.FormattingEnabled = true;
            this.cbFirma.Location = new System.Drawing.Point(12, 92);
            this.cbFirma.Name = "cbFirma";
            this.cbFirma.Size = new System.Drawing.Size(216, 21);
            this.cbFirma.TabIndex = 166;
            this.cbFirma.SelectedIndexChanged += new System.EventHandler(this.cbFirma_SelectedIndexChanged);
            // 
            // cbUrunAgaci
            // 
            this.cbUrunAgaci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUrunAgaci.FormattingEnabled = true;
            this.cbUrunAgaci.Location = new System.Drawing.Point(12, 135);
            this.cbUrunAgaci.Name = "cbUrunAgaci";
            this.cbUrunAgaci.Size = new System.Drawing.Size(216, 21);
            this.cbUrunAgaci.TabIndex = 167;
            // 
            // cbMalzeme
            // 
            this.cbMalzeme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMalzeme.FormattingEnabled = true;
            this.cbMalzeme.Location = new System.Drawing.Point(12, 314);
            this.cbMalzeme.Name = "cbMalzeme";
            this.cbMalzeme.Size = new System.Drawing.Size(216, 21);
            this.cbMalzeme.TabIndex = 168;
            // 
            // cbKalemUrunAgaci
            // 
            this.cbKalemUrunAgaci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKalemUrunAgaci.FormattingEnabled = true;
            this.cbKalemUrunAgaci.Location = new System.Drawing.Point(12, 632);
            this.cbKalemUrunAgaci.Name = "cbKalemUrunAgaci";
            this.cbKalemUrunAgaci.Size = new System.Drawing.Size(216, 21);
            this.cbKalemUrunAgaci.TabIndex = 169;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 769);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 55);
            this.button1.TabIndex = 170;
            this.button1.Text = "Ürün Ağacı Seviyeleri Listesi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UrunAgaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 1006);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbKalemUrunAgaci);
            this.Controls.Add(this.cbMalzeme);
            this.Controls.Add(this.cbUrunAgaci);
            this.Controls.Add(this.cbFirma);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtKalemUrunAgaciKodu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtBilesenMiktari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBilesenKodu);
            this.Controls.Add(this.txtIcerikNumarasi);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkBoxPasifmi);
            this.Controls.Add(this.checkBoxSilindimi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCizimNumarasi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTemelMiktar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMalzemeKodu);
            this.Controls.Add(this.txtUrunAgaciKodu);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerBitis);
            this.Controls.Add(this.dateTimePickerBaslangic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UrunAgaci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ağacı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtUrunAgaciKodu;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxPasifmi;
        private System.Windows.Forms.CheckBox checkBoxSilindimi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCizimNumarasi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTemelMiktar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMalzemeKodu;
        private System.Windows.Forms.TextBox txtBilesenMiktari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBilesenKodu;
        private System.Windows.Forms.TextBox txtIcerikNumarasi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtKalemUrunAgaciKodu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbFirma;
        private System.Windows.Forms.ComboBox cbUrunAgaci;
        private System.Windows.Forms.ComboBox cbMalzeme;
        private System.Windows.Forms.ComboBox cbKalemUrunAgaci;
        private System.Windows.Forms.Button button1;
    }
}