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

namespace EraLauncher
{
    class LauncherFunctionsLibrary
    {
        public void ExecutePage(Page classxyz, Frame PageContent)
        {
            PageContent.Content = classxyz;
        }

        public void WriteToConfig(string CATEGORY, string ITEM, string CONTENT)
        {
            string ConfigurationPath = Environment.ExpandEnvironmentVariables(((MainWindow)App.Current.MainWindow).homevar.configpath);
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(ConfigurationPath);
            data[CATEGORY][ITEM] = CONTENT;
            parser.WriteFile(ConfigurationPath, data);
        }

        public void ExecuteVersionPure(VersionData data)
        {
            string StringF = data.Id;
            string StringEF = StringF.Replace(",", ".");
            ((MainWindow)App.Current.MainWindow).homevar.GameVersion.Content = StringEF;
        }

        /* ENCRYPTION TEST, i just want to look one day at the piece of code i was making when my brain was melting ~~ sizzy
  string tempba = data["VERSIONS"]["sctyshlnc"];
      string[] list = tempba.Split(new string[] { "///" }, StringSplitOptions.None);
      string[] list2 = list[2].Split(new string[] { "//" }, StringSplitOptions.None);
      string final = list2[0];
      int baint;
      bool isNumer = int.TryParse(final, out baint);
      if (isNumer)
      {
          ba = baint/33;
          GameName.Content = ba.ToString();
      }*/

    }
}
