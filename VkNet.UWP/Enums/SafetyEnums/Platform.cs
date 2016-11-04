using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
	[DataContract]
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