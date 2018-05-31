using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

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

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(AppSendRequestParams p)
		{
			var parameters = new VkParameters
			{
					{ "user_id", p.UserId }
					, { "text", p.Text }
					, { "type", p.Type }
					, { "name", p.Name }
					, { "key", p.Key }
					, { "separate", p.Separate }
			};

			return parameters;
		}
	}
}