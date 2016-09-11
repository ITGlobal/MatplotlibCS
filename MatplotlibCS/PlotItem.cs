using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary>
    /// Базовый класс для элементов, которые отрисовываются на графике
    /// </summary>
    public abstract class PlotItem
    {
        /// <summary>
        /// Тип элемента графика (линия, гистограмма, подпись и т.д.)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type => GetType().Name;
    }
}
