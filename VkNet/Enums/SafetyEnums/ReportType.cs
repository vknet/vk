namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип жалобы.
	/// </summary>
	public sealed class ReportType : SafetyEnum<ReportType>
	{
		/// <summary>
		/// Порнография.
		/// </summary>
		public static readonly ReportType Porn = RegisterPossibleValue(value: "porn");

		/// <summary>
		/// Рассылка спама.
		/// </summary>
		public static readonly ReportType Spam = RegisterPossibleValue(value: "spam");

		/// <summary>
		/// Оскорбительное поведение.
		/// </summary>
		public static readonly ReportType Insult = RegisterPossibleValue(value: "insult");

		/// <summary>
		/// Рекламная страница, засоряющая поиск.
		/// </summary>
		public static readonly ReportType Advertisment = RegisterPossibleValue(value: "advertisment");
	}
}