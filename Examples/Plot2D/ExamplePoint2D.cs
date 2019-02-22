using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;

namespace Examples.Plot2D
{
    class ExamplePoint2D : IExample
    {
        /// <summary>
        /// Chart of sin
        /// </summary>
        public void Run(string pythonExePath, string dasPlotPyPath)
        {
            // init engine with right paths 
            var matplotlibCs = new MatplotlibCS.MatplotlibCS(pythonExePath, dasPlotPyPath);

            var figure = new Figure(1, 1)
            {
                FileName = "ExamplePoint2D.png",
                OnlySaveImage = true,
                DPI = 150,
                Subplots =
                {
                    new Axes(1, "The X axis", "The Y axis")
                    {
                        Title = "2D points",
                        Grid = new Grid()
                        {
                            XLim = new double[] {-5, 15},
                            YLim = new double[] {-5, 15}
                        },
                        PlotItems =
                        {
                            new Point2D("Point 1", 0, 0)
                            {
                                MarkerEdgeColor = Color.Black,
                                MarkerFaceColor = Color.Cyan,
                                MarkerSize = 15,
                                MarkerEdgeWidth = 2,
                            },
                            new Point2D("Point 2", 10, 10)
                            {
                                Color = Color.Red,
                                MarkerSize = 15,
                                MarkerEdgeWidth = 3,
                                Marker = Marker.Vline
                            },
                            new Line2D("Line 1")
                            {
                                X = new List<object>() {-2,8.0},
                                Y = new List<double>() {0,10.0},
                                Color = Color.Green, 
                                MarkerEdgeColor = Color.Blue,
                                MarkerFaceColor = Color.None,
                                MarkerEdgeWidth = 3,
                                Marker = Marker.Circle,
                                MarkerSize = 10
                            }
                        }
                    }
                }
            };

            var t = matplotlibCs.BuildFigure(figure);
            t.Wait();
        }
    }
}
