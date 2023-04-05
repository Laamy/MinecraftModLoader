using System;

namespace ModLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileIO.Initialize();

            if (FileIO.Folders.CheckCreate("mods"))
            {
                Console.WriteLine("MML initialized, please go to this uri in your file explorer.");
                Console.WriteLine(FileIO.ConfigFolder.FullName);
                //Console.WriteLine();
                Console.ReadKey();
            }

            // inject mods
        }
    }
}
