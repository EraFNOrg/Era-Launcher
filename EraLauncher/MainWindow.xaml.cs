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

    public partial class MainWindow : Window
    {
        //  public List<FV> Versions
        //{
        //     get; set;
        //}

        public string CurrentLauncherDetails = "Project Era | By danii";
        public MainWindow()
        {
            InitializeComponent();

            this.LauncherInformation.Content = CurrentLauncherDetails;

            this.TvBox.ItemsSource = new MovieData[]
{
            new MovieData{Title="Movie 1"},
            new MovieData{Title="Movie 2"},
            new MovieData{Title="Movie 3"},
            new MovieData{Title="Movie 4"},
            new MovieData{Title="Movie 5"},
            new MovieData{Title="Movie 6"}
};
        }

        public void AddVersion()
        {


            this.TvBox.ItemsSource = new MovieData[]
{
            new MovieData{Title="Movie 1"}
        };
        }


        private void GridBG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

              
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddVersion();
        }
    }
    public class MovieData
    {
        private string _Title;
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }



    }
}