using Examples.Plot2D;
using System;
using System.Linq;
using System.Reflection;

namespace Examples
{    
    /// <summary>
    /// Sample programm which creates several charts and save them in png
    /// </summary>
    class Program
    {
        /// <summary>
        /// Path to python.exe, must be initialized in Main
        /// </summary>
        private static string _pythonExePath;

        /// <summary>
        /// Path to dasPlot.py, script which finally builds plots
        /// </summary>
        private static string _matplotlibPyPath;

        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("You must specify path to python.exe and to matplotlib_cs.py in command line arguments");
                Console.ReadKey();
                return;
            }

            _pythonExePath = args[1];
            _matplotlibPyPath = args[2];
            
            var assembly = Assembly.GetEntryAssembly();
            foreach (Type type in assembly.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IExample))))
            {
                if (args.Length > 0 && !args.Contains(type.Name))
                    continue;

                Console.WriteLine($"{DateTime.UtcNow} Starting {type.Name}");

                var example = (IExample)Activator.CreateInstance(type);

                try
                {
                    example.Run(_pythonExePath, _matplotlibPyPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                Console.WriteLine($"{DateTime.UtcNow} Completed {type.Name}");
            }

            Console.ReadLine();
        }
    }
}
