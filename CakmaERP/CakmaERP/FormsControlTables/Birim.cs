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

            //LoadData();
        }

        private void LoadData()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM Birim");//tablo güncellenecek
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text) && !string.IsNullOrEmpty(txtBirimKodu.Text))
            {
                var data = new Dictionary<string, object>//kolon isimleri ve textboxlar güncellenecek
                {
                    { "firma_kodu", txtFirmaKodu.Text },
                    { "birim_kodu", txtBirimKodu.Text }
                };

                CRUD.Create("Birim", data);
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
            if (!string.IsNullOrEmpty(txtFirmaKodu.Text) && !string.IsNullOrEmpty(txtBirimKodu.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "firma_aciklamasi", txtBirimKodu.Text }
                };

                string condition = $"firma_kodu = '{txtFirmaKodu.Text}'";
                CRUD.Update("Firma", data, condition);
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
                string condition = $"firma_kodu = '{txtFirmaKodu.Text}'";
                CRUD.Delete("Firma", condition);
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
                txtFirmaKodu.Text = row.Cells["firma_kodu"].Value.ToString();
                txtBirimKodu.Text = row.Cells["birim_kodu"].Value.ToString();
            }
        }
    }
}
