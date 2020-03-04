using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using StealthAPI;
using ScriptSDK.Engines;

namespace App.Orders
{
    [Serializable]
    public class xmlconfig
    {
        public string FileName { get; set; }
        public uint ContainerID { get; set; }
        public int ToolTipDelay { get; set; }
        public int WaitDelay { get; set; }

        public static void Make()
        {
            var xs = new XmlSerializer(typeof (xmlconfig));
            var fs = new FileStream("config.xml", FileMode.CreateNew, FileAccess.Write);
            var file = new xmlconfig
            {
                FileName = "Sampler.csv",
                ContainerID = 0xFFFFFFFF,
                ToolTipDelay = 800,
                WaitDelay = 50
            };
            xs.Serialize(fs, file);
            fs.Close();
        }

        public static xmlconfig Parse()
        {
            var xs = new XmlSerializer(typeof (xmlconfig));
            var fs = new FileStream("config.xml", FileMode.Open, FileAccess.Read);
            var file = xs.Deserialize(fs) as xmlconfig;
            fs.Close();
            return file;
        }
    }

    public static class ItemExporter
    {
        private const string cfgname = "config.xml";

        private static bool ValidateConfig()
        {
            if (File.Exists(cfgname))
                return true;

            xmlconfig.Make();
            return false;
        }

        public static void Run()
        {
            ScriptLogger.Initialize();
            ScriptLogger.LogToStealth = true;
            if (ValidateConfig())
            {
                try
                {
                    var data = xmlconfig.Parse();
                    Stealth.Client.UseObject(data.ContainerID);

                    while (Stealth.Client.GetLastContainer() != data.ContainerID)
                    {
                        Stealth.Client.Wait(data.WaitDelay);
                    }
                    if (Stealth.Client.FindTypeEx(0xFFFF, 0xFFFF, data.ContainerID, true) > 0)
                    {
                        var r = Stealth.Client.GetFindList();
                        var l = new List<string>();
                        foreach (var e in r)
                        {
                            Stealth.Client.ClickOnObject(e);
                            var t = string.Empty;
                            while (t.Trim() == "")
                                t = Stealth.Client.GetTooltip(e, data.ToolTipDelay);
                            l.Add(e + ";" + t.Replace("|", ";"));
                        }
                        File.WriteAllLines(data.FileName, l);
                    }
                }
                catch (Exception)
                {
                    ScriptLogger.WriteLine("Error on Export Handling!");
                }
            }
            else
            {
                ScriptLogger.WriteLine(string.Format("Unable to find {0}", cfgname));
            }
        }
    }
}