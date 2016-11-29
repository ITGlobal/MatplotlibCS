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
        plot.plot(self.x,
                  self.y,
                  color=self.color["value"],
                  marker=self.marker,
                  lw=self.lineWidth,
                  ms=self.markerSize,
                  ls=self.lineStyle,
                  markevery=self.markevery,
                  alpha=self.alpha,
                  label=label)
        plot.hold(True)
