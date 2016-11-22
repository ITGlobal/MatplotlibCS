import matplotlib.pyplot as plot


class Hline:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

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
        plot.hold(True)