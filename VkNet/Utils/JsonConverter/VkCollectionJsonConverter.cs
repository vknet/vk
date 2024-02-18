using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VkNet.Utils.JsonConverter;

/// <summary>
/// Vk Collection Json Converter
/// </summary>
public class VkCollectionJsonConverter : Newtonsoft.Json.JsonConverter
{
	private const string ResponsePropertyKey = "response";

	/// <summary>
	/// Инициализация
	/// </summary>
	/// <param name="collectionField"> Collection Field </param>
	public VkCollectionJsonConverter(string collectionField) => CollectionField = string.IsNullOrWhiteSpace(collectionField)
		? "items"
		: collectionField;

	/// <inheritdoc />
	public VkCollectionJsonConverter() : this("items")
	{
	}

	/// <summary>
	/// Количество
	/// </summary>
	private static string CountPropertyKey => "count";

	/// <summary>
	/// Поле с коллекцией данных
	/// </summary>
	private string CollectionField { get; }

	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var vkCollectionType = value.GetType();

		var vkCollectionGenericArgument = vkCollectionType.GetGenericArguments()[0];
		var toListMethod = typeof(Enumerable).GetMethod("ToList");

		if (toListMethod is null)
		{
			return;
		}

		var constructedToListGenericMethod = toListMethod.MakeGenericMethod(vkCollectionGenericArgument);

		var castToListObject = constructedToListGenericMethod.Invoke(null, new[]
		{
			value
		});

		var vkCollectionSurrogate = new
		{
			TotalCount = vkCollectionType.GetProperty("TotalCount")
				?.GetValue(value, null),
			Items = castToListObject
		};

		serializer.Serialize(writer, vkCollectionSurrogate);
	}

	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (!objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		if (reader.TokenType is JsonToken.Null)
		{
			return null;
		}

		var keyType = objectType.GetGenericArguments()[0];

		var constructedListType = typeof(List<>).MakeGenericType(keyType);

		var list = (IList) Activator.CreateInstance(constructedListType);

		var vkCollection = typeof(VkCollection<>).MakeGenericType(keyType);

		var obj = JObject.Load(reader);
		var response = obj[ResponsePropertyKey] ?? obj;

		var totalCount = response[CountPropertyKey]
			.Value<ulong>();

		var converter =
			serializer.Converters.FirstOrDefault(x => x.GetType() == typeof(VkCollectionJsonConverter)) as
				VkCollectionJsonConverter;

		var collectionField = CollectionField;

		if (converter is not null)
		{
			collectionField = converter.CollectionField;
		}

		foreach (var item in response[collectionField])
		{
			list.Add(item.ToObject(keyType));
		}

		return Activator.CreateInstance(vkCollection, totalCount, list);
	}

	/// <summary>
	/// Может преобразовать
	/// </summary>
	/// <param name="objectType"> Тип объекта </param>
	/// <returns> <c> true </c> если можно преобразовать </returns>
	public override bool CanConvert(Type objectType) => typeof(VkCollection<>).IsAssignableFrom(objectType);
}