using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
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
		public static readonly StandardQuestion FirstName = RegisterPossibleValue("first_name");

		/// <summary>
		/// Отчество
		/// </summary>
		public static readonly StandardQuestion PatronymicName = RegisterPossibleValue("patronymic_name");

		/// <summary>
		/// Фамилия
		/// </summary>
		public static readonly StandardQuestion LastName = RegisterPossibleValue("last_name");

		/// <summary>
		/// Адрес электронной почты
		/// </summary>
		public static readonly StandardQuestion Email = RegisterPossibleValue("email");

		/// <summary>
		/// Номер телефона
		/// </summary>
		public static readonly StandardQuestion PhoneNumber = RegisterPossibleValue("phone_number");

		/// <summary>
		/// Возраст
		/// </summary>
		public static readonly StandardQuestion Age = RegisterPossibleValue("age");

		/// <summary>
		/// День рождения
		/// </summary>
		public static readonly StandardQuestion Birthday = RegisterPossibleValue("birthday");

		/// <summary>
		/// Город и страна
		/// </summary>
		public static readonly StandardQuestion Location = RegisterPossibleValue("location");
	}
}