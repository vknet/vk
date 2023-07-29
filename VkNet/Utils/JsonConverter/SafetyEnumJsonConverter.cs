using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace VkNet.Utils.JsonConverter;

/// <summary>
/// TODO: Description
/// </summary>
public class SafetyEnumJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <summary>
	/// Сериализация объекта в JSON
	/// </summary>
	/// <param name="writer"> Json writer </param>
	/// <param name="value"> Значение </param>
	/// <param name="serializer"> Сериализатор </param>
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => writer.WriteValue(value.ToString());

	/// <summary>
	/// Десериализация объекта из JSON
	/// </summary>
	/// <param name="reader"> Json reader </param>
	/// <param name="objectType"> CLR тип десериализуемого объекта </param>
	/// <param name="existingValue"> Значение </param>
	/// <param name="serializer"> Сериализатор </param>
	/// <returns>
	/// SafetyEnum
	/// </returns>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (reader.TokenType is JsonToken.Null)
		{
			return null;
		}

		var value = reader.Value;

		if (value is null)
		{
			if (reader.TokenType is JsonToken.StartObject)
			{
				reader.Read();
			}

			if (reader.TokenType is JsonToken.PropertyName)
			{
				reader.Read();
			}

			value = reader.Value;

			var hasRead = true;

			while (hasRead)
			{
				hasRead = reader.Read();
			}
		}

		var result = Activator.CreateInstance(type: objectType);

		var methods = result.GetType()
			.GetMethods(bindingAttr: BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Static|BindingFlags.FlattenHierarchy);

		result = methods
			.FirstOrDefault(predicate: x => x.Name == "FromJsonString")
			?.Invoke(result, new object[]
			{
				$"{value}"
			});

		var fields = result?.GetType()
			.GetFields();

		if (fields is null)
		{
			return null;
		}

		foreach (var field in fields)
		{
			field.GetValue(null);
		}

		return result;
	}

	//TODO: написать проверку типов
	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => true;
}