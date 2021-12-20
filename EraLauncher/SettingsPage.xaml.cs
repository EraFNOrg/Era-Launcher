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

namespace EraLauncher
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public string CurrentPath;
        public string CurrentVerstr = "Version name";
        LauncherFunctionsLibrary lfn = new LauncherFunctionsLibrary();
        public SettingsPage()
        {
            InitializeComponent();

        }

        private void BrowseEvent(object sender, RoutedEventArgs e)
        {

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            CommonFileDialogResult re = dialog.ShowDialog();

            if (re == CommonFileDialogResult.Ok)
            {
                CurrentPath = dialog.FileName;
                PathBox.Text = dialog.FileName;
            }
        }

        private void HandleRemove(object sender, RoutedEventArgs e)
        {

        }

        private void HandleClose(object sender, RoutedEventArgs e)
        {
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
    }
}
