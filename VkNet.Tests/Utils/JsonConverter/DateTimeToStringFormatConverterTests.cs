using System;
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
			Json = @"
            {
                'response':
                {
                    'date': '05112018'
                }
            }";

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<MessagesSearchParams>("friends.getRequests", VkParameters.Empty);
			Assert.NotNull(result);
			Assert.That(result.Date, Is.EqualTo(new DateTime(2018, 11, 5)));
		}

		[Test]
		public void Serialization()
		{
			ReadJsonFile("JsonConverter", nameof(DateTimeToStringFormatConverter));

			var message = new MessagesSearchParams
			{
				Date = new DateTime(2018, 11, 5)
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
			Assert.That(json, Is.EqualTo(Json));
		}
	}
}