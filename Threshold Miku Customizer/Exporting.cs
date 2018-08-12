using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threshold_Miku_Customizer
{
    public partial class Exporting : Form
    {
        ResourceManager TargetResource;
        Dictionary<string, string> CodeVars;
        long total,lastVal,sum;
        string TargetPath,SkinFolder;
        public Exporting()
        {
            InitializeComponent();
        }

        public void Export(ResourceManager TargetResource, Dictionary<string, string> CodeVars,string TargetPath)
        {
            this.TargetResource = TargetResource;
            this.CodeVars = CodeVars;
            this.TargetPath = TargetPath;
            SkinFolder = TargetResource.GetString("SkinFolder");
            timer1.Enabled = true;
            ShowDialog();
        }

        private void onExtractProgress(object sender, Ionic.Zip.ExtractProgressEventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            if (total != e.TotalBytesToTransfer)
            {
                sum += total - lastVal + e.BytesTransferred;
                total = e.TotalBytesToTransfer;
            }
            else
                sum += e.BytesTransferred - lastVal;

            lastVal = e.BytesTransferred;

            progressBar1.Value = (Int32)sum;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string TempZipFile = Path.GetTempFileName() + ".zip";
            System.IO.File.WriteAllBytes(TempZipFile, (byte[])TargetResource.GetObject("Core"));
            Ionic.Zip.ZipFile zipf = new Ionic.Zip.ZipFile(TempZipFile);
            long totalSize=0;
            foreach (var entry in zipf)
            {
                totalSize += entry.UncompressedSize;
            }
            progressBar1.Maximum = (Int32)totalSize;
            zipf.ExtractProgress += new EventHandler<Ionic.Zip.ExtractProgressEventArgs>(onExtractProgress);
            try
            {
                zipf.ExtractAll(TargetPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
            }
            catch
            {
                MessageBox.Show("Error");
                Close();
            }

            //Save Backgrounds
            if(CodeVars["MainUI.BG"]!="")
            {
                MyFunc.SaveImageByPath(CodeVars["MainUI.BG"],Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/MainBG.tga"));
            }
            if (CodeVars["Settings.BG"] != "")
            {
                MyFunc.SaveImageByPath(CodeVars["Settings.BG"], Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/SettingsDialog.tga"));
            }
            if (CodeVars["Installation.BG"] != "")
            {
                MyFunc.SaveImageByPath(CodeVars["Installation.BG"], Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/InstallAppWizard.tga"));
            }
            if (CodeVars["BackupAndRestore.BG"] != "")
            {
                MyFunc.SaveImageByPath(CodeVars["BackupAndRestore.BG"], Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/BackupWizard.tga"));
            }
            if (CodeVars["SystemInfo.BG"] != "")
            {
                MyFunc.SaveImageByPath(CodeVars["SystemInfo.BG"], Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/SystemInfo.tga"));
            }
            if (CodeVars["Loggin.BG"] != "")
            {
                MyFunc.SaveImageByPath(CodeVars["Loggin.BG"], Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/LoginBG.tga"));
            }
            if (CodeVars["SecurityWizard.BG"] != "")
            {
                MyFunc.SaveImageByPath(CodeVars["SecurityWizard.BG"], Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/bg_security_wizard.tga"));
            }
            if (CodeVars["CDKey.BG"] != "")
            {
                MyFunc.SaveImageByPath(CodeVars["CDKey.BG"], Path.Combine(TargetPath, SkinFolder, "graphics/JackMyth/CDKeyWizard.tga"));
            }

            string Skinpath = Path.Combine(TargetPath, SkinFolder);
            //Apply Collapsed Sliderbar Layout
            {
                bool isCollapsed=false;
                bool.TryParse(CodeVars["MainUI.Collapsed"],out isCollapsed);
                if (isCollapsed)
                {
                    MyFunc.CopyDir(Path.Combine(Skinpath, "Customization/Collapsed Sidebar"), Skinpath,true);
                }
            }

            //Replace Paramter Mark with CodeVars.
            //Text Color
            string SteamStyle = File.ReadAllText(Path.Combine(Skinpath, "resource/styles/steam.styles"));
            for(int i=0;i<6;i++)
            {
                MyFunc.ApplyColorParamter(ref SteamStyle, MyFunc.GetTextTypeByID(i, false),
                    ColorTranslator.FromHtml(CodeVars[MyFunc.GetTextTypeByID(i, false)]));
                MyFunc.ApplyColorParamter(ref SteamStyle, MyFunc.GetTextTypeByID(i, true),
                    ColorTranslator.FromHtml(CodeVars[MyFunc.GetTextTypeByID(i, true)]));
            }
            File.WriteAllText(Path.Combine(Skinpath, "resource/styles/steam.styles"), SteamStyle);
            Close();
        }
    }
}
