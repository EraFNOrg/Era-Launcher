using System.Windows;
using System.Windows.Input;

namespace EraLauncher
{

    public partial class MainWindow : Window
    {
        //  public List<FV> Versions
        //{
        //     get; set;
        //}


        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GridBG_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpperPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void UpperPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void UpperPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void GridBG_MouseDown(object sender, MouseButtonEventArgs e)
        {

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
    }
}