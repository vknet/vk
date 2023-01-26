using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils.JsonConverter;

/// <summary>
/// StringId JsonConverter
/// </summary>
/// <seealso cref="Newtonsoft.Json.JsonConverter" />
public class StringIdJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (!objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		var id = default(long?);
		var linkId = (string) response["id"];

		if (long.TryParse(linkId, out var temporaryId))
		{
			id = temporaryId;
		}

		return id;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
}