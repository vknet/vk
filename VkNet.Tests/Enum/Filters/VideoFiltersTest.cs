using NUnit.Framework;
using VkNet.Enums.Filters;


namespace VkNet.Tests.Enum.Filters
{
	[TestFixture]
    public class VideoFiltersTest
    {
        [Test]
        public void ToString_EveryItems()
        {
            var mp4 = VideoFilters.Mp4;
			var youtube = VideoFilters.Youtube;
            var vimeo = VideoFilters.Vimeo;
            var videoFilters = VideoFilters.Short;
            var filters = VideoFilters.Long;
            var all = VideoFilters.All;
            var shortLong = videoFilters | filters;

			Assert.That(mp4.ToString(), Is.EqualTo("mp4"));
			Assert.That(youtube.ToString(), Is.EqualTo("youtube"));
			Assert.That(vimeo.ToString(), Is.EqualTo("vimeo"));
			Assert.That(filters.ToString(), Is.EqualTo("long"));
			Assert.That(videoFilters.ToString(), Is.EqualTo("short"));
			Assert.That(all.ToString(), Is.EqualTo("mp4,youtube,vimeo,short,long"));
			Assert.That(shortLong.ToString(), Is.EqualTo("short,long"));
		}
    }
}