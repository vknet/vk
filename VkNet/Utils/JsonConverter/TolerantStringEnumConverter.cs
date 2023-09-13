using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Infrastructure;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class TolerantStringEnumConverter : StringEnumConverter
{
	/// <inheritdoc />
	public TolerantStringEnumConverter()
	{
		NamingStrategy = new SnakeCaseNamingStrategy();
	}

	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		try
		{
			return base.ReadJson(reader, objectType, existingValue, serializer);
		}
		catch(System.Exception e)
		{
			var parameter = serializer.Context.TryGetTypeData(typeof(TolerantStringEnumConverter), out var s) ? (bool?)s : null;

			if (IsNullableType(objectType) && parameter is true)
			{
				//_logger.LogError($"\nПОЖАЛУЙСТА ОТКРОЙТЕ ISSUE: {$"https://github.com/vknet/vk/issues/new?title=Add%20new%20value%20to%20{objectType.GenericTypeArguments.FirstOrDefault()}&body={reader.Value}"}\n" + e.Message);
				return null;
			}

			throw;
		}
	}

	private static bool IsNullableType(Type t)
	{
		return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
	}
}