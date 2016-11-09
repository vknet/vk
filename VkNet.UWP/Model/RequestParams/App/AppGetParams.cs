using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода Get для приложений
	/// </summary>
	public struct AppGetParams
	{
		/// <summary>
		/// Список идентификаторов приложений, данные которых необходимо получить.
		/// </summary>
		public IEnumerable<ulong> AppIds
		{ get; set; }

		/// <summary>
		/// Платформа, для которой необходимо вернуть platform_id, принимает значения: ios, android, winphone, web.
		/// </summary>
		public AppPlatforms Platform
		{ get; set; }

		/// <summary>
		/// Позволяет получить дополнительные поля: screenshots. По умолчанию возвращает только основные поля приложений.
		/// </summary>
		public bool Extended
		{ get; set; }

		/// <summary>
		/// <c>true</c> – возвращает список друзей, установивших приложение. (Данный параметр работает только, если пользователь передал валидный access_token) <c>false</c> – не возвращать список друзей, по умолчанию.
		/// </summary>
		public bool ReturnFriends
		{ get; set; }

		/// <summary>
		/// (Работает при использовании return_friends) список дополнительных полей, которые необходимо вернуть для профилей пользователей.
		/// </summary>
		public UsersFields Fields
		{ get; set; }

		/// <summary>
		/// (Работает при использовании return_friends) падеж для склонения имени и фамилии пользователей. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom.
		/// </summary>
		public NameCase NameCase
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		public static VkParameters ToVkParameters(AppGetParams p)
		{
			var parameters = new VkParameters
			{
				{ "app_ids", p.AppIds },
				{ "platform", p.Platform },
				{ "extended", p.Extended },
				{ "return_friends", p.ReturnFriends },
				{ "fields", p.Fields },
				{ "name_case", p.NameCase }
			};

			return parameters;
		}
	}
}
