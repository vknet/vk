using System;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

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
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		public string CaptchaKey { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(LikesAddParams p)
		{
			var result = new VkParameters
			{
					{ "type", p.Type }
					, { "item_id", p.ItemId }
					, { "owner_id", p.OwnerId }
					, { "access_key", p.AccessKey }
					, { "ref", p.Reference }
					, { "captcha_sid", p.CaptchaSid }
					, { "captcha_key", p.CaptchaKey }
			};

			return result;
		}
	}
}