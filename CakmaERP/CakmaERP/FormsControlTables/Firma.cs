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
    public partial class Firma : Form
    {
        public Firma()
        {
            InitializeComponent();

            LoadData();
        }
        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM BSMGR0GEN001");
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
                && !string.IsNullOrEmpty(txtFirmaAdi.Text)
                && !string.IsNullOrEmpty(txtFirmaAdresi1.Text)
                && !string.IsNullOrEmpty(txtFirmaAdresi2.Text)
                && !string.IsNullOrEmpty(txtSehirKodu.Text)
                && !string.IsNullOrEmpty(txtUlkeKodu.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", txtFirmaKodu.Text },
                    { "COMTEXT", txtFirmaAdi.Text },
                    { "ADDRESS1", txtFirmaAdresi1.Text },
                    { "ADDRESS2", txtFirmaAdresi2.Text },
                    { "CITYCODE", txtSehirKodu.Text },
                    { "COUNTRYCODE", txtUlkeKodu.Text }
                };

                CRUD.Create("BSMGR0GEN001", data);
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
                && !string.IsNullOrEmpty(txtFirmaAdi.Text)
                && !string.IsNullOrEmpty(txtFirmaAdresi1.Text)
                && !string.IsNullOrEmpty(txtFirmaAdresi2.Text)
                && !string.IsNullOrEmpty(txtSehirKodu.Text)
                && !string.IsNullOrEmpty(txtUlkeKodu.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "COMTEXT", txtFirmaAdi.Text },
                    { "ADDRESS1", txtFirmaAdresi1.Text },
                    { "ADDRESS2", txtFirmaAdresi2.Text },
                    { "CITYCODE", txtSehirKodu.Text },
                    { "COUNTRYCODE", txtUlkeKodu.Text }
                    
                };

                string condition = $"COMCODE = '{txtFirmaKodu.Text}'";
                CRUD.Update("BSMGR0GEN001", data, condition);
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
                CRUD.Delete("BSMGR0GEN001", condition);
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
                txtSehirKodu.Text = row.Cells["CITYCODE"].Value.ToString();
                txtUlkeKodu.Text = row.Cells["COUNTRYCODE"].Value.ToString();
            }
        }
    }
}
