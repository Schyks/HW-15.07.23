using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HW_15._07._23
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            ImageList imageListIcons = new ImageList();
            imageListIcons.Images.Add(Properties.Resources.icons8_file_50);
            imageListIcons.Images.Add(Properties.Resources.icons8_folder_48);
            treeView1.ImageList = imageListIcons;
        }

        private void Form1_Load(object sender, EventArgs e)
         {
             string desktopPath = "C:\\Users\\Schyks\\Desktop";
             LoadDeskFiles(desktopPath, treeView1.Nodes );
         }

         private void LoadDeskFiles(string path, TreeNodeCollection parentNodes)
         {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);
            
            foreach (string file in files)
                 {
                     parentNodes.Add(Path.GetFileName(file));
                 }
            foreach (string directory in directories)
            {
                TreeNode node = parentNodes.Add(Path.GetFileName(directory));
                node.ImageIndex = 1;
                LoadDeskFiles(directory, node.Nodes);
            }
        }
        }
    }

