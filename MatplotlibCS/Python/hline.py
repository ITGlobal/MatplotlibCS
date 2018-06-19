import matplotlib.pyplot as plot
from line_2d import Line2D
from helpers import if_string_convert_to_datetime

class Hline(Line2D):
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict
        self.xmin = if_string_convert_to_datetime(self.xmin)
        self.xmax = if_string_convert_to_datetime(self.xmax)

    def plot(self, axes):
        label = self.name if self.show_legend else ""
        plot.hlines(self.y,
                    self.xmin,
                    self.xmax,
                    color=self.color["value"],
                    lw=self.lineWidth,
                    linestyle=self.lineStyle,
                    alpha=self.alpha,
                    label=label)
