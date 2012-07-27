using System;

namespace VkToolkit.Model
{
    public class Audio
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public Uri Url { get; set; }
        public long? LyricsId { get; set; }
        public long? AlbumId { get; set; }
        public string Performer { get; set; }

        protected bool Equals(Audio other)
        {
            return Id == other.Id && OwnerId == other.OwnerId && string.Equals(Artist, other.Artist) && string.Equals(Title, other.Title) && Duration == other.Duration && Equals(Url, other.Url) && LyricsId == other.LyricsId && AlbumId == other.AlbumId && string.Equals(Performer, other.Performer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Audio) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ OwnerId.GetHashCode();
                hashCode = (hashCode*397) ^ (Artist != null ? Artist.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Duration;
                hashCode = (hashCode*397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ LyricsId.GetHashCode();
                hashCode = (hashCode*397) ^ AlbumId.GetHashCode();
                hashCode = (hashCode*397) ^ (Performer != null ? Performer.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        public static bool operator == (Audio a1, Audio a2)
        {
            if (a1 == null || a2 == null)
                return false;

            return a1.Id == a2.Id && a1.OwnerId == a2.OwnerId && a1.Artist == a2.Artist & a1.Title == a2.Title &&
                   a1.Duration == a2.Duration && a1.Performer == a2.Performer;
        }

        public static bool operator != (Audio a1, Audio a2)
        {
            return !(a1 == a2);
        }
    }
}
