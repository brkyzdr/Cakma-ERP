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
    public partial class MaliyetMerkezi : Form
    {
        public MaliyetMerkezi()
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

            DataTable ccm = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSCCM001");
            cbMaliyetM.DataSource = ccm;
            cbMaliyetM.DisplayMember = "DOCTYPE";
            cbMaliyetM.ValueMember = "DOCTYPE";
            cbMaliyetM.SelectedIndex = -1;

            DataTable lan = CRUD.Read("SELECT DISTINCT LANCODE FROM GRSGEN002");
            cbDil.DataSource = lan;
            cbDil.DisplayMember = "LANCODE";
            cbDil.ValueMember = "LANCODE";
            cbDil.SelectedIndex = -1;
        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSCCMHEAD");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["CCMDOCTYPE"].HeaderText = "Maliyet Merkezi Tipi";
            dataGridView1.Columns["CCMDOCNUM"].HeaderText = "Maliyet Merkezi Kodu";
            dataGridView1.Columns["CCMDOCFROM"].HeaderText = "Geçerlilik Başlangıç Tarihi";
            dataGridView1.Columns["CCMDOCUNTIL"].HeaderText = "Geçerlilik Bitiş Tarihi";
            dataGridView1.Columns["MAINCCMDOCTYPE"].HeaderText = "Ana Maliyet Merkezi Tipi";
            dataGridView1.Columns["MAINCCMDOCNUM"].HeaderText = "Ana Maliyet Merkezi Kodu";
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
                && !string.IsNullOrEmpty(cbMaliyetM.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtAnaMaliyetMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtAnaMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(cbDil.Text)
                && !string.IsNullOrEmpty(txtMaliyetAciklamasi.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "CCMDOCTYPE", cbMaliyetM.Text },
                    { "CCMDOCNUM", txtMaliyetMerkeziKodu.Text },
                    { "CCMDOCFROM", dateTimePickerBaslangic.Value },
                    { "CCMDOCUNTIL", dateTimePickerBitis.Value },
                    { "MAINCCMDOCTYPE", txtAnaMaliyetMerkeziTipi.Text },
                    { "MAINCCMDOCNUM", txtAnaMaliyetMerkeziKodu.Text },                  
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "CCMDOCTYPE", cbMaliyetM.Text },
                    { "LANCODE", cbDil.Text },
                };               

                CRUD.Create("GRSCCMHEAD", dataHead);
                CRUD.Create("GRSCCMTEXT", dataText);
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
                && !string.IsNullOrEmpty(cbMaliyetM.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtAnaMaliyetMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtAnaMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(cbDil.Text)
                && !string.IsNullOrEmpty(txtMaliyetAciklamasi.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "CCMDOCTYPE", cbMaliyetM.Text },
                    { "CCMDOCNUM", txtMaliyetMerkeziKodu.Text },
                    { "CCMDOCFROM", dateTimePickerBaslangic.Value },
                    { "CCMDOCUNTIL", dateTimePickerBitis.Value },
                    { "MAINCCMDOCTYPE", txtAnaMaliyetMerkeziTipi.Text },
                    { "MAINCCMDOCNUM", txtAnaMaliyetMerkeziKodu.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "CCMDOCTYPE", cbMaliyetM.Text },
                    { "LANCODE", cbDil.Text },
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND CCMDOCTYPE = '{cbMaliyetM.Text}'";
                CRUD.Update("GRSCCMHEAD", dataHead, condition);
                CRUD.Update("GRSCCMTEXT", dataText, condition);
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
                string condition = $"COMCODE = '{cbFirma.Text}' AND CCMDOCTYPE = '{cbMaliyetM.Text}'";
                CRUD.Delete("GRSCCMHEAD", condition);
                CRUD.Delete("GRSCCMTEXT", condition);
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
                cbMaliyetM.Text = row.Cells["CCMDOCTYPE"].Value.ToString();
                txtMaliyetMerkeziKodu.Text = row.Cells["CCMDOCNUM"].Value.ToString();
                dateTimePickerBaslangic.Text = row.Cells["CCMDOCFROM"].Value.ToString();
                dateTimePickerBitis.Text = row.Cells["CCMDOCUNTIL"].Value.ToString();
                txtAnaMaliyetMerkeziTipi.Text = row.Cells["MAINCCMDOCTYPE"].Value.ToString();
                txtAnaMaliyetMerkeziKodu.Text = row.Cells["MAINCCMDOCNUM"].Value.ToString();

                if (row.Cells["ISDELETED"].Value.ToString() == "1") checkBoxSilindimi.Checked = true;
                else checkBoxSilindimi.Checked = false;

                if (row.Cells["ISPASSIVE"].Value.ToString() == "1") checkBoxPasifmi.Checked = true;
                else checkBoxPasifmi.Checked = false;

                var firmakodu = row.Cells["COMCODE"].Value.ToString();
                if (firmakodu != "")
                {
                    DataTable tableText = CRUD.Read("SELECT * FROM GRSCCMTEXT");
                    cbDil.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["LANCODE"].ToString();
                    txtMaliyetAciklamasi.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["CCMSTEXT"].ToString();
                }
                else
                {
                    cbDil.Text = "";
                    txtMaliyetAciklamasi.Text = "";
                }
            }
        }
    }
}
