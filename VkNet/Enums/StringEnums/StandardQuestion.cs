using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <inheritdoc />
/// <summary>
/// Типы стандартных вопросов
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum StandardQuestion
{
	/// <summary>
	/// Имя
	/// </summary>
	FirstName,

	/// <summary>
	/// Отчество
	/// </summary>
	PatronymicName,

	/// <summary>
	/// Фамилия
	/// </summary>
	LastName,

	/// <summary>
	/// Адрес электронной почты
	/// </summary>
	Email,

	/// <summary>
	/// Номер телефона
	/// </summary>
	PhoneNumber,

	/// <summary>
	/// Возраст
	/// </summary>
	Age,

	/// <summary>
	/// День рождения
	/// </summary>
	Birthday,

	/// <summary>
	/// Город и страна
	/// </summary>
	Location
}