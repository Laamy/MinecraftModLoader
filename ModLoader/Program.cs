using System;
using System.IO;

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

            InjectionHandler.injectionStagedEvent += hookEvent;
            
            // inject mods
            foreach (string file in Directory.GetFiles($"{FileIO.ConfigFolder.FullName}\\mods"))
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Extension == ".dll")
                {
                    InjectionHandler.InjectDLL(file);
                    Console.WriteLine($"Injected {fi.Name}");
                }
            }

            Console.ReadLine();
        }

        private static void hookEvent(object sender, InjectEventArgs e)
        {
            Console.WriteLine(e.injectionStage);
        }
    }
}
