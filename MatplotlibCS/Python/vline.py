import matplotlib.pyplot as plot

from line_2d import Line2D


class Vline(Line2D):
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict
        self.check_if_x_is_time()

    def plot(self, axes):
        label = self.name if self.show_legend else ""
        plot.vlines(self.x,
                    self.ymin,
                    self.ymax,
                    color=self.color["value"],
                    lw=self.lineWidth,
                    linestyle=self.lineStyle,
                    alpha=self.alpha,
                    label=label)
