import matplotlib.pyplot as plot


class Hline:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

    def plot(self, axes):
        plot.hlines(self.y,
                    self.xmin,
                    self.xmax,
                    color=self.color,
                    lw=self.lineWidth,
                    linestyle=self.lineStyle)
        plot.hold(True)