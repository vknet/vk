using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.Leads
{
	/// <summary>
	/// Доступна ли рекламная акция пользователю.
	/// </summary>
	[Serializable]
	public class CheckUserParams
	{
		/// <summary>
		/// Идентификатор рекламной акции
		/// </summary>
		[JsonProperty(propertyName: "lead_id")]
		public ulong LeadId { get; set; }

		/// <summary>
		/// Двухбуквенный код страны пользователя (ISO 3166-1 alpha-2, также известный как
		/// ISO2).
		/// </summary>
		[JsonProperty(propertyName: "country")]
		public Iso3166 Country { get; set; }

		/// <summary>
		/// При использовании тестового режима функция вернёт result, соответствующий
		/// значению этого параметра.
		/// </summary>
		[JsonProperty(propertyName: "test_result")]
		public ulong TestResult { get; set; }

		/// <summary>
		/// 1 -- включить тестовый режим;
		/// 0 -- включить боевой режим.
		/// </summary>
		[JsonProperty(propertyName: "test_mode")]
		public bool TestMode { get; set; }

		/// <summary>
		/// Автоматический старт акции при успешной проверке. Доступно по согласованию с
		/// администрацией.
		/// </summary>
		[JsonProperty(propertyName: "auto_start")]
		public bool AutoStart { get; set; }

		/// <summary>
		/// Возраст пользователя.
		/// </summary>
		[JsonProperty(propertyName: "age")]
		public ulong Age { get; set; }
	}
}