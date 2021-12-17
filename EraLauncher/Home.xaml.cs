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

namespace EraLauncher
{
    public partial class Home : Page
    {

        public string CurrentLauncherDetails;
        public VersionData CurrentVersion;
        public MainWindow MainWindowRef;
        List<VersionData> builds = new List<VersionData>();
        EraAPI homeapi;
        
        public Home()
        {
            InitializeComponent();
            if(MainWindowRef != null)
            {
                AddBuild(10.41F, "");
            }
            builds.Add(new VersionData { Id = 5.1F, path = "/Template" });
            AddBuild(4.1F, "");
            AddBuild(7.2F, "");
            AddBuild(8.51F, "");
            AddBuild(4.1F, "");

        }

        // Start Versions code ---------------------------------------
        public void AddVersion()
        {
            this.VersionsList.ItemsSource = new VersionData[]
            {
            new VersionData{Id=0}
            };
        }


        private void ExecuteVersionPure(float ID)
        {
            string StringF = ID.ToString();
            string StringEF = StringF.Replace(",", ".");
            this.GameVersion.Content = StringEF;
        }

        // End versions code ---------------------------------------


        // Events

        private void SelectVersion_Event(object sender, RoutedEventArgs e)
        {
            var Version = (Button)sender;
            string abc = Version.Content.ToString();
            float aID = float.Parse(abc);
            ExecuteVersionPure(aID);
        }

        private void AddBuild(float aID, string path)
        {
            VersionsList.ItemsSource = null;
            builds.Add(new VersionData { Id = aID, path = path });
            VersionsList.ItemsSource = builds;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
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
            AddBuild(2.0F, "a");
        }

        private void OnDiscordButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.discord.gg/erafn");
        }
    }

    // Classes
    public class VersionData
    {
        public string _path;
        private float _Id;
        
        public string path
        {
            get { return this._path;  }
            set { this._path = value; }
        }
        public float Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }
    }
}