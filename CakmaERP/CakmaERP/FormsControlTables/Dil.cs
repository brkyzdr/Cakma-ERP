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
    public partial class Dil : Form
    {
        public Dil()
        {
            InitializeComponent();

            //LoadData();
        }
        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM BSMGR0GEN002");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["LANCODE"].HeaderText = "Dil Kodu";
            dataGridView1.Columns["LANTEXT"].HeaderText = "Dil Adı";
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text) 
                && !string.IsNullOrEmpty(txtDilKodu.Text)
                && !string.IsNullOrEmpty(txtDilAdi.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "LANCODE", txtDilKodu.Text },
                    { "LANTEXT", txtDilAdi.Text }
                };

                CRUD.Create("BSMGR0GEN002", data);
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
                && !string.IsNullOrEmpty(txtDilKodu.Text)
                && !string.IsNullOrEmpty(txtDilAdi.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "LANCODE", txtDilKodu.Text },
                    { "LANTEXT", txtDilAdi.Text }
                };

                string condition = $"COMCODE = '{txtFirmaKodu.Text}'";
                CRUD.Update("BSMGR0GEN002", data, condition);
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
                CRUD.Delete("BSMGR0GEN002", condition);
                MessageBox.Show("Firma başarıyla silindi.");
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
                txtDilKodu.Text = row.Cells["LANCODE"].Value.ToString();
                txtDilAdi.Text = row.Cells["LANTEXT"].Value.ToString();
            }
        }
    }
}
