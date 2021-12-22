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
using Newtonsoft.Json;

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

            StartAnimGrid.Visibility = Visibility.Hidden;
            Random rnd = new Random();

            homevar.BackgroundImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Misc/Images/Backgrounds/" + rnd.Next(1, 11) + ".png"));
                 try
                 {
                     dynamic requestui = api.GetJsonStringElement("https://eracentral.kyiro.repl.co/public/Launcher/launcher-userinterfacesettings.json");
                     homevar.BackgroundImage.Height = Convert.ToInt32(requestui.BackgroundImageHeight.ToString());

                         dynamic strrequest = api.GetJsonStringElement("https://eracentral.kyiro.repl.co/public/Launcher/launcher-defaultstrings.json");
                         // news
                         clvar.LatestNewsText.Content = strrequest.LatestNewsLargeTxt.ToString();
                         clvar.ChangeLog.Text = strrequest.LatestNewsDescription.ToString();
                         BitmapImage bm = new BitmapImage();
                         bm.BeginInit();
                         bm.UriSource = new Uri(@strrequest.NewsImageBGurl.ToString(), UriKind.Absolute);
                         bm.EndInit();
                         ImageBrush image = new ImageBrush();
                         image.Stretch = Stretch.UniformToFill;
                         image.ImageSource = bm;
                             clvar.ImageBG.Background = image;
                     // clvar.ImageBG.Background.Sour = bm;
                     // end news

                /*
                         dynamic requestbg = api.GetJsonStringElement("https://eracentral.kyiro.repl.co/public/Launcher/launcher-backgrounds.json");
                     List<string> list = new List<string>();

                     foreach (var key in requestbg)
                     {
                         list.Add(key.Value.ToString());
                     }


                     /* Random rnd = new Random();

                      int from = Convert.ToInt32(requestui.RandomImageFrom);
                      int to = Convert.ToInt32(requestui.RandomImageTo);
                      var imgurl = @list[rnd.Next(from, to)];
                      BitmapImage bitmap = new BitmapImage();
                      bitmap.BeginInit();
                      bitmap.UriSource = new Uri(imgurl, UriKind.Absolute);
                      bitmap.EndInit();

                      homevar.BackgroundImage.Source = bitmap;
                      MessageBox.Show(bitmap.ToString());*/





                 }
                 catch
                 {
                     MessageBox.Show("Unable to download launcher content.", "ERA Launcher", MessageBoxButton.OK, MessageBoxImage.Stop);
                 }
                 finally
                 {
                     StartAnimGrid.Visibility = Visibility.Hidden;
                   // MessageBox.Show("Downloaded the content", "ERA Launcher", MessageBoxButton.OK, MessageBoxImage.Stop);
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