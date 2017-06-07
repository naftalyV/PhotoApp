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
       
        // public PhotosApp.photoViewModel VM { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            MainAppFrame.Content = AddPixPage;
            ShowWindowsToast("Test", "test", null);
            //DataContext = new photoViewModel();
            //  VM = new PhotosApp.photoViewModel();
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
                            //VM.Camera();
                            break;
                        }
                    case 1:
                        {
                            MainAppFrame.Content = AboutPage;
                            // Toggle_Click();
                            break;
                        }
                    case 2:
                        {
                            RunAsyncDialog();
                            // Toggle_Click();
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
        public static void ShowWindowsToast(string msgBody, string msgHeader, object content = null)
        {
            //for more info
            //https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/02/adaptive-and-interactive-toast-notifications-for-windows-10/
            try
            {

                var xmlToastTemplate = "<toast launch=\"app-defined-string\">" +
                              "<visual>" +
                                "<binding template =\"ToastGeneric\">" +
                                  "<text>" + msgHeader + "</text>" +
                                  "<text>" +
                                   msgBody +
                                  "</text>" +
                                "</binding>" +
                              "</visual>" +
                            "</toast>";

                // load the template as XML document
                Windows.Data.Xml.Dom.XmlDocument xmlDocument = new Windows.Data.Xml.Dom.XmlDocument();
                xmlDocument.LoadXml(xmlToastTemplate);

                // create the toast notification and show to user
                var toastNotification = new ToastNotification(xmlDocument);
                var notification = ToastNotificationManager.CreateToastNotifier();
               // toastNotification.ExpirationTime = DateTime.Now.AddSeconds(10);
                notification.Show(toastNotification);

            }
            catch (Exception ex)
            {

                //  ShowAppDialog(ex.Message, "Failed to inititate toast Error", MsgOptions.OK);
            }
        }
    }
}
