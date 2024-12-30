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

namespace CakmaERP.FormsMainScreens
{
    public partial class UrunAgaciSeviyeleri : Form
    {
        public UrunAgaciSeviyeleri()
        {
            InitializeComponent();
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
        private void UrunAgaciSeviyeleri_Load(object sender, EventArgs e)
        {
        }

        private void LoadTreeView(string firmaAdi)
        {
            treeView1.Nodes.Clear(); // Mevcut düğümleri temizle
            string query = $"SELECT * FROM GRSBOMHEAD WHERE COMCODE = '{firmaAdi}'";
            DataTable dt = CRUD.Read(query);

            Dictionary<string, TreeNode> nodeDict = new Dictionary<string, TreeNode>();

            foreach (DataRow row in dt.Rows)
            {
                string id = row["BOMDOCNUM"].ToString();
                string name = row["BOMDOCTYPE"].ToString();

                TreeNode node = new TreeNode(name) { Tag = id };
                nodeDict[id] = node;

                if (id.Contains("-"))
                {
                    string parentId = id.Substring(0, id.LastIndexOf('-'));
                    if (nodeDict.ContainsKey(parentId))
                    {
                        nodeDict[parentId].Nodes.Add(node);
                    }
                }
                else
                {
                    treeView1.Nodes.Add(node);
                }
            }

            treeView1.ExpandAll(); // Tüm düğümleri genişlet
        }


        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void cbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFirma.SelectedValue != null)
            {
                string selectedFirma = cbFirma.SelectedValue.ToString();
                LoadTreeView(selectedFirma);
            }
        }
    }
}
