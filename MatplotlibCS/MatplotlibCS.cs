using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MatplotlibCS
{
    /// <summary>
    /// Обёртка над питоновским скриптом построения графиков
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class MatplotlibCS
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

        /// <summary>
        /// Python web service URL
        /// </summary>
        private string _serviceUrlCheckAliveMethod = "http://127.0.0.1:57123/";

        /// <summary>
        /// Python web service URL
        /// </summary>
        private string _serviceUrlPlotMethod = "http://127.0.0.1:57123/plot";

        /// <summary>
        /// Kill web service url
        /// </summary>
        private string _serviceUrlKillMethod = "http://127.0.0.1:57123/kill";

        #endregion

        #region .ctor

        /// <summary>
        /// Обёртка над python скриптом, строящим matplotlib графики 
        /// </summary>
        /// <param name="pythonExePath">Путь python.exe</param>
        /// <param name="dasPlotPyPath">Путь dasPlot.py</param>
        /// <param name="jsonTempPath">Опциональный путь директории, в которой хранятся временные json файлы, через которые передаются данные</param>
        public MatplotlibCS(string pythonExePath, string dasPlotPyPath, string jsonTempPath = "c:\\MatplotlibCS")
        {
            _pythonExePath = pythonExePath;
            _dasPlotPyPath = dasPlotPyPath;
            _jsonTempPath = jsonTempPath;

            if (!Directory.Exists(_jsonTempPath))
                Directory.CreateDirectory(_jsonTempPath);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Выполняет задачу построения графиков
        /// </summary>
        /// <param name="task">Описание задачи</param>
        public async Task BuildFigure(Figure task)
        {
            try
            {
                LaunchPythonWebService();

                if (!Path.IsPathRooted(task.FileName))
                    task.FileName = Path.Combine(_jsonTempPath, task.FileName);

                JsonConvert.DefaultSettings = (() =>
                {
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
                    return settings;
                });

                var serializer = new JsonSerializer() { StringEscapeHandling = StringEscapeHandling.EscapeHtml };
                var sb = new StringBuilder();
                using (var writer = new StringWriter(sb))
                {
                    serializer.Serialize(writer, task);
                }

                var json = sb.ToString();
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(_serviceUrlPlotMethod, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Check if python web service is alive and if no, launches it
        /// </summary>
        private void LaunchPythonWebService()
        {
            if (!CheckIfWebServiceIsUpAndRunning())
            {
                var psi = new ProcessStartInfo(_pythonExePath, _dasPlotPyPath)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(psi);
            }
        }

        /// <summary>
        /// Check if python web service is alive
        /// </summary>
        /// <returns>true if service is up and running</returns>
        private bool CheckIfWebServiceIsUpAndRunning()
        {
            try
            {
                //Creating the HttpWebRequest
                var request = WebRequest.Create(_serviceUrlCheckAliveMethod) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "GET";
                //Getting the Web Response.
                var response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                //Any exception will returns false.
                return false;
            }
        }

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
