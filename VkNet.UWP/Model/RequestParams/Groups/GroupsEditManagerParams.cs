using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.editManager
	/// </summary>
	public struct GroupsEditManagerParams
	{
		/// <summary>
		/// Параметры метода groups.editManager
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public GroupsEditManagerParams(bool gag = true)
		{
			GroupId = 0;
			UserId = 0;
			Role = null;
			IsContact = null;
			ContactPosition = null;
			ContactPhone = null;
			ContactEmail = null;
		}

		/// <summary>
		/// Идентификатор сообщества (указывается без знака «минус»). положительное число, обязательный параметр.
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, чьи полномочия в сообществе нужно изменить. положительное число, обязательный параметр.
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Уровень полномочий: 
		/// 
		/// moderator — модератор; 
		/// editor — редактор; 
		/// administrator — администратор. 
		/// 
		/// Если параметр не задан, с пользователя user_id снимаются полномочия руководителя. строка.
		/// </summary>
		public AdminLevel? Role { get; set; }

		/// <summary>
		/// Отображать ли пользователя в блоке контактов сообщества. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? IsContact { get; set; }

		/// <summary>
		/// Должность пользователя, отображаемая в блоке контактов. строка.
		/// </summary>
		public string ContactPosition { get; set; }

		/// <summary>
		/// Телефон пользователя, отображаемый в блоке контактов. строка.
		/// </summary>
		public string ContactPhone { get; set; }

		/// <summary>
		/// Email пользователя, отображаемый в блоке контактов. строка.
		/// </summary>
		public string ContactEmail { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		public static VkParameters ToVkParameters(GroupsEditManagerParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "user_id", p.UserId },
				{ "role", p.Role },
				{ "is_contact", p.IsContact },
				{ "contact_position", p.ContactPosition },
				{ "contact_phone", p.ContactPhone },
				{ "contact_email", p.ContactEmail }
			};

			return parameters;
		}
	}
}