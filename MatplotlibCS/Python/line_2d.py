import matplotlib.pyplot as plot
from datetime import datetime
import matplotlib.dates as mdates
from helpers import if_string_convert_to_datetime

class Line2D:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict
        self.check_if_x_is_time()

    def check_if_x_is_time(self):
        if isinstance(self.x, str) or (isinstance(self.x, list) and isinstance(self.x[0], str)):
            self.x = if_string_convert_to_datetime(self.x)

    def plot(self, axes):
        label = self.name if self.show_legend else ""
        markeredgecolor = self.color["value"] if self.markeredgecolor is None else self.markeredgecolor["value"]
        markerfacecolor = self.color["value"] if self.markerfacecolor is None else self.markerfacecolor["value"]
        plot.plot(self.x,
                  self.y,
                  color=self.color["value"],
                  marker=self.marker,
                  markeredgecolor=markeredgecolor,
                  markeredgewidth=self.markeredgewidth,
                  markerfacecolor=markerfacecolor,
                  lw=self.lineWidth,
                  ms=self.markerSize,
                  ls=self.lineStyle,
                  markevery=self.markevery,
                  alpha=self.alpha,
                  label=label)
