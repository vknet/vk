using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Infrastructure;

/// <inheritdoc cref="DefaultContractResolver" />
public class ConverterReplacingContractResolver : DefaultContractResolver
{
	private readonly Dictionary<(Type type, string name), JsonConverter?> _replacements;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="ConverterReplacingContractResolver" />
	/// </summary>
	public ConverterReplacingContractResolver(IEnumerable<KeyValuePair<(Type type, string name), JsonConverter?>> replacements)
	{
		if (replacements is null)
		{
			throw new ArgumentNullException();
		}

		_replacements = replacements.ToDictionary(r => r.Key, r => r.Value);
	}

	/// <inheritdoc />
	protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
	{
		var property = base.CreateProperty(member, memberSerialization);

		if (!Utilities.IsNullableStringEnum(property.PropertyType))
		{
			return property;
		}

		if (!Utilities.IsTolerantEnum(property.PropertyType))
		{
			return property;
		}

		if (member.DeclaringType is not null && _replacements.TryGetValue((typeof(bool), "DeserializationErrorHandler"), out var converter))
		{
			property.Converter = converter;
		}

		return property;
	}
}