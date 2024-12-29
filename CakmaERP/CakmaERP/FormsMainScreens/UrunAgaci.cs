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
    public partial class UrunAgaci : Form
    {
        public UrunAgaci()
        {
            InitializeComponent();

            LoadData();
            FillComboBox();
        }

        private void FillComboBox()
        {
            DataTable com = CRUD.Read("SELECT DISTINCT COMCODE FROM GRSGEN001");
            cbFirma.DataSource = com;
            cbFirma.DisplayMember = "COMCODE";
            cbFirma.ValueMember = "COMCODE";
            cbFirma.SelectedIndex = -1;

            DataTable bom = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSBOM001");
            cbUrunAgaci.DataSource = bom;
            cbUrunAgaci.DisplayMember = "DOCTYPE";
            cbUrunAgaci.ValueMember = "DOCTYPE";
            cbUrunAgaci.SelectedIndex = -1;

            DataTable mat = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSMAT001");
            cbMalzeme.DataSource = mat;
            cbMalzeme.DisplayMember = "DOCTYPE";
            cbMalzeme.ValueMember = "DOCTYPE";
            cbMalzeme.SelectedIndex = -1;

            DataTable kbom = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSBOM001");
            cbKalemUrunAgaci.DataSource = kbom;
            cbKalemUrunAgaci.DisplayMember = "DOCTYPE";
            cbKalemUrunAgaci.ValueMember = "DOCTYPE";
            cbKalemUrunAgaci.SelectedIndex = -1;
        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSBOMHEAD");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["BOMDOCTYPE"].HeaderText = "Ürün Ağacı Tipi";
            dataGridView1.Columns["BOMDOCNUM"].HeaderText = "Ürün Ağacı Kodu";
            dataGridView1.Columns["BOMDOCFROM"].HeaderText = "Geçerlilik Başlangıç Tarihi";
            dataGridView1.Columns["BOMDOCUNTIL"].HeaderText = "Geçerlilik Bitiş Tarihi";
            dataGridView1.Columns["MATDOCTYPE"].HeaderText = "Malzeme Tipi";
            dataGridView1.Columns["MATDOCNUM"].HeaderText = "Malzeme Kodu";
            dataGridView1.Columns["QUANTITY"].HeaderText = "Temel Miktar";
            dataGridView1.Columns["DRAWNUM"].HeaderText = "Çizim Numarası";
            dataGridView1.Columns["ISDELETED"].HeaderText = "Silindi mi?";
            dataGridView1.Columns["ISPASSIVE"].HeaderText = "Pasif mi?";
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
                && !string.IsNullOrEmpty(cbUrunAgaci.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(cbMalzeme.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtTemelMiktar.Text)
                && !string.IsNullOrEmpty(txtIcerikNumarasi.Text)
                && !string.IsNullOrEmpty(txtBilesenKodu.Text)
                && !string.IsNullOrEmpty(cbKalemUrunAgaci.Text)
                && !string.IsNullOrEmpty(txtKalemUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(txtBilesenMiktari.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "BOMDOCTYPE", cbUrunAgaci.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "BOMDOCFROM", dateTimePickerBaslangic.Value },
                    { "BOMDOCUNTIL", dateTimePickerBitis.Value },
                    { "MATDOCTYPE", cbMalzeme.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "QUANTITY", txtTemelMiktar.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive},
                    { "DRAWNUM", txtCizimNumarasi.Text }
                };
                var dataContent = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "BOMDOCTYPE", cbUrunAgaci.Text },
                    { "CONTENTNUM", txtIcerikNumarasi.Text },
                    { "BOMDOCTYPE", cbUrunAgaci.Text },
                    { "COMPONENT", txtBilesenKodu.Text },
                    { "COMPBOMDOCTYPE", cbKalemUrunAgaci.Text },
                    { "COMPBOMDOCNUM", txtKalemUrunAgaciKodu.Text },
                    { "QUANTITY", txtBilesenMiktari.Text }
                };

                CRUD.Create("GRSBOMHEAD", dataHead);
                CRUD.Create("GRSBOMCONTENT", dataContent);
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
                && !string.IsNullOrEmpty(cbKalemUrunAgaci.Text)
                && !string.IsNullOrEmpty(txtUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(cbMalzeme.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(txtTemelMiktar.Text)
                && !string.IsNullOrEmpty(txtIcerikNumarasi.Text)
                && !string.IsNullOrEmpty(txtBilesenKodu.Text)
                && !string.IsNullOrEmpty(cbKalemUrunAgaci.Text)
                && !string.IsNullOrEmpty(txtKalemUrunAgaciKodu.Text)
                && !string.IsNullOrEmpty(txtBilesenMiktari.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "BOMDOCTYPE", cbUrunAgaci.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "BOMDOCFROM", dateTimePickerBaslangic.Value },
                    { "BOMDOCUNTIL", dateTimePickerBitis.Value },
                    { "MATDOCTYPE", cbMalzeme.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "QUANTITY", txtTemelMiktar.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive},
                    { "DRAWNUM", txtCizimNumarasi.Text }
                };
                var dataContent = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "CONTENTNUM", txtIcerikNumarasi.Text },
                    { "BOMDOCTYPE", cbUrunAgaci.Text },
                    { "COMPONENT", txtBilesenKodu.Text },
                    { "COMPBOMDOCTYPE", cbKalemUrunAgaci.Text },
                    { "COMPBOMDOCNUM", txtKalemUrunAgaciKodu.Text },
                    { "QUANTITY", txtBilesenMiktari.Text }
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND BOMDOCTYPE = '{cbUrunAgaci.Text}'";
                CRUD.Update("GRSBOMHEAD", dataHead, condition);
                CRUD.Update("GRSBOMCONTENT", dataContent, condition);
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
                string condition = $"COMCODE = '{cbFirma.Text}' AND BOMDOCTYPE = '{cbUrunAgaci.Text}'";
                CRUD.Delete("GRSBOMHEAD", condition);
                CRUD.Delete("GRSBOMCONTENT", condition);
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
                cbFirma.Text = row.Cells["COMCODE"].Value.ToString();
                cbUrunAgaci.Text = row.Cells["BOMDOCTYPE"].Value.ToString();
                txtUrunAgaciKodu.Text = row.Cells["BOMDOCNUM"].Value.ToString();
                dateTimePickerBaslangic.Text = row.Cells["BOMDOCFROM"].Value.ToString();
                dateTimePickerBitis.Text = row.Cells["BOMDOCUNTIL"].Value.ToString();
                cbMalzeme.Text = row.Cells["MATDOCTYPE"].Value.ToString();
                txtMalzemeKodu.Text = row.Cells["MATDOCNUM"].Value.ToString();
                txtTemelMiktar.Text = row.Cells["QUANTITY"].Value.ToString();
                txtCizimNumarasi.Text = row.Cells["DRAWNUM"].Value.ToString();

                if (row.Cells["ISDELETED"].Value.ToString() == "1") checkBoxSilindimi.Checked = true;
                else checkBoxSilindimi.Checked = false;

                if (row.Cells["ISPASSIVE"].Value.ToString() == "1") checkBoxPasifmi.Checked = true;
                else checkBoxPasifmi.Checked = false;

                //var firmakodu = cbFirma.Text;
                var firmakodu = row.Cells["COMCODE"].Value.ToString();
                if (firmakodu != "")
                {
                    DataTable tableContent = CRUD.Read("SELECT * FROM GRSBOMCONTENT");
                    txtIcerikNumarasi.Text = tableContent.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["CONTENTNUM"].ToString();
                    txtBilesenKodu.Text = tableContent.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["COMPONENT"].ToString();
                    cbKalemUrunAgaci.Text = tableContent.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["COMPBOMDOCTYPE"].ToString();
                    txtKalemUrunAgaciKodu.Text = tableContent.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["COMPBOMDOCNUM"].ToString();
                    txtBilesenMiktari.Text = tableContent.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["QUANTITY"].ToString();
                }
                else
                {
                    txtIcerikNumarasi.Text = "";
                    txtBilesenKodu.Text = "";
                    cbKalemUrunAgaci.Text = "";
                    txtKalemUrunAgaciKodu.Text = "";
                    txtBilesenMiktari.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunAgaciSeviyeleri urunAgaciSeviyeleri = new UrunAgaciSeviyeleri();
            urunAgaciSeviyeleri.Show();
        }
    }
}
