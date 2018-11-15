import matplotlib.pyplot as plot
from matplotlib.ticker import FormatStrFormatter


class Histogram:
    def __init__(self, jsonDict):
        self.__dict__ = jsonDict

    def plot(self, axes):
        label = self.name if self.show_legend else ""
        counts, bins, patches = plot.hist(
            self.y,
            self.bins,
            color=self.color["value"],
            normed=self.normed,
            orientation=self.orientation,
            range=self.range,
            cumulative=self.cumulative,
            histtype=self.histtype,
            alpha=self.alpha,
            label=label)
        axes.set_xticks(bins)
        # axes.xaxis.set_major_formatter(FormatStrFormatter('%f'))

