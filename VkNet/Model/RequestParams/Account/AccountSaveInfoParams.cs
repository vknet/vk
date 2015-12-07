using System;

namespace VkNet.Model.RequestParams
{
    using Enums;

    using Utils;

    /// <summary>
    /// Параметры запроса метода account.saveProfileInfo
    /// </summary>
    public struct AccountSaveInfoParams
	{
		/// <summary>
		/// Имя пользователя. строка.
		/// </summary>
		public string FirstName
		{ get; set; }

		/// <summary>
		/// Фамилия пользователя. строка.
		/// </summary>
		public string LastName
		{ get; set; }

		/// <summary>
		/// Девичья фамилия пользователя (только для женского пола). строка.
		/// </summary>
		public string MaidenName
		{ get; set; }

		/// <summary>
		/// Короткое имя страницы. строка.
		/// </summary>
		public string ScreenName
		{ get; set; }

		/// <summary>
		/// Пол пользователя. положительное число.
		/// </summary>
		public Sex Sex
		{ get; set; }

		/// <summary>
		/// Семейное положение пользователя. положительное число.
		/// </summary>
		public RelationType Relation
		{ get; set; }

		/// <summary>
		/// Идентификатор пользователя, с которым связано семейное положение. положительное число.
		/// </summary>
		public long? RelationPartnerId
		{ get; set; }

		/// <summary>
		/// Дата рождения пользователя в формате DD.MM.YYYY, например "15.11.1984". строка.
		/// </summary>
		public DateTime? BirthDate
		{ get; set; }

		/// <summary>
		/// Видимость даты рождения. положительное число.
		/// </summary>
		public BirthdayVisibility BirthDateVisibility
		{ get; set; }

		/// <summary>
		/// Родной город пользователя. строка.
		/// </summary>
		public string HomeTown
		{ get; set; }

		/// <summary>
		/// Идентификатор страны пользователя. положительное число.
		/// </summary>
		public long? CountryId
		{ get; set; }

		/// <summary>
		/// Идентификатор города пользователя. положительное число.
		/// </summary>
		public long? CityId
		{ get; set; }

		/// <summary>
		/// Статус пользователя, который также может быть изменен методом status.set строка.
		/// </summary>
		public string Status
		{ get; set; }

		/// <summary>
		/// To the vk parameters.
		/// </summary>
		/// <param name="p">The p.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(AccountSaveInfoParams p)
		{
			return new VkParameters
			{
				{ "first_name", p.FirstName },
				{ "last_name", p.LastName },
				{ "maiden_name", p.MaidenName },
				{ "screen_name", p.ScreenName },
				{ "sex", p.Sex },
				{ "relation", p.Relation },
				{ "relation_partner_id", p.RelationPartnerId },
				{ "bdate", p.BirthDate },
				{ "bdate_visibility", p.BirthDateVisibility },
				{ "home_town", p.HomeTown },
				{ "country_id", p.CountryId },
				{ "city_id", p.CityId },
				{ "status", p.Status }
			};
		}
	}
}