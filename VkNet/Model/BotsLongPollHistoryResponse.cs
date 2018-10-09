using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Обновление в событиях группы
	/// </summary>
	[Serializable]
	public class BotsLongPollHistoryResponse
	{
		/// <summary>
		/// Номер последнего события, начиная с которого нужно получать данные;
		/// </summary>
		[JsonProperty("ts")]
		public string Ts { get; set; }

		/// <summary>
		/// Обновления группы
		/// </summary>

		[JsonProperty("updates")]
		public IEnumerable<GroupUpdate.GroupUpdate> Updates { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static BotsLongPollHistoryResponse FromJson(VkResponse response)
		{
			if (response.ContainsKey("failed"))
			{
				int code = response["failed"];

				if (code == LongPollException.OutdateException)
				{
					throw new LongPollOutdateException(response["ts"]);
				}

				if (code == LongPollException.KeyExpiredException)
				{
					throw new LongPollKeyExpiredException();
				}

				if (code == LongPollException.InfoLostException)
				{
					throw new LongPollInfoLostException();
				}
			}

			var fromJson = new BotsLongPollHistoryResponse
			{
				Ts = response["ts"],
			};

			VkResponseArray updates = response[key: "updates"];
			var updateList = new List<GroupUpdate.GroupUpdate>();

			foreach (var update in updates)
			{
				updateList.Add(GroupUpdate.GroupUpdate.FromJson(update));
			}

			fromJson.Updates = updateList;

			return fromJson;
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator BotsLongPollHistoryResponse(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response: response) : null;
		}
	}
}