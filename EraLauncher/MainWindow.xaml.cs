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
    
        private void GridBG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();

              
            }
        }

      
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
            this.ContentPanel = new Home();
        }

        private void Changelog_Btn_Event(object sender, RoutedEventArgs e)
        {
            
        }
    }
}