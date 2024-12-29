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
    public partial class MalzemeTipi : Form
    {
        public MalzemeTipi()
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
        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSMAT001");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["DOCTYPE"].HeaderText = "Malzeme Tipi";
            dataGridView1.Columns["DOCTYPETEXT"].HeaderText = "Malzeme Tipi Açıklaması";
            dataGridView1.Columns["ISPASSIVE"].HeaderText = "Pasif mi?";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int ispassive;
            if (checkBox1.Checked) ispassive = 1;
            else ispassive = 0;

            if (!string.IsNullOrEmpty(cbFirma.Text) 
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                )
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "DOCTYPE", txtMalzemeTipi.Text },
                    { "DOCTYPETEXT", txtMalzemeTipiAciklamasi.Text },
                    { "ISPASSIVE", ispassive }
                };

                CRUD.Create("GRSMAT001", data);
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
            if (checkBox1.Checked) ispassive = 1;             
            else ispassive = 0;

            if (!string.IsNullOrEmpty(cbFirma.Text)
                && !string.IsNullOrEmpty(txtMalzemeTipi.Text)
                )
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "DOCTYPE", txtMalzemeTipi.Text },
                    { "DOCTYPETEXT", txtMalzemeTipiAciklamasi.Text },
                    { "ISPASSIVE", ispassive }
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND DOCTYPE = '{txtMalzemeTipi.Text}'";
                CRUD.Update("GRSMAT001", data, condition);
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
                string condition = $"COMCODE = '{cbFirma.Text}' AND DOCTYPE = '{txtMalzemeTipi.Text}'";
                CRUD.Delete("GRSMAT001", condition);
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
                txtMalzemeTipi.Text = row.Cells["DOCTYPE"].Value.ToString();
                txtMalzemeTipiAciklamasi.Text = row.Cells["DOCTYPETEXT"].Value.ToString();

                if(row.Cells["ISPASSIVE"].Value.ToString()=="1") checkBox1.Checked = true;
                else checkBox1.Checked = false;              
            }
        }
    }
}
