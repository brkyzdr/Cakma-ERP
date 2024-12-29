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
    public partial class Birim : Form
    {
        public Birim()
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
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSGEN005");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["UNITCODE"].HeaderText = "Birim Kodu";
            dataGridView1.Columns["UNITTEXT"].HeaderText = "Birim Adı";
            dataGridView1.Columns["ISMAINUNIT"].HeaderText = "Ana Ağırlık Birimi mi?";
            dataGridView1.Columns["MAINUNITCODE"].HeaderText = "Ana Ağırlık Birimi Kodu";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int ispassive;
            if (checkBox1.Checked) ispassive = 1;
            else ispassive = 0;

            var data = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(cbFirma.Text)
                && !string.IsNullOrEmpty(txtBirimKodu.Text)
                && !string.IsNullOrEmpty(txtBirimAdi.Text)
                )
            {
                if (txtAnaAgirlikBirimiKodu.Text == "")
                {
                    data = new Dictionary<string, object>
                    {
                        { "COMCODE", cbFirma.Text },
                        { "UNITCODE", txtBirimKodu.Text },
                        { "UNITTEXT", txtBirimAdi.Text },
                        { "ISMAINUNIT", ispassive}
                    };
                }
                else
                {
                    data = new Dictionary<string, object>
                    {
                        { "COMCODE", cbFirma.Text },
                        { "UNITCODE", txtBirimKodu.Text },
                        { "UNITTEXT", txtBirimAdi.Text },
                        { "ISMAINUNIT", ispassive},
                        { "MAINUNITCODE", txtAnaAgirlikBirimiKodu.Text }
                    };
                }
                CRUD.Create("GRSGEN005", data);
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
                && !string.IsNullOrEmpty(txtBirimKodu.Text)
                && !string.IsNullOrEmpty(txtBirimAdi.Text)
                )
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "UNITCODE", txtBirimKodu.Text },
                    { "UNITTEXT", txtBirimAdi.Text },
                    { "ISMAINUNIT", ispassive },
                    { "MAINUNITCODE", txtAnaAgirlikBirimiKodu.Text }
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND UNITCODE = '{txtBirimKodu.Text}'";
                CRUD.Update("GRSGEN005", data, condition);
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
                string condition = $"COMCODE = '{cbFirma.Text}' AND UNITCODE = '{txtBirimKodu.Text}'";
                CRUD.Delete("GRSGEN005", condition);
                MessageBox.Show("Veri başarıyla silindi.");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lütfen firma kodunu girin.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                cbFirma.Text = row.Cells["COMCODE"].Value.ToString();
                txtBirimKodu.Text = row.Cells["UNITCODE"].Value.ToString();
                txtBirimAdi.Text = row.Cells["UNITTEXT"].Value.ToString();

                if (row.Cells["ISMAINUNIT"].Value.ToString() == "1") checkBox1.Checked = true;
                else checkBox1.Checked = false;

                txtAnaAgirlikBirimiKodu.Text = row.Cells["MAINUNITCODE"].Value.ToString();
            }
        }
    }
}
