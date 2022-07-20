using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Текущее значение
	/// </summary>
	[Serializable]
	public class PrivacySettingsValue
	{
		/// <summary>
		/// Категория
		/// </summary>
		[JsonProperty("category")]
		public string Category { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PrivacySettingsValue FromJson(VkResponse response)
		{
			return new PrivacySettingsValue
			{
				Category = response["category"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="PrivacySettingsValue" /> в
		/// <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="PrivacySettingsValue" /> </returns>
		public static implicit operator PrivacySettingsValue(VkResponse response)
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