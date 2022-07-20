using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода Wall.Get
	/// </summary>
	[Serializable]
	public class WallGetParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, со стены которого необходимо
		/// получить записи (по умолчанию — текущий
		/// пользователь).
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Короткий адрес пользователя или сообщества.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества записей.
		/// </summary>
		public ulong Offset { get; set; }

		/// <summary>
		/// Количество записей, которое необходимо получить (но не более 100).
		/// </summary>
		public ulong Count { get; set; }

		/// <summary>
		/// Определяет, какие типы записей на стене необходимо получить. Возможны следующие
		/// значения параметра: Если параметр
		/// не задан, то считается, что он равен all.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public WallFilter Filter { get; set; }

		/// <summary>
		/// <c> true </c> — будут возвращены три массива wall, profiles и groups. По
		/// умолчанию дополнительные поля не
		/// возвращаются.
		/// </summary>
		public bool Extended { get; set; }

		/// <summary>
		/// Список дополнительных полей для профилей и групп, которые необходимо вернуть.
		/// См. описание полей объекта user и
		/// описание полей объекта group. Обратите внимание, этот параметр учитывается
		/// только при extended=1.
		/// </summary>
		public object Fields { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// Текст капчи, который ввел пользователь
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }
	}
}