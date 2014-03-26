namespace VkNet.Model
{
    using VkNet.Exception;
    using VkNet.Utils;

    /// <summary>
    /// Координаты места, в котором была сделана запись.
    /// См. описание <see href="http://vk.com/pages?oid=-1&p=%D0%9E%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5_%D0%BF%D0%BE%D0%BB%D1%8F_geo"/>.
    /// Официальная страница <see href="http://vk.com/dev/post"/>, описывающая запись на стене и объект Geo в нем, почему то 
    /// молчит о том, что возвращаются географические координаты.
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

        #region Методы

        internal static Coordinates FromJson(VkResponse response)
        {
            // TODO: TEST IT!!!!!
            var latitudeWithLongitude = ((string)response).Split(' ');
            if (latitudeWithLongitude.Length != 2)
                throw new VkApiException("Coordinates must have latitude and longitude!");

            double latitude;
            if (!double.TryParse(latitudeWithLongitude[0].Replace(".", ","), out latitude))
                throw new VkApiException("Invalid latitude!");

            double longitude;
            if (!double.TryParse(latitudeWithLongitude[1].Replace(".", ","), out longitude))
                throw new VkApiException("Invalid longitude!");

            var coordinates = new Coordinates { Latitude = latitude, Longitude = longitude };

            return coordinates;
        }

        #endregion
    }
}