using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Threshold_Miku_Customizer
{
    class MyFunc
    {
        static public Image LoadImageByPath(string ImagePath)
        {
            if (Path.GetExtension(ImagePath).Equals("TGA", StringComparison.CurrentCultureIgnoreCase))
            {
                ImageTGA tmpImageTGA = new ImageTGA(ImagePath);
                return tmpImageTGA.Image;
            }
            else
            {
                return Image.FromFile(ImagePath);
            }
        }

        static public void SaveImageByPath(string OriginalPath,string TargetPath)
        {
            if (Path.GetExtension(OriginalPath).Equals("TGA", StringComparison.CurrentCultureIgnoreCase))
            {
                File.Copy(OriginalPath, TargetPath, true);
            }
            else
            {
                Bitmap tmpImage = new Bitmap(OriginalPath);
                ImageTGA tmpImageTGA = new ImageTGA();
                tmpImageTGA.Image = tmpImage;
                tmpImageTGA.SaveImage(TargetPath);
            }
        }

        static public string GetTextTypeByID(int ID,bool isHovered)
        {
            string TextType="";
            switch(ID)
            {
                case 0:
                    TextType = "Uninstall";
                    break;
                case 1:
                    TextType = "Installed";
                    break;
                case 2:
                    TextType = "Running";
                    break;
                case 3:
                    TextType = "Shortcut";
                    break;
                case 4:
                    TextType = "Syncing";
                    break;
                case 5:
                    TextType = "Updating";
                    break;
            }
            if (isHovered)
                TextType += "H";
            return TextType;
        }

        public static void ApplyParamter(ref string DataStr,string ParamterName, string Value)
        {
            DataStr=DataStr.Replace("<%#" + ParamterName + "#%>", Value);
        }

        public static void ApplyColorParamter(ref string DataStr,string ParamterName,Color colorToApply)
        {
            string ColorStr = string.Format("{0} {1} {2} {3}",colorToApply.R,colorToApply.G,colorToApply.B, colorToApply.A);
            ApplyParamter(ref DataStr, ParamterName, ColorStr);
        }

        public static void CopyDir(string sourceDirName, string destDirName,bool ShouldOveride)
        {
            if (sourceDirName.Substring(sourceDirName.Length - 1) != "\\")
            {
                sourceDirName = sourceDirName + "\\";
            }
            if (destDirName.Substring(destDirName.Length - 1) != "\\")
            {
                destDirName = destDirName + "\\";
            }
            if (Directory.Exists(sourceDirName))
            {
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }
                foreach (string item in Directory.GetFiles(sourceDirName))
                {
                    File.Copy(item, destDirName + Path.GetFileName(item), ShouldOveride);
                }
                foreach (string item in Directory.GetDirectories(sourceDirName))
                {
                    CopyDir(item, destDirName + item.Substring(item.LastIndexOf("\\") + 1),ShouldOveride);
                }
            }
        }
    }
}
