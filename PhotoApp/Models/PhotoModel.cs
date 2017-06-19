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
            Location = new BasicGeoposition() { Latitude = 47.620, Longitude = -122.349 };
            
        }

        public int Id { get; set; } 
        public BasicGeoposition Location { get; set; }
        public string Comment { get; set; }
        public DateTime DateTaken { get; set; } 
        public BitmapImage Path { get; set; }
     
    }

}