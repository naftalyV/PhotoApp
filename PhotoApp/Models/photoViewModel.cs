using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace PhotosApp
{
    public class PhotoViewModel
    {
        public ObservableCollection<photoModel> Images { get; set; } = new ObservableCollection<photoModel>();

        public async void Camera()
        {
            // initiate camera app
            CameraCaptureUI cam = new CameraCaptureUI();
            cam.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            StorageFile imageFile = await cam.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (imageFile != null)
            {
                //Location of the picture taken from camera
                var locator = new Geolocator();
                // Shows the user consent UI if needed
                var accessStatus = await Geolocator.RequestAccessAsync();
                if (accessStatus == GeolocationAccessStatus.Allowed)
                {
                    await GeotagHelper.SetGeotagFromGeolocatorAsync(imageFile, locator);
                }

                Images.Add(new photoModel()
                {
                    Path = new BitmapImage(new Uri(imageFile.Path)),
                    Location = locator
                });

            }        }

    }
}
