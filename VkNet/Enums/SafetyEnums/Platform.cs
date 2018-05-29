using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class Platform : SafetyEnum<Platform>
	{
		/// <summary>
		/// Android.
		/// </summary>
		public static readonly Platform Android = RegisterPossibleValue(value: "android");

		/// <summary>
		/// iPhone.
		/// </summary>

		// ReSharper disable once InconsistentNaming
		public static readonly Platform IPhone = RegisterPossibleValue(value: "iphone");

		/// <summary>
		/// wphone.
		/// </summary>
		public static readonly Platform WindowsPhone = RegisterPossibleValue(value: "wphone");
	}
}