# MatplotlibCS
A tiny library for utilizing Matplotlib Python charting library from C#. The general process is this:
1. You create an instance of the class Figure and initialize it's properties with relative data. This instance finally describes everything you want to see on the figure.
2. You initialize DasPlot class instance. You need to specify a path to python.exe and dasPlot.py in constructor.
3. Call DasPlot instance DoTask method to plot the figure.
