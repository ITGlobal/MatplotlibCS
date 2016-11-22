import matplotlib.pyplot as plot


class Histogram:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

    def plot(self, axes):
        plot.hist(
            self.y,
            self.bins,
            color=self.color["value"],
            normed=self.normed,
            orientation=self.orientation,
            range=self.range,
            cumulative=self.cumulative,
            histtype=self.histtype,
            alpha=self.alpha)
        plot.hold(True)
