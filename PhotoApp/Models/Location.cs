using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;

namespace PhotosApp.Models
{
    class Location
    {
       
        public  async Task<string> GetLocationStr()
        {
            var checkAccess = await Geolocator.RequestAccessAsync();

            if (checkAccess == GeolocationAccessStatus.Denied)
            {
                // notification
                return "";
            }
            else
            {
                BasicGeoposition point = await GetLocationPoint();
                string res = await GetLocationStr(point.Latitude.ToString(), point.Longitude.ToString());

                return res;
            }
            // geo.PositionChanged += Geo_PositionChanged;
        }

        public async Task<BasicGeoposition> GetLocationPoint()
        {
            Geolocator geo = new Geolocator();
            geo.DesiredAccuracy = PositionAccuracy.High;
            geo.DesiredAccuracyInMeters = 5;

            geo.ReportInterval = 3000;
            geo.MovementThreshold = 5;

            Geoposition location = await geo.GetGeopositionAsync();

            BasicGeoposition point = location.Coordinate.Point.Position;
            return point;
        }

        //private  void Geo_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        //{
        //    var point = args.Position.Coordinate.Point.Position;

        //    var res = GetLocationName(point.Latitude.ToString(), point.Longitude.ToString()).Result;

        //    //await new Page().Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () => {
        //    //    //  locationTxt.Text = res;
        //    //    var result= res;
        //    //});
        //}

        public async Task<string> GetLocationStr(string latitude, string longitude)
        {
            //use google api to get location
            string baseUri = "http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";

            string location = string.Empty;
            string requestUri = string.Format(baseUri, latitude, longitude);

            // use web service to get location
            using (HttpClient wc = new HttpClient())
            {
                string result = await wc.GetStringAsync(requestUri);
                var xmlElm = XElement.Parse(result);
                var status = (from elm in xmlElm.Descendants()
                              where elm.Name == "status"
                              select elm).FirstOrDefault();

                if (status.Value.ToLower() == "ok")
                {
                    var res = (from elm in xmlElm.Descendants()
                               where elm.Name == "formatted_address"
                               select elm).FirstOrDefault();
                    requestUri = res.Value;
                }

            }
            return requestUri;
        }
    }
}
  
