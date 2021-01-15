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

        string HalfLife;
        string desktopPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

        void FindPath()
        {
            try
            {
                string steamPath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", null) as string;
                string result = SeekDirectory(steamPath);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    HalfLife = result.Substring(0, result.Length - 6);
                    textBox1.Text = HalfLife;
                }
            }
            catch
            {
            }
        }

        #region Beautifiers
        private static string SeekDirectory(string steamDirectory)
        {
            if (steamDirectory == null || !Directory.Exists(steamDirectory))
            {
                return null;
            }

            string path = Path.Combine(steamDirectory, "SteamApps", "Common", "Half-Life", "hl.exe");
            if (File.Exists(path))
            {
                path = GetProperFilePathCapitalization(path);
                if (path.Length >= 2 && path[1] == ':')
                {
                    path = char.ToUpper(path[0]) + path.Substring(1);
                    return path;
                }
            }
            return null;
        }
        private static string GetProperFilePathCapitalization(string filename)
        {
            FileInfo fileInfo = new FileInfo(filename);
            DirectoryInfo dirInfo = fileInfo.Directory;
            return Path.Combine(GetProperDirectoryCapitalization(dirInfo),
                                dirInfo.GetFiles(fileInfo.Name)[0].Name);
        }
        private static string GetProperDirectoryCapitalization(DirectoryInfo dirInfo)
        {
            DirectoryInfo parentDirInfo = dirInfo.Parent;
            if (null == parentDirInfo)
                return dirInfo.Name;
            return Path.Combine(GetProperDirectoryCapitalization(parentDirInfo),
                                parentDirInfo.GetDirectories(dirInfo.Name)[0].Name);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //FastZip fastZip = new FastZip();
            //string fileFilter = null;
            //fastZip.ExtractZip(HalfLife + "HalfLife.zip", HalfLife, fileFilter);

            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                MessageBox.Show("Hiçbir oyun seçilmedi!", "Oyun Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkBox1.Checked)
                {
                    if (File.Exists(HalfLife + "metahook.exe")) File.Delete(HalfLife + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(HalfLife + "HalfLife.zip", CaptionModInstaller.Properties.Resources.HalfLife);
                    ZipFile.ExtractToDirectory(HalfLife + "HalfLife.zip", HalfLife);
                    File.Delete(HalfLife + "HalfLife.zip");
                }

                if (checkBox2.Checked)
                {
                    if (File.Exists(HalfLife + "metahook.exe")) File.Delete(HalfLife + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(HalfLife + "BlueShift.zip", CaptionModInstaller.Properties.Resources.BlueShift);
                    ZipFile.ExtractToDirectory(HalfLife + "BlueShift.zip", HalfLife);
                    File.Delete(HalfLife + "BlueShift.zip");
                }

                if (checkBox3.Checked)
                {
                    if (File.Exists(HalfLife + "metahook.exe")) File.Delete(HalfLife + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(HalfLife + "OpposingForce.zip", CaptionModInstaller.Properties.Resources.OpposingForce);
                    ZipFile.ExtractToDirectory(HalfLife + "OpposingForce.zip", HalfLife);
                    File.Delete(HalfLife + "OpposingForce.zip");
                }

                if (checkBox4.Checked)
                {
                    if (File.Exists(HalfLife + "metahook.exe")) File.Delete(HalfLife + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(HalfLife + "Decay.zip", CaptionModInstaller.Properties.Resources.Decay);
                    ZipFile.ExtractToDirectory(HalfLife + "Decay.zip", HalfLife);
                    File.Delete(HalfLife + "Decay.zip");
                }

                if (checkBox5.Checked)
                {
                    if (File.Exists(HalfLife + "metahook.exe")) File.Delete(HalfLife + "metahook.exe");  // Delete the metahook application if it already exists, we're going to install it anyways.
                    File.WriteAllBytes(HalfLife + "Uplink.zip", CaptionModInstaller.Properties.Resources.Uplink);
                    ZipFile.ExtractToDirectory(HalfLife + "Uplink.zip", HalfLife);
                    File.Delete(HalfLife + "Uplink.zip");
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
            if (File.Exists(HalfLife + @"valve\cl_dlls\client.dll"))
            {
                checkBox1.Enabled = true;
                if (File.Exists(HalfLife + @"valve\metahook\plugins\captionmod.dll"))
                {
                    checkBox1.Text += " [Yama Kurulu]";
                    checkBox1.Enabled = false;
                }
            }
            else checkBox1.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckBS
            //BS
            if (File.Exists(HalfLife + @"bshift\cl_dlls\client.dll"))
            {
                checkBox2.Enabled = true;
                if (File.Exists(HalfLife + @"bshift\metahook\plugins\captionmod.dll"))
                {
                    checkBox2.Text += " [Yama Kurulu]";
                    checkBox2.Enabled = false;
                }
            }
            else checkBox2.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckOF
            //OF
            if (File.Exists(HalfLife + @"gearbox\cl_dlls\client.dll"))
            {
                checkBox3.Enabled = true;
                if (File.Exists(HalfLife + @"gearbox\metahook\plugins\captionmod.dll"))
                {
                    checkBox3.Text += " [Yama Kurulu]";
                    checkBox3.Enabled = false;
                }
            }
            else checkBox3.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckDC
            //DC
            if (File.Exists(HalfLife + @"decay\cl_dlls\client.dll"))
            {
                checkBox4.Enabled = true;
                if (File.Exists(HalfLife + @"decay\metahook\plugins\captionmod.dll"))
                {
                    checkBox4.Text += " [Yama Kurulu]";
                    checkBox4.Enabled = false;
                }
            }
            else checkBox4.Text += " [Oyun Bulunamadı]";
            #endregion

            #region CheckUL
            //HLU
            if (Directory.Exists(HalfLife + @"hlulsl"))
            {
                checkBox5.Enabled = true;
                if (File.Exists(HalfLife + @"hlulsl\metahook\plugins\captionmod.dll"))
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
