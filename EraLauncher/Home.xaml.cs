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

namespace EraLauncher
{
    public partial class Home : Page
    {
        public string CurrentLauncherDetails = "Project Era";
        public VersionData CurrentVersion;
        public Home()
        {
            InitializeComponent();

            this.LauncherInformation.Content = CurrentLauncherDetails;

            this.VersionsList.ItemsSource = new VersionData[]
{
            new VersionData{Id=3.2F},
            new VersionData{Id=4.1F},
};
        }

        // Start Versions code ---------------------------------------
        public void AddVersion()
        {
            this.VersionsList.ItemsSource = new VersionData[]
            {
            new VersionData{Id=0}
            };
        }

        private void ExecuteVersion_Event(object sender, RoutedEventArgs e)
        {
            var Version = (Button)sender;
            string abc = Version.Content.ToString();
            float aID = float.Parse(abc);
            ExecuteVersionPure(aID);
        }

        private void ExecuteVersionPure(float ID)
        {
            string StringF = ID.ToString();
            string StringEF = StringF.Replace(",", ".");
            this.GameVersion.Content = StringEF;
        }

        // End versions code ---------------------------------------


        // Events

        private void MainPage_Btn_Event(object sender, RoutedEventArgs e)
        {
            
        }

        private void Changelog_Btn_Event(object sender, RoutedEventArgs e)
        {
            
        }
    }

    // Classes
    public class VersionData
    {
        private float _Id;
        public float Id
        {
            get { return this._Id; }
            set { this._Id = value; }
        }
    }
}