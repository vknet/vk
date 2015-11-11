using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;
using FluentNUnit;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class GiftsTest
	{
		private GiftsCategory GetMockedGiftsCategory(string url, string json)
		{
			var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
			return new GiftsCategory(new VkApi { AccessToken = "token", Browser = browser });
		}

		[Test]
		public void Get_NormalCase()
		{

			const string url = "https://api.vk.com/method/gifts.get?user_id=32190123&v=5.37&access_token=token";
			const string json =
				@"{
					'response': {
						'count': 5,
						'items': [
							{
								'id': 443110992,
								'from_id': 221634238,
								'message': '',
								'date': 1431167825,
								'gift': {
									'id': 711,
									'thumb_256': 'http://vk.com/images/gift/711/256.jpg',
									'thumb_96': 'http://vk.com/images/gift/711/96.png',
									'thumb_48': 'http://vk.com/images/gift/711/48.png'
								},
								'privacy': 0,
								'gift_hash': 'GHtdZoFyFji3D0ulvWpSWD24ZDZf5bBHrkDUVF9wBoQrgO2HTdcEs7Qo63A/TWWEMUcMyI7HyYlAVNCgbzVfPIR7Exme28kZeSessZt4smEuavmtfK04n*D3HBB8CHLZeStwNQuJJ8wID8s5ZR7OBT*virUoYNWqda3s6uC2DWo-'
							}, {
								'id': 440962831,
								'from_id': 131518798,
								'message': '',
								'date': 1431164005,
								'gift': {
									'id': 711,
									'thumb_256': 'http://vk.com/images/gift/711/256.jpg',
									'thumb_96': 'http://vk.com/images/gift/711/96.png',
									'thumb_48': 'http://vk.com/images/gift/711/48.png'
								},
								'privacy': 0,
								'gift_hash': 'Jx0VKwo/RHV35N1wfAEONurHjvkBlIrf4Zc42*LWGGh9qcBVCFBNAYngwpSbT5pf65NJKQSEZnT3uuWTencpTmLUwhXyn5kafx92vtgb9RgTEIUzLc4n3ioDbm97l2gl37C/77PD7IZKjQOjZ5Ss8eQ1cGqOkBCfN3wDkA1Rs*4-'
							}, {
								'id': 427190810,
								'from_id': 21010218,
								'message': 'С ДНЁМ ВЕЛИКОЙ ПОБЕДЫ!!!',
								'date': 1431129066,
								'gift': {
									'id': 711,
									'thumb_256': 'http://vk.com/images/gift/711/256.jpg',
									'thumb_96': 'http://vk.com/images/gift/711/96.png',
									'thumb_48': 'http://vk.com/images/gift/711/48.png'
								},
								'privacy': 0,
								'gift_hash': 'E4dCOluBRvDzooiYFCmXd684lMuCCsBJae9*8qoPX4PCasZ82jSDGISlCkQiv/p0Vd49/QMZC6V/qag1E2Rq0aEiizzurGVysmyGnamG0kKU46iWTgBTPXzD4rIyRas81PPMw2nndKMGLjAAYJMsWwQnAl7k9sfqfTM7ShC9VSU-'
							}, {
								'id': 164779613,
								'from_id': 21010218,
								'message': '',
								'date': 1368127865,
								'gift': {
									'id': 237,
									'thumb_256': 'http://vk.com/images/gift/237/256.jpg',
									'thumb_96': 'http://vk.com/images/gift/237/96.png',
									'thumb_48': 'http://vk.com/images/gift/237/48.png'
								},
								'privacy': 0,
								'gift_hash': 'aZj2rFIyBrcWonSJ5oFD6gxkhiaoev5O*9Hd4kKt09doUlxHK*tf5QDNHZdISN*iWLmrQWhCHQ9tFvucxrzylKjYCK0IkWICJnUsJiJ*hqPwN4nmeQJGU53OuhO3ew1p2vtv4fPh02jsqxtk8QUjE85BwQlkpyETBHLFeSyXIoQ-'
							}, {
								'id': 133616563,
								'from_id': 35983032,
								'message': '',
								'date': 1336599347,
								'gift': {
									'id': 237,
									'thumb_256': 'http://vk.com/images/gift/237/256.jpg',
									'thumb_96': 'http://vk.com/images/gift/237/96.png',
									'thumb_48': 'http://vk.com/images/gift/237/48.png'
								},
								'privacy': 0,
								'gift_hash': 'tSk0i/6iMLf3L4ZsQYMHC2jH2kdkIKPY9/VjOFG64LzO/8dntUTduJjMnRwd5td7acArdfaBAexHNGk/7tLgqKOfgPd8PrW/XNJ5J0uRGpzNoUIiGBCVo0/fz4rH9CbEvK*WtQaTl4AhyfNAQazEUq/EeImS8CJKJDleHlIEb0I-'
							}
						]
					}
				  }";
			var audio = GetMockedGiftsCategory(url, json);
			int total;
			var gifts = audio.Get(out total, 32190123);

			Assert.That(total, Is.AtLeast(0));
			Assert.That(gifts[0].Id, Is.EqualTo(443110992));
			Assert.That(gifts[0].FromId, Is.EqualTo(221634238));
			Assert.That(gifts[0].Message, Is.EqualTo(string.Empty));
			Assert.That(gifts[0].Date, Is.EqualTo(new DateTime(2015, 05, 09, 10, 37, 05)));
			Assert.That(gifts[0].Gift.Id, Is.EqualTo(711));
			Assert.That(gifts[0].Gift.Thumb256, Is.EqualTo(@"http://vk.com/images/gift/711/256.jpg"));
			Assert.That(gifts[0].Gift.Thumb96, Is.EqualTo(@"http://vk.com/images/gift/711/96.png"));
			Assert.That(gifts[0].Gift.Thumb48, Is.EqualTo(@"http://vk.com/images/gift/711/48.png"));
			Assert.That(gifts[0].Privacy, Is.EqualTo(GiftPrivacy.All));
		}

	}
}