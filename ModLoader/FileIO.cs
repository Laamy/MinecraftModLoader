using System;
using System.IO;

namespace ModLoader
{
    internal class FileIO
    {
        public static DirectoryInfo ConfigFolder { get; private set; }

        public static void Initialize()
        {
            ConfigFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Packages\\Microsoft.MinecraftUWP_8wekyb3d8bbwe\\RoamingState\\MML");

            if (!Directory.Exists(ConfigFolder.FullName))
            {
                Directory.CreateDirectory(ConfigFolder.FullName);
            }
        }

        public class Folders
        {
            public static bool CheckCreate(string path)
            {
                if (!Directory.Exists(ConfigFolder.FullName + "\\" + path))
                {
                    Directory.CreateDirectory(ConfigFolder.FullName + "\\" + path);
                    return true;
                }

                return false;
            }
        }

        public class Files
        {
            public static bool CheckCreate(string path)
            {
                if (!File.Exists(ConfigFolder.FullName + "\\" + path))
                {
                    File.Create(ConfigFolder.FullName + "\\" + path);
                    return true;
                }

                return false;
            }
        }
    }
}