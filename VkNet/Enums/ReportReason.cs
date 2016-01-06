using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Причина жалобы.
	/// </summary>
	public enum ReportReason
	{
		/// <summary>
		/// Это спам.
		/// </summary>
		[DefaultValue]
		Spam = 0,

		/// <summary>
		/// Детская порнография.
		/// </summary>
		ChildPornography = 1,

		/// <summary>
		/// Экстремизм.
		/// </summary>
		Extremism = 2,

		/// <summary>
		/// Насилие.
		/// </summary>
		Violence = 3,

		/// <summary>
		/// Пропаганда наркотиков.
		/// </summary>
		DrugPropaganda = 4,

		/// <summary>
		/// Материал для взрослых.
		/// </summary>
		AdultMaterial  = 5,

		/// <summary>
		/// Оскорбление.
		/// </summary>
		Abuse = 6,
	}
}