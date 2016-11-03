using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;

namespace Examples.Plot2D
{
    class ExampleSin
    {
        /// <summary>
        /// Chart of sin
        /// </summary>
        public static void Run(string pythonExePath, string dasPlotPyPath)
        {
            #region create test data

            const int N = 100;
            var X = new double[N];
            var Y = new double[N];
            var x = 0.0;
            const double h = 2 * Math.PI / N;
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
            var dasPlot = new MatplotlibCS.MatplotlibCS(pythonExePath, dasPlotPyPath);

            var figure = new Figure(1, 1)
            {
                FileName = "ExampleSin.png",
                OnlySaveImage = true,
                Subplots =
                {
                    new Axes(1, "The X axis", "The Y axis")
                    {
                        Title = "ExampleSin",
                        PlotItems =
                        {
                            new Line2D("Sin")
                            {
                                X = X.ToList(),
                                Y = Y.ToList()
                            }
                        }
                    }

                }
            };

            var t = dasPlot.BuildFigure(figure);
            t.Wait();

            #endregion
        }
    }
}
