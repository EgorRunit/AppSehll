using System.IO;
using System.Text.Json;

namespace Ovotan.Windows.Controls.EndPointManagement.Configurations
{
    public class EndPointConfigurations
    {
        object _sync;
        string _rootAppSettings;

        public EndPointConfigurations(string applicationName) 
        { 
            _sync = new object();
            _rootAppSettings = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + applicationName;
        }

        public T LoadEndPoint<T>(string endPointName) where T : class
        {
            var endPointFile = _rootAppSettings + "\\" + endPointName + "\\" + "settings.cfg";
            if(File.Exists(endPointFile))
            {
                var json = File.ReadAllText(endPointFile);
                var nodes = JsonSerializer.Deserialize<T>(json);
                return nodes;
            }
            return null;             
        }

        public void SaveEndPoint<T>(string endPointName, T settings) where T: class
        {
            var data = JsonSerializer.Serialize(settings);
            lock (_sync)
            {
                var endPointFolder = _rootAppSettings + "\\" + endPointName;
                if (!(Directory.Exists(endPointFolder)))
                {
                    Directory.CreateDirectory(endPointFolder);
                }
                var fileName = endPointFolder + "\\settings.cfg";
                using (var file = File.CreateText(fileName))
                {
                    file.Write(data);
                }
            }
        }
    }
}
