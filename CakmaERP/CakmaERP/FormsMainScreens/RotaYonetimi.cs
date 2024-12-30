using CakmaERP.FormsControlTables;
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
            FillComboBox();
            cbFirma.SelectedIndexChanged += cbFirma_SelectedIndexChanged;

        }

        private void FillComboBox()
        {
            DataTable com = CRUD.Read("SELECT DISTINCT COMCODE FROM GRSGEN001");
            cbFirma.DataSource = com;
            cbFirma.DisplayMember = "COMCODE";
            cbFirma.ValueMember = "COMCODE";
            cbFirma.SelectedIndex = -1;

            /*DataTable rot = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSROT001");
            cbRota.DataSource = rot;
            cbRota.DisplayMember = "DOCTYPE";
            cbRota.ValueMember = "DOCTYPE";
            cbRota.SelectedIndex = -1;

            DataTable mat = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSMAT001");
            cbMalzeme.DataSource = mat;
            cbMalzeme.DisplayMember = "DOCTYPE";
            cbMalzeme.ValueMember = "DOCTYPE";
            cbMalzeme.SelectedIndex = -1;

            DataTable wcm = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSWCM001");
            cbIsMerkezi.DataSource = wcm;
            cbIsMerkezi.DisplayMember = "DOCTYPE";
            cbIsMerkezi.ValueMember = "DOCTYPE";
            cbIsMerkezi.SelectedIndex = -1;

            DataTable bom = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSBOM001");
            cbUrunAgaci.DataSource = bom;
            cbUrunAgaci.DisplayMember = "DOCTYPE";
            cbUrunAgaci.ValueMember = "DOCTYPE";
            cbUrunAgaci.SelectedIndex = -1;*/
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

            if (!string.IsNullOrEmpty(cbFirma.Text)
                && !string.IsNullOrEmpty(cbRota.Text)
                && !string.IsNullOrEmpty(txtRotaKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(cbMalzeme.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtTemelMiktar.Text)
                && !string.IsNullOrEmpty(txtOperasyonNumarasi.Text)
                && !string.IsNullOrEmpty(cbIsMerkezi.Text)
                && !string.IsNullOrEmpty(txtIsMerkeziKodu.Text)
                && !string.IsNullOrEmpty(txtOperasyonKodu.Text)
                && !string.IsNullOrEmpty(cbUrunAgaci.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(txtIcerikNumarasi.Text)
                && !string.IsNullOrEmpty(txtBilesenKodu.Text)
                && !string.IsNullOrEmpty(txtBilesenMiktari.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "ROTDOCTYPE", cbRota.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ROTDOCFROM", dateTimePickerBaslangic.Value },
                    { "ROTDOCUNTIL", dateTimePickerBitis.Value },
                    { "MATDOCTYPE", cbMalzeme.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "QUANTITY", txtTemelMiktar.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive },
                    { "DRAWNUM", txtCizimNumarasi.Text }
                };
                var dataOpr = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "OPRNUM", txtOperasyonNumarasi.Text },
                    { "ROTDOCTYPE", cbRota.Text },
                    { "WCMDOCTYPE", cbIsMerkezi.Text },
                    { "WCMDOCNUM", txtIsMerkeziKodu.Text },
                    { "OPRDOCTYPE", txtOperasyonKodu.Text },
                    { "SETUPTIME", txtOperasyonHazirlikSuresi.Text },
                    { "MACHINETIME", txtOperasyonMakineSuresi.Text },
                    { "LABOURTIME", txtOperasyonIscilikSuresi.Text }
                };
                var dataBom = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "BOMDOCTYPE", cbUrunAgaci.Text },
                    { "ROTDOCTYPE", cbRota.Text },
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

            if (!string.IsNullOrEmpty(cbFirma.Text)
                && !string.IsNullOrEmpty(cbRota.Text)
                && !string.IsNullOrEmpty(txtRotaKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(cbMalzeme.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtTemelMiktar.Text)
                && !string.IsNullOrEmpty(txtOperasyonNumarasi.Text)
                && !string.IsNullOrEmpty(cbIsMerkezi.Text)
                && !string.IsNullOrEmpty(txtIsMerkeziKodu.Text)
                && !string.IsNullOrEmpty(txtOperasyonKodu.Text)
                && !string.IsNullOrEmpty(cbUrunAgaci.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(txtIcerikNumarasi.Text)
                && !string.IsNullOrEmpty(txtBilesenKodu.Text)
                && !string.IsNullOrEmpty(txtBilesenMiktari.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "ROTDOCTYPE", cbRota.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ROTDOCFROM", dateTimePickerBaslangic.Value },
                    { "ROTDOCUNTIL", dateTimePickerBitis.Value },
                    { "MATDOCTYPE", cbMalzeme.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "QUANTITY", txtTemelMiktar.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive },
                    { "DRAWNUM", txtCizimNumarasi.Text }
                };
                var dataOpr = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "OPRNUM", txtOperasyonNumarasi.Text },
                    { "ROTDOCTYPE", cbRota.Text },
                    { "WCMDOCTYPE", cbIsMerkezi.Text },
                    { "WCMDOCNUM", txtIsMerkeziKodu.Text },
                    { "OPRDOCTYPE", txtOperasyonKodu.Text },
                    { "SETUPTIME", txtOperasyonHazirlikSuresi.Text },
                    { "MACHINETIME", txtOperasyonMakineSuresi.Text },
                    { "LABOURTIME", txtOperasyonIscilikSuresi.Text }
                };
                var dataBom = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "BOMDOCTYPE", cbUrunAgaci.Text },
                    { "ROTDOCTYPE", cbRota.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "CONTENTNUM", txtIcerikNumarasi.Text },
                    { "COMPONENT", txtBilesenKodu.Text },
                    { "QUANTITY", txtBilesenMiktari.Text }
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND ROTDOCTYPE = '{cbRota.Text}'";
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
            if (!string.IsNullOrEmpty(cbFirma.Text))
            {
                string condition = $"COMCODE = '{cbFirma.Text}' AND ROTDOCTYPE = '{cbRota.Text}'";
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
                cbFirma.SelectedValue = row.Cells["COMCODE"].Value.ToString();
                cbRota.SelectedValue = row.Cells["ROTDOCTYPE"].Value.ToString();
                txtRotaKodu.Text = row.Cells["ROTDOCNUM"].Value.ToString();
                dateTimePickerBaslangic.Text = row.Cells["ROTDOCFROM"].Value.ToString();
                dateTimePickerBitis.Text = row.Cells["ROTDOCUNTIL"].Value.ToString();
                cbMalzeme.SelectedValue = row.Cells["MATDOCTYPE"].Value.ToString();
                txtMalzemeKodu.Text = row.Cells["MATDOCNUM"].Value.ToString();
                txtTemelMiktar.Text = row.Cells["QUANTITY"].Value.ToString();
                txtCizimNumarasi.Text = row.Cells["DRAWNUM"].Value.ToString();

                if (row.Cells["ISDELETED"].Value.ToString() == "1") checkBoxSilindimi.Checked = true;
                else checkBoxSilindimi.Checked = false;

                if (row.Cells["ISPASSIVE"].Value.ToString() == "1") checkBoxPasifmi.Checked = true;
                else checkBoxPasifmi.Checked = false;

                var firmakodu = row.Cells["COMCODE"].Value.ToString();
                if (firmakodu !="")
                {
                    DataTable tableOpr = CRUD.Read("SELECT * FROM GRSROTOPRCONTENT");
                    txtOperasyonNumarasi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["OPRNUM"].ToString();
                    cbIsMerkezi.SelectedValue = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["WCMDOCTYPE"].ToString();
                    txtIsMerkeziKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["WCMDOCNUM"].ToString();
                    txtOperasyonKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["OPRDOCTYPE"].ToString();
                    txtOperasyonHazirlikSuresi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["SETUPTIME"].ToString();
                    txtOperasyonMakineSuresi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["MACHINETIME"].ToString();
                    txtOperasyonIscilikSuresi.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["LABOURTIME"].ToString();

                    DataTable tableBom = CRUD.Read("SELECT * FROM GRSROTBOMCONTENT");
                    cbUrunAgaci.SelectedValue = tableBom.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["BOMDOCTYPE"].ToString();
                    txtUrunAgaciKodu.Text = tableBom.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["BOMDOCNUM"].ToString();
                    txtIcerikNumarasi.Text = tableBom.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["CONTENTNUM"].ToString();
                    txtBilesenKodu.Text = tableBom.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["COMPONENT"].ToString();
                    txtBilesenMiktari.Text = tableBom.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["QUANTITY"].ToString();
                }
                else
                {
                    txtOperasyonNumarasi.Text = "";
                    cbIsMerkezi.SelectedValue = "";
                    txtIsMerkeziKodu.Text = "";
                    txtOperasyonKodu.Text = "";
                    txtOperasyonHazirlikSuresi.Text = "";
                    txtOperasyonMakineSuresi.Text = "";
                    txtOperasyonIscilikSuresi.Text = "";

                    cbUrunAgaci.SelectedValue = "";
                    txtUrunAgaciKodu.Text = "";
                    txtIcerikNumarasi.Text = "";
                    txtBilesenKodu.Text = "";
                    txtBilesenMiktari.Text = "";
                }
            }
        }

        private void cbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFirma.SelectedValue != null)
            {
                // Seçilen firmanın ID'sini alın
                string selectedFirma = cbFirma.SelectedValue.ToString();

                // Seçilen firmaya göre COUNTRYCODE'ları doldur
                string rotQuery = $"SELECT DISTINCT DOCTYPE FROM GRSROT001 WHERE COMCODE = '{selectedFirma}'";
                DataTable rotTable = CRUD.Read(rotQuery);
                cbRota.DataSource = rotTable;
                cbRota.DisplayMember = "DOCTYPE";
                cbRota.ValueMember = "DOCTYPE";
                cbRota.SelectedIndex = -1;

                string wcmQuery = $"SELECT DISTINCT DOCTYPE FROM GRSWCM001 WHERE COMCODE = '{selectedFirma}'";
                DataTable wcmTable = CRUD.Read(wcmQuery);
                cbIsMerkezi.DataSource = wcmTable;
                cbIsMerkezi.DisplayMember = "DOCTYPE";
                cbIsMerkezi.ValueMember = "DOCTYPE";
                cbIsMerkezi.SelectedIndex = -1;

                string matQuery = $"SELECT DISTINCT DOCTYPE FROM GRSMAT001 WHERE COMCODE = '{selectedFirma}'";
                DataTable matTable = CRUD.Read(matQuery);
                cbMalzeme.DataSource = matTable;
                cbMalzeme.DisplayMember = "DOCTYPE";
                cbMalzeme.ValueMember = "DOCTYPE";
                cbMalzeme.SelectedIndex = -1;

                string bomQuery = $"SELECT DISTINCT DOCTYPE FROM GRSBOM001 WHERE COMCODE = '{selectedFirma}'";
                DataTable bomTable = CRUD.Read(bomQuery);
                cbUrunAgaci.DataSource = bomTable;
                cbUrunAgaci.DisplayMember = "DOCTYPE";
                cbUrunAgaci.ValueMember = "DOCTYPE";
                cbUrunAgaci.SelectedIndex = -1;
            }
            else
            {
                // Eğer firma seçimi temizlenirse diğer combobox'ları da temizle

                cbRota.DataSource = null;
                cbIsMerkezi.DataSource = null;
                cbMalzeme.DataSource = null;
                cbUrunAgaci.DataSource = null;
            }
        }
    }
}
