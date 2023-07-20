using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using VkNet.Enums.StringEnums;

namespace VkNet.Utils.JsonConverter;

/// <summary>
/// Converter OrderState Enum
/// </summary>
public class OrderStateJsonConverter : StringEnumConverter
{
	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		return Utilities.Deserialize<OrderState>(response);
	}
}