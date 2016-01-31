﻿using System;

namespace VkNet.Model
{
	using Utils;

	/// <summary>
	/// Настройки уведомлений для беседы
	/// </summary>
	[Serializable]
	public class PushSettings
	{
		/// <summary>
		/// Состояние звукового оповещения
		/// </summary>
		public bool Sound { get; set; }

		/// <summary>
		/// Неизвестный параметр
		/// </summary>
		public int? DisabledUntil { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static PushSettings FromJson(VkResponse response)
		{
			var settings = new PushSettings
			{
				Sound = response.ContainsKey("sound") && response["sound"],
				DisabledUntil = response.ContainsKey("disabled_until") ? response["disabled_until"] : null
			};
			return settings;
		}
	}
}
