using System;

namespace ModLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileIO.Initialize();

            Console.WriteLine(FileIO.ConfigFolder.FullName);

            if (FileIO.Folders.CheckCreate("mods"))
            {

            }
            else
            {
                // inject mods
            }
        }
    }
}
