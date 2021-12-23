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
using IniParser;
using IniParser.Model;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace EraLauncher
{
    public partial class Home : Page
    {

        public string CurrentLauncherDetails;
        public VersionData CurrentVersion;
        public List<VersionData> builds = new List<VersionData>();
        LauncherFunctionsLibrary lfn = new LauncherFunctionsLibrary();
        public string templastsavedkeyname;
        public SectionData templastsavedsection;


        int OgraniczenieWersji = 8; // Versions limit
        public string configpath = @"%localAppdata%\ProjectEra\launcherconfig"; // Path for the config ini

        public Home()
        {
            InitializeComponent();

            #region LauncherConfiguration
            var parser = new FileIniDataParser();



            // i skidded this cuz its 21th and im lazy
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string specificFolder = System.IO.Path.Combine(folder, "ProjectEra");
            Directory.CreateDirectory(specificFolder);
                 string configFile = @"%localAppdata%\ProjectEra\launcherconfig";
                  string configfinalstr = Environment.ExpandEnvironmentVariables(configFile);

                  if (!File.Exists(configfinalstr))
                  {
                      parser.WriteFile(Environment.ExpandEnvironmentVariables(configpath), new IniData());
                  }
                  IniData bdata = parser.ReadFile(Environment.ExpandEnvironmentVariables(configpath));
                  foreach (var section in bdata.Sections)
                  {
                     if(section.SectionName == "VERSIONS")
                      {
                          foreach (var key in section.Keys)
                          {
                             string[] alist = key.Value.Split(new string[] { "||" }, StringSplitOptions.None);
                             AddBuild(new VersionData { Id = alist[0], path=alist[1] });
                          }
                      }
                  }
                  #endregion
            
        }



        // Events

        private void SelectVersion_Event(object sender, RoutedEventArgs e)
        {
            var Version = (Button)sender;
            string abc = Version.Content.ToString();
            foreach (VersionData m in builds)
            {
                if (m.Id == abc)
                {
                    CurrentVersion = m;
                    lfn.ExecuteVersionPure(m);
                }

            }
        }
        public void AddBuild(VersionData vdata)
        {
            if(Directory.Exists(vdata.path + "/FortniteGame/Binaries/Win64/"))
                {
                vdata.Id.Replace(",", ".");
                string ConfigurationPath = Environment.ExpandEnvironmentVariables(configpath);
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(ConfigurationPath);
                int VersionsCount = builds.Count + 1;
                if (VersionsCount < OgraniczenieWersji + 1)
                {
                    string VersionIndexStr = "v" + VersionsCount.ToString();
                    data["VERSIONS"][VersionIndexStr] = vdata.Id + "||" + vdata.path;
                    parser.WriteFile(ConfigurationPath, data);
                    VersionsList.ItemsSource = null;
                    // to do = move this to the versiondata class
                    builds.Add(vdata);
                    VersionsList.ItemsSource = builds;
                }
            }
        }

        public void RemoveCurrentBuildFromConfig()
        {
            
            string ConfigurationPath = Environment.ExpandEnvironmentVariables(configpath);
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(ConfigurationPath);
            foreach(var section in data.Sections)
            {
                if(section.SectionName == "VERSIONS")
                {
                    foreach(var key in section.Keys)
                    {
                        if(key.Value == CurrentVersion.Id + "||" + CurrentVersion.path)
                        {
                            section.Keys.RemoveKey(key.KeyName);
                            parser.WriteFile(ConfigurationPath, data);
                            break;
                        }
                    }
                }
            }
        }

        
        private void OnDiscordButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.discord.gg/erafn");
        }

        private void AddVersionClick(object sender, RoutedEventArgs e)
        {
            AdditionalSettingsFrameContent.Content = new AddVersionPage();
            AdditionalSettingsFrameContent.Visibility = Visibility.Visible;
        }


        private void RemoveBuildEvent(object sender, RoutedEventArgs e)
        {
            if(CurrentVersion != null)
            {
                AdditionalSettingsFrameContent.Content = new SettingsPage();
                AdditionalSettingsFrameContent.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Unable to perform action. You must select a version profile first!", "ERA Launcher", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void HandleNavigatingAdditionalSettingsFrame(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                e.Cancel = true;
            }
        }

        private void OnBGImageLoadedTEMP(object sender, RoutedEventArgs e)
        {
        /*    Random rnd = new Random();
            int index = rnd.Next(3, 5);

            // SCUFFEEEEED, WE WILL MOVE IT TO FTP TOMORROW WITH MATID ~~ sizzy

            BackgroundImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/Misc/Images/BackgroundImagesTEMP/" + index + ".jpg"));*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(VersionData versionData in builds)
            {
                System.Windows.Forms.MessageBox.Show(versionData.path);
            }
        }

        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(
  IntPtr hProcess,
  IntPtr lpThreadAttributes,
  uint dwStackSize,
  UIntPtr lpStartAddress,
  IntPtr lpParameter,
  uint dwCreationFlags,
  out IntPtr lpThreadId
);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
            UInt32 dwDesiredAccess,
            Int32 bInheritHandle,
            Int32 dwProcessId
            );

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(
        IntPtr hObject
        );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            UIntPtr dwSize,
            uint dwFreeType
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern UIntPtr GetProcAddress(
            IntPtr hModule,
            string procName
            );

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(
            IntPtr hProcess,
            IntPtr lpAddress,
            uint dwSize,
            uint flAllocationType,
            uint flProtect
            );

        [DllImport("kernel32.dll")]
        static extern int WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            uint nSize,
            int lpNumberOfBytesWritten
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(
            string lpModuleName
            );

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        internal static extern Int32 WaitForSingleObject(
            IntPtr handle,
            Int32 milliseconds
            );

        public static bool Inject(int P, string DllPath)
        {
            IntPtr hndPrc = OpenProcess(0x1F0FFF, 1, P);

            if (hndPrc == IntPtr.Zero) return false;

            IntPtr lpAddress = VirtualAllocEx(hndPrc, (IntPtr)null, (uint)DllPath.Length, 0x1000, 0x40);

            if (lpAddress == IntPtr.Zero) return false;

            byte[] bytes = Encoding.ASCII.GetBytes(DllPath);

            if (WriteProcessMemory(hndPrc, lpAddress, bytes, (uint)bytes.Length, 0) == 0) return false;

            UIntPtr Injector = (UIntPtr)GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            IntPtr bytesout;
            IntPtr hThread = (IntPtr)CreateRemoteThread(hndPrc, (IntPtr)null, 0, Injector, lpAddress, 0, out bytesout);

            CloseHandle(hndPrc);

            return true;
        }

        public static int PreInject(int ProcessID, string DllPath)
        {
            if (!File.Exists(DllPath)) return 0;

            if (ProcessID == 0) return 1;

            if (!Inject(ProcessID, DllPath)) return 2;

            return 3;
        }

        public void StartFortnite()
        {
            var Fortnite = new Process
            {
                StartInfo =
                    {
                        FileName = System.IO.Path.Combine(CurrentVersion.path, @"FortniteGame\Binaries\Win64\FortniteClient-Win64-Shipping.exe"),
                        Arguments = "-noeac -nobe -fltoken=none -NoCodeGuards -epicapp=Fortnite -epicenv=Prod -epicportal -epiclocale=en-us -skippatchcheck -NOSSLPINNING -AUTH_LOGIN=ERA@ERA.ERA -AUTH_TYPE=epic -AUTH_PASSWORD=ERA",
                        UseShellExecute = false
                    }
            };

            Fortnite.Start();
            Fortnite.WaitForInputIdle();

            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);

            PreInject(Fortnite.Id, System.IO.Path.Combine(strWorkPath + @"\EraV2.dll"));
        }

        private void HandleGameLaunch(object sender, RoutedEventArgs e)
        {
            // Here, danii
            if (CurrentVersion != null)
            {
                if (Process.GetProcessesByName("FortniteClient-Win64-Shipping").Length == 0)
                {
                    new Thread(new ThreadStart(StartFortnite)).Start();
                }
                else
                {
                    MessageBox.Show("Fortnite is already running.", "ERA Launcher", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Unable to perform action. You must select a version profile first!", "ERA Launcher", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // Classes
    public class VersionData
    {
        public string _path;
        public string _Id;
        public string _splashpath;


        public string path
        {
            get { return this._path;  }
            set { this._path = value; }
        }

        public string splashpath
        {
            
            get { return path + @"\FortniteGame\Content\Splash\Splash.bmp"; }
            set { this._splashpath = value; }
        }
        public string Id
        {
            get { return this._Id.Replace(",", "."); }
            set { this._Id = value; }
        }
    }
}