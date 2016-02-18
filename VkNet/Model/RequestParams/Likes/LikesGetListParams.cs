﻿using System.Security.Policy;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса likes.getList
	/// </summary>
	public struct LikesGetListParams
	{
		/// <summary>
		/// Параметры запроса likes.getList
		/// </summary>
		public LikesGetListParams(bool gog = true)
		{
			Type = LikeObjectType.Post;
			Filter = LikesFilter.Likes;
			OwnerId = null;
			ItemId = 0;
			PageUrl = null;
			FriendsOnly = null;
			Offset = null;
			Count = null;
			SkipOwn = null;
		    Extended = null;
		}
		/// <summary>
		/// Тип объекта.
		/// </summary>
		public LikeObjectType Type
		{ get; set; }

		/// <summary>
		/// Идентификатор владельца Like-объекта: id пользователя, id сообщества (со знаком «минус») или id приложения. Если параметр type равен sitepage, то в качестве owner_id необходимо передавать id приложения. Если параметр не задан, то считается, что он равен либо идентификатору текущего пользователя, либо идентификатору текущего приложения (если type равен sitepage).
		/// </summary>
		public long? OwnerId
		{ get; set; }

		/// <summary>
		/// Идентификатор Like-объекта. Если type равен sitepage, то параметр item_id может содержать значение параметра page_id, используемый при инициализации виджета «Мне нравится».
		/// </summary>
		public long ItemId
		{ get; set; }

		/// <summary>
		/// Url страницы, на которой установлен виджет «Мне нравится». Используется вместо параметра item_id, если при размещении виджета не был указан page_id.
		/// </summary>
		public Url PageUrl
		{ get; set; }

		/// <summary>
		/// Указывает, следует ли вернуть всех пользователей, добавивших объект в список "Мне нравится" или только тех, которые рассказали о нем друзьям. Параметр может принимать следующие значения:строка.
		/// </summary>
		public LikesFilter Filter
		{ get; set; }

		/// <summary>
		/// Указывает, необходимо ли возвращать только пользователей, которые являются друзьями текущего пользователя.
		/// </summary>
		public bool? FriendsOnly
		{ get; set; }

		/// <summary>
		/// Смещение, относительно начала списка, для выборки определенного подмножества. Если параметр не задан, то считается, что он равен 0.
		/// </summary>
		public uint? Offset
		{ get; set; }

		/// <summary>
		/// Количество возвращаемых идентификаторов пользователей.
		/// </summary>
		public uint? Count
		{ get; set; }

		/// <summary>
		/// Не возвращать самого пользователя.
		/// </summary>
		public bool? SkipOwn
		{ get; set; }

        /// <summary>
        /// 1 — возвращать расширенную информацию о пользователях и сообществах из списка поставивших отметку «Мне нравится» или сделавших репост. По умолчанию — 0.
        /// </summary>
        public bool? Extended { get; set; }
	    

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(LikesGetListParams p)
		{
			var parameters = new VkParameters
				{
					{ "type", p.Type },
					{ "owner_id", p.OwnerId },
					{ "item_id", p.ItemId },
					{ "page_url", p.PageUrl },
					{ "filter", p.Filter },
					{ "friends_only", p.FriendsOnly },
					{ "extended", p.Extended },
					{ "offset", p.Offset },
					{ "skip_own", p.SkipOwn }
				};
			if (p.FriendsOnly.HasValue && p.FriendsOnly.Value)
			{
				if (p.Count <= 100)
				{
					parameters.Add("count", p.Count);
				}
			} else
			{
				if (p.Count <= 1000)
				{
					parameters.Add("count", p.Count);
				}
			}

			return parameters;
		}
	}
}
