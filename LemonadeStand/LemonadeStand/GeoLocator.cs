using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;
using System.Device.Location;

namespace LemonadeStand
{
    class GeoLocator
    {

        public GeoCoordinate getLocation(string address)
        {
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            string lat = locationElement.Element("lat").Value;
            string lng = locationElement.Element("lng").Value;
            GeoCoordinate location = new GeoCoordinate();
            location.Latitude = Convert.ToDouble(lat);
            location.Longitude = Convert.ToDouble(lng);

            return location;
        }
    }
}
