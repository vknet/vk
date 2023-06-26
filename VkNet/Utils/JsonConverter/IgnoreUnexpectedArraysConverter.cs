using System;
using JetBrains.Annotations;
using Newtonsoft.Json.Serialization;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
[UsedImplicitly]
public class IgnoreUnexpectedArraysConverter : IgnoreUnexpectedArraysConverterBase
{
	private readonly IContractResolver _resolver;

	/// <inheritdoc />
	public IgnoreUnexpectedArraysConverter(IContractResolver resolver) =>
		_resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));

	/// <inheritdoc />
	public override bool CanConvert(Type objectType)
	{
		if (objectType.IsPrimitive || objectType == typeof(string))
		{
			return false;
		}

		return _resolver.ResolveContract(objectType) is JsonObjectContract;
	}
}