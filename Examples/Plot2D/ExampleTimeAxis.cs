using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;

namespace Examples.Plot2D
{
    class ExampleTimeAxis
    {
        /// <summary>
        /// Chart of sin
        /// </summary>
        public static void Run(string pythonExePath, string dasPlotPyPath)
        {
            #region create test data

            const int N = 10;
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

            var timeTicks = new List<DateTime>();
            timeTicks.Add(DateTime.Now);
            var timeStep = new TimeSpan(0, 4, 0, 0);
            for (int i = 1; i < N; i++)
                timeTicks.Add(timeTicks[i - 1] + timeStep);
            
            var figure = new Figure(1, 1)
            {
                FileName = "ExampleTimeAxis.png",
                OnlySaveImage = true,
                DPI = 150,
                Subplots =
                {
                    new Axes(1, "Time", "Value")
                    {
                        Title = "Time Axis Example",
                        LegendBorder = false,
                        Grid = new Grid()
                        {
                            MinorAlpha = 0.2,
                            MajorAlpha = 1.0,
                            XTimeTicks = timeTicks.Cast<object>().ToList(),
                            TimeTickFormat = TimeTickFormat.HHMMSS,
                            YMajorTicks = new[] {-1, 2.5, 0.25, 0.125},
                            XMinorTicks = new[] {0.0, 7.25, 0.25, 1.125},
                            YMinorTicks = new[] {-1, 2.5, 0.125, 1.025},
                            XTickFontSize = 8,
                            XTickRotation = 30
                        },
                        PlotItems =
                        {
                            new Line2D("Data")
                            {
                                X = timeTicks.Cast<object>().ToList(),
                                Y = Y1.ToList(),
                                LineStyle = LineStyle.Dashed,
                                Marker = Marker.Circle,
                                MarkerSize = 5
                            },
                            new Vline("vl", new object[] {DateTime.Now.AddHours(2)},-1,1)
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
