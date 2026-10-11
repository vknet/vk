using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class TolerantStringEnumConverter : StringEnumConverter
{
	private readonly bool? _ignoreUnknownValues;

	/// <inheritdoc />
	public TolerantStringEnumConverter() => NamingStrategy = new SnakeCaseNamingStrategy();

	/// <summary>
	/// Создает конвертер с указанным поведением для неизвестных значений enum.
	/// </summary>
	/// <param name="ignoreUnknownValues">
	/// Следует ли заменить неизвестное значение nullable enum на <see langword="null"/>.
	/// </param>
	public TolerantStringEnumConverter(bool? ignoreUnknownValues) : this() => _ignoreUnknownValues = ignoreUnknownValues;

	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		try
		{
			return base.ReadJson(reader, objectType, existingValue, serializer);
		}
		catch (System.Exception)
		{
			if (IsNullableType(objectType) && _ignoreUnknownValues is true)
			{
				// Неизвестное значение может означать, что VK API добавил новый элемент enum.
				// Создайте Issue: https://github.com/vknet/vk/issues/new, чтобы добавить его в соответствующий enum библиотеки.
				return null;
			}

			throw;
		}
	}

	private static bool IsNullableType(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
}

/// <summary>
/// Настраивает конвертеры enum, заданные через <see cref="JsonConverterAttribute"/>.
/// </summary>
internal sealed class TolerantStringEnumContractResolver(bool? ignoreUnknownValues) : DefaultContractResolver
{
	protected override JsonContract CreateContract(Type objectType)
	{
		var contract = base.CreateContract(objectType);
		contract.Converter = ReplaceTolerantConverter(contract.Converter);

		return contract;
	}

	protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
	{
		var property = base.CreateProperty(member, memberSerialization);
		property.Converter = ReplaceTolerantConverter(property.Converter);

		return property;
	}

	private Newtonsoft.Json.JsonConverter ReplaceTolerantConverter(Newtonsoft.Json.JsonConverter converter) => converter is TolerantStringEnumConverter
		? new TolerantStringEnumConverter(ignoreUnknownValues)
		: converter;
}
