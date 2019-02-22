using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatplotlibCS;
using MatplotlibCS.PlotItems;

namespace Examples.Plot2D
{
    class ExampleArс : IExample
    {
        /// <summary>
        /// Chart of sin
        /// </summary>
        public void Run(string pythonExePath, string dasPlotPyPath)
        {
            #region create test data
            
            var X = new double[2] {-1, 1};
            var Y = new double[2] {-1, 1};

            #endregion

            #region create plot

            // init engine with right paths 
            var matplotlibCs = new MatplotlibCS.MatplotlibCS(pythonExePath, dasPlotPyPath);

            var figure = new Figure(1, 1)
            {
                FileName = "ExampleArc.png",
                OnlySaveImage = true,
                Width = 1080,
                DPI = 150,
                Subplots =
                {
                    new Axes(1, "The X axis", "The Y axis")
                    {
                        Title = "Arc, Annotations",
                        LegendLocation = LegendLocation.LowerLeft,
                        Grid = new Grid()
                        {
                            MinorAlpha = 0.2,
                            MajorAlpha = 1.0,
                        },
                        PlotItems =
                        {
                            new Line2D("45")
                            {
                                X = new List<object>() {-1, 1},
                                Y = new List<double>() {-1, 1},
                                Color = Color.Blue
                            },
                            new Line2D("90")
                            {
                                X = new List<object>() {0, 0},
                                Y = new List<double>() {-1, 1},
                                Color = Color.Magenta
                            },
                            new Line2D("145")
                            {
                                X = new List<object>() {-1, 1},
                                Y = new List<double>() {1, -1},
                                Color = Color.Green
                            },

                            new Arc("45 arc", 0, 0, 0.5, 0.5, 0, 0, 45) {Color = Color.Blue},
                            new Arc("90 arc", 0, 0, 0.6, 0.6, 0, 0, 90) {Color = Color.Magenta},
                            new Arc("135 arc", 0, 0, 0.7, 0.7, 0, 0, 135) {Color = Color.Green},

                            new Text("ant1","45", 0.1, 0.04) {Alpha = 0.4},
                            new Annotation("ant2","90", 0.2, 0.6, 0.11, 0.26) {Alpha = 0.5},
                            new Annotation("ant3","135", -0.2, 0.6, -0.08, 0.32),

                            new Hline("0", 0, -1, 1) {LineStyle = LineStyle.Solid, Color = Color.Black}
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
