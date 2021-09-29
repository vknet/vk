using System;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class VideoModel : BaseTest
	{
		[Test]
		public void ToString_VideoShouldHaveAccessKey()
		{
			var video = new Video
			{
				Id = 1234,
				OwnerId = 1234,
				AccessKey = "test"
			};

			var result = video.ToString();

			Assert.AreEqual(result, "video1234_1234_test");
		}

		[Test]
		public void Cans_ArePresent()
		{
			ReadJsonFile("Models", "video_with_ads_and_timeline");

			var response = GetResponse();

			var video = Video.FromJson(response);

			Assert.True(video.CanComment);
			Assert.True(video.CanLike);
			Assert.True(video.CanRepost);
			Assert.True(video.CanSubscribe);
			Assert.True(video.CanAddToFaves);
			Assert.True(video.CanAdd);
		}

		[Test]
		public void OvId_IsPresent()
		{
			ReadJsonFile("Models", "video_with_ads_and_timeline");

			var response = GetResponse();

			var video = Video.FromJson(response);

			Assert.AreEqual("2930947729488", video.OvId);
		}

		[Test]
		public void Files_AllFields_ArePresent()
		{
			ReadJsonFile("Models", "video_with_ads_and_timeline");

			var response = GetResponse();

			var video = Video.FromJson(response);

			var files = video.Files;

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=hJ-nQdUFlJE&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=0"),
				files.Mp4_240);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=AaOYcMVln7E&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=1"),
				files.Mp4_360);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=stO4D-MNhVA&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=2"),
				files.Mp4_480);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=6zFPxlcmMW0&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=3"),
				files.Mp4_720);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=P479kIBCu5M&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=5"),
				files.Mp4_1080);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/video.m3u8?srcIp=217.70.31.125&expires=1633249784334&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&mid=2930947729488&type=4&sig=kKC4Rp0aao4&ct=8&urls=185.226.52.190&clientType=13&cmd=videoPlayerCdn&id=1777443670608"),
				files.Hls);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=stO4D-MNhVA&ct=6&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=2"),
				files.DashUni);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=AaOYcMVln7E&ct=6&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=1"),
				files.DashSep);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/?sig=_PmzhECbdtY&ct=6&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=4"),
				files.DashWebm);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/srcIp/217.70.31.125/expires/1633249784334/srcAg/UNKNOWN/fromCache/1/ms/45.136.22.169/mid/2930947729488/type/2/sig/JahccvslsEY/ct/28/urls/185.226.52.190/clientType/13/id/1777443670608/ondemand/hls_1777443670608.m3u8"),
				files.HlsOnDemand);

			Assert.AreEqual(
				new Uri(
					"https://vkvd79.mycdn.me/srcIp/217.70.31.125/expires/1633249784334/srcAg/UNKNOWN/fromCache/1/ms/45.136.22.169/mid/2930947729488/type/2/sig/JahccvslsEY/ct/29/urls/185.226.52.190/clientType/13/id/1777443670608/ondemand/dash_1777443670608.mpd"),
				files.DashOnDemand);

			Assert.AreEqual("vkvd185.mycdn.me", files.FailOverHost);
		}

		[Test]
		public void TimelineThumbs_AllFields_ArePresent()
		{
			ReadJsonFile("Models", "video_with_ads_and_timeline");

			var response = GetResponse();

			var video = Video.FromJson(response);

			var timelineThumbs = video.TimelineThumbs;

			Assert.AreEqual(9, timelineThumbs.CountPerImage);
			Assert.AreEqual(3, timelineThumbs.CountPerRow);
			Assert.AreEqual(208, timelineThumbs.CountTotal);
			Assert.AreEqual(180, timelineThumbs.FrameHeight);
			Assert.AreEqual(320.0f, timelineThumbs.FrameWidth);
			Assert.AreEqual(24, timelineThumbs.Links.Count);
			Assert.IsTrue(timelineThumbs.IsUv);
			Assert.AreEqual(5, timelineThumbs.Frequency);
		}

		[Test]
		public void Ads_AllFields_ArePresent()
		{
			ReadJsonFile("Models", "video_with_ads_and_timeline");

			var response = GetResponse();

			var video = Video.FromJson(response);

			var ads = video.Ads;

			Assert.AreEqual(551874, ads.SlotId);
			Assert.AreEqual(1.0f, ads.Timeout);
			Assert.AreEqual(1, ads.CanPlay);

			Assert.IsNotNull(ads.Params);

			var sections = ads.Sections;

			Assert.AreEqual(3, sections.Count);
			Assert.AreEqual(VideoAdsSection.Preroll, sections[0]);
			Assert.AreEqual(VideoAdsSection.Midroll, sections[1]);
			Assert.AreEqual(VideoAdsSection.Postroll, sections[2]);

			var midrollPercents = ads.MidrollPercents;
			Assert.AreEqual(2, midrollPercents.Count);
			Assert.AreEqual(0.25f, midrollPercents[0]);
			Assert.AreEqual(0.75f, midrollPercents[1]);

			Assert.AreEqual(1, ads.AutoPlayPreroll);
		}

		[Test]
		public void AdsParams_AllFields_ArePresent()
		{
			ReadJsonFile("Models", "video_with_ads_and_timeline");

			var response = GetResponse();

			var video = Video.FromJson(response);

			var ads = video.Ads;

			var @params = ads.Params;
			Assert.IsNotNull(@params);

			Assert.AreEqual(12345678, @params.VkId);
			Assert.AreEqual(1039, @params.Duration);
			Assert.AreEqual("-136270576_456239929", @params.VideoId);
			Assert.AreEqual(21469, @params.Pl);
			Assert.AreEqual("-585277666870842567", @params.ContentId);
			Assert.AreEqual(1, @params.Lang);

			// All Puid`s are basically random, but for provided JSON they are provided correctly

			Assert.AreEqual("986", @params.PuId1);
			Assert.AreEqual(17, @params.PuId2);
			Assert.AreEqual(1, @params.PuId3);
			Assert.AreEqual(1, @params.PuId4);
			Assert.AreEqual(14, @params.PuId5);
			Assert.AreEqual(86, @params.PuId6);
			Assert.AreEqual(1, @params.PuId7);
			Assert.AreEqual(9, @params.PuId8);
			Assert.AreEqual(0, @params.PuId9);
			Assert.AreEqual(4, @params.PuId10);
			Assert.AreEqual(16, @params.PuId12);
			Assert.AreEqual(2, @params.PuId13);
			Assert.AreEqual(2, @params.PuId14);
			Assert.AreEqual(1, @params.PuId15);
			Assert.AreEqual(0, @params.PuId18);
			Assert.AreEqual(2, @params.PuId21);

			Assert.AreEqual("4551227ff8b9944114687581748264426f663db8", @params.Sign);
			Assert.AreEqual(136270576, @params.GroupId);
			Assert.AreEqual(29, @params.VkCatId);
		}

		[Test]
		public void Video_Live_AllFields_ArePresent()
		{
			ReadJsonFile("Models", "video_live");

			var response = GetResponse();

			var video = Video.FromJson(response);

			Assert.AreEqual(0, video.Duration);
			Assert.AreEqual("live", video.Type);
			Assert.AreEqual("started", video.LiveStatus);
			Assert.True(video.Live);
			Assert.AreEqual(89, video.Spectators);
		}

		[Test]
		public void Video_Live_Files_Contains_Live_Uris()
		{
			ReadJsonFile("Models", "video_live");

			var response = GetResponse();

			var video = Video.FromJson(response);

			var files = video.Files;

			Assert.AreEqual(
				new Uri(
					"https://vkvsd16.mycdn.me/hls/1095312673357_offset_p.m3u8/sig/OWp_G67RlXg/srcIp/217.70.31.125/expires/1633252742236/clientType/13/srcAg/UNKNOWN/fromCache/1/mid/2669706881869/id/1095312673357/video.m3u8?p"),
				files.HlsLivePlayback);

			Assert.AreEqual(
				new Uri(
					"https://vkvsd16.mycdn.me/dash/stream_1095312673357_offset_p/stream.manifest/sig/OWp_G67RlXg/srcIp/217.70.31.125/expires/1633252742236/clientType/13/srcAg/UNKNOWN/fromCache/1/mid/2669706881869/id/1095312673357/video"),
				files.DashLivePlayback);
		}

		[Test]
		public void Video_Live_LiveSettings_AllFields_ArePresent()
		{
			ReadJsonFile("Models", "video_live");

			var response = GetResponse();

			var video = Video.FromJson(response);

			var liveSettings = video.LiveSettings;

			Assert.AreEqual(1, liveSettings.CanRewind);
			Assert.AreEqual(1, liveSettings.IsEndless);
			Assert.AreEqual(7200, liveSettings.MaxDuration);
		}
	}
}