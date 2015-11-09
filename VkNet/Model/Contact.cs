namespace VkNet.Model
{
    using System;

    using Utils;

    [Serializable]
    /// <summary>
    /// Контакты группы
    /// </summary>
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
            var contact = new Contact();

            contact.UserId = response["user_id"];
            contact.Description = response["desc"];
            contact.Email = response["email"];
            contact.Phone = response["phone"]; ;

            return contact;
        }

        #endregion
    }
}