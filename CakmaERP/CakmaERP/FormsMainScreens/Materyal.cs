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
    public partial class Materyal : Form
    {
        public Materyal()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSMATHEAD");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["MATDOCTYPE"].HeaderText = "Malzeme Tipi";
            dataGridView1.Columns["MATDOCNUM"].HeaderText = "Malzeme Kodu";
            dataGridView1.Columns["MATDOCFROM"].HeaderText = "Geçerlilik Başlangıç Tarihi";
            dataGridView1.Columns["MATDOCUNTIL"].HeaderText = "Geçerlilik Bitiş Tarihi";
            dataGridView1.Columns["SUPPLYTYPE"].HeaderText = "Tedarik Tipi";
            dataGridView1.Columns["STUNIT"].HeaderText = "Malzeme Stok Birimi";
            dataGridView1.Columns["NETWEIGHT"].HeaderText = "Net Ağırlık";
            dataGridView1.Columns["NWUNIT"].HeaderText = "Net Ağırlık Birimi";
            dataGridView1.Columns["BRUTWEIGHT"].HeaderText = "Brüt Ağırlık";
            dataGridView1.Columns["BWUNIT"].HeaderText = "Brüt Ağırlık Birimi";
            dataGridView1.Columns["ISBOM"].HeaderText = "Ürün Ağacı Var Mı?";
            dataGridView1.Columns["BOMDOCTYPE"].HeaderText = "Ürün Ağacı Tipi";
            dataGridView1.Columns["BOMDOCNUM"].HeaderText = "Ürün Ağacı Kodu";
            dataGridView1.Columns["ISROUTE"].HeaderText = "Rota Var Mı?";
            dataGridView1.Columns["ROTDOCTYPE"].HeaderText = "Rota Tipi";
            dataGridView1.Columns["ROTDOCNUM"].HeaderText = "Rota Kodu";
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

            if (!string.IsNullOrEmpty(txtFirmaKodu.Text)
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtTedarikTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeStokBirimi.Text)               
                && !string.IsNullOrEmpty(txtDilKodu.Text)               
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "MATDOCTYPE", txtMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "MATDOCFROM", dateTimePickerBaslangic.Text },
                    { "MATDOCUNTIL", dateTimePickerBitis.Text },
                    { "SUPPLYTYPE", txtTedarikTipi.Text },
                    { "STUNIT", txtMalzemeStokBirimi.Text },
                    { "NETWEIGHT", txtNetAgirlik.Text },
                    { "NWUNIT", txtNetAgirlikBirimi.Text },
                    { "BRUTWEIGHT", txtBrutAgirlik.Text },
                    { "BWUNIT", txtBrutAgirlikBirimi.Text },
                    { "ISBOM", txtUrunAgaciVarmi.Text },
                    { "BOMDOCTYPE", txtUrunAgaciTipi.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "ISROUTE", txtRotaVarmi.Text },
                    { "ROTDOCTYPE", txtRotaTipi.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "LANCODE", txtDilKodu.Text },
                    { "MATSTEXT", txtMalzemeAciklamasi.Text }
                };

                CRUD.Create("GRSMATHEAD", dataHead);
                CRUD.Create("GRSMATTEXT", dataText);
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
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtTedarikTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeStokBirimi.Text)
                && !string.IsNullOrEmpty(txtDilKodu.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "MATDOCTYPE", txtMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "MATDOCFROM", dateTimePickerBaslangic.Text },
                    { "MATDOCUNTIL", dateTimePickerBitis.Text },
                    { "SUPPLYTYPE", txtTedarikTipi.Text },
                    { "STUNIT", txtMalzemeStokBirimi.Text },
                    { "NETWEIGHT", txtNetAgirlik.Text },
                    { "NWUNIT", txtNetAgirlikBirimi.Text },
                    { "BRUTWEIGHT", txtBrutAgirlik.Text },
                    { "BWUNIT", txtBrutAgirlikBirimi.Text },
                    { "ISBOM", txtUrunAgaciVarmi.Text },
                    { "BOMDOCTYPE", txtUrunAgaciTipi.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "ISROUTE", txtRotaVarmi.Text },
                    { "ROTDOCTYPE", txtRotaTipi.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "LANCODE", txtDilKodu.Text },
                    { "MATSTEXT", txtMalzemeAciklamasi.Text }
                };

                string condition = $"COMCODE = '{txtFirmaKodu.Text}'";
                CRUD.Update("GRSMATHEAD", dataHead, condition);
                CRUD.Update("GRSMATTEXT", dataText, condition);
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
                string condition = $"COMCODE = '{txtFirmaKodu.Text}'";
                CRUD.Delete("GRSMATHEAD", condition);
                CRUD.Delete("GRSMATTEXT", condition);
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
                txtMalzemeTipi.Text = row.Cells["MATDOCTYPE"].Value.ToString();
                txtMalzemeKodu.Text = row.Cells["MATDOCNUM"].Value.ToString();
                dateTimePickerBaslangic.Text = row.Cells["MATDOCFROM"].Value.ToString();
                dateTimePickerBitis.Text = row.Cells["MATDOCUNTIL"].Value.ToString();
                txtTedarikTipi.Text = row.Cells["SUPPLYTYPE"].Value.ToString();
                txtMalzemeStokBirimi.Text = row.Cells["STUNIT"].Value.ToString();
                txtNetAgirlik.Text = row.Cells["NETWEIGHT"].Value.ToString();
                txtNetAgirlikBirimi.Text = row.Cells["NWUNIT"].Value.ToString();
                txtBrutAgirlik.Text = row.Cells["BRUTWEIGHT"].Value.ToString();
                txtBrutAgirlikBirimi.Text = row.Cells["BWUNIT"].Value.ToString();
                txtUrunAgaciVarmi.Text = row.Cells["ISBOM"].Value.ToString();
                txtUrunAgaciTipi.Text = row.Cells["BOMDOCTYPE"].Value.ToString();
                txtUrunAgaciKodu.Text = row.Cells["BOMDOCNUM"].Value.ToString();
                txtRotaVarmi.Text = row.Cells["ISROUTE"].Value.ToString();
                txtRotaTipi.Text = row.Cells["ROTDOCTYPE"].Value.ToString();
                txtRotaKodu.Text = row.Cells["BOMDOCNUM"].Value.ToString();

                if (row.Cells["ISDELETED"].Value.ToString() == "1") checkBoxSilindimi.Checked = true;
                else checkBoxSilindimi.Checked = false;

                if (row.Cells["ISPASSIVE"].Value.ToString() == "1") checkBoxPasifmi.Checked = true;
                else checkBoxPasifmi.Checked = false;


                DataTable tableText = CRUD.Read("SELECT * FROM GRSMATTEXT");
                var firmakodu = txtFirmaKodu.Text;
                txtDilKodu.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["LANCODE"].ToString();
                txtMalzemeAciklamasi.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["MATSTEXT"].ToString();
            }
        }
    }
}
