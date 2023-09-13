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
        }

        /*private void btnAbrir_Click(object sender, EventArgs e)
        {
            string[] lines;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de texto|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lines = File.ReadAllLines(openFileDialog.FileName);
                arbolito.Nodes.Clear();
                TreeNode fatherNode = null;
                int previousLevel = -1;
                foreach (string line in lines)
                {
                    int level = 0; ;

                    while (line[level] == '.')
                        level++;

                    string textNode = line.TrimStart('.');
                    TreeNode newNode = new TreeNode(textNode);

                    if (level == previousLevel)
                    {
                        if (fatherNode != null)
                        {
                            fatherNode.Parent.Nodes.Add(newNode);
                        }
                    }
                    else if (level > previousLevel)
                    {
                        if (fatherNode != null)
                        {
                            fatherNode.Nodes.Add(newNode);
                        }
                    }
                    else
                    {
                        for (int i = previousLevel; i >= level; i--)
                            fatherNode = fatherNode.Parent;
                        fatherNode.Parent.Nodes.Add(newNode);
                    }
                    fatherNode = newNode;
                    previousLevel = level;
                }
            }

        }*/


        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string[] lines;

            OpenFileDialog openFileDialog = new OpenFileDialog();   

            openFileDialog.Filter = "Archivos de texto|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lines = File.ReadAllLines(openFileDialog.FileName);
                arbolito.Nodes.Clear();
                foreach (string line in lines)
                {
                    TreeNode fatherNode = null;
                    string[] nodes = line.Split('.');
                    /*if (nodes[0] != "")
                        fatherNode = null;
                    else
                        fatherNode = new TreeNode(nodes[0].Trim());*/
                    foreach (string textNode in nodes)
                    {
                        TreeNode newNode = new TreeNode(textNode.Trim());
                        if (fatherNode == null)
                        {
                             arbolito.Nodes.Add(newNode);
                             fatherNode = newNode;
                        }
                        else
                        {
                             fatherNode.Nodes.Add(newNode);
                             fatherNode = newNode;
                        }
                    }
                }
            }

        }


    }
}

