namespace VkToolkit.Model
{
    public class Geo
    {
        public string Type { get; set; }
        public Coordinates Coordinates { get; set; }
        public Place Place { get; set; }
    }

    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}