using Newtonsoft.Json;
using System;
using System.Globalization;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.GroupUpdate;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class UpdateTypeConverter : JsonConverter<UpdateType>
{
	/// <inheritdoc />
	public override UpdateType ReadJson(JsonReader reader, Type objectType, UpdateType existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		if (reader.Value == null)
			return null;

		var info = CultureInfo.CurrentCulture.TextInfo;

		var groupUpdateTypeStr = reader.Value.ToString().ToLower().Replace("_", " ");
		groupUpdateTypeStr = info.ToTitleCase(groupUpdateTypeStr).Replace(" ", string.Empty);

		return new UpdateType(Utilities.Deserialize<GroupUpdateType>(groupUpdateTypeStr).Value);
	}

	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, UpdateType value, JsonSerializer serializer)
	{
		writer.WriteValue(value?.Value);
	}
}