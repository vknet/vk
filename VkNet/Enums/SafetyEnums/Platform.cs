using System;


namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class Platform : SafetyEnum<Platform>
	{
		/// <summary>
		/// Android.
		/// </summary>
		public static readonly Platform Android = RegisterPossibleValue("android");

		/// <summary>
		/// iPhone.
		/// </summary>
		public static readonly Platform IPhone = RegisterPossibleValue("iphone");

		/// <summary>
		/// wphone.
		/// </summary>
		public static readonly Platform WindowsPhone = RegisterPossibleValue("wphone");
	}
}