using System;

namespace VkNet.Enums.SafetyEnums
{
	using Utils;
	using System.Text.RegularExpressions;

	/// <summary>
	/// Уровень доступа к комментированию альбома
	/// </summary>
	public sealed class Privacy : SafetyEnum<Privacy>
	{
		/// <summary>
		/// Доступно всем пользователям.
		/// </summary>
		[DefaultValue]
		public static readonly Privacy All = RegisterPossibleValue("all");

		/// <summary>
		/// Доступно друзьям текущего пользователя.
		/// </summary>
		public static readonly Privacy Friends = RegisterPossibleValue("friends");

		/// <summary>
		/// Доступно друзьям и друзьям друзей.
		/// </summary>
		public static readonly Privacy FriendsOfFriends = RegisterPossibleValue("friends_of_friends");

		/// <summary>
		/// Доступно друзьям друзей текущего пользователя.
		/// </summary>
		public static readonly Privacy FriendsOfFriendsOnly = RegisterPossibleValue("friends_of_friends_only");

		/// <summary>
		/// Недоступно никому.
		/// </summary>
		public static readonly Privacy Nobody = RegisterPossibleValue("nobody");

		/// <summary>
		/// Доступно только мне.
		/// </summary>
		public static readonly Privacy OnlyMe = RegisterPossibleValue("only_me");

		/// <summary>
		/// Доступно для списка
		/// </summary>
		/// <param name="number">Номер списка.</param>
		/// <returns>Номер списка.</returns>
		public static Privacy AvailableForList(long number)
		{
			return RegisterPossibleValue("list" + number);
		}

		/// <summary>
		/// Недоступно для списка
		/// </summary>
		/// <param name="number">Номер списка.</param>
		/// <returns>Номер списка.</returns>
		public static Privacy UnAvailableForList(long number)
		{
			return RegisterPossibleValue("-list" + number);
		}

		/// <summary>
		/// Доступно для пользователя
		/// </summary>
		/// <param name="number">Номер списка.</param>
		/// <returns>Номер списка.</returns>
		public static Privacy AvailableForUser(long number)
		{
			return RegisterPossibleValue(number.ToString());
		}

		/// <summary>
		/// Недоступно для пользователя
		/// </summary>
		/// <param name="number">Номер списка.</param>
		/// <returns>Номер списка.</returns>
		public static Privacy UnAvailableForUser(long number)
		{
			return RegisterPossibleValue("-" + number);
		}
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Privacy FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "all":
					return All;
				case "friends":
					return Friends;
				case "friends_of_friends":
					return FriendsOfFriends;
				case "friends_of_friends_only":
					return FriendsOfFriendsOnly;
				case "nobody":
					return Nobody;
				case "only_me":
					return OnlyMe;
				default:
					{
						var input = response.ToString();
						var idPattern = new Regex(@"([\d]+)");
						long id = 0;
						long.TryParse(idPattern.Match(input).Groups[1].Value, out id);
						if (input.StartsWith("list"))
						{
							return AvailableForList(id);
						}
						if (input.StartsWith("-list"))
						{
							return UnAvailableForList(id);
						}

						return input.StartsWith("-") ? UnAvailableForUser(id) : AvailableForUser(id);
					}
			}
		}
	}
}