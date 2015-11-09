namespace VkNet.Model
{
    using System;

    using Utils;

    [Serializable]
    /// <summary>
    /// Информация о географическом месте, в котором была сделана запись. 
    /// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo"/>.
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