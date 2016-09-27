using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;

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
        private static string _dasPlotPyPath;

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("You must specify path to python.exe and to dasPlot.py in command line arguments");
                Console.ReadKey();
                return;
            }

            _pythonExePath = args[0];
            _dasPlotPyPath = args[1];

            ExampleSin();
        }

        /// <summary>
        /// Chart of sin
        /// </summary>
        static void ExampleSin()
        {
            #region create test data

            const int N = 100;
            var X = new double[N];
            var Y = new double[N];
            var x = 0.0;
            const double h = 2*Math.PI/N;
            for (var i = 0; i < N; i++)
            {
                var y = Math.Sin(x);
                X[i] = x;
                Y[i] = y;
                x += h;
            }

            #endregion

            #region create plot

            // init engine with right paths 
            var dasPlot = new DasPlot(_pythonExePath, _dasPlotPyPath);

            var figure = new Figure(1, 1);
            var axes = new Axes(1, "The X axis", "The Y axis");
            figure.Subplots.Add(axes);

            var line = new Line2D("Sin");
            axes.PlotItems.Add(line);

            line.X.AddRange(X);
            line.Y.AddRange(Y);

            dasPlot.DoTask(figure);

            #endregion

        }
    }
}
