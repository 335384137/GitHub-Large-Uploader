using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
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
        public async Task RunCommand(string Command)
        {
            string[] CommandChut = { Command };
            File.WriteAllLines(User + "\\Documents\\RunCommand.bat", CommandChut);
            await Task.Factory.StartNew(() =>
            {
                var C = Process.Start(User + "\\Documents\\RunCommand.bat");
                C.WaitForExit();
            });
            File.Delete(User + "\\Documents\\RunCommand.bat");
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
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
                ExitButton.Enabled = false;
                foreach (var file in Source.GetFiles())
                {
                    file.MoveTo(GitDirectory + "\\" + file.Name);
                    StatusLabel.Text = "Status: Pushing " + file.Name;
                    if (ShowCommandCheckBox.Checked == false)
                    {
                        await RunCommandHidden("cd /d \"" + GitDirectory +
                                               "\" \n git add --all \n git commit -m \"dew\" \n git push origin");
                    }
                    else
                    {
                        await RunCommand("cd /d \"" + GitDirectory +
                                               "\" \n git add --all \n git commit -m \"dew\" \n git push origin");
                    }

                    Files++;
                    if (Files < progressBar1.Maximum)
                    {
                        progressBar1.Value = Files;
                    }

                    bool Internet = false;
                    while(Internet == false)
                    {
                        try
                        {
                            StatusLabel.Text = "Status: Checking for internet";
                            using (var client = new WebClient())
                            {
                                client.DownloadFileAsync(
                                    new Uri(
                                        "https://raw.githubusercontent.com/EpicGamesGun/GitHub-Large-Uploader/master/InternetCheck.txt"),
                                    Environment.GetEnvironmentVariable("TEMP") + "\\GitHubInternetCheck.txt");
                                while (client.IsBusy)
                                {
                                    await Task.Delay(10);
                                }
                            }

                            if (File.ReadLines(Environment.GetEnvironmentVariable("TEMP") + "\\GitHubInternetCheck.txt")
                                    .ElementAtOrDefault(0) == "true")
                            {
                                Internet = true;
                            }
                        }
                        catch
                        {
                            StatusLabel.Text = "Status: No Internet";
                        }
                    }
                    Internet = false;
                }

                ExitButton.Enabled = true;
            }
            SoundPlayer dew = new SoundPlayer(Resources.Finished_Upload);
            dew.Play();
        }

        private bool Exit = false;
        public async Task RunCommandHidden(string Command)
        {
            string[] CommandChut = { Command };
            File.WriteAllLines(System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\RunCommand.bat", CommandChut);
            Process C = new Process();
            C.StartInfo.FileName = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\RunCommand.bat";
            C.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            C.EnableRaisingEvents = true;
            C.Exited += C_Exited;
            C.Start();
            while (Exit == false)
            {
                await Task.Delay(10);
            }

            Exit = false;
            File.Delete(System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\RunCommand.bat");
        }

        private void C_Exited(object sender, EventArgs e)
        {
            Exit = true;
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
