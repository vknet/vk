using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Контакты группы
	/// </summary>
	[Serializable]
	public class Contact
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Электронная почта.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Телефон.
		/// </summary>
		public string Phone { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Contact FromJson(VkResponse response)
		{
			var contact = new Contact
			{
					UserId = response[key: "user_id"]
					, Description = response[key: "desc"]
					, Email = response[key: "email"]
					, Phone = response[key: "phone"]
			};

			return contact;
		}

	#endregion
	}
}