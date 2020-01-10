using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(textBox1.Text == "") != Convert.ToBoolean(textBox2.Text == ""))
            {
                MessageBox.Show("Please select the source directory and the github directory.");
            }
            else
            {
                string GitDirectory = textBox2.Text;
                DirectoryInfo Source = new DirectoryInfo(textBox1.Text);
                foreach (var file in Source.GetFiles())
                {
                    file.MoveTo(GitDirectory + "\\" + file.Name);
                    RunCommand("cd \"" + GitDirectory + "\" \n git add --all \n git commit -m \"dew\" \n git push origin");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the source directory for the files that you want to upload");
            FolderBrowserDialog dewBrowserDialog = new FolderBrowserDialog();
            dewBrowserDialog.RootFolder = Environment.SpecialFolder.UserProfile;
            dewBrowserDialog.ShowDialog();
            if (Directory.Exists(dewBrowserDialog.SelectedPath))
            {
                textBox1.Text = dewBrowserDialog.SelectedPath;
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
            dewDialog.RootFolder = Environment.SpecialFolder.UserProfile;
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
