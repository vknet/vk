using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.updateTargetGroup
	/// </summary>
	[Serializable]
	public class UpdateTargetGroupParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Идентификатор аудитории. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("target_group_id")]
		public long TargetGroupId { get; set; }

		/// <summary>
		/// Новое название аудитории ретаргетинга — строка до 64 символов. обязательный параметр, строка
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Домен сайта, на котором будет размещен код учета пользователей.
		/// Устаревший параметр. Используется только для старых групп ретаргетинга, которые пополнялись без помощи пикселя. Для новых аудиторий его следует опускать, иначе будет возвращена ошибка. строка
		/// </summary>
		[JsonProperty("domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Только для рекламных агентств.
		/// id клиента, в рекламном кабинете которого будет редактироваться аудитория. целое число
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Только для аудиторий, которые пополняются с помощью пикселя.
		/// количество дней, через которое пользователи, добавляемые в аудиторию, будут автоматически исключены из нее.
		/// 0 — автоудаление пользователей отсутствует. положительное число, максимальное значение 365
		/// </summary>
		[JsonProperty("lifetime")]
		public ulong Lifetime { get; set; }

		/// <summary>
		/// Передайте в этом параметре идентификатор пикселя, если требуется собирать аудиторию с веб-сайта. целое число
		/// </summary>
		[JsonProperty("target_pixel_id")]
		public long? TargetPixelId { get; set; }

		/// <summary>
		/// Закодированный в JSON массив правил, в соответствии с которыми будет пополняться аудитория из пикселя. Подробнее см. документацию метода ads.createTargetGroup. данные в формате JSON
		/// </summary>
		[JsonProperty("target_pixel_rules")]
		public IDictionary<string, string> TargetPixelRules { get; set; }
	}
}