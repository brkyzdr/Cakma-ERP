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
using CakmaERP.FormsControlTables;
using CakmaERP.FormsMainScreens;

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

        #region CRUD class usage example
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
        #endregion

        #region Kontrol Tabloları Buttons
        private void btnFirma_Click(object sender, EventArgs e)
        {
            Firma firma = new Firma();
            firma.Show();
        }
        
        private void btnBirim_Click(object sender, EventArgs e)
        {
            Birim birim = new Birim();
            birim.Show();
        }

        private void btnDil_Click(object sender, EventArgs e)
        {
            Dil dil = new Dil();
            dil.Show();
        }

        private void btnMalzemeTipi_Click(object sender, EventArgs e)
        {
            MalzemeTipi malzemeTipi = new MalzemeTipi();
            malzemeTipi.Show();
        }

        private void btnUlke_Click(object sender, EventArgs e)
        {
            Ulke ulke = new Ulke(); 
            ulke.Show();
        }

        private void btnMaliyetMerkeziKontrol_Click(object sender, EventArgs e)
        {
            MaliyetMerkeziKontrol maliyetMerkeziKontrol =new MaliyetMerkeziKontrol();
            maliyetMerkeziKontrol.Show();
        }

        private void btnSehir_Click(object sender, EventArgs e)
        {
            Sehir sehir = new Sehir();
            sehir.Show();        
        }

        private void btnUrunAgaciKontrol_Click(object sender, EventArgs e)
        {
            UrunAgaciKontrol urunAgaciKontrol =new UrunAgaciKontrol();
            urunAgaciKontrol.Show();
        }

        private void btnRotaTipi_Click(object sender, EventArgs e)
        {
            RotaTipi rotaTipi =new RotaTipi();  
            rotaTipi.Show();
        }
        
        private void btnIsMerkeziTipi_Click(object sender, EventArgs e)
        {
            IsMerkeziTipi isMerkeziTipi =new IsMerkeziTipi();
            isMerkeziTipi.Show();
        }

        private void btnOperasyonTipi_Click(object sender, EventArgs e)
        {
            OperasyonTipi operasyonTipi =new OperasyonTipi();
            operasyonTipi.Show();
        }
        #endregion

        #region Ana Ekranlar Buttons
        private void btnUrunAgaci_Click(object sender, EventArgs e)
        {
            UrunAgaci urunAgaci =new UrunAgaci();
            urunAgaci.Show();
        }
        #endregion
    }
}