using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CakmaERP;

namespace CakmaERP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }





        //CRUD class usage example
        private void Create()
        {
            Dictionary<string, object> newData = new Dictionary<string, object>
            {
                { "Name", "Ali" },
                { "Age", 25 },
                { "Email", "ali@example.com" }
            };
            CRUD.Create("Employees", newData);
        }
        private void Read()
        {
            DataTable dataTable = CRUD.Read("SELECT * FROM Employees");
            //ex://dataGridView1.DataSource = dataTable;
        }
        private void Update()
        {
            Dictionary<string, object> updatedData = new Dictionary<string, object>
            {
                { "Name", "Veli" },
                { "Age", 30 }
            };
            CRUD.Update("Employees", updatedData, "Id = 1");
        }
        private void Delete()
        {
            CRUD.Delete("Employees", "Id = 1");
        }

        private void btnFirma_Click(object sender, EventArgs e)
        {

        }
    }
}
