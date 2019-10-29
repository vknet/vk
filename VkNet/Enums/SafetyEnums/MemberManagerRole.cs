namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Роли, возвращаемые в Groups.GetMembers()
	/// </summary>
	public class MemberManagerRole : ManagerRole
	{
		/// <summary>
		/// Создатель сообщества
		/// </summary>
		public static readonly ManagerRole Creator = RegisterPossibleValue(value: "creator");
	}
}