using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Массив объектов UserSpecification
	/// </summary>
	[Serializable]
	public class UserSpecification
	{
		/// <summary>
		/// Идентификатор пользователя, добавляемого как администратор/наблюдатель.
		/// </summary>
		[JsonProperty(propertyName: "user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// Флаг, описывающий тип полномочий
		/// </summary>
		[JsonProperty(propertyName: "role")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AccessRole Role { get; set; }

		/// <summary>
		/// Идентификатор клиента
		/// </summary>
		[JsonProperty(propertyName: "client_id")]
		public long ClientId{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static UserSpecification FromJson(VkResponse response)
		{
			return new UserSpecification
			{
				UserId = response[key: "user_id"]
				, Role = response[key: "role"]
				, ClientId = response["client_id"]
			};
		}
	}
}