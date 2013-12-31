namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о географическом месте, в котором была сделана запись. 
    /// См. описание <see cref="http://vk.com/pages?oid=-1&p=%D0%9E%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5_%D0%BF%D0%BE%D0%BB%D1%8F_geo"/>.
    /// </summary>
    public class Geo
    {
        /// <summary>
        /// Имя типа информации о географическом месте (в настоящий момент поддерживается единственный тип "place", это означает, 
        /// что запись привязана к определенному географическому месту в базе мест.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Координаты места, в котором была сделана запись.
        /// </summary>
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Информация о месте, в котором была сделана запись.
        /// </summary>
        public Place Place { get; set; }

        #region Методы

        internal static Geo FromJson(VkResponse response)
        {
            // TODO: TEST IT!!!!!
            var geo = new Geo();

            geo.Place = response["place"];
            geo.Coordinates = response["coordinates"];
            geo.Type = response["type"];

            return geo;
        }

        #endregion
    }
}