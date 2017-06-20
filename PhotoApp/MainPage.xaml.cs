using PhotosApp;
using PhotosApp.Models;
using PhotosApp.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhotosApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal AddPix AddPixPage { get; set; } = new AddPix();
        internal About AboutPage { get; set; } = new About();
        Location l = new Location();
        string strL;
        public MainPage()
        {
            this.InitializeComponent();
            MainAppFrame.Content = AddPixPage;
            SetTile.StartTile();
            SetLocation();
        }

        private async void SetLocation()
        {
            strL = await l.GetLocationStr();
        }

        public void HmburgerMenu()
        {
            mySplit.IsPaneOpen = !mySplit.IsPaneOpen;

        }
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {

            if (MainAppFrame.CanGoForward)
            {
                MainAppFrame.GoForward();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                ListBox lb = sender as ListBox;

                switch (lb.SelectedIndex)
                {
                    case 0:
                        {
                            MainAppFrame.Content = AddPixPage;

                            break;
                        }
                    case 1:
                        {
                            MainAppFrame.Content = AboutPage;

                            break;
                        }
                    case 2:
                        {
                            RunAsyncDialog();

                            break;
                        }
                }
            }
        }
        private async void RunAsyncDialog()
        {
            MessageDialog closDilog = new MessageDialog("");
            closDilog.Title = "Closing Confirmation";
            closDilog.Content = "are you sure about it ?";
            closDilog.Commands.Add(new UICommand() { Id = 0, Label = "Yes" });
            closDilog.Commands.Add(new UICommand() { Id = 1, Label = "No" });

            IUICommand res = await closDilog.ShowAsync();
            if ((int)res.Id == 0)
            {
                Application.Current.Exit();
            }
        }

        private void Toggle_Toggled(object sender, RoutedEventArgs e)
        {

            if (RequestedTheme != ElementTheme.Dark)
            {
                RequestedTheme = ElementTheme.Dark;
            }
            else
                RequestedTheme = ElementTheme.Light;
        }

    }
}


