using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace PixelArtTileTools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start()
        {
            // disable accesskeys without alt
            //CoreCompatibilityPreferences.IsAltKeyRequiredInAccessKeyDefaultScope = true; // TODO doesnt work in 8.0?

            // make window resizable (this didnt work when used pure xaml to do this)
            WindowChrome Resizable_BorderLess_Chrome = new WindowChrome();
            Resizable_BorderLess_Chrome.CornerRadius = new CornerRadius(0);
            Resizable_BorderLess_Chrome.CaptionHeight = 1.0;
            WindowChrome.SetWindowChrome(this, Resizable_BorderLess_Chrome);
        }

        private void Button_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Trace.WriteLine("Button_PreviewMouseDoubleClick");
            // only can do restore here, we dont want accidental maximize (max window not really needed)
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            //if (chkMinimizeToTaskbar.IsChecked == true)
            //{
            //    notifyIcon.Visible = true;
            //    this.Hide();
            //}
            //else
            //{
            this.WindowState = WindowState.Minimized;
            //            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnRectangleMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void OnWindowKeyDown(object sender, KeyEventArgs e)
        {
            // disable alt key?
            /*
            if (Keyboard.Modifiers == ModifierKeys.Alt)
            {
                e.Handled = true;
            }*/
            //switch (tabControl.SelectedIndex)
            //{
            switch (e.Key)
            {
                case Key.LeftCtrl: // used for ctrl+c
                    break;

                case Key.Escape: // clear project search
                    break;
                case Key.F5:
                    break;
                case Key.Up:
                case Key.Down:
                case Key.Left:
                case Key.Right:
                    break;
                default: // any key anykey
                         // skip these keys
                    if (Keyboard.Modifiers == ModifierKeys.Alt) return;
                    if (Keyboard.Modifiers == ModifierKeys.Control) return;
                    break;
            }
        } // OnWindowKeyDown

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveSettingsOnExit();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.IsActive == false) return; // dont run code on window init

            var win = (Window)sender;
            // save new size instead, to fix DPI scaling issue
            //Properties.Settings.Default.windowWidth = (int)e.NewSize.Width;
            //Properties.Settings.Default.windowHeight = (int)e.NewSize.Height;
            //Properties.Settings.Default.Save();
        }

        private void SaveSettingsOnExit()
        {
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            // need to run here, so that main window gets hidden if start from commandline as new/upgrade project
            Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }


        void PaletteLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
         //   PickPalette(e);
//            SetCurrentColorPreviewBox(rectCurrentColor, currentColor);
//            ResetCurrentBrightnessPreview(currentColor);
        }

    } // class
} // namespace