using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Событие о изменении настроек сообщества
	/// </summary>
	[Serializable]
	public class GroupChangeSettings
	{
		/// <summary>
		/// Идентификатор пользователя, который внёс изменения;
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Тип материала.
		/// </summary>
		[JsonProperty("changes")]
		public string Changes { get; set; }


		#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static GroupChangeSettings FromJson(VkResponse response)
		{
			return new GroupChangeSettings
			{
				UserId = response["user_id"],
				Changes = response["changes"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="GroupChangeSettings" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="GroupChangeSettings" /></returns>
		public static implicit operator GroupChangeSettings(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

		#endregion
	}
}