using System.Text.RegularExpressions;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Уровень доступа к комментированию альбома
/// </summary>
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public sealed class Privacy : SafetyEnum<Privacy>
{
	/// <summary>
	/// Доступно всем пользователям.
	/// </summary>
	[VkNetDefaultValue]
	public static readonly Privacy All = RegisterPossibleValue(value: "all");

	/// <summary>
	/// Доступно друзьям текущего пользователя.
	/// </summary>
	public static readonly Privacy Friends = RegisterPossibleValue(value: "friends");

	/// <summary>
	/// Доступно друзьям и друзьям друзей.
	/// </summary>
	public static readonly Privacy FriendsOfFriends = RegisterPossibleValue(value: "friends_of_friends");

	/// <summary>
	/// Доступно друзьям друзей текущего пользователя.
	/// </summary>
	public static readonly Privacy FriendsOfFriendsOnly = RegisterPossibleValue(value: "friends_of_friends_only");

	/// <summary>
	/// Недоступно никому.
	/// </summary>
	public static readonly Privacy Nobody = RegisterPossibleValue(value: "nobody");

	/// <summary>
	/// Доступно только мне.
	/// </summary>
	public static readonly Privacy OnlyMe = RegisterPossibleValue(value: "only_me");

	/// <summary>
	/// Доступно для списка
	/// </summary>
	/// <param name="number"> Номер списка. </param>
	/// <returns> Номер списка. </returns>
	public static Privacy AvailableForList(long number) => RegisterPossibleValue(value: "list" + number);

	/// <summary>
	/// Недоступно для списка
	/// </summary>
	/// <param name="number"> Номер списка. </param>
	/// <returns> Номер списка. </returns>
	public static Privacy UnAvailableForList(long number) => RegisterPossibleValue(value: "-list" + number);

	/// <summary>
	/// Доступно для пользователя
	/// </summary>
	/// <param name="number"> Номер списка. </param>
	/// <returns> Номер списка. </returns>
	public static Privacy AvailableForUser(long number) => RegisterPossibleValue(value: number.ToString());

	/// <summary>
	/// Недоступно для пользователя
	/// </summary>
	/// <param name="number"> Номер списка. </param>
	/// <returns> Номер списка. </returns>
	public static Privacy UnAvailableForUser(long number) => RegisterPossibleValue(value: "-" + number);

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns>
	/// Уровень доступа к комментированию альбома
	/// </returns>
	public new static Privacy FromJson(VkResponse response)
	{
		switch (response.ToString())
		{
			case "all":

			{
				return All;
			}

			case "friends":

			{
				return Friends;
			}

			case "friends_of_friends":

			{
				return FriendsOfFriends;
			}

			case "friends_of_friends_only":

			{
				return FriendsOfFriendsOnly;
			}

			case "nobody":

			{
				return Nobody;
			}

			case "only_me":

			{
				return OnlyMe;
			}

			default:

			{
				var input = response.ToString();
				var idPattern = new Regex(pattern: @"([\d]+)");
				long id;

				long.TryParse(idPattern.Match(input: input)
					.Groups[groupnum: 1]
					.Value, out id);

				if (input.StartsWith(value: "list"))
				{
					return AvailableForList(number: id);
				}

				if (input.StartsWith(value: "-list"))
				{
					return UnAvailableForList(number: id);
				}

				return input.StartsWith(value: "-")
					? UnAvailableForUser(number: id)
					: AvailableForUser(number: id);
			}
		}
	}
}