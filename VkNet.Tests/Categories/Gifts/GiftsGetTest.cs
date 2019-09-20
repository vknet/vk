using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Gifts
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GiftsGetTest : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Gifts";

		[Test]
		public void Get_NormalCase()
		{
			Url = "https://api.vk.com/method/gifts.get";
			ReadCategoryJsonPath(nameof(Get_NormalCase));

			var gifts = Api.Gifts.Get(32190123);

			Assert.That(gifts.TotalCount, Is.AtLeast(0));

			var gift = gifts.FirstOrDefault();

			Assert.That(gift, Is.Not.Null);
			Assert.That(gift.Id, Is.EqualTo(-577952355));
			Assert.That(gift.FromId, Is.EqualTo(103942820));

			Assert.That(gift.Message,
						Is.EqualTo("С Днём Рождения!!! Пущай в доме твоём всегда будут уют, тепло, весёлость и вкусняшки ^.^"));

			Assert.That(gift.Date.Value, Is.EqualTo(DateHelper.TimeStampToDateTime(1452854355)));
			Assert.That(gift.Gift.Id, Is.EqualTo(658));

			Assert.That(gift.Gift.Thumb256, Is.EqualTo(new Uri("https://vk.com/images/gift/658/256.jpg")));

			Assert.That(gift.Gift.Thumb96, Is.EqualTo(new Uri("https://vk.com/images/gift/658/96.png")));

			Assert.That(gift.Gift.Thumb48, Is.EqualTo(new Uri("https://vk.com/images/gift/658/48.png")));

			Assert.That(gift.Privacy, Is.EqualTo(GiftPrivacy.All));

			Assert.That(gift.GiftHash,
						Is.EqualTo(
								   "XZuJeI8mbdkphj7QQ8I7n*Bh1bnuJQqwraxWyjYdp45ZWPhzrn6pTPlUirsRlvyPq7iwAd5/I6iWNYl8pch6jZVRjT5BnpGtN8flF00CFI58XXEJboNLTyfvO4pFL48psGgKdgRJJgi8cL7zfcGZhVMYXG/lrCHVP9GoLXdOSso-"));
		}
	}
}