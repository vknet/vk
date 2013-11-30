using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Информация о географическом месте, в котором была сделана запись. 
    /// </summary>
    public class Geo
    {
        /// <summary>
        /// Имя типа информации о географическом месте (в настоящий момент поддерживается единственный тип "place", это означает, 
        /// что запись привязана к определенному географическому месту в базе мест.)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Информация о месте, в котором была сделана запись.
        /// </summary>
        public Place Place { get; set; }
        /// <summary>
        /// Координаты места, в котором была сделана запись.
        /// </summary>
        public Coordinates Coordinates { get; set; }

        internal static Geo FromJson(VkResponse geo)
        {
            // TODO: TEST IT!!!!!
            var result = new Geo();

            result.Place = geo["place"];
            result.Type = geo["type"];
            result.Coordinates = geo["coordinates"];

            return result;
        }
    }
}