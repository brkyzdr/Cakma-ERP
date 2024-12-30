using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CakmaERP.FormsControlTables
{
    public partial class Sehir : Form
    {
        public Sehir()
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

            /*DataTable country = CRUD.Read("SELECT DISTINCT COUNTRYCODE FROM GRSGEN003");
            cbUlke.DataSource = country;
            cbUlke.DisplayMember = "COUNTRYCODE";
            cbUlke.ValueMember = "COUNTRYCODE";
            cbUlke.SelectedIndex = -1;*/
        }


        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSGEN004");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["CITYCODE"].HeaderText = "Şehir Kodu";
            dataGridView1.Columns["CITYTEXT"].HeaderText = "Şehir Adı";
            dataGridView1.Columns["COUNTRYCODE"].HeaderText = "Ülke Kodu";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbFirma.Text) 
                && !string.IsNullOrEmpty(txtSehirKodu.Text)
                )
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "CITYCODE", txtSehirKodu.Text },
                    { "CITYTEXT", txtSehirAdi.Text },
                    { "COUNTRYCODE", cbUlke.Text }
                };

                CRUD.Create("GRSGEN004", data);
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
            if (!string.IsNullOrEmpty(cbFirma.Text)
                && !string.IsNullOrEmpty(txtSehirKodu.Text)
                )
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "CITYCODE", txtSehirKodu.Text },
                    { "CITYTEXT", txtSehirAdi.Text },
                    { "COUNTRYCODE", cbUlke.Text }
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND CITYCODE = '{txtSehirKodu.Text}'";
                CRUD.Update("GRSGEN004", data, condition);
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
                string condition = $"COMCODE = '{cbFirma.Text}' AND CITYCODE = '{txtSehirKodu.Text}'";
                CRUD.Delete("GRSGEN004", condition);
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
                txtSehirKodu.Text = row.Cells["CITYCODE"].Value.ToString();
                txtSehirAdi.Text = row.Cells["CITYTEXT"].Value.ToString();
                cbUlke.Text = row.Cells["COUNTRYCODE"].Value.ToString();
            }
        }

        private void cbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFirma.SelectedValue != null)
            {
                // Seçilen firmanın ID'sini alın
                string selectedFirma = cbFirma.SelectedValue.ToString();               

                // Seçilen firmaya göre COUNTRYCODE'ları doldur
                string countryQuery = $"SELECT DISTINCT COUNTRYCODE FROM GRSGEN003 WHERE COMCODE = '{selectedFirma}'";
                DataTable countryTable = CRUD.Read(countryQuery);
                cbUlke.DataSource = countryTable;
                cbUlke.DisplayMember = "COUNTRYCODE";
                cbUlke.ValueMember = "COUNTRYCODE";
                cbUlke.SelectedIndex = -1;
            }
            else
            {
                // Eğer firma seçimi temizlenirse diğer combobox'ları da temizle
                
                cbUlke.DataSource = null;
            }
        }
    }
}
