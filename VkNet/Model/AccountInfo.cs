﻿using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Хранит информацию о текущем аккаунте. Подробнее: <see href="https://vk.com/dev/account.getInfo"/>
	/// </summary>
	public class AccountInfo
	{
		/// <summary>
		/// Строковой код страны, определенный по IP адресу, с которого сделан запрос.
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// Пользователь установил в настройках аккаунта "Всегда использовать безопасное соединение"
		/// </summary>
		public bool? HttpsRequired { get; set; }

		/// <summary>
		/// Битовая маска, отвечающая за прохождение обучения использованию приложения.
		/// </summary>
		public int? Intro { get; set; }

		/// <summary>
		/// Числовой идентификатор текущего языка пользователя.
		/// </summary>
		public int? Language { get; set; }

		/// <summary>
		/// 1 - на стене пользователя по-умолчанию должны отображаться только собственные записи.
		/// Соответствует настройке на сайте "Показывать только мои записи", 0 - на стене пользователя должны отображаться все записи.
		/// </summary>
		public bool? OwnPostsDefault { get; set; }

		/// <summary>
		///  1 - пользователь отключил комментирование записей на стене, 0 - комментирование записей разрешено.
		/// </summary>
		public bool? NoWallReplies { get; set; }


		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static AccountInfo FromJson(VkResponse response)
		{
			return new AccountInfo
			{
				Country = response["country"],
				HttpsRequired = response["https_required"],
				Intro = response["intro"],
				Language = response["lang"],
				OwnPostsDefault = response["own_posts_default"],
				NoWallReplies = response["no_wall_replies"]
			};
		}
	}
}