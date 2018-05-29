using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода account.saveProfileInfo
	/// </summary>
	[Serializable]
	public class AccountSaveProfileInfoParams
	{
		/// <summary>
		/// Имя пользователя. строка.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия пользователя. строка.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Девичья фамилия пользователя (только для женского пола). строка.
		/// </summary>
		public string MaidenName { get; set; }

		/// <summary>
		/// Короткое имя страницы. строка.
		/// </summary>
		public string ScreenName { get; set; }

		/// <summary>
		/// Пол пользователя. Возможные значения:
		/// 1 — женский;
		/// 2 — мужской.
		/// положительное число.
		/// </summary>
		public Sex? Sex { get; set; }

		/// <summary>
		/// Семейное положение пользователя. Возможные значения:
		/// 1 — не женат/не замужем;
		/// 2 — есть друг/есть подруга;
		/// 3 — помолвлен/помолвлена;
		/// 4 — женат/замужем;
		/// 5 — всё сложно;
		/// 6 — в активном поиске;
		/// 7 — влюблён/влюблена;
		/// 0 — не указано.
		/// положительное число.
		/// </summary>
		public RelationType? Relation { get; set; }

		/// <summary>
		/// Идентификатор пользователя, с которым связано семейное положение. положительное
		/// число.
		/// </summary>
		public User RelationPartner { get; set; }

		/// <summary>
		/// Дата рождения пользователя в формате DD.MM.YYYY, например "15.11.1984". строка.
		/// </summary>
		public string BirthDate { get; set; }

		/// <summary>
		/// Видимость даты рождения. Возможные значения:
		/// 1 — показывать дату рождения;
		/// 2 — показывать только месяц и день;
		/// 0 — не показывать дату рождения.
		/// положительное число.
		/// </summary>
		public BirthdayVisibility? BirthdayVisibility { get; set; }

		/// <summary>
		/// Родной город пользователя. строка.
		/// </summary>
		public string HomeTown { get; set; }

		/// <summary>
		/// Идентификатор страны пользователя. положительное число.
		/// </summary>
		public Country Country { get; set; }

		/// <summary>
		/// Идентификатор города пользователя. положительное число.
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// Статус пользователя, который также может быть изменен методом status.set
		/// строка.
		/// </summary>
		public string Status { get; set; }

		/// <summary>
		/// Телефон.
		/// </summary>
		/// <remarks>
		/// Обнаружено опытным путем.
		/// </remarks>
		public string Phone { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> Объект типа AccountSaveProfileInfoParams </returns>
		public static VkParameters ToVkParameters(AccountSaveProfileInfoParams p)
		{
			if (p.RelationPartner != null)
			{
				VkErrors.ThrowIfNumberIsNegative(expr: () => p.RelationPartner.Id);
			}

			if (p.Country != null)
			{
				VkErrors.ThrowIfNumberIsNegative(expr: () => p.Country.Id);
			}

			if (p.City != null)
			{
				VkErrors.ThrowIfNumberIsNegative(expr: () => p.City.Id);
			}

			var result = new VkParameters
			{
					{ "first_name", p.FirstName }
					, { "last_name", p.LastName }
					, { "maiden_name", p.MaidenName }
					, { "screen_name", p.ScreenName }
					, { "sex", p.Sex }
					, { "relation", p.Relation }
					, { "relation_partner_id", p.RelationPartner?.Id }
					, { "bdate", p.BirthDate }
					, { "bdate_visibility", p.BirthdayVisibility }
					, { "home_town", p.HomeTown }
					, { "country_id", p.Country?.Id }
					, { "city_id", p.City?.Id }
					, { "status", p.Status }
					, { "phone", p.Phone }
			};

			return result;
		}
	}
}