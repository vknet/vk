using VkToolkit.Exception;
using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        internal static Coordinates FromJson(VkResponse coordinates)
        {
            // TODO: TEST IT!!!!!
            var latitudeWithLongitude = ((string)coordinates).Split(' ');
            if (latitudeWithLongitude.Length != 2)
                throw new VkApiException("Coordinates must have latitude and longitude!");

            double latitude;
            if (!double.TryParse(latitudeWithLongitude[0], out latitude))
                throw new VkApiException("Invalid latitude!");

            double longitude;
            if (!double.TryParse(latitudeWithLongitude[1], out longitude))
                throw new VkApiException("Invalid longitude!");

            var result = new Coordinates { Latitude = latitude, Longitude = longitude };

            return result;
        }
    }
}