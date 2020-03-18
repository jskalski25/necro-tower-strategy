using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MapMockup1.ConfigManager.ConfigCategories
{
    public class UserSettings
    {
        [XmlIgnore]
        public string Path ="";

        public string UserName;

        public int Width;
        public int Height;

        public UserSettings()
        {

        }

        public void SaveSettings()
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

        public void LoadDeflaut()
        {
            Width = 800;
            Height = 600;
        }
        
    }
}
