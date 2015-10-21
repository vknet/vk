using System;
using System.Collections.Generic;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.NewsFeed
{
	/// <summary>
	/// Список параметров запроса newsfeed.get
	/// </summary>
	public class GetRecommendedParams
	{
		/// <summary>
		/// Время в формате unixtime, начиная с которого следует получить новости для текущего пользователя.
		/// </summary>
		public string StartTime
		{ get; set; }

		/// <summary>
		/// Время в формате unixtime, до которого следует получить новости для текущего пользователя. Если параметр не задан, то он считается равным текущему времени. положительное число.
		/// </summary>
		public string EndTime
		{ get; set; }

		/// <summary>
		/// Максимальное количество фотографий, информацию о которых необходимо вернуть. По умолчанию 5. положительное число.
		/// </summary>
		public uint MaxPhotos
		{ get; set; }

		/// <summary>
		/// Идентификатор, необходимый для получения следующей страницы результатов. Значение, необходимое для передачи в этом параметре, возвращается в поле ответа next_from. строка, доступен начиная с версии 5.13.
		/// </summary>
		public long StartFrom
		{ get; set; }

		/// <summary>
		/// Указывает, какое максимальное число новостей следует возвращать, но не более 100. По умолчанию 50.
		/// </summary>
		public ushort Count
		{ get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть. список строк, разделенных через запятую.
		/// </summary>
		public UsersFields Fields
		{ get; set; }

	}
}
