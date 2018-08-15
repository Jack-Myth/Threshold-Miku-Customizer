using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Ionic.Zip;

namespace Threshold_Miku_Customizer
{
    public partial class Form1 : Form
    {
        Label[] GameListControls;
        Point GameListNormalPosition, GameListCollapsedPosition;
        ResourceManager CurrentTheme;
        Dictionary<string, string> CodeVars=new Dictionary<string, string>();

        private void MainUI_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("MainUI.BG", MainUI_BGPic);
        }

        private void Settings_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("Settings.BG", Settings_BGPic);
        }

        private void LoadImageFor(string PicID,PictureBox PicBox)
        {
            openFileDialog1.Filter = "Supported Image|*.png;*.jpg;*.jpeg";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                CodeVars[PicID] = openFileDialog1.FileName;
                PicBox.BackgroundImage = MyFunc.LoadImageByPath(openFileDialog1.FileName);
            }
        }

        private void Installation_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("Installation.BG", Installation_BGPic);
        }

        private void BackAndRestore_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("BackupAndRestore.BG", BackupAndRestore_BGPic);
        }

        private void SystemInfo_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("SystemInfo.BG", SystemInfo_BGPic);
        }

        private void Loggin_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("Loggin.BG", Loggin_BGPic);
        }

        private void SecurityWizard_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("SecurityWizard.BG", SecurityWizard_BGPic);
        }

        private void checkCollapsedSidebar_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).Checked)
            {
                MainUI_BGPic.Image = (Image)CurrentTheme.GetObject("MainUICMask");
                MainUI_BGPic.Size = new Size(809, 606);
                GameListPanel.Location = GameListCollapsedPosition;
            }
            else
            {
                MainUI_BGPic.Image = (Image)CurrentTheme.GetObject("MainUIMask");
                MainUI_BGPic.Size = new Size(896, 606);
                GameListPanel.Location = GameListNormalPosition;
            }
            CodeVars["MainUI.Collapsed"] = ((CheckBox)sender).Checked.ToString();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            ApplyResource();
        }

        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
            ApplyResource();
        }

        private void CDKey_BG_Click(object sender, EventArgs e)
        {
            LoadImageFor("CDKey.BG", CDKey_BGPic);
        }

        private void buildSkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                Exporting xExporting = new Exporting();
                xExporting.Export(CurrentTheme, CodeVars, folderBrowserDialog1.SelectedPath);
            }
        } 

        private void MainBG_NormalTextColor_Click(object sender, EventArgs e)
        {
            string TextType = MyFunc.GetTextTypeByID(MainUI_TextComboBox.SelectedIndex, false);
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                CodeVars[TextType] = ColorTranslator.ToHtml(colorDialog1.Color);
                foreach(Label GamelistItem in GameListControls)
                {
                    onGameListItemLeaved(GamelistItem, new EventArgs());
                }
                MainBG_NormalTextColor.BackColor = colorDialog1.Color;
            }
        }

        public Form1()
        {
            InitializeComponent();
            //Set Threshold Miku Light as default Theme.
            CurrentTheme = new ResourceManager("Threshold_Miku_Customizer.ThresholdMikuLight", Assembly.GetExecutingAssembly());
            GameListPanel.Parent = MainUI_BGPic;
            string[] GameList = new string[]
            {
                "武侠乂",
                "NEKOPARA Vol. 0",
                "NEKOPARA Vol. 1",
                "NEKOPARA Vol. 2",
                "NEKOPARA Vol. 3",
                "Batman: Arkham Asylum GOTY Edition",
                "Batman: Arkham City GOTY",
                "Batman: Arkham Knight",
                "Batman™: Arkham Origins",
                "Batman™: Arkham Origins Blackgate -Deluxe Edition",
                "Psychoballs",
                "Psychonauts",
                "Psychonauts Demo",
                "Pukan Bye Bye",
                "PulseCharge",
                "Pulstar",
                "Puppy Dog: Jigsaw Puzzles",
                "Purgatory",
                "Purgatory II",
                "Purple Heart",
                "PUSH",
                "Pushover",
                "Puzzle Galaxies",
                "Puzzle Nebula",
                "Puzzles At Mystery Manor",
                "Puzzles Under The Hill",
                "QLORB",
                "QLORB 2",
                "Quad Hopping",
                "Quake Champions",
                "QUALIA 3: Multi Agent",
                "Quanect",
                "Quantum Break",
                "Qubika",
                "Quest for Infamy",
                "Qvabllock",
                "R.O.V.E.R.",
                "Rabiez: Epidemic",
                "ReX",
                "Rheum",
                "Ricochet",
                "Ricochet Kills: Noir",
                "Ringies",
                "Ripped Pants at Work",
                "Rise of Crustaceans",
                "Rising Storm / Red Orchestra 2 Multiplayer",
                "RKN - Roskomnadzor banned the Internet",
                "Roads of Rome"
            };
            GameListNormalPosition = new Point(151, 56);
            GameListCollapsedPosition = new Point(35, 56);
            GameListControls = new Label[GameList.Length];
            bool RunningGame = false;
            Random rd = new Random();
            for (int i = 0; i < GameList.Length; i++)
            {
                Label tmpLabel = new Label();
                GameListPanel.Controls.Add(tmpLabel);
                tmpLabel.Text = GameList[i];
                tmpLabel.Font = new Font("宋体", 8);
                tmpLabel.AutoSize = true;
                int tmpRandom = rd.Next(5);
                while (tmpRandom == 2 && RunningGame)
                {
                    tmpRandom = rd.Next(5);
                }
                if (tmpRandom == 2)
                    RunningGame = true;
                ResourceManager resourceManager = new ResourceManager("Threshold_Miku_Customizer.Form1", Assembly.GetExecutingAssembly());
                switch (tmpRandom)
                {
                    case 2:
                        tmpLabel.Text += " " + resourceManager.GetString("Code.running");
                        break;
                    case 4:
                        tmpLabel.Text += " " + resourceManager.GetString("Code.syncing");
                        break;
                    case 5:
                        tmpLabel.Text += " " + resourceManager.GetString("Code.updating");
                        break;
                }
                tmpLabel.Tag = tmpRandom;
                tmpLabel.Location = new Point(3, i * 12 + 3);
                tmpLabel.MouseHover += new System.EventHandler(onGameListItemHovered);
                tmpLabel.MouseLeave += new System.EventHandler(onGameListItemLeaved);
                //onGameListItemLeaved(tmpLabel, new EventArgs());
                GameListControls[i] = tmpLabel;
            }
            ResetCodeVars();
            foreach (Label tmpGameListItem in GameListControls)
                onGameListItemLeaved(tmpGameListItem, new EventArgs());
        }

        private void ResetCodeVars()
        {
            CodeVars.Clear();
            //Init CodeVars
            CodeVars.Add("MainUI.BG", "");
            CodeVars.Add("Settings.BG", "");
            CodeVars.Add("Installation.BG", "");
            CodeVars.Add("BackupAndRestore.BG", "");
            CodeVars.Add("SystemInfo.BG", "");
            CodeVars.Add("Loggin.BG", "");
            CodeVars.Add("SecurityWizard.BG", "");
            CodeVars.Add("CDKey.BG", "");
            CodeVars.Add("MainUI.Collapsed", false.ToString());
            for (int i = 0; i < 6; i++)
            {
                CodeVars.Add(MyFunc.GetTextTypeByID(i, false), CurrentTheme.GetString(MyFunc.GetTextTypeByID(i, false)));
                CodeVars.Add(MyFunc.GetTextTypeByID(i, true), CurrentTheme.GetString(MyFunc.GetTextTypeByID(i, true)));
            }
        }

        private void ResetPreview()
        {
            MainUI_BGPic.BackgroundImage=(Image)CurrentTheme.GetObject("MainBG");
            Settings_BGPic.BackgroundImage = (Image)CurrentTheme.GetObject("SettingsDialog");
            Installation_BGPic.BackgroundImage = (Image)CurrentTheme.GetObject("InstallAppWizard");
            BackupAndRestore_BGPic.BackgroundImage = (Image)CurrentTheme.GetObject("BackupWizard");
            SystemInfo_BGPic.BackgroundImage = (Image)CurrentTheme.GetObject("SystemInfo");
            Loggin_BGPic.BackgroundImage = (Image)CurrentTheme.GetObject("LoginBG");
            SecurityWizard_BGPic.BackgroundImage = (Image)CurrentTheme.GetObject("bg_security_wizard");
            CDKey_BGPic.BackgroundImage = (Image)CurrentTheme.GetObject("CDKeyWizard");
            //MainUI_BGPic.Image = (Image)CurrentTheme.GetObject("MainUIMask");
            checkCollapsedSidebar.Checked = false;
            checkCollapsedSidebar_CheckedChanged(checkCollapsedSidebar, new EventArgs());
            Settings_BGPic.Image = (Image)CurrentTheme.GetObject("SettingsMask");
            Installation_BGPic.Image = (Image)CurrentTheme.GetObject("InstallationMask");
            BackupAndRestore_BGPic.Image = (Image)CurrentTheme.GetObject("BackupAndRestoreMask");
            SystemInfo_BGPic.Image = (Image)CurrentTheme.GetObject("SystemInfoMask");
            Loggin_BGPic.Image = (Image)CurrentTheme.GetObject("LoginMask");
            SecurityWizard_BGPic.Image = (Image)CurrentTheme.GetObject("TwoFactorMask");
            CDKey_BGPic.Image = (Image)CurrentTheme.GetObject("CDKeyWizardMask");
            GameListPanel.BackgroundImage = (Image)CurrentTheme.GetObject("FadeLR");
            foreach (Label tmpGameListItem in GameListControls)
                onGameListItemLeaved(tmpGameListItem, new EventArgs());
        }

        //0=uninstall
        //1=Installed
        //2=Running
        //3=Shortcut
        //4=Syncing
        //5=Updating
        private void onGameListItemHovered(object sender, EventArgs e)
        {
            Label senderLabel = (Label)sender;
            senderLabel.ForeColor = ColorTranslator.FromHtml(CodeVars[MyFunc.GetTextTypeByID((int)senderLabel.Tag,true)]);
        }
        private void onGameListItemLeaved(object sender, EventArgs e)
        {
            Label senderLabel = (Label)sender;
            senderLabel.ForeColor = ColorTranslator.FromHtml(CodeVars[MyFunc.GetTextTypeByID((int)senderLabel.Tag, false)]);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyResourceToAll(Control.ControlCollection ctc, System.ComponentModel.ComponentResourceManager res)
        {
            foreach (Control ct in ctc)
            {
                res.ApplyResources(ct, ct.Name);
                if (ct.HasChildren)
                {
                    ApplyResourceToAll(ct.Controls,res);
                }
            }
        }

        private void MainBG_HoverTextColor_Click(object sender, EventArgs e)
        {
            string TextType = MyFunc.GetTextTypeByID(MainUI_TextComboBox.SelectedIndex, true);
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CodeVars[TextType] = ColorTranslator.ToHtml(colorDialog1.Color);
                MainBG_HoverTextColor.BackColor = colorDialog1.Color;
            }
        }

        private void MainUI_TextComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comSender = (ComboBox)sender;
            if (comSender.SelectedIndex>=0&& comSender.SelectedIndex<6)
            {
                MainBG_NormalTextColor.BackColor = ColorTranslator.FromHtml(CodeVars[MyFunc.GetTextTypeByID(comSender.SelectedIndex, false)]);
                MainBG_HoverTextColor.BackColor = ColorTranslator.FromHtml(CodeVars[MyFunc.GetTextTypeByID(comSender.SelectedIndex, true)]);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML Document|*.xml";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            XmlDocument SavXMLDoc = new XmlDocument();
            SavXMLDoc.Load(openFileDialog1.FileName);
            CodeVars.Clear();
            foreach(XmlNode node in SavXMLDoc.DocumentElement.ChildNodes)
            {
                CodeVars.Add(node.Name, node.InnerText);
            }
            PraseCodeVarToPreview();
        }

        private void PraseCodeVarToPreview()
        {
            ResetPreview();
            if (CodeVars["MainUI.BG"] != "")
            {
                MainUI_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["MainUI.BG"]);
            }
            if (CodeVars["Settings.BG"] != "")
            {
                Settings_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["Settings.BG"]);
            }
            if (CodeVars["Installation.BG"] != "")
            {
                Installation_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["Installation.BG"]);
            }
            if (CodeVars["BackupAndRestore.BG"] != "")
            {
                BackupAndRestore_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["BackupAndRestore.BG"]);
            }
            if (CodeVars["SystemInfo.BG"] != "")
            {
                SystemInfo_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["SystemInfo.BG"]);
            }
            if (CodeVars["Loggin.BG"] != "")
            {
                Loggin_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["Loggin.BG"]);
            }
            if (CodeVars["SecurityWizard.BG"] != "")
            {
                SecurityWizard_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["SecurityWizard.BG"]);
            }
            if (CodeVars["CDKey.BG"] != "")
            {
                CDKey_BGPic.BackgroundImage = MyFunc.LoadImageByPath(CodeVars["CDKey.BG"]);
            }
            bool Collapsed = false;
            bool.TryParse(CodeVars["MainUI.Collapsed"], out Collapsed);
            checkCollapsedSidebar.Checked = Collapsed;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "XML Document|*.xml";
            if(saveFileDialog1.ShowDialog()!=DialogResult.OK)
                return;
            XmlDocument SavXMLDoc = new XmlDocument();
            XmlElement RootElement = SavXMLDoc.CreateElement("SaveSettings");
            SavXMLDoc.AppendChild(RootElement);
            foreach(KeyValuePair<string,string> Pair in CodeVars.ToList())
            {
                var Element= SavXMLDoc.CreateElement(Pair.Key);
                Element.InnerText = Pair.Value;
                RootElement.AppendChild(Element);
            }
            SavXMLDoc.Save(saveFileDialog1.FileName);
        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            (new About()).ShowDialog();
        }

        private void checkUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Jack-Myth/Threshold-Miku-Customizer/releases");
        }

        private void thresholdMikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTheme = new ResourceManager("Threshold_Miku_Customizer.ThresholdMiku", Assembly.GetExecutingAssembly());
            ResetCodeVars();
            ResetPreview();
            Loggin_BGPic.Size = Loggin_BGPic.Image.Size;
            Installation_BGPic.Size = Installation_BGPic.Image.Size;
            SecurityWizard_BGPic.Size = SecurityWizard_BGPic.Image.Size;
        }

        private void thresholdMikuLightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTheme = new ResourceManager("Threshold_Miku_Customizer.ThresholdMikuLight", Assembly.GetExecutingAssembly());
            ResetCodeVars();
            ResetPreview();
            Loggin_BGPic.Size = Loggin_BGPic.Image.Size;
            Installation_BGPic.Size = Installation_BGPic.Image.Size;
            SecurityWizard_BGPic.Size = SecurityWizard_BGPic.Image.Size;
        }

        private void ApplyResource()
        {
            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(typeof(Form1));
            ApplyResourceToAll(Controls,res);
            //菜单
            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                res.ApplyResources(item, item.Name);
                foreach (ToolStripItem subItem in item.DropDownItems)
                {
                    res.ApplyResources(subItem, subItem.Name);
                }
            }

            //MainUI_TextComboBox
            MainUI_TextComboBox.Items[0] = res.GetString("MainUI_TextComboBox.Items");
            for (int i=1;i<6;i++)
            {
                MainUI_TextComboBox.Items[i] = res.GetString("MainUI_TextComboBox.Items"+i.ToString());
            }

            //Caption
            res.ApplyResources(this, "$this");
        }
    }

}
