using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <inheritdoc />
/// <summary>
/// Типы стандартных вопросов
/// </summary>
[Serializable]
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public class StandardQuestion : SafetyEnum<StandardQuestion>
{
	/// <summary>
	/// Имя
	/// </summary>
	[EnumMember(Value = "first_name")]
	public static readonly StandardQuestion FirstName = RegisterPossibleValue("first_name");

	/// <summary>
	/// Отчество
	/// </summary>
	[EnumMember(Value = "patronymic_name")]
	public static readonly StandardQuestion PatronymicName = RegisterPossibleValue("patronymic_name");

	/// <summary>
	/// Фамилия
	/// </summary>
	[EnumMember(Value = "last_name")]
	public static readonly StandardQuestion LastName = RegisterPossibleValue("last_name");

	/// <summary>
	/// Адрес электронной почты
	/// </summary>
	[EnumMember(Value = "email")]
	public static readonly StandardQuestion Email = RegisterPossibleValue("email");

	/// <summary>
	/// Номер телефона
	/// </summary>
	[EnumMember(Value = "phone_number")]
	public static readonly StandardQuestion PhoneNumber = RegisterPossibleValue("phone_number");

	/// <summary>
	/// Возраст
	/// </summary>
	[EnumMember(Value = "age")]
	public static readonly StandardQuestion Age = RegisterPossibleValue("age");

	/// <summary>
	/// День рождения
	/// </summary>
	[EnumMember(Value = "birthday")]
	public static readonly StandardQuestion Birthday = RegisterPossibleValue("birthday");

	/// <summary>
	/// Город и страна
	/// </summary>
	[EnumMember(Value = "location")]
	public static readonly StandardQuestion Location = RegisterPossibleValue("location");
}