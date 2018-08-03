namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип статуса ссылки
	/// </summary>
	public class LinkStatusType : SafetyEnum<LinkStatusType>
	{
		/// <summary>
		/// Ссылку допустимо использовать в рекламных объявлениях;
		/// </summary>
		public static readonly LinkStatusType Allowed = RegisterPossibleValue(value: "allowed");

		/// <summary>
		/// Ссылку допустимо использовать в рекламных объявлениях;
		/// </summary>
		public static readonly LinkStatusType Disallowed = RegisterPossibleValue(value: "disallowed");

		/// <summary>
		/// Ссылку допустимо использовать в рекламных объявлениях;
		/// </summary>
		public static readonly LinkStatusType InProgress = RegisterPossibleValue(value: "in_progress");
	}
}