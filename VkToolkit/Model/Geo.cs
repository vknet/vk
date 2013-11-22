using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Geo
    {
        public string Type { get; set; }
        public Coordinates Coordinates { get; set; }
        public Place Place { get; set; }

        internal static Geo FromJson(VkResponse geo)
        {
            // TODO: TEST IT!!!!!
            var result = new Geo();

            result.Type = geo["type"];
            result.Coordinates = geo["coordinates"];
            result.Place = geo["place"];

            return result;
        }
    }
}