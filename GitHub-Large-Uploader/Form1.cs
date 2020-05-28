using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitHub_Large_Uploader.Properties;

namespace GitHub_Large_Uploader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string User = System.Environment.GetEnvironmentVariable("USERPROFILE");
        public void RunCommand(string Command)
        {
            string[] CommandChut = { Command };
            File.WriteAllLines(User + "\\Documents\\RunCommand.bat", CommandChut);
            var C = Process.Start(User + "\\Documents\\RunCommand.bat");
            C.WaitForExit();
            File.Delete(User + "\\Documents\\RunCommand.bat");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(textBox1.Text == "") != Convert.ToBoolean(textBox2.Text == ""))
            {
                MessageBox.Show("Please select the source directory and the github directory.");
            }
            else
            {
                string GitDirectory = textBox2.Text;
                DirectoryInfo Source = new DirectoryInfo(textBox1.Text);
                var Files = 0;
                foreach (var file in Source.GetFiles())
                {
                    file.MoveTo(GitDirectory + "\\" + file.Name);
                    RunCommand("cd /d \"" + GitDirectory + "\" \n git add --all \n git commit -m \"dew\" \n git push origin");
                    Files++;
                    if (Files < progressBar1.Maximum)
                    {
                        progressBar1.Value = Files;
                    }
                }
            }
            SoundPlayer dew = new SoundPlayer(Resources.Finished_Upload);
            dew.Play();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the source directory for the files that you want to upload");
            FolderBrowserDialog dewBrowserDialog = new FolderBrowserDialog();
            dewBrowserDialog.ShowDialog();
            if (Directory.Exists(dewBrowserDialog.SelectedPath))
            {
                textBox1.Text = dewBrowserDialog.SelectedPath;
                DirectoryInfo d = new DirectoryInfo(dewBrowserDialog.SelectedPath);
                var Files = 0;
                foreach (var file in d.GetFiles())
                {
                    Files++;
                }

                progressBar1.Maximum = Files;
            }
            else
            {
                MessageBox.Show("Invalid Directory");
                Process.Start(Application.ExecutablePath);
                Close();
                Application.Exit();
            }
            MessageBox.Show("Now select your GitHub Directory");
            FolderBrowserDialog dewDialog = new FolderBrowserDialog();
            dewDialog.ShowDialog();
            if (Directory.Exists(dewDialog.SelectedPath))
            {
                textBox2.Text = dewDialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("Invalid Directory");
                Process.Start(Application.ExecutablePath);
                Close();
                Application.Exit();
            }
        }
    }
}
