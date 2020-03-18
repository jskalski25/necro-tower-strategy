using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MapMockup1.ConfigManager.ConfigCategories;

namespace MapMockup1.ConfigManager
{
    public static class XmlConverters
    {
        public static string UserSettingsToXml(UserSettings userSettings)
        {
            var serializer = new XmlSerializer(typeof(UserSettings));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var xmlSettings = new XmlWriterSettings
            {
                Encoding = Encoding.Unicode,
                Indent = true
            };

            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww, xmlSettings))
                {
                    serializer.Serialize(writer, userSettings, ns);
                    return sww.ToString();
                }
            }
        }

        public static UserSettings ReadUserSettings(string xml)
        {
            UserSettings userSettings = null;

            XmlSerializer deserializer = new XmlSerializer(typeof(UserSettings));
            using (TextReader reader = new StringReader(xml))
            {
                userSettings = (UserSettings) deserializer.Deserialize(reader);
            }

            return userSettings;
        }
    }
}
