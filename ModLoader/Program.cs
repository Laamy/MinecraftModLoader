using System;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] logo = @"      ___           ___                   
     /__/\         /__/\                  
    |  |::\       |  |::\                 
    |  |:|:\      |  |:|:\    ___     ___ 
  __|__|:|\:\   __|__|:|\:\  /__/\   /  /\
 /__/::::| \:\ /__/::::| \:\ \  \:\ /  /:/
 \  \:\~~\__\/ \  \:\~~\__\/  \  \:\  /:/ 
  \  \:\        \  \:\         \  \:\/:/  
   \  \:\        \  \:\         \  \::/   
    \  \:\        \  \:\         \__\/    
     \__\/         \__\/                  ".Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string logoItem in logo)
            {
                Console.SetCursorPosition((Console.WindowWidth - logoItem.Length) / 2, Console.CursorTop);
                Console.WriteLine(logoItem);
            }
            Task.Factory.StartNew(() =>
            {
                Console.Cur
                foreach (string logoItem in logo)
                {

                    Console.SetCursorPosition((Console.WindowWidth - logoItem.Length) / 2, Console.CursorTop);
                    Console.Write(logoItem);
                }
            });

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
