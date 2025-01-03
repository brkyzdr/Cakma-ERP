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
            /*DataTable com = CRUD.Read("SELECT DISTINCT COMCODE FROM GRSGEN001");
            cbFirma.DataSource = com;
            cbFirma.DisplayMember = "COMCODE";
            cbFirma.ValueMember = "COMCODE";
            cbFirma.SelectedIndex = -1;*/

            DataTable com = CRUD.Read("SELECT DISTINCT BOMDOCTYPE FROM GRSMATHEAD");
            cbFirma.DataSource = com;
            cbFirma.DisplayMember = "BOMDOCTYPE";
            cbFirma.ValueMember = "BOMDOCTYPE";
            cbFirma.SelectedIndex = -1;
        }
        private void UrunAgaciSeviyeleri_Load(object sender, EventArgs e)
        {
        }
        /*
        private void LoadTreeView(string bomdoctype)
        {
            treeView1.Nodes.Clear(); // Mevcut düğümleri temizle
            string query = $"SELECT * FROM GRSMATHEAD WHERE BOMDOCTYPE = '{bomdoctype}'";
            //string query = $"SELECT * FROM GRSBOMHEAD WHERE COMCODE = '{firmaAdi}'";
            DataTable dt = CRUD.Read(query);

            Dictionary<string, TreeNode> nodeDict = new Dictionary<string, TreeNode>();
            int supplytype = 2;

            foreach (DataRow row in dt.Rows)
            {
                string matdocnum=row["MATDOCNUM"].ToString();
                string id = row["BOMDOCNUM"].ToString();
                supplytype = Convert.ToInt32(row["SUPPLYTYPE"]);
                string name = "FK: "+row["COMCODE"].ToString()+", Malzeme Kodu: "+matdocnum+"";
                TreeNode node = new TreeNode(name) { Tag = id };
                nodeDict[id] = node;

                if (id.Contains("-"))
                {
                    string parentId = id.Substring(0, id.LastIndexOf('-'));
                    if (nodeDict.ContainsKey(parentId)&& supplytype==1)
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
        */

        private void LoadTreeView(string bomdoctype)
        {
            treeView1.Nodes.Clear(); // Mevcut düğümleri temizle
            string query = $"SELECT * FROM GRSMATHEAD WHERE BOMDOCTYPE = '{bomdoctype}'";
            DataTable dt = CRUD.Read(query);

            Dictionary<string, TreeNode> nodeDict = new Dictionary<string, TreeNode>();

            foreach (DataRow row in dt.Rows)
            {
                string matdocnum = row["MATDOCNUM"].ToString();
                string id = row["BOMDOCNUM"].ToString();
                int supplytype = Convert.ToInt32(row["SUPPLYTYPE"]);
                string name = "FK: " + row["COMCODE"].ToString() + ", Malzeme Kodu: " + matdocnum;

                TreeNode node = new TreeNode(name) { Tag = id };
                nodeDict[id] = node;

                if (id.Contains("-"))
                {
                    string parentId = id.Substring(0, id.LastIndexOf('-'));

                    // Eğer parentId mevcutsa ve SUPPLYTYPE kontrolüne göre eklenmeliyse
                    if (nodeDict.ContainsKey(parentId))
                    {
                        if (supplytype == 1)
                        {
                            nodeDict[parentId].Nodes.Add(node); // SUPPLYTYPE 1 ise çocuk eklenebilir
                        }
                        else if (supplytype == 0)
                        {
                            nodeDict[parentId].Nodes.Add(node); // SUPPLYTYPE 0 ise sadece düğüm eklenir
                            node.Nodes.Clear(); // Çocuklarını eklememek için mevcut düğümleri temizle
                        }
                    }
                }
                else
                {
                    // Ana düğümler doğrudan eklenir
                    treeView1.Nodes.Add(node);
                }
            }

            // SUPPLYTYPE 0 olan düğümlerin alt düğümlerini kaldır
            foreach (DataRow row in dt.Rows)
            {
                string id = row["BOMDOCNUM"].ToString();
                int supplytype = Convert.ToInt32(row["SUPPLYTYPE"]);

                if (supplytype == 0 && nodeDict.ContainsKey(id))
                {
                    nodeDict[id].Nodes.Clear(); // Çocuk düğümleri temizle
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
