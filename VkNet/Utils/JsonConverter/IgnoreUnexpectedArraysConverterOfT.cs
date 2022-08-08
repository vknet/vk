using System;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class IgnoreUnexpectedArraysConverter<T> : IgnoreUnexpectedArraysConverterBase
{
	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => typeof(T).IsAssignableFrom(objectType);
}