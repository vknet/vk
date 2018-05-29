using System;
using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// тип радиуса зоны поиска
	/// </summary>
	[Serializable]
	public enum Radius
	{
		/// <summary>
		/// 300 метров;
		/// </summary>
		[DefaultValue]
		ThreeHundredMeters = 1

		, /// <summary>
		/// 2400 метров;
		/// </summary>
		TwoThousandFourHundred = 2

		, /// <summary>
		/// 18 километров;
		/// </summary>
		EighteenKilometers = 3

		, /// <summary>
		/// 150 километров.
		/// </summary>
		OneHendredFiftyKilometers = 4
	}
}