using System.ComponentModel;
using Windows.ApplicationModel.Resources;
using Windows.Globalization;

namespace BrunoEitererCV.Services
{
    public partial class LocalizationService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ResourceLoader _resourceLoader;

        public string this[string key] => _resourceLoader.GetString(key);

        public LocalizationService()
        {
            ApplicationLanguages.PrimaryLanguageOverride = "en";
            _resourceLoader = ResourceLoader.GetForViewIndependentUse();
        }

        public void ChangeLanguage(string languageCode)
        {
            ApplicationLanguages.PrimaryLanguageOverride = languageCode;

            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceManager.Current.DefaultContext.Reset();

            _resourceLoader = ResourceLoader.GetForViewIndependentUse();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
