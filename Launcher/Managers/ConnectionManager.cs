using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{

    public class ConnectionManager
    {
        public static int FailedCount { get; set; } = 0;
        public static async Task<Version> GetVersionAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds((FailedCount + 1) * 5);
                    var result = await client.GetStringAsync(url);
                    FailedCount = 0;
                    return JsonConvert.DeserializeObject<Version>(result);
                }
            }
            catch
            {
                FailedCount++;
                if (FailedCount > 6) FailedCount = 0;
                return null;
            }
        }
        public static async Task<string> GetChangeLogAsync(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var result = await client.GetStringAsync(url);
                    return result;
                }
            }
            catch
            {
                return "Unknown error, refresh it !";
            }
        }
    }
}
