﻿using System;
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
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EraLauncher
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public string CurrentPath;
        public string CurrentVerstr = "Version name";
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

     /*   private void AttemptAdd(object sender, RoutedEventArgs e)
        {
            string abc = CurrentVerstr;

            if (Directory.Exists(CurrentPath + "/FortniteGame/Binaries/Win64/"))
            {
                if (abc.Length < 16 - 1)
                {
                    string g = abc.Replace(".", ",");
                    // && abc.Length < 4
                    ((MainWindow)App.Current.MainWindow).homevar.AddBuild(g, CurrentPath, "xyz");
                    ((MainWindow)App.Current.MainWindow).homevar.AdditionalSettingsFrameContent.Visibility = Visibility.Hidden;
                    ((MainWindow)App.Current.MainWindow).homevar.AdditionalSettingsFrameContent.Content = null;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Your version name has more than 16 characters!", "ERA Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please make sure the path you selected contains folders FortniteGame & Engine", "ERA Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }*/



        private void AttemptRemove(object sender, RoutedEventArgs e)
        {

        }
    }
}
