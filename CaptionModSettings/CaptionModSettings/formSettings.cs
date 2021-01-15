using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace HalfLifeInstaller
{
    public partial class formSettings : Form
    {
        public formSettings()
        {
            InitializeComponent();
        }
        #region Variables
        string FontName;
        float FontSize;
        string ArgumentToRun;
        string HalfLife;
        string[] ayarlarScheme;
        string[] ayarlarPanel;
        #endregion

        #region Operations
        void FindPath()
        {
            try
            {
                string steamPath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", null) as string;
                string result = SeekDirectory(steamPath);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    HalfLife = result.Substring(0,result.Length-6);
                }
            }
            catch
            {
            }
        }
        void StartGame()
        {
            ProcessStartInfo processinfo = new ProcessStartInfo();
            processinfo.Arguments = "-game " + ArgumentToRun;
            processinfo.FileName = HalfLife + "metahook.exe";
            processinfo.WorkingDirectory = Path.GetDirectoryName(processinfo.FileName);

            try
            {
                Process process = Process.Start(processinfo);
                process.EnableRaisingEvents = true;
            }
            catch
            {
            }
        }
        void SetFont()
        {
            if (FontName != null)
            {
                ayarlarScheme = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//CaptionScheme.res");

                ayarlarScheme[53] = null;
                ayarlarScheme[54] = null;

                ayarlarScheme[53] = "\t\t\t\t\"name\" \t" + "\"" + FontName + "\"";
                ayarlarScheme[54] = "\t\t\t\t\"tall\" \t" + "\"" + Math.Round(FontSize) + "\"";
                File.WriteAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//CaptionScheme.res", ayarlarScheme);

                ayarlarScheme = null;                
            }
        }
        void SetPrefix()
        {
            ayarlarPanel = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//SubtitlePanel.res");
            if (chkPrefix.Checked)
            {
                ayarlarPanel[34] = null;
                ayarlarPanel[34] = "\t\t\"prefix\" \t\t\"1\"";
                File.WriteAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//SubtitlePanel.res", ayarlarPanel);

            }
            else
            {
                ayarlarPanel[34] = null;
                ayarlarPanel[34] = "\t\t\"prefix\" \t\t \"0\"";
                File.WriteAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//SubtitlePanel.res", ayarlarPanel);
            }
            ayarlarPanel = null;
        }
        void SetBackground()
        {
            ayarlarScheme = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//CaptionScheme.res");
            if (chkBackground.Checked)
            {
                ayarlarScheme[14] = null;
                ayarlarScheme[14] = "\t\t\"ControlBG\" \t\t\"0 0 0 100\"";
                File.WriteAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//CaptionScheme.res", ayarlarScheme);

            }
            else
            {
                ayarlarScheme[14] = null;
                ayarlarScheme[14] = "\t\t\"ControlBG\" \t\t \"0 0 0 0\"";
                File.WriteAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//CaptionScheme.res", ayarlarScheme);
            }
            ayarlarScheme = null;
        }
        void SetAlignment()
        {
            ayarlarPanel = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//SubtitlePanel.res");
            switch (cmbAlignment.SelectedItem.ToString())
            {
                case "Sağ":
                    ayarlarPanel[28] = null;
                    ayarlarPanel[28] = "\t\t\"textalign\"\t\t\"R\"\t\t\t\t\t//Text Alignment, L/C/R";
                    break;

                case "Sol":
                    ayarlarPanel[28] = null;
                    ayarlarPanel[28] = "\t\t\"textalign\"\t\t\"L\"\t\t\t\t\t//Text Alignment, L/C/R";
                    break;

                case "Orta":
                    ayarlarPanel[28] = null;
                    ayarlarPanel[28] = "\t\t\"textalign\"\t\t\"C\"\t\t\t\t\t//Text Alignment, L/C/R";
                    break;
            }
            File.WriteAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//SubtitlePanel.res", ayarlarPanel);
            ayarlarPanel = null;
        }
        #endregion

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

        private void Form1_Load(object sender, EventArgs e)
        {
           FindPath();

            //Check if both the game and the CaptionMod is installed...
            if (File.Exists(HalfLife + @"valve\cl_dlls\client.dll") && File.Exists(HalfLife +@"valve\metahook\plugins\captionmod.dll")) cmbGames.Items.Add("Half-Life");
            if (File.Exists(HalfLife + @"gearbox\cl_dlls\client.dll") && File.Exists(HalfLife + @"gearbox\metahook\plugins\captionmod.dll")) cmbGames.Items.Add("Half-Life: Opposing Force");
            if (File.Exists(HalfLife + @"bshift\cl_dlls\client.dll") && File.Exists(HalfLife + @"bshift\metahook\plugins\captionmod.dll")) cmbGames.Items.Add("Half-Life: Blue Shift");
            if (File.Exists(HalfLife + @"decay\cl_dlls\client.dll") && File.Exists(HalfLife + @"decay\metahook\plugins\captionmod.dll")) cmbGames.Items.Add("Half-Life: Decay");
            //This is a mod.
            if (File.Exists(HalfLife + @"hlulsl\metahook\plugins\captionmod.dll")) cmbGames.Items.Add("Half-Life: Uplink");

            //No games? Then quit.
            if (cmbGames.Items.Count == 0)
            {
                MessageBox.Show("Kurulu yama bulunamadı, şimdi çıkılıyor...");
                Application.Exit();
            }

            else
            {
                //Select the first game.
                cmbGames.SelectedIndex = 0;

                //Load the settings from files.
                ayarlarScheme = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//CaptionScheme.res");
                ayarlarPanel = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//SubtitlePanel.res");

                #region PreviewSettings
                if (ayarlarPanel[34] == "\t\t\"prefix\" \t\t\"1\"")
                {
                    chkPrefix.Checked = true;
                }
                else
                {
                    chkPrefix.Checked = false;
                }

                if (ayarlarScheme[14] == "\t\t\"ControlBG\" \t\t\"0 0 0 100\"")
                {
                    chkBackground.Checked = true;
                }
                else
                {
                    chkBackground.Checked = false;
                }

                switch (ayarlarPanel[28])
                {
                    case "\t\t\"textalign\"\t\t\"L\"\t\t\t\t\t//Text Alignment, L/C/R":
                        cmbAlignment.SelectedItem = "Sol";
                        break;
                    case "\t\t\"textalign\"\t\t\"C\"\t\t\t\t\t//Text Alignment, L/C/R":
                        cmbAlignment.SelectedItem = "Orta";
                        break;
                    case "\t\t\"textalign\"\t\t\"R\"\t\t\t\t\t//Text Alignment, L/C/R":
                        cmbAlignment.SelectedItem = "Sağ";
                        break;
                }
                #endregion

                #region Load fonts and sizes
                foreach (FontFamily oneFontFamily in FontFamily.Families)
                {
                    cmbFonts.Items.Add(oneFontFamily.Name);
                }

                for (int i = 1; i < 73; i++)
                {
                    cmbFontSize.Items.Add(i);
                }
                cmbFonts.SelectedItem = ayarlarScheme[53].Substring(13, ayarlarScheme[53].Length - 14);
                cmbFontSize.SelectedItem = int.Parse(ayarlarScheme[54].Substring(13, ayarlarScheme[54].Length - 14));
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        
        {
            SetPrefix();
            SetBackground();
            SetFont();
            SetAlignment();
            StartGame();
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGames.SelectedItem.ToString() == "Half-Life")
            {
                ArgumentToRun = "valve";
                pictureBox1.Image = CaptionModSettings.Properties.Resources.hl;
            }

            if (cmbGames.SelectedItem.ToString() == "Half-Life: Opposing Force")
            {
                ArgumentToRun = "gearbox";
                pictureBox1.Image = CaptionModSettings.Properties.Resources.of;
            }

            if (cmbGames.SelectedItem.ToString() == "Half-Life: Blue Shift")
            {
                ArgumentToRun = "bshift";
                pictureBox1.Image = CaptionModSettings.Properties.Resources.bs;
            }

            if (cmbGames.SelectedItem.ToString() == "Half-Life: Decay")
            {
                ArgumentToRun = "decay";
                pictureBox1.Image = CaptionModSettings.Properties.Resources.dc;
            }

            if (cmbGames.SelectedItem.ToString() == "Half-Life: Uplink")
            {
                ArgumentToRun = "hlulsl";
                pictureBox1.Image = CaptionModSettings.Properties.Resources.ul;
            }
            #region PreviewSettings
            ayarlarScheme = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//CaptionScheme.res");
            ayarlarPanel = File.ReadAllLines(HalfLife + "//" + ArgumentToRun + "//captionmod//SubtitlePanel.res");

            if (ayarlarPanel[34] == "\t\t\"prefix\" \t\t\"1\"")
            {
                chkPrefix.Checked = true;
            }
            else
            {
                chkPrefix.Checked = false;
            }

            if (ayarlarScheme[14] == "\t\t\"ControlBG\" \t\t\"0 0 0 100\"")
            {
                chkBackground.Checked = true;
            }
            else
            {
                chkBackground.Checked = false;
            }

            switch (ayarlarPanel[28])
            {
                case "\t\t\"textalign\"\t\t\"L\"\t\t\t\t\t//Text Alignment, L/C/R":
                    cmbAlignment.SelectedItem = "Sol";
                    break;
                case "\t\t\"textalign\"\t\t\"C\"\t\t\t\t\t//Text Alignment, L/C/R":
                    cmbAlignment.SelectedItem = "Orta";
                    break;
                case "\t\t\"textalign\"\t\t\"R\"\t\t\t\t\t//Text Alignment, L/C/R":
                    cmbAlignment.SelectedItem = "Sağ";
                    break;
            }

            cmbFonts.SelectedItem = ayarlarScheme[53].Substring(13, ayarlarScheme[53].Length - 14);
            cmbFontSize.SelectedItem = int.Parse(ayarlarScheme[54].Substring(13, ayarlarScheme[54].Length - 14));
            #endregion
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPreview.Font = new Font(cmbFonts.SelectedItem.ToString(), txtPreview.Font.Size);
            FontName = cmbFonts.SelectedItem.ToString();

            if (cmbFonts.SelectedItem.ToString() == "Segoe UI")
            {
                btnResetFont.Enabled = false;
            }
            else
            {
                btnResetFont.Enabled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFontSize.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                txtPreview.Font = new Font(txtPreview.Font.FontFamily, cmbFontSize.SelectedIndex);
                FontSize = float.Parse(cmbFontSize.SelectedItem.ToString());

            }

            if (cmbFontSize.SelectedItem.ToString() == "19")
            {
                btnResetFontSize.Enabled = false;
            }
            else
            {
                btnResetFontSize.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbFonts.SelectedItem = "Segoe UI";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmbFontSize.SelectedItem = 19;
        }

        private void cmbAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAlignment.SelectedItem.ToString())
            {
                case "Sağ":
                    txtPreview.TextAlign = HorizontalAlignment.Right;
                    break;

                case "Sol":
                    txtPreview.TextAlign = HorizontalAlignment.Left;
                    break;

                case "Orta":
                    txtPreview.TextAlign = HorizontalAlignment.Center;
                    break;
            }
        }
    }
}
