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
using System.Diagnostics;

namespace TelloPlus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void extentionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            int i = 10;
            try
            {
                System.IO.Directory.CreateDirectory("files/extensions");
            }
            catch
            {
                MessageBox.Show("TelloPlus can't write in this directory, please run the program as administrator");
            }
            // Creates a button for each Extention detected (by looking at the extentions folder)
            foreach (var extention in System.IO.Directory.GetDirectories(@"files/extensions"))
            {
                var extentionName = new DirectoryInfo(extention).Name;
                Button extButton = new Button();
                extButton.Text = extentionName;
                extButton.Top = 5 + i;
                extButton.Left = 25;
                extButton.Width = 150;
                extButton.Click += (s, x) => 
                {
                    string name = (s as Button).Text;
                    string exePath = @"files\extensions\" + name + @"\start.bat";
                    
                    Process.Start(exePath);
                    
                };
                panel1.Controls.Add(extButton);
                
                i = i + 30;

            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            installExtForm iEF = new installExtForm();
            iEF.ShowDialog();
        }
    }
}
