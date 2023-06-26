using System;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class VideoModel : BaseTest
{
	[Fact]
	public void ToString_VideoShouldHaveAccessKey()
	{
		var video = new Video
		{
			Id = 1234,
			OwnerId = 1234,
			AccessKey = "test"
		};

		var result = video.ToString();

		result.Should()
			.Be("video1234_1234_test");
	}

	[Fact]
	public void Cans_ArePresent()
	{
		ReadJsonFile("Models", "video_with_ads_and_timeline");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		video.CanComment.Should()
			.BeTrue();

		video.CanLike.Should()
			.BeTrue();

		video.CanRepost.Should()
			.BeTrue();

		video.CanSubscribe.Should()
			.BeTrue();

		video.CanAddToFaves.Should()
			.BeTrue();

		video.CanAdd.Should()
			.BeTrue();
	}

	[Fact]
	public void OvId_IsPresent()
	{
		ReadJsonFile("Models", "video_with_ads_and_timeline");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		video.OvId.Should()
			.Be("2930947729488");
	}

	[Fact]
	public void Files_AllFields_ArePresent()
	{
		ReadJsonFile("Models", "video_with_ads_and_timeline");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		var files = video.Files;

		files.Mp4_240.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=hJ-nQdUFlJE&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=0"));

		files.Mp4_360.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=AaOYcMVln7E&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=1"));

		files.Mp4_480.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=stO4D-MNhVA&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=2"));

		files.Mp4_720.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=6zFPxlcmMW0&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=3"));

		files.Mp4_1080.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=P479kIBCu5M&ct=0&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=5"));

		files.Hls.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/video.m3u8?srcIp=217.70.31.125&expires=1633249784334&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&mid=2930947729488&type=4&sig=kKC4Rp0aao4&ct=8&urls=185.226.52.190&clientType=13&cmd=videoPlayerCdn&id=1777443670608"));

		files.DashUni.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=stO4D-MNhVA&ct=6&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=2"));

		files.DashSep.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=AaOYcMVln7E&ct=6&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=1"));

		files.DashWebm.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/?sig=_PmzhECbdtY&ct=6&srcIp=217.70.31.125&urls=185.226.52.190&expires=1633249784334&clientType=13&srcAg=UNKNOWN&fromCache=1&ms=45.136.22.169&appId=512000384397&id=1777443670608&type=4"));

		files.HlsOnDemand.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/srcIp/217.70.31.125/expires/1633249784334/srcAg/UNKNOWN/fromCache/1/ms/45.136.22.169/mid/2930947729488/type/2/sig/JahccvslsEY/ct/28/urls/185.226.52.190/clientType/13/id/1777443670608/ondemand/hls_1777443670608.m3u8"));

		files.DashOnDemand.Should()
			.Be(new Uri(
				"https://vkvd79.mycdn.me/srcIp/217.70.31.125/expires/1633249784334/srcAg/UNKNOWN/fromCache/1/ms/45.136.22.169/mid/2930947729488/type/2/sig/JahccvslsEY/ct/29/urls/185.226.52.190/clientType/13/id/1777443670608/ondemand/dash_1777443670608.mpd"));

		files.FailOverHost.Should()
			.Be("vkvd185.mycdn.me");
	}

	[Fact]
	public void TimelineThumbs_AllFields_ArePresent()
	{
		ReadJsonFile("Models", "video_with_ads_and_timeline");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		var timelineThumbs = video.TimelineThumbs;

		timelineThumbs.CountPerImage.Should()
			.Be(9);

		timelineThumbs.CountPerRow.Should()
			.Be(3);

		timelineThumbs.CountTotal.Should()
			.Be(208);

		timelineThumbs.FrameHeight.Should()
			.Be(180);

		timelineThumbs.FrameWidth.Should()
			.Be(320.0f);

		timelineThumbs.Links.Should()
			.HaveCount(24);

		timelineThumbs.IsUv.Should()
			.BeTrue();

		timelineThumbs.Frequency.Should()
			.Be(5);
	}

	[Fact]
	public void Ads_AllFields_ArePresent()
	{
		ReadJsonFile("Models", "video_with_ads_and_timeline");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		var ads = video.Ads;

		ads.SlotId.Should()
			.Be(551874);

		ads.Timeout.Should()
			.Be(1.0f);

		ads.CanPlay.Should()
			.Be(1);

		ads.Params.Should()
			.NotBeNull();

		var sections = ads.Sections;

		sections.Should()
			.HaveCount(3);

		sections.Should()
			.HaveElementAt(0, VideoAdsSection.Preroll);

		sections.Should()
			.HaveElementAt(1, VideoAdsSection.Midroll);

		sections.Should()
			.HaveElementAt(2, VideoAdsSection.Postroll);

		var midrollPercents = ads.MidrollPercents;

		midrollPercents.Should()
			.HaveCount(2);

		midrollPercents.Should()
			.HaveElementAt(0, 0.25f);

		midrollPercents.Should()
			.HaveElementAt(1, 0.75f);

		ads.AutoPlayPreroll.Should()
			.Be(1);
	}

	[Fact]
	public void AdsParams_AllFields_ArePresent()
	{
		ReadJsonFile("Models", "video_with_ads_and_timeline");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		var ads = video.Ads;

		var @params = ads.Params;

		@params.Should()
			.NotBeNull();

		@params.VkId.Should()
			.Be(12345678);

		@params.Duration.Should()
			.Be(1039);

		@params.VideoId.Should()
			.Be("-136270576_456239929");

		@params.Pl.Should()
			.Be(21469);

		@params.ContentId.Should()
			.Be("-585277666870842567");

		@params.Lang.Should()
			.Be(1);

		// All Puid`s are basically random, but for provided JSON they are provided correctly

		@params.PuId1.Should()
			.Be("986");

		@params.PuId2.Should()
			.Be(17);

		@params.PuId3.Should()
			.Be(1);

		@params.PuId4.Should()
			.Be(1);

		@params.PuId5.Should()
			.Be(14);

		@params.PuId6.Should()
			.Be(86);

		@params.PuId7.Should()
			.Be(1);

		@params.PuId8.Should()
			.Be(9);

		@params.PuId9.Should()
			.Be(0);

		@params.PuId10.Should()
			.Be(4);

		@params.PuId12.Should()
			.Be(16);

		@params.PuId13.Should()
			.Be(2);

		@params.PuId14.Should()
			.Be(2);

		@params.PuId15.Should()
			.Be(1);

		@params.PuId18.Should()
			.Be(0);

		@params.PuId21.Should()
			.Be(2);

		@params.Sign.Should()
			.Be("4551227ff8b9944114687581748264426f663db8");

		@params.GroupId.Should()
			.Be(136270576);

		@params.VkCatId.Should()
			.Be(29);
	}

	[Fact]
	public void Video_Live_AllFields_ArePresent()
	{
		ReadJsonFile("Models", "video_live");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		video.Duration.Should()
			.Be(0);

		video.Type.Should()
			.Be("live");

		video.LiveStatus.Should()
			.Be("started");

		video.Live.Should()
			.BeTrue();

		video.Spectators.Should()
			.Be(89);
	}

	[Fact]
	public void Video_Live_Files_Contains_Live_Uris()
	{
		ReadJsonFile("Models", "video_live");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		var files = video.Files;

		files.HlsLivePlayback.Should()
			.Be(new Uri(
				"https://vkvsd16.mycdn.me/hls/1095312673357_offset_p.m3u8/sig/OWp_G67RlXg/srcIp/217.70.31.125/expires/1633252742236/clientType/13/srcAg/UNKNOWN/fromCache/1/mid/2669706881869/id/1095312673357/video.m3u8?p"));

		files.DashLivePlayback.Should()
			.Be(new Uri(
				"https://vkvsd16.mycdn.me/dash/stream_1095312673357_offset_p/stream.manifest/sig/OWp_G67RlXg/srcIp/217.70.31.125/expires/1633252742236/clientType/13/srcAg/UNKNOWN/fromCache/1/mid/2669706881869/id/1095312673357/video"));
	}

	[Fact]
	public void Video_Live_LiveSettings_AllFields_ArePresent()
	{
		ReadJsonFile("Models", "video_live");

		Url = "https://api.vk.com/method/friends.getRequests";
		var video = Api.Call<Video>("friends.getRequests", VkParameters.Empty);

		var liveSettings = video.LiveSettings;

		liveSettings.CanRewind.Should()
			.Be(1);

		liveSettings.IsEndless.Should()
			.Be(1);

		liveSettings.MaxDuration.Should()
			.Be(7200);
	}
}