using System;
using System.Collections.Generic;
using System.Linq;
using VkNet.Utils;

namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Права доступа приложений.
	/// См. описание <see href="https://vk.com/dev/permissions" />.
	/// </summary>
	public sealed class Settings
	{
		private static readonly Dictionary<string, ulong> MaskMap = new Dictionary<string, ulong>
		{
			{ "notify", 1 },
			{ "friends", 2 },
			{ "photos", 4 },
			{ "audio", 8 },
			{ "video", 16 },
			{ "app_widget", 64 },
			{ "pages", 128 },
			{ "addlinktoleftmenu", 256 },
			{ "status", 1024 },
			{ "notes", 2048 },
			{ "messages", 4096 },
			{ "wall", 8192 },
			{ "ads", 32768 },
			{ "offline", 65536 },
			{ "docs", 131072 },
			{ "groups", 262144 },
			{ "notifications", 524288 },
			{ "stats", 1048576 },
			{ "email", 4194304 },
			{ "market", 134217728 }
		};

		private static readonly Dictionary<string, string> Alias = new Dictionary<string, string>
		{
			{
				"all", string.Join(separator: ",", values: MaskMap.Keys.Where(predicate: x => x != "offline").OrderBy(keySelector: x => x))
			}
		};

		private List<string> _settings;

		/// <summary>
		/// Числовая маска выбранных прав доступа
		/// </summary>
		private ulong Mask { get; set; }

		/// <summary>
		/// Список выбранных прав
		/// </summary>
		private IEnumerable<string> Selected => _settings ??= new List<string>();

		/// <summary>
		/// Пользователь разрешил отправлять ему уведомления.
		/// </summary>
		public static Settings Notify => GetByName(name: "notify");

		/// <summary>
		/// Доступ к друзьям.
		/// </summary>
		public static Settings Friends => GetByName(name: "friends");

		/// <summary>
		/// Доступ к фотографиям.
		/// </summary>
		public static Settings Photos => GetByName(name: "photos");

		/// <summary>
		/// Доступ к аудио записям.
		/// </summary>
		public static Settings Audio => GetByName(name: "audio");

		/// <summary>
		/// Доступ к видеозаписям.
		/// </summary>
		public static Settings Video => GetByName(name: "video");

		/// <summary>
		/// Доступ к wiki-страницам.
		/// </summary>
		public static Settings Pages => GetByName(name: "pages");

		/// <summary>
		/// Добавление ссылки на приложение в меню слева.
		/// </summary>
		public static Settings AddLinkToLeftMenu => GetByName(name: "addLinkToLeftMenu");

		/// <summary>
		/// Доступ к статусу пользователя.
		/// </summary>
		public static Settings Status => GetByName(name: "status");

		/// <summary>
		/// Доступ заметкам пользователя.
		/// </summary>
		public static Settings Notes => GetByName(name: "notes");

		/// <summary>
		/// Доступ к расширенным методам работы с сообщениями.
		/// </summary>
		public static Settings Messages => GetByName(name: "messages");

		/// <summary>
		/// Доступ к обычным и расширенным методам работы со стеной.
		/// </summary>
		public static Settings Wall => GetByName(name: "wall");

		/// <summary>
		/// Доступ к расширенным методам работы с рекламным API.
		/// </summary>
		public static Settings Ads => GetByName(name: "ads");

		/// <summary>
		/// Доступ к API в любое время со стороннего сервера.
		/// </summary>
		public static Settings Offline => GetByName(name: "offline");

		/// <summary>
		/// Доступ к документам.
		/// </summary>
		public static Settings Documents => GetByName(name: "docs");

		/// <summary>
		/// Доступ к группам пользователя.
		/// </summary>
		public static Settings Groups => GetByName(name: "groups");

		/// <summary>
		/// Доступ к оповещениям об ответах пользователю.
		/// </summary>
		public static Settings Notifications => GetByName(name: "notifications");

		/// <summary>
		/// Доступ к статистике групп и приложений пользователя, администратором которых он
		/// является.
		/// </summary>
		public static Settings Statistic => GetByName(name: "stats");

		/// <summary>
		/// Доступ к email пользователя. Доступно только для сайтов.
		/// </summary>
		public static Settings Email => GetByName(name: "email");

		/// <summary>
		/// Доступ к товарам. Доступно только для сайтов.
		/// </summary>
		public static Settings Market => GetByName(name: "market");

		/// <summary>
		/// Доступ к статистике групп и приложений пользователя, администратором которых он
		/// является.
		/// </summary>
		public static Settings Stats => GetByName(name: "stats");

		/// <summary>
		/// Доступ к статистике групп и приложений пользователя, администратором которых он
		/// является.
		/// </summary>
		public static Settings AppWidget => GetByName(name: "app_widget");

		/// <summary>
		/// Доступ ко всем возможным операциям (без Off line и NoHttps).
		/// </summary>
		public static Settings All => AddLinkToLeftMenu
									|Ads
									|AppWidget
									|Audio
									|Documents
									|Email
									|Friends
									|Groups
									|Market
									|Notes
									|Notifications
									|Notify
									|Pages
									|Photos
									|Stats
									|Status
									|Video
									|Wall;

		private static Settings GetByName(string name)
		{
			var n = name.ToLower();

			if (MaskMap.ContainsKey(key: n))
			{
				return new Settings
				{
					Mask = MaskMap[key: n], _settings = new List<string> { n }
				};
			}

			if (!Alias.ContainsKey(key: n))
			{
				throw new ArgumentException(message: $"Undefined access setting '{n}'");
			}

			var res = new Settings();

			return Alias[key: n].Split(',').Aggregate(seed: res, func: (current, v) => current|GetByName(name: v));
		}

		/// <summary>
		/// Получить из json
		/// </summary>
		/// <param name="response"> Ответ Vk </param>
		/// <returns> </returns>
		public static Settings FromJson(VkResponse response)
		{
			var value = response.ToString();

			return FromJsonString(val: value);
		}

		/// <summary>
		/// Получить из json
		/// </summary>
		/// <param name="val"> Json строка </param>
		/// <returns> </returns>
		public static Settings FromJsonString(string val)
		{
			var vals = val.Split(',').Select(selector: x => x.Trim());

			var res = new Settings();

			foreach (var v in vals)
			{
				if (MaskMap.ContainsKey(key: v.ToLower()))
				{
					res |= GetByName(name: v);
				} else if (Alias.ContainsKey(key: v.ToLower()))
				{
					res |= GetByName(name: v);
				}
			}

			return res;
		}

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
		/// <returns> </returns>
		public override string ToString()
		{
			return string.Join(separator: ",", value: Selected.ToArray());
		}

		/// <summary>
		/// Преобразовать в числовую маску выбранные права доступа
		/// </summary>
		/// <returns> </returns>
		public ulong ToUInt64()
		{
			return Mask;
		}

		/// <summary>
		/// Сравнение с другим набором прав
		/// </summary>
		/// <param name="obj"> </param>
		/// <returns> </returns>
		public override bool Equals(object obj)
		{
			var other = obj as Settings;

			return Mask == other?.Mask;
		}

		/// <summary>
		/// Get Hash
		/// </summary>
		/// <returns> </returns>
		public override int GetHashCode()
		{
			return Selected?.GetHashCode() ?? 0;
		}

		/// <summary>
		/// Объединяет наборы настройки
		/// </summary>
		/// <param name="a"> Первый набор </param>
		/// <param name="b"> Второй набор </param>
		/// <returns> </returns>
		public static Settings operator |(Settings a, Settings b)
		{
			foreach (var s in b.Selected)
			{
				if (a.Selected.Contains(value: s))
				{
					continue;
				}

				a.Mask += MaskMap[key: s];
				a._settings.Add(item: s);
			}

			return a;
		}
	}
}