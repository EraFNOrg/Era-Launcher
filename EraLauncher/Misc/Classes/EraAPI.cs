using RestSharp;
using System;
using System.Net;

namespace EraLauncher.Misc.Classes
{
    public class EraAPI //syf, chaos i rozpierdol | MaTiD
    {
        #region Field Region

        static RestClient _client = new RestClient(FTPUrl.FTPServer);

        public static string LauVersion => GetLauVersion();
        public static string Changelog => GetChangelog();

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

        static string GetChangelog()
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
