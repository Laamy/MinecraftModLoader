using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ModLoader
{
    internal class Program
    {
        public static List<string> _console = new List<string>();
        public static string[] logo = @"      ___           ___                   
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

        public static void Print(string message = null)
        {
            Console.Clear();

            for (int i = 0; i < logo.Length; i++)
            {
                string logoItem = logo[i];

                Console.SetCursorPosition((Console.WindowWidth - logoItem.Length) / 2, i);
                Console.Write(logoItem);
            }

            Console.WriteLine();

            if (message != null)
            {
                _console.Add(message);
            }

            foreach (string str in _console)
            {
                Console.WriteLine(str);
            }
        }

        static void Main(string[] args)
        {
            FileIO.Initialize();

            Task.Factory.StartNew(() =>
            {
                int consoleWidth = Console.WindowWidth;

                while (true) try
                    {
                        Task.Delay(50);

                        if (Console.WindowWidth != consoleWidth)
                        {
                            consoleWidth = Console.WindowWidth;
                            Print();
                        }
                    }
                    catch (ArgumentOutOfRangeException) { } // kill errors
                    catch (IOException) { }
            });

            if (FileIO.Folders.CheckCreate("mods"))
            {
                Print("MML initialized, please go to this uri in your file explorer.");
                Print(FileIO.ConfigFolder.FullName);
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
                    Print($"Injected {fi.Name}");
                }
            }

            Console.ReadLine();
        }

        private static void hookEvent(object sender, InjectEventArgs e)
        {
            Print(e.injectionStage);
        }
    }
}
