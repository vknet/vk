using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Типы стандартных вопросов
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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