using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class GiftsTest : BaseTest
	{
		[Test]
		public void Get_NormalCase()
		{
			Url = "https://api.vk.com/method/gifts.get?user_id=32190123&v=" + VkApi.VkApiVersion + "&access_token=token";
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
			int total;
			var gifts = Api.Gifts.Get(out total, 32190123);
			Assert.That(total, Is.AtLeast(0));

			var gift = gifts.FirstOrDefault();

			Assert.That(gift, Is.Not.Null);
			Assert.That(gift.Id, Is.EqualTo(577952355));
			Assert.That(gift.FromId, Is.EqualTo(103942820));
			Assert.That(gift.Message, Is.EqualTo("С Днём Рождения!!! Пущай в доме твоём всегда будут уют, тепло, весёлость и вкусняшки ^.^"));
			Assert.That(gift.Date.Value, Is.EqualTo(DateHelper.TimeStampToDateTime(1452854355)));
			Assert.That(gift.Gift.Id, Is.EqualTo(658));
			Assert.That(gift.Gift.Thumb256, Is.EqualTo(new Uri("https://vk.com/images/gift/658/256.jpg")));
			Assert.That(gift.Gift.Thumb96, Is.EqualTo(new Uri("https://vk.com/images/gift/658/96.png")));
			Assert.That(gift.Gift.Thumb48, Is.EqualTo(new Uri("https://vk.com/images/gift/658/48.png")));
			Assert.That(gift.Privacy, Is.EqualTo(GiftPrivacy.All));
			Assert.That(gift.GiftHash, Is.EqualTo("XZuJeI8mbdkphj7QQ8I7n*Bh1bnuJQqwraxWyjYdp45ZWPhzrn6pTPlUirsRlvyPq7iwAd5/I6iWNYl8pch6jZVRjT5BnpGtN8flF00CFI58XXEJboNLTyfvO4pFL48psGgKdgRJJgi8cL7zfcGZhVMYXG/lrCHVP9GoLXdOSso-"));
		}
	}
}