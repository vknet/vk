﻿using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о военной службе пользователя.
	/// </summary>
	[Serializable]
	public class Military
	{
		/// <summary>
		/// Номер части.
		/// </summary>
		public string Unit { get; set; }

		/// <summary>
		/// Идентификатор части в базе данных.
		/// </summary>
		public ulong? UnitId { get; set; }

		/// <summary>
		/// Идентификатор страны, в которой находится часть.
		/// </summary>
		public long? CountryId { get; set; }

		/// <summary>
		/// Год начала службы.
		/// </summary>
		public int? From { get; set; }

		/// <summary>
		/// Год окончания службы.
		/// </summary>
		public int? Until { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Military FromJson(VkResponse response)
		{
			var military = new Military
			{
				Unit = response["unit"],
				UnitId = response["unit_id"],
				CountryId = response["country_id"],
				From = response["from"],
				Until = response["until"]
			};

			return military;
		}
	}
}