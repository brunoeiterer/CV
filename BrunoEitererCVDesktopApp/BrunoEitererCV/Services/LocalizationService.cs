using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BrunoEitererCV.Services
{
    public partial class LocalizationService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Dictionary<string, string> _resources = [];

        private void LoadResources(string filePath)
        {
            _resources.Clear();

            var doc = XDocument.Load(filePath);

            if(doc.Root == null)
            {
                throw new InvalidOperationException($"The resource file {filePath} is invalid");
            }

            foreach (var data in doc.Root.Elements("data"))
            {
                var name = data.Attribute("name")?.Value.Replace('.', '/');
                var value = data.Element("value")?.Value;

                if (name != null && value != null)
                {
                    _resources[name] = value;
                }
            }
        }

        public string this[string key] => _resources[key];

        public void ChangeLanguage(string languageCode)
        {
            LoadResources($"Strings/Resources-{languageCode}.resw");

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
