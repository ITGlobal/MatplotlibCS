using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;

namespace Examples.Plot2D
{
    class ExampleVisibility : IExample
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
                FileName = "ExampleVisibility1.png",
                OnlySaveImage = true,
                DPI = 150,
                Subplots =
                {
                    new Axes(1, "The X axis", "The Y axis")
                    {
                        Title = "Visibility",
                        PlotItems =
                        {
                            new Line2D("Line 1")
                            {
                                X = new List<object>() {-1, 1},
                                Y = new List<double>() {-1, 1},
                                LineStyle = LineStyle.Dashed,
                                Color = Color.Blue
                            },
                            new Line2D("Line 2")
                            {
                                X = new List<object>() {-1, 1},
                                Y = new List<double>() {-2, 2},
                                LineStyle = LineStyle.Solid,
                                Color = Color.Red,
                                IsVisible = false // set this line invisible for first image
                            },
                            new Point2D("plus", 0.5, -0.5)
                            {
                                Marker = Marker.Circle,
                                MarkerSize = 10,
                                Color = Color.Green,
                                LineWidth = 2
                            },
                        }
                    }
                }
            };

            var t = matplotlibCs.BuildFigure(figure);
            t.Wait();

            figure.Subplots[0]["Line 2"].IsVisible = true; // now turn one line2 vivibility and build the second image with new name
            figure.FileName = "ExampleVisibility2.png";
            t = matplotlibCs.BuildFigure(figure);
            t.Wait();
        }
    }
}
