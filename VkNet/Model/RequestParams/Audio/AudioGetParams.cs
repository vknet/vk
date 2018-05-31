using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода audio.get
	/// </summary>
	[Serializable]
	public class AudioGetParams
	{
		/// <summary>
		/// Идентификатор владельца аудиозаписей (пользователь или сообщество). Обратите
		/// внимание, идентификатор сообщества в
		/// параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1
		/// соответствует идентификатору
		/// сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор
		/// текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор альбома с аудиозаписями. целое число.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Идентификаторы аудиозаписей, информацию о которых необходимо вернуть. список
		/// положительных чисел, разделенных
		/// запятыми.
		/// </summary>
		public IEnumerable<long> AudioIds { get; set; }

		/// <summary>
		/// 1 — возвращать информацию о пользователях, загрузивших аудиозапись. флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? NeedUser { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного количества аудиозаписей. По
		/// умолчанию — 0. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество аудиозаписей, информацию о которых необходимо вернуть. Максимальное
		/// значение — 6000. положительное
		/// число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(AudioGetParams p)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", p.OwnerId }
					, { "album_id", p.AlbumId }
					, { "audio_ids", p.AudioIds }
					, { "need_user", p.NeedUser }
					, { "offset", p.Offset }
					, { "count", p.Count }
			};

			return parameters;
		}
	}
}