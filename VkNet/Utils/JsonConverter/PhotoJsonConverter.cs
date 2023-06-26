using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class PhotoJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		var previews = new Previews
		{
			Photo50 = response[key: "photo_50"],
			Photo100 = response[key: "photo_100"] ?? response[key: "photo_medium"],
			Photo130 = response[key: "photo_130"],
			Photo200 = response[key: "photo_200"] ?? response[key: "photo_200_orig"],
			Photo400 = response[key: "photo_400_orig"]
		};

		if (response.ContainsKey(key: "photo"))
		{
			if (Uri.IsWellFormedUriString(response[key: "photo"]
					.ToString(), UriKind.Absolute))
			{
				previews.Photo50 = response[key: "photo"];
			} else
			{
				previews.Photo = JsonConvert.DeserializeObject<Photo>(response[key: "photo"]);
			}
		}

		previews.PhotoMax = response[key: "photo_max"]
							?? response[key: "photo_max_orig"]
							?? response[key: "photo_big"]
							?? previews.Photo400 ?? previews.Photo200 ?? previews.Photo100 ?? previews.Photo50;

		return previews;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}