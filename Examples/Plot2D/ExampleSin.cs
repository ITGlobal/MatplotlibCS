﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;

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
            var Y1 = new double[N];
            var Y2 = new double[N];
            var x = 0.0;
            const double h = 2 * Math.PI / N;
            var rnd = new Random();
            for (var i = 0; i < N; i++)
            {
                var y = Math.Sin(x);
                X[i] = x;
                Y1[i] = y;

                y = Math.Sin(2 * x);
                Y2[i] = y + rnd.NextDouble() / 10.0;

                x += h;
            }

            #endregion

            #region create plot

            // init engine with right paths 
            var matplotlibCs = new MatplotlibCS.MatplotlibCS(pythonExePath, dasPlotPyPath);

            var figure = new Figure(1, 1)
            {
                FileName = "ExampleSin.png",
                OnlySaveImage = true,
                DPI = 150,
                Subplots =
                {
                    new Axes(1, "The X axis", "The Y axis")
                    {
                        Title = "Sin(x), Sin(2x), VLines, HLines, Annotations",
                        Grid = new Grid()
                        {
                            MinorAlpha = 0.2,
                            MajorAlpha = 1.0,
                            XMajorTicks = new[] {0.0, 7.6, 0.5},
                            YMajorTicks = new[] {-1, 2.5, 0.25},
                            XMinorTicks = new[] {0.0, 7.25, 0.25},
                            YMinorTicks = new[] {-1, 2.5, 0.125}
                        },
                        PlotItems =
                        {
                            new Line2D("Sin")
                            {
                                X = X.ToList(),
                                Y = Y1.ToList(),
                                LineStyle = LineStyle.Dashed
                            },

                            new Line2D("Sin 2x")
                            {
                                X = X.ToList(),
                                Y = Y2.ToList(),
                                LineStyle = LineStyle.Solid,
                                LineWidth = 0.5f,
                                Color = Color.Green,
                                Markevery = 5,
                                MarkerSize = 10,
                                Marker = Marker.Circle
                            },

                            new Text("Text annotation", 4.5, 0.76)
                            {
                                FontSize = 17
                            },

                            new Annotation("Arrow text annotation", 0.5, -0.7, 3, 0)
                            {
                                Color = Color.Blue
                            },

                            new Vline("vert line", 3.0, -1, 1),
                            new Hline("hrzt line", new[] {0.1, 0.25, 0.375}, 0, 5) {LineStyle = LineStyle.Dashed, Color = Color.Magenta}
                        }
                    }

                }
            };

            var t = matplotlibCs.BuildFigure(figure);
            t.Wait();

            #endregion
        }
    }
}
