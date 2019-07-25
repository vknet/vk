using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Tests.Utils.JsonConverter
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class VkCollectionJsonConverterTests : BaseTest
	{
		[Test]
		public void Deserialize()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(VkCollectionJsonConverter), "VkCollectionOfMessages");

			var result = JsonConvert.DeserializeObject<VkCollection<Message>>(Json);

			var message = result.FirstOrDefault();

			Assert.NotNull(result);
			Assert.NotNull(message);
			Assert.AreEqual(1, message.Id);
			Assert.AreEqual(2, message.OwnerId);
		}

		[Test]
		public void Deserialize_Throws_InvalidOperationException()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(VkCollectionJsonConverter), "VkCollectionWithoutArrayField");

			Assert.Throws<InvalidOperationException>(() => JsonConvert.DeserializeObject<VkCollection<Message>>(Json));
		}

		[Test]
		public void Serialize()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(VkCollectionJsonConverter), "VkCollectionOfMessages");

			var vkCollection = new VkCollection<Message>(1,
				new[]
				{
					new Message()
					{
						Id = 1,
						OwnerId = 2
					}
				});

			var json = JsonConvert.SerializeObject(vkCollection,
				new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Ignore,
					Formatting = Formatting.Indented
				});

			Assert.AreEqual(json, Json);
		}
	}
}