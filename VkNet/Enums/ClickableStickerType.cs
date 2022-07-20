using System.Runtime.Serialization;

namespace VkNet.Enums
{
	/// <summary>
	/// Тип стикера.
	/// </summary>
	public enum ClickableStickerType
	{
		/// <summary>
		/// Упоминание.
		/// </summary>
		[EnumMember(Value = "mention")]
		Mention,

		/// <summary>
		/// Хэштег.
		/// </summary>
		[EnumMember(Value = "hashtag")]
		Hashtag
	}
}