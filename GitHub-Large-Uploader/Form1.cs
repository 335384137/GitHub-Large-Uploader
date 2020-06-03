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
using Ookii.Dialogs.Wpf;

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

        private bool Queue = false;
        private bool QueueButtonPressed = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ForceNextButton.Enabled = false;
        }
        Timer time = new Timer();
        Stopwatch stopwatch = new Stopwatch();
        private async void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(textBox1.Text == "") != Convert.ToBoolean(textBox2.Text == ""))
            {
                MessageBox.Show("Please select the source directory and the github directory.");
            }
            else
            {
                while (Queue == false)
                {
                    string GitDirectory = textBox2.Text;
                    DirectoryInfo Source = new DirectoryInfo(textBox1.Text);
                    var Files = 0;
                    ExitButton.Enabled = false;
                    UploadButton.Enabled = false;
                    foreach (var file in Source.GetFiles())
                    {
                        ForceNextButton.Enabled = true;
                        if (CopyFilesCheckBox.Checked == false)
                        {
                            if (File.Exists(GitDirectory + "\\" + file.Name))
                            {
                                File.Delete(GitDirectory + "\\" + file.Name);
                            }

                            file.MoveTo(GitDirectory + "\\" + file.Name);
                        }
                        else
                        {
                            if (File.Exists(GitDirectory + "\\" + file.Name))
                            {
                                File.Delete(GitDirectory + "\\" + file.Name);
                            }

                            file.CopyTo(GitDirectory + "\\" + file.Name);
                        }

                        StatusLabel.Text = "Status: Pushing " + file.Name;
                        stopwatch.Start();
                        if (ShowCommandCheckBox.Checked == false)
                        {
                            try
                            {
                                await RunCommandHidden("cd /d \"" + GitDirectory +
                                                       "\" \n git add --all \n git commit -m \"dew\" \n git push origin");
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            try
                            {

                                await RunCommand("cd /d \"" + GitDirectory +
                                                 "\" \n git add --all \n git commit -m \"dew\" \n git push origin");
                            }
                            catch
                            {

                            }
                        }

                        stopwatch.Stop();
                        try
                        {
                            int ToSeconds = Int32.Parse(stopwatch.ElapsedMilliseconds.ToString()) / 1000;
                            int ToMinutes = ToSeconds / 60;
                            int ToHour = ToMinutes / 60;

                            string EstimatedMinutes()
                            {
                                int EstimatedMinutesD = ToMinutes * (progressBar1.Maximum - Files);
                                int EstimatedSeconds = ToSeconds * (progressBar1.Maximum - Files);
                                Console.WriteLine("Estimated Minutes: " + EstimatedMinutesD + " Estimated Seconds: " +
                                                  EstimatedSeconds);
                                if (Convert.ToBoolean(EstimatedSeconds < 60))
                                {
                                    return EstimatedSeconds + " Second(s)";
                                }
                                else
                                {
                                    if (EstimatedMinutesD < 60)
                                    {
                                        return (EstimatedMinutesD / 60).ToString() + " Hour(s)\n(" + EstimatedMinutesD +
                                               " Minute(s))";
                                    }

                                    return EstimatedMinutesD + " Minute(s)";
                                }
                            }

                            EstimatedLabel.Text = "Estimated Time Left: " + EstimatedMinutes();
                        }
                        catch
                        {
                            EstimatedLabel.Text = "No estimation";
                        }

                        stopwatch.Reset();
                        Files++;
                        if (Files < progressBar1.Maximum)
                        {
                            progressBar1.Value = Files;
                        }

                        bool Internet = false;
                        while (Internet == false)
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

                                if (File.ReadLines(Environment.GetEnvironmentVariable("TEMP") +
                                                   "\\GitHubInternetCheck.txt")
                                        .ElementAtOrDefault(0) == "true")
                                {
                                    Internet = true;
                                }
                                else
                                {
                                    StatusLabel.Text = "Status: No Internet";
                                }

                                File.Delete(Environment.GetEnvironmentVariable("TEMP") + "\\GitHubInternetCheck.txt");
                            }
                            catch
                            {
                                StatusLabel.Text = "Status: No Internet";
                            }

                            ForceNextButton.Enabled = false;
                        }

                        if (QueueButtonPressed == true)
                        {
                            QueueButtonPressed = false;
                            Queue = false;
                            var Lines = 0;
                            foreach (var readLine in File.ReadLines(UploadQueue))
                            {
                                Lines++;
                            }
                            var LinesToRead = 1;
                            while (LinesToRead < Lines)
                            {
                                File.WriteAllText(UploadQueue + "TEMP", File.ReadLines(UploadQueue).ElementAtOrDefault(LinesToRead));
                                LinesToRead++;
                            }
                            File.WriteAllText(UploadQueue, File.ReadAllText(UploadQueue + "TEMP"));
                            Lines = 0;
                            LinesToRead = 1;
                        }
                        else
                        {
                            Queue = true;
                        }
                        Internet = false;
                    }
                }

                UploadButton.Enabled = true;
                ExitButton.Enabled = true;
            }
            SoundPlayer dew = new SoundPlayer(Resources.Finished_Upload);
            await Task.Factory.StartNew(() => { dew.PlaySync(); });
            StatusLabel.Text = "Status: Waiting for input";
            progressBar1.Value = 0;
            SystemSounds.Beep.Play();
            if (ShutdownCheckbox.Checked == true)
            {
                SoundPlayer Shut = new SoundPlayer(Resources.ShutdownIn30Seconds);
                await Task.Factory.StartNew(() => { Shut.PlaySync(); });
                for (int i = 30; i > 0; i = i - 1)
                {
                    StatusLabel.Text = "Shutting Down In: " + i + " Seconds";
                    Random h = new Random();
                    int j = h.Next(0, 1);
                    
                        SystemSounds.Hand.Play();
                    
                    await Task.Delay(1000);
                }
                StatusLabel.Text = "Shutting Down";
                SoundPlayer dewd = new SoundPlayer(Resources.ShuttingDown);
                dewd.PlaySync();
                await RunCommandHidden("shutdown /s /f /t 00");
            }
        }

        private string UploadQueue = Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt";
        private bool Exit = false;
        private bool Kill = false;
        public async Task RunCommandHidden(string Command)
        {
            Kill = false;
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
                if (Kill == true)
                {
                    C.Kill();
                }
            }

            Kill = false;
            Exit = false;
            try
            {
                File.Delete(System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\RunCommand.bat");
            }
            catch
            {

            }
        }

        private void C_Exited(object sender, EventArgs e)
        {
            Exit = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the source directory for the files that you want to upload");
            VistaFolderBrowserDialog dewBrowserDialog = new VistaFolderBrowserDialog();
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
            VistaFolderBrowserDialog dewDialog = new VistaFolderBrowserDialog();
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                 "\\Documents\\GitHub"))
            {
                dewDialog.RootFolder = Environment.SpecialFolder.CommonDocuments;
            }
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

        private async void ForceNextButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kill = true;
        }

        private void QueueButton_Click(object sender, EventArgs e)
        {
            QueueButtonPressed = true;
            if (!File.Exists(Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt"))
            {
                File.WriteAllText(Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt", textBox1.Text + ":" + textBox2.Text);
            }
            else
            {
                File.WriteAllText(Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt",
                    File.ReadAllText(Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt") + "\n" + textBox1.Text + ":" + textBox2.Text);
            }
        }
    }
}
