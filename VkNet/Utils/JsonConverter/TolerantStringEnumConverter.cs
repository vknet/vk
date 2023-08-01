﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class TolerantStringEnumConverter : StringEnumConverter
{
	private readonly bool? _parameter;

	/// <inheritdoc />
	public TolerantStringEnumConverter() : this(null) { }

	/// <inheritdoc />
	public TolerantStringEnumConverter(bool? parameter) => _parameter = parameter;

	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		try
		{
			NamingStrategy = new SnakeCaseNamingStrategy();
			return base.ReadJson(reader, objectType, existingValue, serializer);
		}
		catch(System.Exception e)
		{
			if (IsNullableType(objectType) && _parameter is true)
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