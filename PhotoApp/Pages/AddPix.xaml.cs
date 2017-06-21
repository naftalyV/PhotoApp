using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PhotosApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPix : Page
    {

        public AddPix()
        {
            this.InitializeComponent();

        }
        private photoModel selected;

        public photoModel Selected
        {
            get { return selected; }
            set
            {
                if (value != selected)
                {
                    selected = value;
                    Bindings.Update();
                }
            }
        }
        private void brdDrop_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void brdDrop_Drop(object sender, DragEventArgs e)
        {
            // dataview is snoop in to the file..
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                //any file (>0)
                if (items.Any())
                {
                    StorageFile selected = items[0] as StorageFile;
                    var type = selected.ContentType;
                    //if image
                    if (type == "image/jpeg")
                    {
                        var imgCopy = await selected
                            .CopyAsync(ApplicationData.Current.LocalFolder, selected.Name, 
                            NameCollisionOption.ReplaceExisting);
                        //img.Source = new BitmapImage(new Uri(imgCopy.Path));

                        VM.Images.Add(new photoModel() { Path = new BitmapImage(new Uri(imgCopy.Path)) });
                        //Images.Add(imgCopy );
                        //VM.Images.Add(imgCopy.Path);
                        Bindings.Update();
                   }
                }
            }
        }

        //private void Toggle_Toggled(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
