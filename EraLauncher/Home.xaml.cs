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
using EraLauncher.Misc.Classes;
using IniParser;
using IniParser.Model;
using System.Net;
using System.IO;


namespace EraLauncher
{
    public partial class Home : Page
    {

        public string CurrentLauncherDetails;
        public VersionData CurrentVersion;
        List<VersionData> builds = new List<VersionData>();
        EraAPI homeapi;
        
        // versions 
        int ba = 0;
        int baxl = 8;
        static string configpath = @"%localAppdata%\ProjectEra\";

        public Home()
        {
            InitializeComponent();

            // global ini variable
            var parser = new FileIniDataParser();

 

            // Configuration
            string configFile = @"%localAppdata%\ProjectEra\launcherconfig.ini";
            string configfinalstr = Environment.ExpandEnvironmentVariables(configFile);
            if (!File.Exists(configfinalstr))
            {
                parser.WriteFile(Environment.ExpandEnvironmentVariables(configpath + "launcherconfig.ini"), new IniData());
            }
            IniData bdata = parser.ReadFile(Environment.ExpandEnvironmentVariables(configpath + "launcherconfig.ini"));
            foreach (var section in bdata.Sections)
            {
               if(section.SectionName == "VERSIONS")
                {
                    foreach (var key in section.Keys)
                    {
                       string[] alist = key.Value.Split(new string[] { "||" }, StringSplitOptions.None);
                        AddBuild(alist[0], alist[1], "xyz");
                    }
                }
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

        // Pure executing version
        private void ExecuteVersionPure(string ID)
        {
            string StringF = ID;
            string StringEF = StringF.Replace(",", ".");
            this.GameVersion.Content = StringEF;
        }


        // Events

        // Writes data to config
        public void WriteToConfig(string CATEGORY, string ITEM, string CONTENT)
        {
            string ConfigurationPath = Environment.ExpandEnvironmentVariables(configpath + "launcherconfig.ini");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(ConfigurationPath);
            data[CATEGORY][ITEM] = CONTENT;
            parser.WriteFile(ConfigurationPath, data);
        }
        private void SelectVersion_Event(object sender, RoutedEventArgs e)
        {
            var Version = (Button)sender;
            string abc = Version.Content.ToString();
            ExecuteVersionPure(abc);
        }
        public int AddBuild(string aID, string path, string asplashpath)
        {
            if(Directory.Exists(path + "/FortniteGame/Binaries/Win64/"))
                {
                string ConfigurationPath = Environment.ExpandEnvironmentVariables(configpath + "launcherconfig.ini");
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(ConfigurationPath);
                int bc = builds.Count + 1;
                if (bc < baxl + 1)
                {
                    string versiona = bc.ToString();
                    string final = "v" + versiona;
                    data["VERSIONS"][final] = aID + "||" + path;
                    parser.WriteFile(ConfigurationPath, data);
                    VersionsList.ItemsSource = null;
                    string splashpath = path + @"\FortniteGame\Content\Splash\Splash.bmp";
                    //    MessageBox.Show(splashpath);
                    var rv = new VersionData { Id = aID, path = path, splashpath = splashpath };
                    builds.Add(rv);
                    VersionsList.ItemsSource = builds;
                    return builds.IndexOf(rv);
                }
            }
            return 0;
        }

        public void RemoveBuildPure()
        {
           // var toremove = builds.Find(x => x == build);
            //builds.Remove(toremove);

           int a = AddBuild("PLACEHOLDER", "TEST", "A");

        }


        private void OnDiscordButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.discord.gg/erafn");
        }

        private void AddVersionClick(object sender, RoutedEventArgs e)
        {
            // test float replacement for version adding
            /* string abc = "a";
             if (abc.Any(char.IsDigit) && abc.Length < 4)
             {
                 abc.Replace(".", ",");
                 float aID = float.Parse(abc);
                 // && abc.Length < 4
                 AddBuild(aID, "");
             }*/
            AdditionalSettingsFrameContent.Content = new AddVersionPage();
            AdditionalSettingsFrameContent.Visibility = Visibility.Visible;
          //  AddBuild(2.0F, "a");
        }


        private void RemoveBuildEvent(object sender, RoutedEventArgs e)
        {
            RemoveBuildPure();
        }
    }

    // Classes
    public class VersionData
    {
        public string _path;
        private string _Id;
        private float _splashpath;

        public string path
        {
            get { return this._path;  }
            set { this._path = value; }
        }

        public string splashpath
        {
            get { return this._path; }
            set { this._path = value; }
        }
        public string Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }
    }
}