using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project5.ConfigManager.ConfigCategories;

namespace Project5.ConfigManager
{
    public class Config
    {
        public const string UserSettingsPath = "UserSettings.xml";

        public UserSettings UserSettings;
        
        public Config()
        {

        }

        /// <summary>
        /// Wczytaj ustawienia użytkownika z pliku, jeżeli nie istnieje utwórz go.
        /// </summary>
        public void Initialize()
        {
            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            UserSettings result;

            if (!File.Exists(UserSettingsPath))
            {
                Debug.WriteLine("Brak pliku z UserSettings");
                UserSettings = new UserSettings();
                UserSettings.SaveSettings(UserSettingsPath);
            }
            else
            {
                UserSettings = XmlConverters.ReadUserSettings(File.ReadAllText(UserSettingsPath));
            }
        }

        public void SaveToFile()
        {
            UserSettings.SaveSettings(UserSettingsPath);
        }
    }
}
