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
    public partial class Home : Page
    {

        public string CurrentLauncherDetails;
        public VersionData CurrentVersion;
        public List<VersionData> builds = new List<VersionData>();
        LauncherFunctionsLibrary lfn = new LauncherFunctionsLibrary();
        public string templastsavedkeyname;
        public SectionData templastsavedsection;


        int OgraniczenieWersji = 8; // Versions limit
        public string configpath = @"%localAppdata%\ProjectEra\launcherconfig"; // Path for the config ini

        public Home()
        {
            InitializeComponent();

            #region LauncherConfiguration
            var parser = new FileIniDataParser();



            // i skidded this cuz its 21th and im lazy
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string specificFolder = System.IO.Path.Combine(folder, "ProjectEra");
            Directory.CreateDirectory(specificFolder);
                 string configFile = @"%localAppdata%\ProjectEra\launcherconfig";
                  string configfinalstr = Environment.ExpandEnvironmentVariables(configFile);

                  if (!File.Exists(configfinalstr))
                  {
                      parser.WriteFile(Environment.ExpandEnvironmentVariables(configpath), new IniData());
                  }
                  IniData bdata = parser.ReadFile(Environment.ExpandEnvironmentVariables(configpath));
                  foreach (var section in bdata.Sections)
                  {
                     if(section.SectionName == "VERSIONS")
                      {
                          foreach (var key in section.Keys)
                          {
                             string[] alist = key.Value.Split(new string[] { "||" }, StringSplitOptions.None);
                             AddBuild(new VersionData { Id = alist[0], path=alist[1] });
                          }
                      }
                  }
                  #endregion
            
        }



        // Events

        private void SelectVersion_Event(object sender, RoutedEventArgs e)
        {
            var Version = (Button)sender;
            string abc = Version.Content.ToString();
            foreach (VersionData m in builds)
            {
                if (m.Id == abc)
                {
                    CurrentVersion = m;
                    lfn.ExecuteVersionPure(m);
                }

            }
        }
        public void AddBuild(VersionData vdata)
        {
            if(Directory.Exists(vdata.path + "/FortniteGame/Binaries/Win64/"))
                {
                vdata.Id.Replace(",", ".");
                string ConfigurationPath = Environment.ExpandEnvironmentVariables(configpath);
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(ConfigurationPath);
                int VersionsCount = builds.Count + 1;
                if (VersionsCount < OgraniczenieWersji + 1)
                {
                    string VersionIndexStr = "v" + VersionsCount.ToString();
                    data["VERSIONS"][VersionIndexStr] = vdata.Id + "||" + vdata.path;
                    parser.WriteFile(ConfigurationPath, data);
                    VersionsList.ItemsSource = null;
                    // to do = move this to the versiondata class
                    builds.Add(vdata);
                    VersionsList.ItemsSource = builds;
                }
            }
        }

        public void RemoveCurrentBuildFromConfig()
        {
            
            string ConfigurationPath = Environment.ExpandEnvironmentVariables(configpath);
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(ConfigurationPath);
            foreach(var section in data.Sections)
            {
                if(section.SectionName == "VERSIONS")
                {
                    foreach(var key in section.Keys)
                    {
                        if(key.Value == CurrentVersion.Id + "||" + CurrentVersion.path)
                        {
                            section.Keys.RemoveKey(key.KeyName);
                            parser.WriteFile(ConfigurationPath, data);
                            break;
                        }
                    }
                }
            }
        }

        
        private void OnDiscordButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.discord.gg/erafn");
        }

        private void AddVersionClick(object sender, RoutedEventArgs e)
        {
            AdditionalSettingsFrameContent.Content = new AddVersionPage();
            AdditionalSettingsFrameContent.Visibility = Visibility.Visible;
        }


        private void RemoveBuildEvent(object sender, RoutedEventArgs e)
        {
            if(CurrentVersion != null)
            {
                AdditionalSettingsFrameContent.Content = new SettingsPage();
                AdditionalSettingsFrameContent.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Unable to perform action. You must select a version profile first!", "ERA Launcher", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void HandleNavigatingAdditionalSettingsFrame(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }

        private void OnBGImageLoadedTEMP(object sender, RoutedEventArgs e)
        {
        /*    Random rnd = new Random();
            int index = rnd.Next(3, 5);

            // SCUFFEEEEED, WE WILL MOVE IT TO FTP TOMORROW WITH MATID ~~ sizzy

            BackgroundImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Misc/Images/BackgroundImagesTEMP/" + index + ".jpg"));*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(VersionData versionData in builds)
            {
                System.Windows.Forms.MessageBox.Show(versionData.path);
            }
        }

        private void HandleGameLaunch(object sender, RoutedEventArgs e)
        {
            // Here, danii
            if (CurrentVersion != null)
            {

            }
            else
            {
                MessageBox.Show("Unable to perform action. You must select a version profile first!", "ERA Launcher", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // Classes
    public class VersionData
    {
        public string _path;
        public string _Id;
        public string _splashpath;


        public string path
        {
            get { return this._path;  }
            set { this._path = value; }
        }

        public string splashpath
        {
            
            get { return path + @"\FortniteGame\Content\Splash\Splash.bmp"; }
            set { this._splashpath = value; }
        }
        public string Id
        {
            get { return this._Id.Replace(",", "."); }
            set { this._Id = value; }
        }
    }
}