using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода Get для приложений
	/// </summary>
	[Serializable]
	public class AppGetParams
	{
		/// <summary>
		/// Список идентификаторов приложений, данные которых необходимо получить.
		/// </summary>
		[JsonProperty(propertyName: "app_ids")]
		public IEnumerable<ulong> AppIds { get; set; }

		/// <summary>
		/// Платформа, для которой необходимо вернуть platform_id, принимает значения: ios,
		/// android, winphone, web.
		/// </summary>
		[JsonProperty(propertyName: "platform")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public AppPlatforms Platform { get; set; }

		/// <summary>
		/// Позволяет получить дополнительные поля: screenshots. По умолчанию возвращает
		/// только основные поля приложений.
		/// </summary>
		[JsonProperty(propertyName: "extended")]
		public bool Extended { get; set; }

		/// <summary>
		/// <c> true </c> – возвращает список друзей, установивших приложение. (Данный
		/// параметр работает только, если
		/// пользователь передал валидный access_token) <c> false </c> – не возвращать
		/// список друзей, по умолчанию.
		/// </summary>
		[JsonProperty(propertyName: "return_friends")]
		public bool ReturnFriends { get; set; }

		/// <summary>
		/// (Работает при использовании return_friends) список дополнительных полей,
		/// которые необходимо вернуть для профилей
		/// пользователей.
		/// </summary>
		[JsonProperty(propertyName: "fields")]
		public UsersFields Fields { get; set; }

		/// <summary>
		/// (Работает при использовании return_friends) падеж для склонения имени и фамилии
		/// пользователей. Возможные значения:
		/// именительный – nom, родительный – gen, дательный – dat, винительный – acc,
		/// творительный – ins, предложный – abl. По
		/// умолчанию nom.
		/// </summary>
		[JsonProperty(propertyName: "name_case")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NameCase NameCase { get; set; }
	}
}