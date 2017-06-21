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
using PhotosApp.Models;
using System.ComponentModel;

namespace PhotosApp
{
    public class photoModel
    {
        public photoModel()
        {
            Comment = "Place Your comment here :)";
            DateTaken = DateTime.Now;
            // Location = new Location().GetLocationPoint().Result;
            intiLocation();
        }

        private async void intiLocation()
        {
            LocationStr = await new Location().GetLocationStr();
        }

        public int Id { get; set; } 
        public BasicGeoposition Location { get; set; }
        public string LocationStr { get; set; }
        public string Comment { get; set; }
        public DateTime DateTaken { get; set; } 
        public BitmapImage Path { get; set; }
     
    }

}