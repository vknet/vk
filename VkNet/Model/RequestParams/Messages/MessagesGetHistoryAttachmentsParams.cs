using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода messages.getHistoryAttachments
	/// </summary>
	[Serializable]
	public class MessagesGetHistoryAttachmentsParams
	{
		/// <summary>
		/// Идентификатор назначения. Для групповой беседы:
		/// 2000000000   id беседы.
		/// Для email:
		/// id беседы &lt; -2000000000
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр.
		/// </summary>
		public long PeerId { get; set; }

		/// <summary>
		/// Тип материалов, который необходимо вернуть.
		/// Доступные значения:
		/// photo — фотографии;
		/// video — видеозаписи;
		/// audio — аудиозаписи;
		/// doc — документы;
		/// link — ссылки;
		/// market — товары;
		/// wall — записи;
		/// share — ссылки, товары и записи.
		/// Обратите внимание — существует ограничение по дате отправки вложений. Так, для
		/// получения доступны вложения типов
		/// photo,video,audio,doc , отправленные не ранее 25.03.2013, link — не ранее
		/// 20.05.13, market,wall — 01.02.2016.
		/// строка, по умолчанию photo.
		/// </summary>
		public MediaType MediaType { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества объектов. строка.
		/// </summary>
		public string StartFrom { get; set; }

		/// <summary>
		/// Количество объектов, которое необходимо получить (но не более 200).
		/// положительное число, максимальное значение 200,
		/// по умолчанию 30.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Параметр, указывающий нужно ли возвращать ли доступные размеры фотографии в
		/// специальном формате. флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? PhotoSizes { get; set; }

		/// <summary>
		/// Список слов, разделенных через запятую.
		/// </summary>
		public IEnumerable<string> Fields { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> Объект типа MessagesGetHistoryAttachmentsParams </returns>
		public static VkParameters ToVkParameters(MessagesGetHistoryAttachmentsParams p)
		{
			var result = new VkParameters
			{
					{ "peer_id", p.PeerId }
					, { "media_type", p.MediaType }
					, { "start_from", p.StartFrom }
					, { "count", p.Count }
					, { "photo_sizes", p.PhotoSizes }
					, { "fields", p.Fields }
			};

			return result;
		}
	}
}