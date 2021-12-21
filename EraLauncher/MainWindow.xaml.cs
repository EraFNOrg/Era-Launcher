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
using System.Net;
using System.IO;
using EraLauncher.Misc.Classes;

namespace EraLauncher
{
    public partial class MainWindow : Window
    {
        #region variables
        public Home homevar = new Home();
        public Changelog clvar = new Changelog();
        LauncherFunctionsLibrary lfn = new LauncherFunctionsLibrary();
        public bool AllowNavigation = false;
        public bool KeepCancel = false;
        public EraAPI api = new EraAPI();

        #endregion
        public MainWindow()
        {
            // tutaj 
            InitializeComponent();

        }
        // --
        #region Events
        private void Close_Button_Event(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimalize_Button_Event(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MainPage_Btn_Event(object sender, RoutedEventArgs e)
        {
            lfn.ExecutePage(homevar, PageContent);
        }
        private void Changelog_Btn_Event(object sender, RoutedEventArgs e)
        {
            lfn.ExecutePage(clvar, PageContent);
        }

        private void UpperPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void OnStartAnimationBackgroundLoaded(object sender, RoutedEventArgs e)
        {

            StartAnimGrid.Visibility = Visibility.Visible;
            try
            {
                List<string> apiitems = api.GetEraCloudstorage();
                clvar.ChangeLog.Text = api.GetItemContentFromCloudstorageList(apiitems[0]);
                clvar.LatestNewsText.Content = api.GetItemContentFromCloudstorageList(apiitems[1]);
                homevar.LauncherInformation.Text = api.GetItemContentFromCloudstorageList(apiitems[2]);
                clvar.KnownIssues.Content = api.GetItemContentFromCloudstorageList(apiitems[16]);
                clvar.KnownIssuesDescription.Text = api.GetItemContentFromCloudstorageList(apiitems[17]);
                clvar.News.Content = api.GetItemContentFromCloudstorageList(apiitems[18]);
                clvar.Announcementsdesc.Text = api.GetItemContentFromCloudstorageList(apiitems[19]);
                clvar.ChangeLog.FontSize = Convert.ToDouble(api.GetItemContentFromCloudstorageList(apiitems[20]));
                homevar.LaunchButton.FontSize = Convert.ToDouble(api.GetItemContentFromCloudstorageList(apiitems[21]));
                if (api.GetItemContentFromCloudstorageList(apiitems[3]) == "true")
                {
                    var fullpathspec = api.GetItemContentFromCloudstorageList(apiitems[4]);
                    string xdspec = fullpathspec.ToString();
                    string okspec = @xdspec;
                    BitmapImage bitmapspec = new BitmapImage();
                    bitmapspec.BeginInit();
                    bitmapspec.UriSource = new Uri(okspec, UriKind.Absolute);
                    bitmapspec.EndInit();

                    homevar.BackgroundImage.Source = bitmapspec;
                }
                else
                {
                    Random rnd = new Random();
                    string randomi = api.GetItemContentFromCloudstorageList(apiitems[5]);
                    string[] list = randomi.Split(new string[] { "/" }, StringSplitOptions.None);

                    int index = rnd.Next(int.Parse(list[0]), int.Parse(list[1]));
                    var fullpath = api.GetItemContentFromCloudstorageList(apiitems[index]);
                    string xd = fullpath.ToString();
                    string ok = @xd;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(ok, UriKind.Absolute);
                    bitmap.EndInit();

                    homevar.BackgroundImage.Source = bitmap;
                }
                var xfullpathspec = api.GetItemContentFromCloudstorageList(apiitems[15]);
                string xxdspec = xfullpathspec.ToString();
                string xokspec = @xxdspec;
                BitmapImage xbitmapspec = new BitmapImage();
                xbitmapspec.BeginInit();
                xbitmapspec.UriSource = new Uri(xokspec, UriKind.Absolute);
                xbitmapspec.EndInit();

                clvar.ImageBG.Source = xbitmapspec;
            }
            catch
            {
                
            }


        }


private void Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }

        private void HandlePageContentLoaded(object sender, RoutedEventArgs e)
        {
            lfn.ExecutePage(homevar, PageContent);
        }
        #endregion
    }
}