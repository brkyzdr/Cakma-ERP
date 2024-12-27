using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CakmaERP.FormsMainScreens
{
    public partial class RotaYonetimi : Form
    {
        public RotaYonetimi()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSROTHEAD");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["ROTDOCTYPE"].HeaderText = "Rota Tipi";
            dataGridView1.Columns["ROTDOCNUM"].HeaderText = "Rota Kodu";
            dataGridView1.Columns["ROTDOCFROM"].HeaderText = "Geçerlilik Başlangıç Tarihi";
            dataGridView1.Columns["ROTDOCUNTIL"].HeaderText = "Geçerlilik Bitiş Tarihi";
            dataGridView1.Columns["MATDOCTYPE"].HeaderText = "Malzeme Tipi";
            dataGridView1.Columns["MATDOCNUM"].HeaderText = "Malzeme Kodu";
            dataGridView1.Columns["QUANTITY"].HeaderText = "Temel Miktar";
            dataGridView1.Columns["ISDELETED"].HeaderText = "Silindi mi?";
            dataGridView1.Columns["ISPASSIVE"].HeaderText = "Pasif mi?";
            dataGridView1.Columns["DRAWNUM"].HeaderText = "Çizim Numarası";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int ispassive;
            if (checkBoxPasifmi.Checked) ispassive = 1;
            else ispassive = 0;

            int isdeleted;
            if (checkBoxSilindimi.Checked) isdeleted = 1;
            else isdeleted = 0;

            if (!string.IsNullOrEmpty(txtFirmaKodu.Text)
                && !string.IsNullOrEmpty(txtRotaTipi.Text)
                && !string.IsNullOrEmpty(txtRotaKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtTemelMiktar.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtOperasyonNumarasi.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciTipi.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(txtIcerikNumarasi.Text)
                && !string.IsNullOrEmpty(txtBilesenKodu.Text)
                && !string.IsNullOrEmpty(txtBilesenMiktari.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "ROTDOCTYPE", txtRotaTipi.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ROTDOCFROM", dateTimePickerBaslangic.Text },
                    { "ROTDOCUNTIL", dateTimePickerBitis.Text },
                    { "MATDOCTYPE", txtMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "QUANTITY", txtTemelMiktar.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive },
                    { "DRAWNUM", txtCizimNumarasi }
                };
                var dataOpr = new Dictionary<string, object>
                {
                    { "ROTDOCTYPE", txtMaliyetMerkeziTipi.Text },
                    { "ROTDOCNUM", txtMaliyetMerkeziKodu.Text },
                    { "MATDOCTYPE", txtMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "OPRNUM", txtOperasyonNumarasi.Text },
                    { "WCMDOCTYPE", txtIsMerkeziTipi.Text },
                    { "WCMDOCNUM", txtIsMerkeziKodu.Text },
                    { "OPRDOCTYPE", txtOperasyonKodu.Text },
                    { "SETUPTIME", txtOperasyonHazirlikSuresi.Text },
                    { "MACHINETIME", txtOperasyonMakineSuresi.Text },
                    { "LABOURTIME", txtOperasyonIscilikSuresi.Text }
                };
                var dataBom = new Dictionary<string, object>
                {
                    { "BOMDOCTYPE", txtUrunAgaciTipi.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "CONTENTNUM", txtIcerikNumarasi.Text },
                    { "COMPONENT", txtBilesenKodu.Text },
                    { "QUANTITY", txtBilesenMiktari.Text }
                };

                CRUD.Create("GRSROTHEAD", dataHead);
                CRUD.Create("GRSROTOPRCONTENT", dataOpr);
                CRUD.Create("GRSROTBOMCONTENT", dataBom);
                MessageBox.Show("Veri başarıyla eklendi.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ispassive;
            if (checkBoxPasifmi.Checked) ispassive = 1;
            else ispassive = 0;

            int isdeleted;
            if (checkBoxSilindimi.Checked) isdeleted = 1;
            else isdeleted = 0;

            if (!string.IsNullOrEmpty(txtFirmaKodu.Text)
                && !string.IsNullOrEmpty(txtRotaTipi.Text)
                && !string.IsNullOrEmpty(txtRotaKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtTemelMiktar.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtOperasyonNumarasi.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciTipi.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(txtIcerikNumarasi.Text)
                && !string.IsNullOrEmpty(txtBilesenKodu.Text)
                && !string.IsNullOrEmpty(txtBilesenMiktari.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "ROTDOCTYPE", txtRotaTipi.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ROTDOCFROM", dateTimePickerBaslangic.Text },
                    { "ROTDOCUNTIL", dateTimePickerBitis.Text },
                    { "MATDOCTYPE", txtMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "QUANTITY", txtTemelMiktar.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive },
                    { "DRAWNUM", txtCizimNumarasi }
                };
                var dataOpr = new Dictionary<string, object>
                {
                    { "ROTDOCTYPE", txtMaliyetMerkeziTipi.Text },
                    { "ROTDOCNUM", txtMaliyetMerkeziKodu.Text },
                    { "MATDOCTYPE", txtMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "OPRNUM", txtOperasyonNumarasi.Text },
                    { "WCMDOCTYPE", txtIsMerkeziTipi.Text },
                    { "WCMDOCNUM", txtIsMerkeziKodu.Text },
                    { "OPRDOCTYPE", txtOperasyonKodu.Text },
                    { "SETUPTIME", txtOperasyonHazirlikSuresi.Text },
                    { "MACHINETIME", txtOperasyonMakineSuresi.Text },
                    { "LABOURTIME", txtOperasyonIscilikSuresi.Text }
                };
                var dataBom = new Dictionary<string, object>
                {
                    { "BOMDOCTYPE", txtUrunAgaciTipi.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "CONTENTNUM", txtIcerikNumarasi.Text },
                    { "COMPONENT", txtBilesenKodu.Text },
                    { "QUANTITY", txtBilesenMiktari.Text }
                };

                string condition = $"firma_kodu = '{txtFirmaKodu.Text}'";
                CRUD.Update("GRSROTHEAD", dataHead, condition);
                CRUD.Update("GRSROTOPRCONTENT", dataOpr, condition);
                CRUD.Update("GRSROTBOMCONTENT", dataBom, condition);
                MessageBox.Show("Veri başarıyla güncellendi.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text))
            {
                string condition = $"firma_kodu = '{txtFirmaKodu.Text}'";
                CRUD.Delete("GRSROTHEAD", condition);
                CRUD.Delete("GRSROTOPRCONTENT", condition);
                CRUD.Delete("GRSROTBOMCONTENT", condition);
                MessageBox.Show("Veri başarıyla silindi.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtFirmaKodu.Text = row.Cells["COMCODE"].Value.ToString();
                txtRotaTipi.Text = row.Cells["ROTDOCTYPE"].Value.ToString();
                txtRotaKodu.Text = row.Cells["ROTDOCNUM"].Value.ToString();
                dateTimePickerBaslangic.Text = row.Cells["ROTDOCFROM"].Value.ToString();
                dateTimePickerBitis.Text = row.Cells["ROTDOCUNTIL"].Value.ToString();
                txtMalzemeTipi.Text = row.Cells["MATDOCTYPE"].Value.ToString();
                txtMalzemeKodu.Text = row.Cells["MATDOCNUM"].Value.ToString();
                txtTemelMiktar.Text = row.Cells["QUANTITY"].Value.ToString();
                txtCizimNumarasi.Text = row.Cells["DRAWNUM"].Value.ToString();

                if (row.Cells["ISDELETED"].Value.ToString() == "1") checkBoxSilindimi.Checked = true;
                else checkBoxSilindimi.Checked = false;

                if (row.Cells["ISPASSIVE"].Value.ToString() == "1") checkBoxPasifmi.Checked = true;
                else checkBoxPasifmi.Checked = false;

                var firmakodu = txtFirmaKodu.Text;

                DataTable tableOpr = CRUD.Read("SELECT * FROM GRSROTOPRCONTENT");              
                txtMaliyetMerkeziTipi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["ROTDOCTYPE"].ToString();
                txtMaliyetMerkeziKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["ROTDOCNUM"].ToString();
                txtMalzemeTipi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["MATDOCTYPE"].ToString();
                txtMalzemeKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["MATDOCNUM"].ToString();
                txtOperasyonNumarasi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["OPRNUM"].ToString();
                txtIsMerkeziTipi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["WCMDOCTYPE"].ToString();
                txtIsMerkeziKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["WCMDOCNUM"].ToString();
                txtOperasyonKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["OPRDOCTYPE"].ToString();
                txtOperasyonHazirlikSuresi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["SETUPTIME"].ToString();
                txtOperasyonMakineSuresi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["MACHINETIME"].ToString();
                txtOperasyonIscilikSuresi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["LABOURTIME"].ToString();

                DataTable tableBom = CRUD.Read("SELECT * FROM GRSROTBOMCONTENT");
                txtUrunAgaciTipi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["BOMDOCTYPE"].ToString();
                txtUrunAgaciKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["BOMDOCNUM"].ToString();
                txtIcerikNumarasi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["CONTENTNUM"].ToString();
                txtBilesenKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["COMPONENT"].ToString();
                txtBilesenMiktari.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["QUANTITY"].ToString();
            }
        }
    }
}
