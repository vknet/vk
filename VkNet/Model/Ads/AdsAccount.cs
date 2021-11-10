using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Описание рекламного аккаунта.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getAccounts
	/// </remarks>
	[Serializable]
	public class AdsAccount
	{
		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty(propertyName: "account_id")]
		public ulong AccountId { get; set; }

		/// <summary>
		/// Тип рекламного кабинета.
		/// </summary>
		[JsonProperty(propertyName: "account_type")]
		[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
		public AccountType AccountType { get; set; }

		/// <summary>
		/// Cтатус рекламного кабинета.
		/// </summary>
		[JsonProperty(propertyName: "account_status")]
		public AccountStatus AccountStatus { get; set; }

		/// <summary>
		/// Название аккаунта
		/// </summary>
		[JsonProperty(propertyName: "account_name")]
		public string AccountName { get; set; }

		/// <summary>
		/// Права пользователя в рекламном кабинете.
		/// </summary>
		[JsonProperty(propertyName: "access_role")]
		[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
		public AccessRole AccessRole { get; set; }

	#region Методы

		/// <summary>
		/// Информация о рекламном аккаунте
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static AdsAccount FromJson(VkResponse response)
		{
			if (response[key: "account_id"] == null)
			{
				return null;
			}

			var adsAccount = new AdsAccount
			{
					AccountId = response[key: "account_id"]
					, AccountType = response[key: "account_type"]
					, AccountStatus = response[key: "account_status"]
					, AccountName = response[key: "account_name"]
					, AccessRole = response[key: "access_role"]
			};

			return adsAccount;
		}

	#endregion
	}
}