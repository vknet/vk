using System;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип записи post, copy, reply, postpone, suggest
	/// </summary>
	[Serializable]
	public sealed class PostType : SafetyEnum<PostType>
	{
		/// <summary>
		/// Запись на стене (по умолчанию);
		/// v5.6+ - репосты имею тип "post"
		/// </summary>
		public static readonly PostType Post = RegisterPossibleValue(value: "post");

		/// <summary>
		/// Репост до версии 5.6 (сейчас не описано)
		/// </summary>
		public static readonly PostType Copy = RegisterPossibleValue(value: "copy");

		/// <summary>
		/// Ответ на запись с закрытыми комментариями (м.б. еще что-то)
		/// </summary>
		public static readonly PostType Reply = RegisterPossibleValue(value: "reply");

		/// <summary>
		/// Закрепленная запись
		/// </summary>
		public static readonly PostType Postpone = RegisterPossibleValue(value: "postpone");

		/// <summary>
		/// Предложенная запись
		/// </summary>
		public static readonly PostType Suggest = RegisterPossibleValue(value: "suggest");
	}
}