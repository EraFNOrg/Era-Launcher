using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace EraLauncher.Misc.Classes
{
    public class EraAPI
    {
        public string GetItemContentFromCloudstorageList(string _string)
        {
           string[] list = _string.Split(new string[] { ";" }, StringSplitOptions.None);
                return list[1];
        }
        public dynamic GetJsonStringElement(string url)
        {
            WebClient client = new WebClient();
            try
            {

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                Stream data = client.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                dynamic json = JsonConvert.DeserializeObject(s);
                return json;
            }
            catch
            {
                return "Couldn't connect to the central server!";
            }
        }

    }
}
