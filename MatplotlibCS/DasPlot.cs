using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary>
    /// Wrapper for lounching python script, which actually builds charts
    /// </summary>
    public class DasPlot
    {
        #region Fields

        /// <summary>
        /// Path to python.exe
        /// </summary>
        private readonly string _pythonExePath;

        /// <summary>
        /// Path to dasPlot.py
        /// </summary>
        private readonly string _dasPlotPyPath;

        #endregion

        #region .ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pythonExePath">Path to python.exe</param>
        /// <param name="dasPlotPyPath">Path to dasPlot.py</param>
        public DasPlot(string pythonExePath, string dasPlotPyPath)
        {
            _pythonExePath = pythonExePath;
            _dasPlotPyPath = dasPlotPyPath;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Build a figure based on described 
        /// </summary>
        /// <param name="task">Описание задачи</param>
        public void DoTask(Figure task)
        {
            var args = "";
            var serializer = new JsonSerializer() {StringEscapeHandling = StringEscapeHandling.EscapeHtml};
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, task);
                args = writer.ToString();
                args = args.Replace("\"", "\\\"");
            }

            var psi = new ProcessStartInfo(_pythonExePath, $"{_dasPlotPyPath} \"{args}\"");
            var process = Process.Start(psi);
            process.WaitForExit();
        }

        #endregion
    }
}
