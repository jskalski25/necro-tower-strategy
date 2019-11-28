using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project5.ConfigManager.ConfigCategories
{
    public class UserSettings
    {
        //public string UserName;
        public int WindowWidth = 800;
        public int WindowHeight = 600;
        public bool FullScreen;

        public UserSettings()
        {

        }

        public void SaveSettings(string Path)
        {
            if (Path.Length > 1)
            {
                try
                {
                    var settingsXml = XmlConverters.UserSettingsToXml(this);
                    try
                    {
                        File.WriteAllText(Path, settingsXml);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Błąd zapisu pliku z UserSettings " + ex);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Błąd konwersji settings to xml " + ex);
                }
            }
            else
            {
                Debug.WriteLine("Podano nie właściwą ścieżkę podczas zapisu UserSettings");
            }
        }
        
    }
}
