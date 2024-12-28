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
            FillComboBox();
        }

        private void FillComboBox()
        {
            DataTable com = CRUD.Read("SELECT DISTINCT COMCODE FROM GRSGEN001");
            cbFirma.DataSource = com;
            cbFirma.DisplayMember = "COMCODE";
            cbFirma.ValueMember = "COMCODE";
            cbFirma.SelectedIndex = -1;

            DataTable mat = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSMAT001");
            cbMalzemeTipi.DataSource = mat;
            cbMalzemeTipi.DisplayMember = "DOCTYPE";
            cbMalzemeTipi.ValueMember = "DOCTYPE";
            cbMalzemeTipi.SelectedIndex = -1;

            DataTable msb = CRUD.Read("SELECT DISTINCT UNITCODE FROM GRSGEN005");
            cbMalzemeStokBirimi.DataSource = msb;
            cbMalzemeStokBirimi.DisplayMember = "UNITCODE";
            cbMalzemeStokBirimi.ValueMember = "UNITCODE";
            cbMalzemeStokBirimi.SelectedIndex = -1;

            DataTable nab = CRUD.Read("SELECT DISTINCT UNITCODE FROM GRSGEN005");
            cbNetAgirlikBirimi.DataSource = nab;
            cbNetAgirlikBirimi.DisplayMember = "UNITCODE";
            cbNetAgirlikBirimi.ValueMember = "UNITCODE";
            cbNetAgirlikBirimi.SelectedIndex = -1;

            DataTable bab = CRUD.Read("SELECT DISTINCT UNITCODE FROM GRSGEN005");
            cbBrutAgirlikBirimi.DataSource = bab;
            cbBrutAgirlikBirimi.DisplayMember = "UNITCODE";
            cbBrutAgirlikBirimi.ValueMember = "UNITCODE";
            cbBrutAgirlikBirimi.SelectedIndex = -1;

            DataTable bom = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSBOM001");
            cbUrunAgaciTipi.DataSource = bom;
            cbUrunAgaciTipi.DisplayMember = "DOCTYPE";
            cbUrunAgaciTipi.ValueMember = "DOCTYPE";
            cbUrunAgaciTipi.SelectedIndex = -1;

            DataTable rot = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSROT001");
            cbRotaTipi.DataSource = rot;
            cbRotaTipi.DisplayMember = "DOCTYPE";
            cbRotaTipi.ValueMember = "DOCTYPE";
            cbRotaTipi.SelectedIndex = -1;

            DataTable lan = CRUD.Read("SELECT DISTINCT LANCODE FROM GRSGEN002");
            cbFirma.DataSource = lan;
            cbFirma.DisplayMember = "LANCODE";
            cbFirma.ValueMember = "LANCODE";
            cbFirma.SelectedIndex = -1;
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

            if (!string.IsNullOrEmpty(cbFirma.Text)
                && !string.IsNullOrEmpty(cbMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtTedarikTipi.Text)
                && !string.IsNullOrEmpty(cbMalzemeStokBirimi.Text)               
                && !string.IsNullOrEmpty(cbDil.Text)               
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "MATDOCTYPE", cbMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "MATDOCFROM", dateTimePickerBaslangic.Text },
                    { "MATDOCUNTIL", dateTimePickerBitis.Text },
                    { "SUPPLYTYPE", txtTedarikTipi.Text },
                    { "STUNIT", cbMalzemeStokBirimi.Text },
                    { "NETWEIGHT", txtNetAgirlik.Text },
                    { "NWUNIT", cbNetAgirlikBirimi.Text },
                    { "BRUTWEIGHT", txtBrutAgirlik.Text },
                    { "BWUNIT", cbBrutAgirlikBirimi.Text },
                    { "ISBOM", txtUrunAgaciVarmi.Text },
                    { "BOMDOCTYPE", cbUrunAgaciTipi.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "ISROUTE", txtRotaVarmi.Text },
                    { "ROTDOCTYPE", cbRotaTipi.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "LANCODE", cbDil.Text },
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

            if (!string.IsNullOrEmpty(cbFirma.Text)
                && !string.IsNullOrEmpty(cbMalzemeTipi.Text)
                && !string.IsNullOrEmpty(txtMalzemeKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtTedarikTipi.Text)
                && !string.IsNullOrEmpty(cbMalzemeStokBirimi.Text)
                && !string.IsNullOrEmpty(cbDil.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "MATDOCTYPE", cbMalzemeTipi.Text },
                    { "MATDOCNUM", txtMalzemeKodu.Text },
                    { "MATDOCFROM", dateTimePickerBaslangic.Text },
                    { "MATDOCUNTIL", dateTimePickerBitis.Text },
                    { "SUPPLYTYPE", txtTedarikTipi.Text },
                    { "STUNIT", cbMalzemeStokBirimi.Text },
                    { "NETWEIGHT", txtNetAgirlik.Text },
                    { "NWUNIT", cbNetAgirlikBirimi.Text },
                    { "BRUTWEIGHT", txtBrutAgirlik.Text },
                    { "BWUNIT", cbBrutAgirlikBirimi.Text },
                    { "ISBOM", txtUrunAgaciVarmi.Text },
                    { "BOMDOCTYPE", cbUrunAgaciTipi.Text },
                    { "BOMDOCNUM", txtUrunAgaciKodu.Text },
                    { "ISROUTE", txtRotaVarmi.Text },
                    { "ROTDOCTYPE", cbRotaTipi.Text },
                    { "ROTDOCNUM", txtRotaKodu.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "LANCODE", cbDil.Text },
                    { "MATSTEXT", txtMalzemeAciklamasi.Text }
                };

                string condition = $"COMCODE = '{cbFirma.Text}'";
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
            if (!string.IsNullOrEmpty(cbFirma.Text))
            {
                string condition = $"COMCODE = '{cbFirma.Text}'";
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
                cbFirma.Text = row.Cells["COMCODE"].Value.ToString();
                cbMalzemeTipi.Text = row.Cells["MATDOCTYPE"].Value.ToString();
                txtMalzemeKodu.Text = row.Cells["MATDOCNUM"].Value.ToString();
                dateTimePickerBaslangic.Text = row.Cells["MATDOCFROM"].Value.ToString();
                dateTimePickerBitis.Text = row.Cells["MATDOCUNTIL"].Value.ToString();
                txtTedarikTipi.Text = row.Cells["SUPPLYTYPE"].Value.ToString();
                cbMalzemeStokBirimi.Text = row.Cells["STUNIT"].Value.ToString();
                txtNetAgirlik.Text = row.Cells["NETWEIGHT"].Value.ToString();
                cbNetAgirlikBirimi.Text = row.Cells["NWUNIT"].Value.ToString();
                txtBrutAgirlik.Text = row.Cells["BRUTWEIGHT"].Value.ToString();
                cbBrutAgirlikBirimi.Text = row.Cells["BWUNIT"].Value.ToString();
                txtUrunAgaciVarmi.Text = row.Cells["ISBOM"].Value.ToString();
                cbUrunAgaciTipi.Text = row.Cells["BOMDOCTYPE"].Value.ToString();
                txtUrunAgaciKodu.Text = row.Cells["BOMDOCNUM"].Value.ToString();
                txtRotaVarmi.Text = row.Cells["ISROUTE"].Value.ToString();
                cbRotaTipi.Text = row.Cells["ROTDOCTYPE"].Value.ToString();
                txtRotaKodu.Text = row.Cells["BOMDOCNUM"].Value.ToString();
                
                if (row.Cells["ISDELETED"].Value.ToString() == "1") checkBoxSilindimi.Checked = true;
                else checkBoxSilindimi.Checked = false;

                if (row.Cells["ISPASSIVE"].Value.ToString() == "1") checkBoxPasifmi.Checked = true;
                else checkBoxPasifmi.Checked = false;


                DataTable tableText = CRUD.Read("SELECT * FROM GRSMATTEXT");
                var firmakodu = cbFirma.Text;
                cbDil.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["LANCODE"].ToString();
                txtMalzemeAciklamasi.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["MATSTEXT"].ToString();
            }
        }
    }
}
