using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CakmaERP.FormsControlTables
{
    public partial class Firma : Form
    {
        public Firma()
        {
            InitializeComponent();

            LoadData();
            //FillComboBox();//Normalde firma kodunu dolduruyoruz sadece
            txtFirmaKodu.TextChanged += txtFirmaKodu_TextChanged;
        }
        private void FillComboBox()
        {
            /*string query = "SELECT DISTINCT FIRMA FROM YourFirmaTable"; // FIRMA bilgilerini sorgula
            DataTable firmaTable = CRUD.Read(query);

            cbFirma.DataSource = firmaTable;
            cbFirma.DisplayMember = "FIRMA"; // Gösterilecek değer
            cbFirma.ValueMember = "FIRMA";   // Seçimde kullanılacak değer
            cbFirma.SelectedIndex = -1;      // Varsayılan olarak boş göster*/
        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSGEN001");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["COMTEXT"].HeaderText = "Firma Adı";
            dataGridView1.Columns["ADDRESS1"].HeaderText = "Firma Adresi-1";
            dataGridView1.Columns["ADDRESS2"].HeaderText = "Firma Adresi-2";
            dataGridView1.Columns["CITYCODE"].HeaderText = "Şehir Kodu";
            dataGridView1.Columns["COUNTRYCODE"].HeaderText = "Ülke Kodu";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text) 
                && !string.IsNullOrEmpty(txtFirmaAdi.Text))
            {
                var data = new Dictionary<string, object> { };
                if (cbUlkeKodu.Text=="" )
                {
                    data = new Dictionary<string, object>
                    {
                        { "COMCODE", txtFirmaKodu.Text },
                        { "COMTEXT", txtFirmaAdi.Text },
                        { "ADDRESS1", txtFirmaAdresi1.Text },
                        { "ADDRESS2", txtFirmaAdresi2.Text },
                     };
                }
                else
                {
                    data = new Dictionary<string, object>
                    {
                        { "COMCODE", txtFirmaKodu.Text },
                        { "COMTEXT", txtFirmaAdi.Text },
                        { "ADDRESS1", txtFirmaAdresi1.Text },
                        { "ADDRESS2", txtFirmaAdresi2.Text },
                        { "CITYCODE", cbSehirKodu.Text },
                        { "COUNTRYCODE", cbUlkeKodu.Text }
                    };
                }
                

                CRUD.Create("GRSGEN001", data);
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
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text)
                && !string.IsNullOrEmpty(txtFirmaAdi.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "COMTEXT", txtFirmaAdi.Text },
                    { "ADDRESS1", txtFirmaAdresi1.Text },
                    { "ADDRESS2", txtFirmaAdresi2.Text },
                    { "CITYCODE", cbSehirKodu.Text },
                    { "COUNTRYCODE", cbUlkeKodu.Text }
                    
                };

                string condition = $"COMCODE = '{txtFirmaKodu.Text}'";
                CRUD.Update("GRSGEN001", data, condition);
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
                CRUD.Delete("GRSGEN001", condition);
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
                txtFirmaAdi.Text = row.Cells["COMTEXT"].Value.ToString();
                txtFirmaAdresi1.Text = row.Cells["ADDRESS1"].Value.ToString();
                txtFirmaAdresi2.Text = row.Cells["ADDRESS2"].Value.ToString();
                cbSehirKodu.Text = row.Cells["CITYCODE"].Value.ToString();
                cbUlkeKodu.Text = row.Cells["COUNTRYCODE"].Value.ToString();
            }
        }

        private void txtFirmaKodu_TextChanged(object sender, EventArgs e)
        {
            if (txtFirmaKodu.Text!= null)
            {
                // Seçilen firmanın ID'sini alın
                string selectedFirma = txtFirmaKodu.Text;

                // Seçilen firmaya göre CITYCODE'ları doldur
                string cityQuery = $"SELECT DISTINCT CITYCODE FROM GRSGEN004 WHERE COMCODE = '{selectedFirma}'";
                DataTable cityTable = CRUD.Read(cityQuery);
                cbSehirKodu.DataSource = cityTable;
                cbSehirKodu.DisplayMember = "CITYCODE";
                cbSehirKodu.ValueMember = "CITYCODE";
                cbSehirKodu.SelectedIndex = -1;

                // Seçilen firmaya göre COUNTRYCODE'ları doldur
                string countryQuery = $"SELECT DISTINCT COUNTRYCODE FROM GRSGEN003 WHERE COMCODE = '{selectedFirma}'";
                DataTable countryTable = CRUD.Read(countryQuery);
                cbUlkeKodu.DataSource = countryTable;
                cbUlkeKodu.DisplayMember = "COUNTRYCODE";
                cbUlkeKodu.ValueMember = "COUNTRYCODE";
                cbUlkeKodu.SelectedIndex = -1;
            }
            else
            {
                // Eğer firma seçimi temizlenirse diğer combobox'ları da temizle
                cbSehirKodu.DataSource = null;
                cbUlkeKodu.DataSource = null;
            }
        }
    }
}
