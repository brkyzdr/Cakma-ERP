using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CakmaERP.FormsMainScreens
{
    public partial class IsMerkezi : Form
    {
        public IsMerkezi()
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

            DataTable wcm = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSWCM001");
            cbIsMerkeziTipi.DataSource = wcm;
            cbIsMerkeziTipi.DisplayMember = "DOCTYPE";
            cbIsMerkeziTipi.ValueMember = "DOCTYPE";
            cbIsMerkeziTipi.SelectedIndex = -1;

            DataTable ccm = CRUD.Read("SELECT DISTINCT DOCTYPE FROM GRSCCM001");
            cbMaliyetMerkeziTipi.DataSource = ccm;
            cbMaliyetMerkeziTipi.DisplayMember = "DOCTYPE";
            cbMaliyetMerkeziTipi.ValueMember = "DOCTYPE";
            cbMaliyetMerkeziTipi.SelectedIndex = -1;

            DataTable lan = CRUD.Read("SELECT DISTINCT LANCODE FROM GRSGEN002");
            cbDilKodu.DataSource = lan;
            cbDilKodu.DisplayMember = "LANCODE";
            cbDilKodu.ValueMember = "LANCODE";
            cbDilKodu.SelectedIndex = -1;

        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSWCMHEAD");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["WCMDOCTYPE"].HeaderText = "İş Merkezi Tipi";
            dataGridView1.Columns["WCMDOCNUM"].HeaderText = "İş Merkezi Kodu";
            dataGridView1.Columns["WCMDOCFROM"].HeaderText = "Geçerlilik Başlangıç Tarihi";
            dataGridView1.Columns["WCMDOCUNTIL"].HeaderText = "Geçerlilik Bitiş Tarihi";
            dataGridView1.Columns["MAINWCMDOCTYPE"].HeaderText = "Ana İş Merkezi Tipi";
            dataGridView1.Columns["MAINWCMDOCNUM"].HeaderText = "Ana İş Merkezi Kodu";
            dataGridView1.Columns["CCMDOCTYPE"].HeaderText = "Maliyet Merkezi Tipi";
            dataGridView1.Columns["CCMDOCNUM"].HeaderText = "Maliyet Merkezi Kodu";
            dataGridView1.Columns["WORKTIME"].HeaderText = "Günlük Çalışma Saati";
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
                && !string.IsNullOrEmpty(cbIsMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtIsMerkeziKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtAnaIsMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtAnaIsMerkeziKodu.Text)
                && !string.IsNullOrEmpty(cbMaliyetMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(cbDilKodu.Text)
                && !string.IsNullOrEmpty(txtIsAciklamasi.Text)
                && !string.IsNullOrEmpty(txtOperasyonKodu.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "WCMDOCTYPE", cbIsMerkeziTipi.Text },
                    { "WCMDOCNUM", txtIsMerkeziKodu.Text },
                    { "WCMDOCFROM", dateTimePickerBaslangic.Value },
                    { "WCMDOCUNTIL", dateTimePickerBitis.Value },
                    { "MAINWCMDOCTYPE", txtAnaIsMerkeziTipi.Text },
                    { "MAINWCMDOCNUM", txtAnaIsMerkeziKodu.Text },
                    { "CCMDOCTYPE", cbMaliyetMerkeziTipi.Text },
                    { "CCMDOCNUM", txtMaliyetMerkeziKodu.Text },
                    { "WORKTIME", txtGunlukCalismaSatti.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "WCMDOCTYPE", cbIsMerkeziTipi.Text },
                    { "LANCODE", cbDilKodu.Text },
                    { "WCMSTEXT", txtIsAciklamasi.Text }
                };
                var dataOpr = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "WCMDOCTYPE", cbIsMerkeziTipi.Text },
                    { "OPRDOCTYPE", txtOperasyonKodu.Text }
                };

                CRUD.Create("GRSWCMHEAD", dataHead);
                CRUD.Create("GRSWCMTEXT", dataText);
                CRUD.Create("GRSWCMOPR", dataOpr);
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
                && !string.IsNullOrEmpty(cbIsMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtIsMerkeziKodu.Text)
                && !string.IsNullOrEmpty(dateTimePickerBaslangic.Text)
                && !string.IsNullOrEmpty(dateTimePickerBitis.Text)
                && !string.IsNullOrEmpty(txtAnaIsMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtAnaIsMerkeziKodu.Text)
                && !string.IsNullOrEmpty(cbMaliyetMerkeziTipi.Text)
                && !string.IsNullOrEmpty(txtMaliyetMerkeziKodu.Text)
                && !string.IsNullOrEmpty(cbDilKodu.Text)
                && !string.IsNullOrEmpty(txtIsAciklamasi.Text)
                && !string.IsNullOrEmpty(txtOperasyonKodu.Text)
                )
            {
                var dataHead = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "WCMDOCTYPE", cbIsMerkeziTipi.Text },
                    { "WCMDOCNUM", txtIsMerkeziKodu.Text },
                    { "WCMDOCFROM", dateTimePickerBaslangic.Value },
                    { "WCMDOCUNTIL", dateTimePickerBitis.Value },
                    { "MAINWCMDOCTYPE", txtAnaIsMerkeziTipi.Text },
                    { "MAINWCMDOCNUM", txtAnaIsMerkeziKodu.Text },
                    { "CCMDOCTYPE", cbMaliyetMerkeziTipi.Text },
                    { "CCMDOCNUM", txtMaliyetMerkeziKodu.Text },
                    { "WORKTIME", txtGunlukCalismaSatti.Text },
                    { "ISDELETED", isdeleted },
                    { "ISPASSIVE", ispassive }
                };
                var dataText = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "WCMDOCTYPE", cbIsMerkeziTipi.Text },
                    { "LANCODE", cbDilKodu.Text },
                    { "WCMSTEXT", txtIsAciklamasi.Text }
                };
                var dataOpr = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "WCMDOCTYPE", cbIsMerkeziTipi.Text },
                    { "OPRDOCTYPE", txtOperasyonKodu.Text }
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND WCMDOCTYPE = '{cbIsMerkeziTipi.Text}'";
                CRUD.Update("GRSWCMHEAD", dataHead, condition);
                CRUD.Update("GRSWCMTEXT", dataText, condition);
                CRUD.Update("GRSWCMOPR", dataOpr, condition);
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
                string condition = $"COMCODE = '{cbFirma.Text}' AND WCMDOCTYPE = '{cbIsMerkeziTipi.Text}'";
                CRUD.Delete("GRSWCMHEAD", condition);
                CRUD.Delete("GRSWCMTEXT", condition);
                CRUD.Delete("GRSWCMOPR", condition);
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
                cbIsMerkeziTipi.Text = row.Cells["WCMDOCTYPE"].Value.ToString();
                txtIsMerkeziKodu.Text = row.Cells["WCMDOCNUM"].Value.ToString();
                dateTimePickerBaslangic.Text = row.Cells["WCMDOCFROM"].Value.ToString();
                dateTimePickerBitis.Text = row.Cells["WCMDOCUNTIL"].Value.ToString();
                txtAnaIsMerkeziTipi.Text = row.Cells["MAINWCMDOCTYPE"].Value.ToString();
                txtAnaIsMerkeziKodu.Text = row.Cells["MAINWCMDOCNUM"].Value.ToString();
                cbMaliyetMerkeziTipi.Text = row.Cells["CCMDOCTYPE"].Value.ToString();
                txtMaliyetMerkeziKodu.Text = row.Cells["CCMDOCNUM"].Value.ToString();
                txtGunlukCalismaSatti.Text = row.Cells["WORKTIME"].Value.ToString();

                if (row.Cells["ISDELETED"].Value.ToString() == "1") checkBoxSilindimi.Checked = true;
                else checkBoxSilindimi.Checked = false;

                if (row.Cells["ISPASSIVE"].Value.ToString() == "1") checkBoxPasifmi.Checked = true;
                else checkBoxPasifmi.Checked = false;

                var firmakodu = row.Cells["COMCODE"].Value.ToString();
                if (firmakodu != "")
                {
                    DataTable tableText = CRUD.Read("SELECT * FROM GRSWCMTEXT");
                    DataTable tableOpr = CRUD.Read("SELECT * FROM GRSWCMOPR");
                    cbDilKodu.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["LANCODE"].ToString();
                    txtIsAciklamasi.Text = tableText.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["WCMSTEXT"].ToString();
                    txtOperasyonKodu.Text = tableOpr.AsEnumerable().FirstOrDefault(r => r.Field<string>("COMCODE") == firmakodu)["OPRDOCTYPE"].ToString();
                }
                else
                {
                    cbDilKodu.Text = "";
                    txtIsAciklamasi.Text = "";
                    txtOperasyonKodu.Text = "";
                }
            }
        }
    }
}
