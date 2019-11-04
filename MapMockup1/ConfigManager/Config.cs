using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapMockup1.ConfigManager.ConfigCategories;

namespace MapMockup1.ConfigManager
{
    public class Config
    {
        public const string UserSettingsPath = "UserSettings.xml";

        public UserSettings UserSettings;
        

        public Config()
        {

        }

        public void Initialize()
        {
            UserSettings = LoadUserSettings();
        }

        private UserSettings LoadUserSettings()
        {
            UserSettings result;

            if (!File.Exists(UserSettingsPath))
            {
                Debug.WriteLine("Brak pliku z UserSettings");
                result = new UserSettings();
            }

            result = XmlConverters.ReadUserSettings(File.ReadAllText(UserSettingsPath));

            result.Path = UserSettingsPath;
            return result;
        }
    }
}
