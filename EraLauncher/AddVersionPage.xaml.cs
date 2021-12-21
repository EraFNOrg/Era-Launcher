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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EraLauncher
{
    /// <summary>
    /// Logika interakcji dla klasy Changelog.xaml
    /// </summary>
    public partial class AddVersionPage : Page
    {
        public string LastGamePath;
        public string CurrentVerstr = "Version name";
        public AddVersionPage()
        {

            InitializeComponent();
            ((MainWindow)App.Current.MainWindow).AllowNavigation = false;
        }



        private void BrowseEvent(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                dialog.Multiselect = false;
            CommonFileDialogResult res = dialog.ShowDialog();
            if (res==CommonFileDialogResult.Ok)
                {
                LastGamePath = dialog.FileName;
                    PathBox.Text = dialog.FileName;
                }
        }

        private void AttemptAdd(object sender, RoutedEventArgs e)
        {
            // Path to look for, checking if the direcotyr exists
            if (Directory.Exists(LastGamePath + "/FortniteGame/Binaries/Win64/"))
            {
                // Gotta do -1, since the first index is 0 and i don't want to make it 15 ~~ sizzy
                if (CurrentVerstr.Length < 16 - 1)
                {
                    ((MainWindow)App.Current.MainWindow).homevar.AddBuild(new VersionData { Id= CurrentVerstr.Replace(".", ",") , path=LastGamePath });
                    AttemptClose(this, new RoutedEventArgs());
                }
                else
                {
                    // Notification about the version name being incorrect
                    System.Windows.Forms.MessageBox.Show("Your version name has more than 16 characters!", "ERA Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                // Notification about the version path being incorrect
                System.Windows.Forms.MessageBox.Show("Unable to perform this action. Please make sure the path you selected contains folders FortniteGame & Engine", "ERA Launcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            if(textbox != null)
            {
                CurrentVerstr = textbox.Text;
            }
        }

        private void AttemptClose(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).homevar.AdditionalSettingsFrameContent.Content = null;
        }
    }
}
