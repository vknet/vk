using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса SendRequest для приложений.
	/// </summary>
	[Serializable]
	public class AppSendRequestParams
	{
		/// <summary>
		/// Идентификатор пользователя, которому следует отправить запрос.
		/// </summary>
		[JsonProperty(propertyName: "user_id")]
		public ulong UserId { get; set; }

		/// <summary>
		/// Текст запроса.
		/// </summary>
		[JsonProperty(propertyName: "text")]
		public string Text { get; set; }

		/// <summary>
		/// Тип запроса, может принимать значения:.
		/// </summary>
		[JsonProperty(propertyName: "type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AppRequestType Type { get; set; }

		/// <summary>
		/// Уникальное в рамках приложения имя для каждого вида отправляемого запроса.
		/// </summary>
		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }

		/// <summary>
		/// Строка, которая будет возвращена назад при переходе пользователя по запросу в
		/// приложение. Может использоваться для
		/// подсчета конверсии.
		/// </summary>
		[JsonProperty(propertyName: "key")]
		public string Key { get; set; }

		/// <summary>
		/// Запрет на группировку запроса с другими, имеющими тот же name. По умолчанию
		/// отключен.
		/// </summary>
		[JsonProperty(propertyName: "separate")]
		public bool Separate { get; set; }
	}
}