using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using IniParser;
using IniParser.Model;
using System.Net;
using System.IO;
using RestSharp;

namespace EraLauncher.Misc.Classes
{
    public class EraAPI //syf, chaos i rozpierdol | MaTiD
    {
        #region Field Region

        static RestClient _client = new RestClient(FTPUrl.FTPServer);

        public string LauVersion => GetLauVersion();
        public string Changelog => GetChangelog();

        #endregion

        #region Method Region

        static void SetApi()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _client.UserAgent = $"EraLauncher/{FTPUrl.LauVersionOffline}";
        }

        static string GetLauVersion()
        {
            SetApi();

            var version = _client.Get(new RestRequest("pliki/lauver")).Content;
            if (string.IsNullOrEmpty(version))
                version = FTPUrl.LauVersionOffline;

            return version;
        }

        string GetChangelog()
        {
            SetApi();

            var changelogtext = _client.Get(new RestRequest("pliki/changelog")).Content;
            if (string.IsNullOrEmpty(changelogtext))
                changelogtext = FTPUrl.ChangelogTextOffline;

            return changelogtext;
        }

        #endregion
    }
}
