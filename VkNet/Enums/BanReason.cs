using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Причина бана
	/// </summary>
	public enum BanReason
	{
		/// <summary>
		/// Другое.
		/// </summary>
		[DefaultValue]
		Other = 0

		, /// <summary>
		/// Спам.
		/// </summary>
		Spam = 1

		, /// <summary>
		/// Оскорбление участников.
		/// </summary>
		VerbalAbuse = 2

		, /// <summary>
		/// Нецензурные выражения.
		/// </summary>
		StrongLanguage = 3

		, /// <summary>
		/// Сообщения не по теме.
		/// </summary>
		IrrelevantMessages = 4
	}
}