using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;

namespace Examples.Plot2D
{
    class ExampleHistogram : IExample
    {
        /// <summary>
        /// Chart of sin
        /// </summary>
        public void Run(string pythonExePath, string dasPlotPyPath)
        {
            #region create test data

            const int N = 1000;
            var X = new double[N];
            var rnd = new Random();
            for (var i = 0; i < N; i++)
                X[i] = (rnd.NextDouble()-0.5)*10.0;

            #endregion

            #region create plot

            // init engine with right paths 
            var matplotlibCs = new MatplotlibCS.MatplotlibCS(pythonExePath, dasPlotPyPath);

            var figure = new Figure(2, 2)
            {
                FileName = "ExampleHistogram.png",
                OnlySaveImage = true,
                DPI = 150,
                Subplots =
                {
                    new Axes(1, "The X axis", "The Y axis")
                    {
                        Title = "Hist 1",
                        ShowLegend = false,
                        PlotItems =
                        {
                            new Histogram("Sin")
                            {
                                Y = X.ToList(),
                            }
                        }
                    },
                    new Axes(2, "The X axis", "The Y axis")
                    {
                        Title = "Hist 2",
                        PlotItems =
                        {
                            new Histogram("Sin")
                            {
                                Y = X.ToList(),
                                Color = Color.Black,
                                Alpha = 0.5,
                                Range = new []{-1, 1.0}
                            }
                        }
                    },
                    new Axes(3, "The X axis", "The Y axis")
                    {
                        Title = "Hist 3",
                        PlotItems =
                        {
                            new Histogram("Sin")
                            {
                                Y = X.ToList(),
                                Orientation = HistogramOrientation.Horizontal
                            }
                        }
                    },
                    new Axes(4, "The X axis", "The Y axis")
                    {
                        Title = "Hist 4",
                        PlotItems =
                        {
                            new Histogram("Sin")
                            {
                                Y = X.ToList(),
                                Bins = 10,
                                Color = Color.Red,
                                Alpha = 0.5,
                                Range = new []{-1, 1.0},
                                Normed = true
                            }
                        }
                    },

                }
            };

            var t = matplotlibCs.BuildFigure(figure);
            t.Wait();

            #endregion
        }
    }
}
