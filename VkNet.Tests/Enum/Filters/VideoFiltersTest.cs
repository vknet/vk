using NUnit.Framework;
using VkNet.Enums.Filters;
using FluentNUnit;

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

            mp4.ToString().ShouldEqual("mp4");
            youtube.ToString().ShouldEqual("youtube");
            vimeo.ToString().ShouldEqual("vimeo");
            filters.ToString().ShouldEqual("long");
            videoFilters.ToString().ShouldEqual("short");
            all.ToString().ShouldEqual("mp4,youtube,vimeo,short,long");
            shortLong.ToString().ShouldEqual("short,long");
        }
    }
}