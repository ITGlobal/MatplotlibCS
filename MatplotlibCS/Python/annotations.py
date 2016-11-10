import matplotlib.pyplot as plot

class Text:
    def __init__(self, jsonDict):
        self.fontSize = 12
        self.color = 'k'
        self.__dict__ = jsonDict

    def plot(self, axes):
        plot.text(self.x,
                  self.y,
                  self.text,
                  size = self.fontSize,
                  color = self.color)

class Annotation:
    def __init__(self, jsonDict):
        self.fontSize = 12
        self.color = 'k'
        self.__dict__ = jsonDict

    def plot(self, axes):
        plot.annotate(self.text,
                      xy=(self.arrow_x, self.arrow_y),
                      xycoords='data',
                      xytext=(self.text_x, self.text_y),
                      textcoords='data',
                      color = self.color,
                      arrowprops=dict(
                          color = self.color,
                          arrowstyle="->",
                          connectionstyle='arc3,rad=0',
                      )
                      )
