using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArbolCastilloCorpus_CastilloPardo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ImageList imageList = new ImageList();
            imageList.Images.Add(Image.FromFile(@"C:\Users\Francisco Castillo.000\Downloads\documentsfolderblank_99359.png"));
            imageList.Images.Add(Image.FromFile(@"C:\Users\Francisco Castillo.000\Downloads\downloadfolderblank_99350.png"));
            arbolito.ImageList = imageList;
            arbolito.ImageIndex = 0;
            arbolito.SelectedImageIndex = 1;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string[] lines;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de texto|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                arbolito.Nodes.Clear();
                lines = File.ReadAllLines(openFileDialog.FileName);
             
                foreach (string line in lines) 
                {
                    int level = 0;
                    TreeNode node = arbolito.TopNode;
                    addNode(line,node,level);
                }
            }
        }
        private void addNode(string line, TreeNode node, int level)
        {
            if (!line[0].Equals('.'))
            {
                string nodeName = line;
                TreeNode newNode = new TreeNode(nodeName);
                if (level == 0)
                    arbolito.Nodes.Add(newNode);
                else
                    node.Nodes.Add(newNode);
                node = newNode;
            }
            else
            {
                level++;
                string newLine = line.Substring(1).Trim();
                if (level > 1)
                {
                    node = node.FirstNode; //arbolito.TopNode.FirstNode
                    addNode(newLine, node, level);
                }
                else
                {
                    addNode(newLine, node, level);
                }
                
            }
        }


    }


}


