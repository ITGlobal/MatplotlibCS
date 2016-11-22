import matplotlib.pyplot as plot


class Vline:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

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
        plot.hold(True)
