using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace Launcher
{
    public class Configuration
    {
        public string urlVersion { get; set; }
        public string urlChangeLog { get; set; }
        public string urlDiscord { get; set; }
        public string urlYoutube { get; set; }
        public string urlVk { get; set; }
        public string urlLauncherVersion { get; set; }


        public static Configuration GetConfiguration()
        {
            var data = File.ReadAllText(@"config.json");
            return JsonConvert.DeserializeObject<Configuration>(data);
        }
    }
}
