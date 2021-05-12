using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Настройки приватности
	/// </summary>
	[Serializable]
	public class Privacy
	{
		/// <summary>
		/// Категории уровней доступа
		/// </summary>
		[JsonProperty("category")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PrivacyCategory Category { get; set; }

		/// <summary>
		/// Владельцы настроек приватности
		/// </summary>
		[JsonProperty("owners")]
		public PrivacyOwners Owners { get; set; }

		/// <summary>
		/// Настроек приватности для списков друзей
		/// </summary>
		[JsonProperty("lists")]
		public PrivacyOwners Lists { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">
		/// Ответ сервера.
		/// </param>
		/// <returns></returns>
		public static Privacy FromJson(VkResponse response)
		{
			return new Privacy
			{
				Category = response["category"],
				Owners = response["owners"],
				Lists = response["lists"]
			};
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			var _category = Category?.ToString();
			var category = string.IsNullOrEmpty(_category) ? Enumerable.Empty<string>() : new[] { _category };
			var allowedLists = Lists?.Allowed?.Select(x => "list" + x) ?? Enumerable.Empty<string>();
			var excludedLists = Lists?.Excluded?.Select(x => "-list" + x) ?? Enumerable.Empty<string>();
			var allowedOwners = Owners?.Allowed?.Select(x => x.ToString()) ?? Enumerable.Empty<string>();
			var excludedOwners = Owners?.Excluded?.Select(x => "-" + x) ?? Enumerable.Empty<string>();

			var privacyList = category.Concat(allowedLists).Concat(allowedOwners).Concat(excludedLists).Concat(excludedOwners);

			return string.Join(",", privacyList);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Privacy(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}