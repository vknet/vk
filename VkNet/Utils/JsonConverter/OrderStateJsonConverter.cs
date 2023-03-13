using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <summary>
///
/// </summary>
public class OrderStateJsonConverter : StringEnumConverter
{
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		return Utilities.Deserialize<OrderState>(response);
	}
}