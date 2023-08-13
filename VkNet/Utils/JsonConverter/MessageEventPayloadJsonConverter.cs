using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class MessageEventPayloadJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var obj = JObject.Load(reader);
		var responseJToken = obj["payload"] ?? obj;
		var response = new VkResponse(responseJToken);

		var a = Regex.Replace(response.ToString(),  "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");

		return a;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => true;
}