﻿using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.get
	/// </summary>
	public struct VideoGetParams
	{
		/// <summary>
		/// Параметры метода video.get
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public VideoGetParams(bool gag = true)
		{
			OwnerId = null;
			Videos = null;
			AlbumId = null;
			Count = null;
			Offset = null;
			Extended = null;
		}


		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежат видеозаписи. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Перечисленные через запятую идентификаторы — идущие через знак подчеркивания id пользователей, которым принадлежат видеозаписи, и id самих видеозаписей. Если видеозапись принадлежит сообществу, то в качестве первого параметра используется -id сообщества.
		/// Пример значения videos: 
		/// -4363_136089719,13245770_137352259 
		/// Некоторые видеозаписи, идентификаторы которых могут быть получены через API, закрыты приватностью, и не будут получены. В этом случае следует использовать ключ доступа access_key в её идентификаторе. Пример значения videos: 
		/// 
		/// 1_129207899_220df2876123d3542f, 6492_135055734_e0a9bcc31144f67fbd 
		/// Поле access_key будет возвращено вместе с остальными данными видеозаписи в методах, которые возвращают видеозаписи, закрытые приватностью, но доступные в данном контексте. Например данное поле имеют видеозаписи, возвращаемые методом newsfeed.get. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<Attachments.Video> Videos { get; set; }

		/// <summary>
		/// Идентификатор альбома, видеозаписи из которого нужно вернуть. целое число.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Количество возвращаемых видеозаписей. положительное число, максимальное значение 200, по умолчанию 100.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение относительно первой найденной видеозаписи для выборки определенного подмножества. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Определяет, возвращать ли информацию о настройках приватности видео для текущего пользователя. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(VideoGetParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "videos", p.Videos },
				{ "album_id", p.AlbumId },
				{ "count", p.Count },
				{ "offset", p.Offset },
				{ "extended", p.Extended }
			};

			return parameters;
		}
	}
}