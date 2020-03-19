using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода likes.add
	/// </summary>
	[Serializable]
	public class LikesAddParams
	{
		/// <summary>
		/// Тип объекта.
		/// </summary>
		/// <remarks>
		/// Возможные типы:
		/// post — запись на стене пользователя или группы;
		/// comment — комментарий к записи на стене;
		/// photo — фотография;
		/// audio — аудиозапись;
		/// video — видеозапись;
		/// note — заметка;
		/// market — товар;
		/// photo_comment — комментарий к фотографии;
		/// video_comment — комментарий к видеозаписи;
		/// topic_comment — комментарий в обсуждении;
		/// market_comment — комментарий к товару; строка, обязательный параметр (Строка,
		/// обязательный параметр).
		/// </remarks>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public LikeObjectType Type { get; set; }

		/// <summary>
		/// Идентификатор объекта. положительное число, обязательный параметр
		/// (Положительное число, обязательный параметр).
		/// </summary>
		public long ItemId { get; set; }

		/// <summary>
		/// Идентификатор владельца объекта. целое число, по умолчанию идентификатор
		/// текущего пользователя (Целое число, по
		/// умолчанию идентификатор текущего пользователя).
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Ключ доступа в случае работы с приватными объектами. строка (Строка).
		/// </summary>
		public string AccessKey { get; set; }

		/// <summary>
		/// Ссылка.
		/// </summary>
		public string Reference { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }
	}
}