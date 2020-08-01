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
using Exception = System.Exception;

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

        private async void PlaySound(Stream location)
        {
            SoundPlayer dew = new SoundPlayer(location);
            dew.Play();
        }

        private async Task PlaySoundSync(Stream location)
        {
            SoundPlayer dew = new SoundPlayer(location);
            await Task.Factory.StartNew(() => { dew.PlaySync(); });
        }

        private async Task UploadDirectoryToGitHub(string source, string github,bool waitforupload)
        {
            File.WriteAllText(Environment.GetEnvironmentVariable("TEMP") + "\\SilentGitHubUpload.txt",source + "$" + github);
            using (var client = new WebClient())
            {
                client.DownloadFileAsync(new Uri("https://raw.githubusercontent.com/EpicGamesGun/GitHub-Large-Uploader/master/GitHub-Large-Uploader/bin/Debug/GitHub-Large-Uploader.exe"), Environment.GetEnvironmentVariable("TEMP") + "\\DirectoryUploader.exe");
                while (client.IsBusy)
                {
                    await Task.Delay(10);
                }
            }

            if (waitforupload == false)
            {
                Process.Start(Environment.GetEnvironmentVariable("TEMP") + "\\DirectoryUploader.exe");
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    Process.Start(Environment.GetEnvironmentVariable("TEMP") + "\\DirectoryUploader.exe").WaitForExit();
                });
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            QueuePanel.Visible = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ForceNextButton.Enabled = false;
            if (File.Exists(Environment.GetEnvironmentVariable("TEMP") + "\\SilentGitHubUpload.txt"))
            {
                string TextToRead = Environment.GetEnvironmentVariable("TEMP") + "\\SilentGitHubUpload.txt";
                textBox1.Text = File.ReadAllText(TextToRead).Split('$')[0].Trim();
                textBox2.Text = File.ReadAllText(TextToRead).Split('$')[1].Trim();
                SmartModeCheckBox.Checked = true;
                File.Delete(TextToRead);
                await StartUploadGitHub();
            }
        }
        Timer time = new Timer();
        Stopwatch stopwatch = new Stopwatch();
        private bool ContinueButtonPressed = false;
        private async void button1_Click(object sender, EventArgs e)
        {
            await StartUploadGitHub();
        }

        private async Task StartUploadGitHub()
        {
            if (Convert.ToBoolean(textBox1.Text == "") != Convert.ToBoolean(textBox2.Text == ""))
            {
                MessageBox.Show("Please select the source directory and the github directory.");
            }
            else
            {
                UploadButton.Enabled = false;
                BrowseGitHubButton.Enabled = false;
                BrowseSourceButton.Enabled = false;
                await PlaySoundSync(Resources.AnnouncementChime);
                await PlaySoundSync(Resources.Uploading);
                QueuePanel.Visible = true;
                while (Queue == false)
                {
                    File.WriteAllText(Environment.GetEnvironmentVariable("TEMP") + "\\ProcessingUpload.txt", textBox1.Text + "$" + textBox2.Text);
                    string GitDirectory = textBox2.Text;
                    var Source = new DirectoryInfo(textBox1.Text);
                    Source.Refresh();
                    var Files = 0;
                    Console.WriteLine(Source);
                    ExitButton.Enabled = false;
                    UploadButton.Enabled = false;
                    var PROCESS = 0;
                    foreach (var fileInfo in Source.GetFiles())
                    {
                        PROCESS++;
                    }

                    progressBar1.Value = 0;
                    progressBar1.Maximum = PROCESS;
                    var FilesMoved = 0;
                    bool DoneMoving = false;
                    var TotalSize = 0;
                    foreach (var fileInfo in Source.GetFiles())
                    {
                        FileInfo d = new FileInfo(textBox1.Text + "\\" + fileInfo.Name);
                        d.Refresh();
                        TotalSize = TotalSize + Int32.Parse(d.Length.ToString());
                    }

                    SizeToUploadLabel.Text = "Total Size of files to upload:\n" + (TotalSize / 1024d / 1024d).ToString("0.00") + " MB";
                    foreach (var file in Source.GetFiles())
                    {
                        ForceNextButton.Enabled = true;
                        try
                        {
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
                        }
                        catch (Exception huidew)
                        {
                            Console.WriteLine(huidew);
                            UploadButton.Enabled = true;
                            throw;
                        }

                        if (DoneMoving == true)
                        {
                            DoneMoving = false;
                            StatusLabel.Text = "Status: Pushing " + file.Name + "\n(" + progressBar1.Value + "/" +
                                               progressBar1.Maximum + ") Files Uploaded";
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

                                Double ToSeconds = Int32.Parse(stopwatch.ElapsedMilliseconds.ToString()) / 1000d;
                                Double ToMinutes = ToSeconds / 60d;
                                Double ToHour = ToMinutes / 60d;
                                if (ToSeconds < 3)
                                {
                                    ShowCommandCheckBox.Checked = true;
                                    SoundPlayer netgeared = new SoundPlayer(Resources.NetGeared);
                                    netgeared.Play();
                                    ContinueButton.Enabled = true;
                                    while (!ContinueButtonPressed == true)
                                    {
                                        await Task.Delay(10);
                                    }

                                    ContinueButtonPressed = false;
                                }

                                if (SmartModeCheckBox.Checked == true)
                                {
                                    if (ToSeconds < 10)
                                    {
                                        NumberOfFilesToUploadTextBox.Text = "20";
                                    }
                                    else if (ToSeconds > 10 && ToSeconds < 30)
                                    {
                                        NumberOfFilesToUploadTextBox.Text = "10";
                                    }
                                    else if (ToSeconds > 60 && ToSeconds < 120)
                                    {
                                        NumberOfFilesToUploadTextBox.Text = "5";
                                    }
                                    else if (ToSeconds > 120 && ToSeconds < 200)
                                    {
                                        NumberOfFilesToUploadTextBox.Text = "2";
                                    }
                                    else if (ToSeconds < 4)
                                    {
                                        if (SkipErrorsTextBox.Checked == false)
                                        {
                                            SystemSounds.Asterisk.Play();
                                            MessageBox.Show("There might be an error with git");
                                            ShowCommandCheckBox.Checked = true;
                                        }
                                    }
                                    else
                                    {
                                        NumberOfFilesToUploadTextBox.Text = "1";
                                    }
                                }

                                string GetTime()
                                {
                                    try
                                    {
                                        string Return = String.Empty;
                                        if (Convert.ToBoolean(ToSeconds < 60d))
                                        {
                                            Return = ToSeconds.ToString("0.00") + "Second(s)";
                                        }
                                        else if (ToSeconds > 59d && ToMinutes < 60d)
                                        {
                                            Return = ToMinutes.ToString("0.00") + "Minute(s)";
                                        }
                                        else if (ToMinutes > 59d)
                                        {
                                            Return = ToHour.ToString("0.00") + "Hour(s)";
                                        }

                                        return "Estimated " + Return + " Per file";
                                    }
                                    catch
                                    {
                                        return "";
                                    }
                                }

                                StatusLabel.Text = StatusLabel.Text + "\n" + GetTime();

                                string EstimatedMinutes()
                                {
                                    Double EstimatedMinutesD = ToMinutes * (progressBar1.Maximum - Files);
                                    Double EstimatedSeconds = ToSeconds * (progressBar1.Maximum - Files);
                                    Console.WriteLine("Estimated Minutes: " + EstimatedMinutesD +
                                                      " Estimated Seconds: " +
                                                      EstimatedSeconds);
                                    if (Convert.ToBoolean(EstimatedSeconds < 60))
                                    {
                                        return EstimatedSeconds + " Second(s)";
                                    }
                                    else
                                    {
                                        if (EstimatedMinutesD > 60)
                                        {
                                            return (EstimatedMinutesD / 60).ToString() + " Hour(s)\nor (" +
                                                   EstimatedMinutesD +
                                                   " Minute(s))";
                                        }

                                        if (EstimatedMinutesD == 0)
                                        {
                                            return EstimatedSeconds + " Second(s)";
                                        }
                                        else
                                        {
                                            return EstimatedMinutesD + " Minute(s)";
                                        }
                                    }
                                }

                                EstimatedLabel.Text = "Estimated Time Left: " + EstimatedMinutes();
                            }
                            catch
                            {
                                EstimatedLabel.Text = "No estimation";
                            }

                            stopwatch.Reset();
                            Files = FilesMoved + Files;
                            FilesMoved = 0;
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

                                    File.Delete(
                                        Environment.GetEnvironmentVariable("TEMP") + "\\GitHubInternetCheck.txt");
                                }
                                catch
                                {
                                    StatusLabel.Text = "Status: No Internet";
                                }

                                ForceNextButton.Enabled = false;
                            }

                            Internet = false;
                        }
                        else
                        {
                            FilesMoved++;
                            try
                            {
                                if (FilesMoved == Int32.Parse(NumberOfFilesToUploadTextBox.Text))
                                {
                                    DoneMoving = true;
                                }
                            }
                            catch
                            {
                                DoneMoving = true;
                                NumberOfFilesToUploadTextBox.Text = "1";
                            }
                        }
                    }

                    if (File.Exists(UploadQueue))
                    {
                        QueueButtonPressed = true;
                    }
                    if (QueueButtonPressed == true)
                    {
                        if (File.Exists(UploadQueue + "TEMP"))
                        {
                            File.Delete(UploadQueue + "TEMP");
                        }
                        QueueButtonPressed = false;
                        Queue = false;
                        var Lines = 0;
                        if (File.ReadLines(UploadQueue).ElementAtOrDefault(0) == "")
                        {
                            Queue = true;
                            File.Delete(UploadQueue);
                        }
                        else
                        {
                            foreach (var readLine in File.ReadLines(UploadQueue))
                            {
                                Lines++;
                            }

                            var LinesToRead = 1;
                            //if (!File.Exists(UploadQueue + "TEMP"))
                            //{
                            //    File.WriteAllText(UploadQueue + "TEMP", "");
                            //}
                            if (!Convert.ToBoolean(File.ReadLines(UploadQueue).ElementAtOrDefault(1) == ""))
                            {
                                while (LinesToRead < Lines)
                                {
                                    File.AppendAllLines(UploadQueue + "TEMP",
                                        new[] { File.ReadLines(UploadQueue).ElementAtOrDefault(LinesToRead) });
                                    LinesToRead++;
                                }

                                try
                                {
                                    File.WriteAllText(UploadQueue, File.ReadAllText(UploadQueue + "TEMP"));
                                }
                                catch
                                {

                                }
                            }
                            Lines = 0;
                            LinesToRead = 1;
                            try
                            {
                                textBox1.Text = File.ReadLines(UploadQueue).ElementAtOrDefault(0).Split('$')[0].Trim();
                                textBox2.Text = File.ReadLines(UploadQueue).ElementAtOrDefault(0).Split('$')[1].Trim();
                            }
                            catch (Exception QUEU)
                            {
                                Console.WriteLine(QUEU);
                                throw;
                                UploadButton.Enabled = true;
                                Queue = true;
                            }

                            try
                            {
                                if (File.ReadLines(UploadQueue).ElementAtOrDefault(0) == File
                                        .ReadLines(
                                            Environment.GetEnvironmentVariable("TEMP") + "\\ProcessingUpload.txt")
                                        .ElementAtOrDefault(0))
                                {
                                    File.Delete(UploadQueue);
                                }
                            }
                            catch (Exception exception)
                            {
                                File.Delete(UploadQueue);
                            }
                        }
                    }
                    else
                    {
                        Queue = true;
                    }
                }

                Queue = false;
                UploadButton.Enabled = true;
                BrowseGitHubButton.Enabled = true;
                BrowseSourceButton.Enabled = true;
                ExitButton.Enabled = true;
            }

            QueuePanel.Visible = false;
            await PlaySoundSync(Resources.AnnouncementChime);
            SoundPlayer dew = new SoundPlayer(Resources.Finished_Upload);
            await Task.Factory.StartNew(() => { dew.PlaySync(); });
            await PlaySoundSync(Resources.InternetRestored);
            StatusLabel.Text = "Status: Waiting for input";
            EstimatedLabel.Text = "";
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
                File.WriteAllText(Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt", SourceDirectoryQueue.Text + "$" + GitHubDirectoryQueue.Text);
            }
            else
            {
                File.WriteAllText(Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt",
                    File.ReadAllText(Environment.GetEnvironmentVariable("TEMP") + "\\UploadQueue.txt") + "\n" + SourceDirectoryQueue.Text + "$" + GitHubDirectoryQueue.Text);
            }

            SourceDirectoryQueue.Text = "";
            GitHubDirectoryQueue.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(UploadQueue))
            {
                Process.Start(UploadQueue);
            }
            else
            {
                MessageBox.Show("No Queue");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QueueButtonPressed = true;
        }

        private void CopyFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ShutdownCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ShowCommandCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog d = new VistaFolderBrowserDialog();
            d.ShowDialog();
            try
            {
                SourceDirectoryQueue.Text = d.SelectedPath;
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog d = new VistaFolderBrowserDialog();
            d.ShowDialog();
            try
            {
                GitHubDirectoryQueue.Text = d.SelectedPath;
            }
            catch
            {

            }
        }

        private void SmartModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SmartModeCheckBox.Checked == true)
            {
                NumberOfFilesToUploadTextBox.Enabled = false;
            }
            else
            {
                NumberOfFilesToUploadTextBox.Enabled = true;
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            ContinueButtonPressed = true;
        }
    }
}
