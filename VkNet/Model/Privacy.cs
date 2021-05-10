using System;
using System.Collections.ObjectModel;
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
				Owners = response["owners"]
			};
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			var owners = Owners?.ToString();
			if (string.IsNullOrEmpty(owners))
			{
				return Category.ToString();
			}
			return Category.ToString() + "," + owners;
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