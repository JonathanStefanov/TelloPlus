using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Collections;
using System.IO.Compression;

namespace TelloPlus
{
    public partial class installExtForm : Form
    {
        public installExtForm()
        {
            InitializeComponent();
        }

        private void installExtForm_Load(object sender, EventArgs e)
        {
            int i = 10;
            try { 
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("http://telloplus.ml/api/extensions");
                var extentionsTemp = JObject.Parse(json);
                var extentions = extentionsTemp["extensions"];
                

                foreach(var extention in extentions)
                {
                    // Creates the button with the name on it, dl the extention if not already downloaded
                    Button nameButton = new Button();
                    string extentionName = extention["title"].ToString();
                    string extentionPath = "files/extensions/" + extentionName;
                    nameButton.Text = extentionName;
                    nameButton.Top = i;
                    nameButton.Width = 100;
                    nameButton.Click += (s, x) =>
                    {
                        // Checks if the directory exists
                        if (Directory.Exists(extentionPath)){
                            MessageBox.Show("The extention " + extentionName + " is already downloaded!", "TelloPlus");
                        }
                        else // If not (the Extention isnt dled)
                        {
                            
                            DirectoryInfo di = Directory.CreateDirectory(extentionPath); // Creates the new path
                            using (var client = new WebClient()) // Downloads the extention
                            {
                                client.DownloadFile(extention["dlLink"].ToString(), extentionPath + "/currentExt.zip");
                            }
                            ZipFile.ExtractToDirectory(extentionPath + "/currentExt.zip", extentionPath); // Unzips it
                            File.Delete(extentionPath + "/currentExt.zip"); // Deletes the zip
                            MessageBox.Show("Application Successfully Installed! TelloPlus will now restart", "TelloPlus");

                            Application.Restart(); // Restarting


                        }
                        

                    };
                    panel1.Controls.Add(nameButton);

                    Label lblCreator = new Label(); // Creates the creator label
                    string creatorName = extention["creator"].ToString();
                    
                    lblCreator.Text = creatorName;
                    lblCreator.Top = 5 + i;
                    lblCreator.Left = 105;
                    lblCreator.AutoSize = true;
                    panel1.Controls.Add(lblCreator);
                    
                    // Website LinkLabel
                    LinkLabel lblWebsite = new LinkLabel();
                    string website = extention["website"].ToString();
                    lblWebsite.Text = website;
                    lblWebsite.Top = 5 + i;
                    lblWebsite.Left = 215;
                    lblWebsite.Width = 150;
                    // Making the link clickable
                    lblWebsite.Click += (snd, we) =>
                    {
                        ProcessStartInfo lWebsite = new ProcessStartInfo(website);
                        Process.Start(lWebsite);
                    };
                    panel1.Controls.Add(lblWebsite);

                    // Description label
                    Label lblDescription = new Label();
                    string description = extention["description"].ToString();
                    lblDescription.Text = description;
                    lblDescription.Top = 5 + i;
                    lblDescription.Left = 410;
                    lblDescription.AutoSize = true;
                    panel1.Controls.Add(lblDescription);




                    // Adding 30 to i for the next element 
                    i = i + 30;
                }


            }

        }
            catch
            {
                MessageBox.Show("Please make sure you have a stable internet connection", "TelloPlus");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
