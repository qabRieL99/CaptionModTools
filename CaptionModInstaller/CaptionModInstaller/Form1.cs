using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.IO.Compression;
//using ICSharpCode.SharpZipLib.Zip;


namespace CaptionModInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string mainDirectory;
        string desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

        void FindPath()
        {
            try
            {
                RegistryKey HLKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 70", false);
                RegistryKey BSKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 130", false);
                RegistryKey OFKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 50", false);

                if (HLKey == null)
                {
                    if (BSKey == null)
                    {
                        if (OFKey == null)
                        {
                        }
                        else
                        {
                            RegistryKey OFKey2 = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false);
                            mainDirectory = OFKey2.OpenSubKey("Steam App 50").GetValue("InstallLocation").ToString();
                        }
                    }
                    else
                    {
                        RegistryKey BSKey2 = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false);
                        mainDirectory = BSKey2.OpenSubKey("Steam App 130").GetValue("InstallLocation").ToString();
                    }
                }
                else
                {
                    RegistryKey HLKey2 = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false);
                    mainDirectory = HLKey2.OpenSubKey("Steam App 70").GetValue("InstallLocation").ToString();
                }
                    textBox1.Text = mainDirectory;
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                MessageBox.Show("Hiçbir oyun seçilmedi!", "Oyun Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkBox1.Checked)
                {
                    if (File.Exists(mainDirectory + "metahook.exe")) File.Delete(mainDirectory + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(mainDirectory + "HalfLife.zip", CaptionModInstaller.Properties.Resources.HalfLife);
                    ZipFile.ExtractToDirectory(mainDirectory + "HalfLife.zip", mainDirectory);
                    File.Delete(mainDirectory + "HalfLife.zip");
                }

                if (checkBox2.Checked)
                {
                    if (File.Exists(mainDirectory + "metahook.exe")) File.Delete(mainDirectory + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(mainDirectory + "BlueShift.zip", CaptionModInstaller.Properties.Resources.BlueShift);
                    ZipFile.ExtractToDirectory(mainDirectory + "BlueShift.zip", mainDirectory);
                    File.Delete(mainDirectory + "BlueShift.zip");
                }

                if (checkBox3.Checked)
                {
                    if (File.Exists(mainDirectory + "metahook.exe")) File.Delete(mainDirectory + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(mainDirectory + "OpposingForce.zip", CaptionModInstaller.Properties.Resources.OpposingForce);
                    ZipFile.ExtractToDirectory(mainDirectory + "OpposingForce.zip", mainDirectory);
                    File.Delete(mainDirectory + "OpposingForce.zip");
                }

                if (checkBox4.Checked)
                {
                    if (File.Exists(mainDirectory + "metahook.exe")) File.Delete(mainDirectory + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(mainDirectory + "Decay.zip", CaptionModInstaller.Properties.Resources.Decay);
                    ZipFile.ExtractToDirectory(mainDirectory + "Decay.zip", mainDirectory);
                    File.Delete(mainDirectory + "Decay.zip");
                }

                if (checkBox5.Checked)
                {
                    if (File.Exists(mainDirectory + "metahook.exe")) File.Delete(mainDirectory + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(mainDirectory + "Uplink.zip", CaptionModInstaller.Properties.Resources.Uplink);
                    ZipFile.ExtractToDirectory(mainDirectory + "Uplink.zip", mainDirectory);
                    File.Delete(mainDirectory + "Uplink.zip");
                }
                if (File.Exists(desktopPath + "//CaptionMod Ayarları.exe")) File.Delete(desktopPath + "//CaptionMod Ayarları.exe");
                File.WriteAllBytes(desktopPath +"//CaptionMod Ayarları.exe", CaptionModInstaller.Properties.Resources.CaptionModSettings);
                MessageBox.Show("Kurulum tamamlandı, iyi oyunlar!\nProgram kapanacak.", "Kurulum Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FindPath();

            #region CheckHL
            if (File.Exists(mainDirectory + @"\valve\cl_dlls\client.dll"))
            {
                checkBox1.Enabled = true;
                if (File.Exists(mainDirectory + @"\valve\metahook\plugins\captionmod.dll"))
                {
                    checkBox1.Text += " [Yama Kurulu]";
                    checkBox1.Enabled = false;
                }
            }
            else checkBox1.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckBS
            //BS
            if (File.Exists(mainDirectory + @"\bshift\cl_dlls\client.dll"))
            {
                checkBox2.Enabled = true;
                if (File.Exists(mainDirectory + @"\bshift\metahook\plugins\captionmod.dll"))
                {
                    checkBox2.Text += " [Yama Kurulu]";
                    checkBox2.Enabled = false;
                }
            }
            else checkBox2.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckOF
            //OF
            if (File.Exists(mainDirectory + @"\gearbox\cl_dlls\client.dll"))
            {
                checkBox3.Enabled = true;
                if (File.Exists(mainDirectory + @"\gearbox\metahook\plugins\captionmod.dll"))
                {
                    checkBox3.Text += " [Yama Kurulu]";
                    checkBox3.Enabled = false;
                }
            }
            else checkBox3.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckDC
            //DC
            if (File.Exists(mainDirectory + @"\decay\cl_dlls\client.dll"))
            {
                checkBox4.Enabled = true;
                if (File.Exists(mainDirectory + @"\decay\metahook\plugins\captionmod.dll"))
                {
                    checkBox4.Text += " [Yama Kurulu]";
                    checkBox4.Enabled = false;
                }
            }
            else checkBox4.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckUL
            //HLU
            if (Directory.Exists(mainDirectory + @"\hlulsl"))
            {
                checkBox5.Enabled = true;
                if (File.Exists(mainDirectory + @"hlulsl\metahook\plugins\captionmod.dll"))
                {
                    checkBox5.Text += " [Yama Kurulu]";
                    checkBox5.Enabled = false;
                }
            }
            else checkBox5.Text += " [Oyun Bulunamadı]";
            #endregion;
        }
    }
}
