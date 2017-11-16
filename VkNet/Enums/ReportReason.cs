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
		ChildPornography,

		/// <summary>
		/// Экстремизм.
		/// </summary>
		Extremism,

		/// <summary>
		/// Насилие.
		/// </summary>
		Violence,

		/// <summary>
		/// Пропаганда наркотиков.
		/// </summary>
		DrugPropaganda,

		/// <summary>
		/// Материал для взрослых.
		/// </summary>
		AdultMaterial,

		/// <summary>
		/// Оскорбление.
		/// </summary>
		Abuse
	}
}