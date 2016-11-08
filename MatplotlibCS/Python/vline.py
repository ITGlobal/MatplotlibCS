import matplotlib.pyplot as plot


class Vline:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

    def plot(self, axes):
        plot.vlines(self.x,
                    self.ymin,
                    self.ymax,
                    color=self.color,
                    lw=self.lineWidth,
                    linestyle=self.lineStyle)
        plot.hold(True)
