﻿using System;
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
    public partial class Ulke : Form
    {
        public Ulke()
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
            DataTable dataTable = CRUD.Read("SELECT * FROM GRSGEN003");
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns["COMCODE"].HeaderText = "Firma Kodu";
            dataGridView1.Columns["COUNTRYCODE"].HeaderText = "Ülke Kodu";
            dataGridView1.Columns["COUNTRYTEXT"].HeaderText = "Ülke Adı";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbFirma.Text) 
                && !string.IsNullOrEmpty(txtUlkeKodu.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "COUNTRYCODE", txtUlkeKodu.Text },
                    { "COUNTRYTEXT", txtUlkeAdi.Text }
                };

                CRUD.Create("GRSGEN003", data);
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
                && !string.IsNullOrEmpty(txtUlkeKodu.Text))
            {
                var data = new Dictionary<string, object>
                {
                    { "COMCODE", cbFirma.Text },
                    { "COUNTRYCODE", txtUlkeKodu.Text },
                    { "COUNTRYTEXT", txtUlkeAdi.Text }
                };

                string condition = $"COMCODE = '{cbFirma.Text}' AND COUNTRYCODE = '{txtUlkeKodu.Text}'";
                CRUD.Update("GRSGEN003", data, condition);
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
                string condition = $"COMCODE = '{cbFirma.Text}'AND COUNTRYCODE = '{txtUlkeKodu.Text}'";
                CRUD.Delete("GRSGEN003", condition);
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
                txtUlkeKodu.Text = row.Cells["COUNTRYCODE"].Value.ToString();
                txtUlkeAdi.Text = row.Cells["COUNTRYTEXT"].Value.ToString();
            }
        }
    }
}
