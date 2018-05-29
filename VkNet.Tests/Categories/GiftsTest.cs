using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Tests.Helper;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage(category: "ReSharper", checkId: "PublicMembersMustHaveComments")]
	public class GiftsTest : BaseTest
	{
		[Test]
		public void Get_NormalCase()
		{
			Url = "https://api.vk.com/method/gifts.get";

			Json =
					@"{
					response: {
						count: 6,
						items: [{
							id: 577952355,
							from_id: 103942820,
							message: 'С Днём Рождения!!! Пущай в доме твоём всегда будут уют, тепло, весёлость и вкусняшки ^.^',
							date: 1452854355,
							gift: {
								id: 658,
								thumb_256: 'https://vk.com/images/gift/658/256.jpg',
								thumb_96: 'https://vk.com/images/gift/658/96.png',
								thumb_48: 'https://vk.com/images/gift/658/48.png'
							},
							privacy: 0,
							gift_hash: 'XZuJeI8mbdkphj7QQ8I7n*Bh1bnuJQqwraxWyjYdp45ZWPhzrn6pTPlUirsRlvyPq7iwAd5/I6iWNYl8pch6jZVRjT5BnpGtN8flF00CFI58XXEJboNLTyfvO4pFL48psGgKdgRJJgi8cL7zfcGZhVMYXG/lrCHVP9GoLXdOSso-'
						}, {
							id: 443110992,
							from_id: 221634238,
							message: '',
							date: 1431167825,
							gift: {
								id: 711,
								thumb_256: 'https://vk.com/images/gift/711/256.jpg',
								thumb_96: 'https://vk.com/images/gift/711/96.png',
								thumb_48: 'https://vk.com/images/gift/711/48.png'
							},
							privacy: 0,
							gift_hash: 'iceMVGPQLpYLpbd5HdBGRrmCce5QzjGiJ8ugBtJPqrC/sqfH7MoJqwC7yjIiI*tYU8TZlPr7utHQCkAYvUgpKUT2x6/Cy2dBKjpsG/LhKIei/yhmVdoSW5GCJbdWKx3*nOBRzamrreWv6I8G/df8sfEFndOeBj4wMxmXIeXiw2k-'
						}]
					}
				  }";

			var gifts = Api.Gifts.Get(userId: 32190123);
			Assert.That(actual: gifts.TotalCount, expression: Is.AtLeast(expected: 0));

			var gift = gifts.FirstOrDefault();

			Assert.That(actual: gift, expression: Is.Not.Null);
			Assert.That(actual: gift.Id, expression: Is.EqualTo(expected: 577952355));
			Assert.That(actual: gift.FromId, expression: Is.EqualTo(expected: 103942820));

			Assert.That(actual: gift.Message
					, expression: Is.EqualTo(
							expected: "С Днём Рождения!!! Пущай в доме твоём всегда будут уют, тепло, весёлость и вкусняшки ^.^"));

			Assert.That(actual: gift.Date.Value, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1452854355)));
			Assert.That(actual: gift.Gift.Id, expression: Is.EqualTo(expected: 658));

			Assert.That(actual: gift.Gift.Thumb256
					, expression: Is.EqualTo(expected: new Uri(uriString: "https://vk.com/images/gift/658/256.jpg")));

			Assert.That(actual: gift.Gift.Thumb96
					, expression: Is.EqualTo(expected: new Uri(uriString: "https://vk.com/images/gift/658/96.png")));

			Assert.That(actual: gift.Gift.Thumb48
					, expression: Is.EqualTo(expected: new Uri(uriString: "https://vk.com/images/gift/658/48.png")));

			Assert.That(actual: gift.Privacy, expression: Is.EqualTo(expected: GiftPrivacy.All));

			Assert.That(actual: gift.GiftHash
					, expression: Is.EqualTo(expected:
							"XZuJeI8mbdkphj7QQ8I7n*Bh1bnuJQqwraxWyjYdp45ZWPhzrn6pTPlUirsRlvyPq7iwAd5/I6iWNYl8pch6jZVRjT5BnpGtN8flF00CFI58XXEJboNLTyfvO4pFL48psGgKdgRJJgi8cL7zfcGZhVMYXG/lrCHVP9GoLXdOSso-"));
		}
	}
}