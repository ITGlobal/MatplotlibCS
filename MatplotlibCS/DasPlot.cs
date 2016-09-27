using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatplotlibCS
{
    /// <summary>
    /// Обёртка над питоновским скриптом построения графиков
    /// </summary>
    public class DasPlot
    {
        #region Fields

        /// <summary>
        /// Пусть к интерпрететору питона
        /// </summary>
        private string _pythonExePath;

        /// <summary>
        /// Путь к скрипту dasPlot.py
        /// </summary>
        private string _dasPlotPyPath;

        /// <summary>
        /// Путь директории, в которой хранятся временные json-файлы, через которые передаются параметры задачи
        /// </summary>
        private string _jsonTempPath;

        #endregion

        #region .ctor

        /// <summary>
        /// Обёртка над python скриптом, строящим matplotlib графики 
        /// </summary>
        /// <param name="pythonExePath">Путь python.exe</param>
        /// <param name="dasPlotPyPath">Путь dasPlot.py</param>
        /// <param name="jsonTempPath">Опциональный путь директории, в которой хранятся временные json файлы, через которые передаются данные</param>
        public DasPlot(string pythonExePath, string dasPlotPyPath, string jsonTempPath = "c:\\temp\\MatplotlibCS")
        {
            _pythonExePath = pythonExePath;
            _dasPlotPyPath = dasPlotPyPath;
            _jsonTempPath = jsonTempPath;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Выполняет задачу построения графиков
        /// </summary>
        /// <param name="task">Описание задачи</param>
        public void DoTask(Figure task)
        {
            var jsonPath = GetNewJsonPath();
            var serializer = new JsonSerializer() {StringEscapeHandling = StringEscapeHandling.EscapeHtml};

            using (var writer = new StreamWriter(jsonPath))
            {
                serializer.Serialize(writer, task);
            }
            
            var psi = new ProcessStartInfo(_pythonExePath, $"{_dasPlotPyPath} \"{jsonPath}\"");
            var process = Process.Start(psi);
            process.WaitForExit();
        } 

        #endregion

        #region Private methods

        /// <summary>
        /// Возвращает новый путь, по которому можно сохранить json задачи
        /// </summary>
        /// <returns></returns>
        private string GetNewJsonPath()
        {
            if (!Directory.Exists(_jsonTempPath))
            {
                Directory.CreateDirectory(_jsonTempPath);
            }

            return Path.Combine(_jsonTempPath, $"task-{DateTime.Now:HHmmssfff}.json");
        }

        #endregion
    }
}
