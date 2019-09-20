using System;
using System.Globalization;
using Newtonsoft.Json;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Tests.Utils.JsonConverter
{
	public class DateTimeToStringFormatConverterTests : BaseTest
	{
		[Test]
		public void Deserialize()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(DateTimeToStringFormatConverter), nameof(Deserialize));
			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<MessagesSearchParams>("friends.getRequests", VkParameters.Empty);
			Assert.NotNull(result);
			Assert.That(result.Date, Is.EqualTo(new DateTime(2018, 11, 5)));
		}

		[Test]
		public void Serialization()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(DateTimeToStringFormatConverter), nameof(Serialization));

			var message = new MessagesSearchParams
			{
				Date = new DateTime(2018, 11, 5),
				Count = 20
			};

			var json = JsonConvert.SerializeObject(message,
				new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Ignore,
					Formatting = Formatting.Indented
				});

			var result = JsonConvert.DeserializeObject<MessagesSearchParams>(json);

			Assert.NotNull(result);
			var compare = string.Compare(json, Json, CultureInfo.InvariantCulture, CompareOptions.IgnoreSymbols);
			Assert.IsTrue(compare == 0);
		}
	}
}