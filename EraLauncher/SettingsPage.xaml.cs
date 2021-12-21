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
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using IniParser;
using IniParser.Model;
using System.Net;
using System.IO;
using EraLauncher.Misc.Classes;


namespace EraLauncher
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public string NewPath;
        public string CurrentVerstr = "Version name";
        public EraAPI api = new EraAPI();

        LauncherFunctionsLibrary lfn = new LauncherFunctionsLibrary();
        public SettingsPage()
        {
            InitializeComponent();

        }
        #region events
        // Path changing
        private void BrowseEvent(object sender, RoutedEventArgs e)
        {

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            dialog.InitialDirectory = PathBox.Text;
            CommonFileDialogResult re = dialog.ShowDialog();
            if (re == CommonFileDialogResult.Ok)
            {
                string ConfigurationPath = Environment.ExpandEnvironmentVariables(((MainWindow)App.Current.MainWindow).homevar.configpath);
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(ConfigurationPath);
                //parser.WriteFile(ConfigurationPath, data);
                if (Directory.Exists(dialog.FileName + "/FortniteGame/Binaries/Win64/"))
                {
                    PathBox.Text = dialog.FileName;
                }
                else
                {
                    // Notification about the game path being incorrect.
                    System.Windows.Forms.MessageBox.Show("Unable to perform this action. Please make sure the path you selected contains folders FortniteGame & Engine", "ERA Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }

        private void HandleClose(object sender, RoutedEventArgs e)
        {
            string ConfigurationPath = Environment.ExpandEnvironmentVariables(((MainWindow)App.Current.MainWindow).homevar.configpath);
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(ConfigurationPath);
            foreach (var section in data.Sections)
            {
                if (section.SectionName == "VERSIONS")
                {
                    foreach (var key in section.Keys)
                    {
                        string[] listx = key.Value.Split(new string[] { "||" }, StringSplitOptions.None);
                        if (((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.path == listx[1])
                        {
                            var builds = ((MainWindow)App.Current.MainWindow).homevar.builds;
                            foreach (VersionData versionData in builds)
                            {
                                if (versionData.path == ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.path)
                                {
                                    ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.path = NewPath;
                                    versionData.path = NewPath;
                                    versionData.splashpath = NewPath + @"\FortniteGame\Content\Splash\Splash.bmp";
                                    ((MainWindow)App.Current.MainWindow).homevar.VersionsList.ItemsSource = null;
                                    ((MainWindow)App.Current.MainWindow).homevar.VersionsList.ItemsSource = builds;
                                    key.Value = listx[0] + "||" + NewPath;
                                    parser.WriteFile(ConfigurationPath, data);

                                    break;
                                }
                            }
                        }
                    }
                }
            }
            foreach (var section in data.Sections)
            {
                if (section.SectionName == "VERSIONS")
                {
                    foreach (var key in section.Keys)
                    {
                        string[] listx = key.Value.Split(new string[] { "||" }, StringSplitOptions.None);
                        if (((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.Id == listx[0])
                        {
                            var builds = ((MainWindow)App.Current.MainWindow).homevar.builds;
                            foreach (VersionData versionData in builds)
                            {
                                if (versionData.Id == ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.Id)
                                {
                                    ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.Id = CurrentVerstr;
                                    versionData.Id = CurrentVerstr;
                                    ((MainWindow)App.Current.MainWindow).homevar.VersionsList.ItemsSource = null;
                                    ((MainWindow)App.Current.MainWindow).homevar.VersionsList.ItemsSource = builds;
                                    key.Value = CurrentVerstr + "||" + listx[1];
                                    parser.WriteFile(ConfigurationPath, data);
                                    ((MainWindow)App.Current.MainWindow).homevar.GameVersion.Content = ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.Id;

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        ((MainWindow)App.Current.MainWindow).homevar.AdditionalSettingsFrameContent.Content = null;
    }

        private void PathBoxLoaded(object sender, RoutedEventArgs e)
        {
            string path = ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.path;
            PathBox.Text = path;
            string id = ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion.Id;
            VersionBox.Text = id;
        }

        private void HandleRemoveProfile(object sender, RoutedEventArgs e)
        {
            VersionData vers = ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion;
            bool exists = ((MainWindow)App.Current.MainWindow).homevar.builds.Contains(vers);
            if(exists)
            {
                ((MainWindow)App.Current.MainWindow).homevar.VersionsList.ItemsSource = null;
                ((MainWindow)App.Current.MainWindow).homevar.builds.Remove(vers);
                ((MainWindow)App.Current.MainWindow).homevar.RemoveCurrentBuildFromConfig();
                    ((MainWindow)App.Current.MainWindow).homevar.VersionsList.ItemsSource = ((MainWindow)App.Current.MainWindow).homevar.builds;
                ((MainWindow)App.Current.MainWindow).homevar.CurrentVersion = null;
                lfn.ExecuteVersionPure(new VersionData { Id = "Select Game Version.", path = "placeholder" });
                ((MainWindow)App.Current.MainWindow).homevar.AdditionalSettingsFrameContent.Content = null;
            }

        }

        private void OnPathTextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            if (textbox != null)
            {
                NewPath = textbox.Text;
            }
        }

        private void HandleVersionNameTextBoxContentChange(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            if (textbox != null)
            {
                CurrentVerstr = textbox.Text;
            }
        }

        #endregion

        private void OnEclipseLoaded(object sender, RoutedEventArgs e)
        {
            List<string> apiitems = api.GetEraCloudstorage();
            var fullpathspec = api.GetItemContentFromCloudstorageList(apiitems[22]);
            string xdspec = fullpathspec.ToString();
            string okspec = @xdspec;
            BitmapImage bitmapspec = new BitmapImage();
            bitmapspec.BeginInit();
            bitmapspec.UriSource = new Uri(okspec, UriKind.Absolute);
            bitmapspec.EndInit();

            SkinImage.ImageSource = bitmapspec;

        }
    }
}
