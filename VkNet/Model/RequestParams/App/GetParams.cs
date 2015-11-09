using System.Collections.Generic;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.App
{
	/// <summary>
	/// Параметры метода Get для приложений
	/// </summary>
	public class GetParams
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
	}
}
