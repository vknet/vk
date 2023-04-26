using Newtonsoft.Json;
using System;
using VkNet.Model.GroupUpdate;

namespace VkNet.Utils.JsonConverter
{
	/// <inheritdoc />
	public class GroupIdConverter : JsonConverter<GroupId>
	{
		/// <inheritdoc />
		public override GroupId ReadJson(JsonReader reader, Type objectType, GroupId existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			if (reader.Value == null)
				return null;

			var id = Convert.ToUInt64(reader.Value);
			return new GroupId(id);
		}

		/// <inheritdoc />
		public override void WriteJson(JsonWriter writer, GroupId value, JsonSerializer serializer)
		{
			writer.WriteValue(value?.Value);
		}
	}
}
