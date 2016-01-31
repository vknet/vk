using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
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

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Platform FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "android":
					{
						return Android;
					}
				case "iphone":
					{
						return IPhone;
					}
				case "wphone":
					{
						return WindowsPhone;
					}
				default:
					{
						return null;
					}
			}
		}
	}
}