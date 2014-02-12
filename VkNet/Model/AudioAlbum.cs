using VkNet.Utils;

namespace VkNet.Model
{
    public class AudioAlbum
    {
        public long? OwnerId { get; set; }
        public long? AlbumId { get; set; }
        public string Title { get; set; }

        internal static AudioAlbum FromJson(VkResponse response)
        {
            var album = new AudioAlbum();

            album.OwnerId = response["owner_id"];
            album.AlbumId = response["album_id"];
            album.Title = response["title"];

            return album;
        }
    }
}