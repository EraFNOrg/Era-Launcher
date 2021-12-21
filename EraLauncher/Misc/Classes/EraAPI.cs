using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace EraLauncher.Misc.Classes
{
    public class EraAPI
    {
        public string GetItemContentFromCloudstorageList(string _string)
        {
           string[] list = _string.Split(new string[] { ";" }, StringSplitOptions.None);
                return list[1];
        }
        public List<string> GetEraCloudstorage()
        {
            WebClient client = new WebClient();
            try
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                Stream data = client.OpenRead("https://eracentral.kyiro.repl.co/public/Launcher/launcher-cloudstorage.txt");
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                string[] stringsa = s.Split(new string[] { "||" }, StringSplitOptions.None);
                List<string> stringsb = stringsa.ToList();

                return stringsb;
            }
            catch
            {
                ((MainWindow)App.Current.MainWindow).clvar.ChangeLog.Text = "Couldn't connect to the central server!";

                return new List<string>();
            }
        }

    }
}
