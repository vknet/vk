using System;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Семейное положение.
	/// </summary>
	[Serializable]
	public enum RelationType
	{
		/// <summary>
		/// Не указано.
		/// </summary>
		[DefaultValue]
		Unknown = 0

		, /// <summary>
		/// Не женат/не замужем.
		/// </summary>
		NotMarried = 1

		, /// <summary>
		/// Встречаюсь.
		/// </summary>
		HasFriend = 2

		, /// <summary>
		/// Помолвлен/помолвлена.
		/// </summary>
		Engaged = 3

		, /// <summary>
		/// Женат/замужем.
		/// </summary>
		Married = 4

		, /// <summary>
		/// Всё сложно.
		/// </summary>
		ItsComplex = 5

		, /// <summary>
		/// В активном поиске.
		/// </summary>
		InActiveSearch = 6

		, /// <summary>
		/// Влюблен/влюблена.
		/// </summary>
		Amorous = 7

		, /// <summary>
		/// В гражданском браке
		/// </summary>
		CivilMarriage = 8
	}
}