using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Geolocation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace PhotosApp
{
    public class photoModel
    {
        public photoModel()
        {
            Comment = "Place Your comment here :)";
            DateTaken = DateTime.Now;
        }

        public int Id { get; set; }
        public Geolocator Location { get; set; }
        public string Comment { get; set; }
        public DateTime DateTaken { get; set; } 
        public BitmapImage Path { get; set; }
     
    }

}