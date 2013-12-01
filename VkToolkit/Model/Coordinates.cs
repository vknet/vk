using VkToolkit.Exception;
using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Координаты места, в котором была сделана запись.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Географическая широта.
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Географическая долгота.
        /// </summary>
        public double Longitude { get; set; }

        internal static Coordinates FromJson(VkResponse coordinates)
        {
            // TODO: TEST IT!!!!!
            var latitudeWithLongitude = ((string)coordinates).Split(' ');
            if (latitudeWithLongitude.Length != 2)
                throw new VkApiException("Coordinates must have latitude and longitude!");

            double latitude;
            if (!double.TryParse(latitudeWithLongitude[0].Replace(".", ","), out latitude))
                throw new VkApiException("Invalid latitude!");

            double longitude;
            if (!double.TryParse(latitudeWithLongitude[1].Replace(".", ","), out longitude))
                throw new VkApiException("Invalid longitude!");

            var result = new Coordinates { Latitude = latitude, Longitude = longitude };

            return result;
        }
    }
}