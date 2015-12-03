using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Возможные значения параметра display, задающего внешний вид окна авторизации.
    /// </summary>
    public sealed class Deactivated : SafetyEnum<Deactivated>
    {
		/// <summary>
		/// Удалено.
		/// </summary>
		public static readonly Deactivated Deleted = RegisterPossibleValue("deleted");

		/// <summary>
		/// Заблокировано.
		/// </summary>
		public static readonly Deactivated Banned = RegisterPossibleValue("banned");

		/// <summary>
		/// Заблокировано.
		/// </summary>
		[DefaultValue]
		public static readonly Deactivated Activated = RegisterPossibleValue("activated");

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Deactivated FromJson(VkResponse response)
		{
			switch (response.ToString())
			{
				case "deleted":
					{
						return Deleted;
					}
				case "banned":
					{
						return Banned;
					}
				default:
				{
					return Activated;
				}
			}
		}
	}
}