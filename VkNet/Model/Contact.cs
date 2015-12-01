namespace VkNet.Model
{
    using System;

    using Utils;

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

        internal static Contact FromJson(VkResponse response)
		{
			var contact = new Contact
			{
				UserId = response["user_id"],
				Description = response["desc"],
				Email = response["email"],
				Phone = response["phone"]
			};

			return contact;
		}

		#endregion
	}
}