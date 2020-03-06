namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Права пользователя в рекламном кабинете.
	/// </summary>
	public sealed class DemographicsType : SafetyEnum<DemographicsType>
	{
		/// <summary>
		/// Объявление.
		/// </summary>
		public static readonly DemographicsType Ad = RegisterPossibleValue(value: "ad");

		/// <summary>
		/// Кампания.
		/// </summary>
		public static readonly DemographicsType Campaign = RegisterPossibleValue(value: "campaign");

	}
}