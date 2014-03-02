namespace VkNet.Model
{
    using Utils;

    /// <summary>
    /// Класс видео альбома
    /// </summary>
    public class VideoAlbum
    {
        public long? Id { get; set; }
        public long? OwnerId { get; set; }
        public string Title { get; set; }
        public long? Count { get; set; }

        internal static VideoAlbum FromJson(VkResponse response)
        {
            var album = new VideoAlbum();

            album.Id = Utilities.GetNullableLongId(response["id"]);
            album.OwnerId = response["owner_id"];
            album.Title = response["title"];
            album.Count = Utilities.GetNullableLongId(response["count"]);

            return album;
        }
    }
}