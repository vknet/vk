
using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Объект, который содержит информацию о статусе печатании
	/// </summary>
	[Serializable]
	public class MessageTypingState
	{
		/// <summary>
		/// Идентификатор пользователя, который набирает текст.
		/// </summary>
		[JsonProperty("from_id")]
		public long? FromId { get; set; }

		/// <summary>
		/// Идентификатор сообщества, которому пользователь пишет сообщение.
		/// </summary>
		[JsonProperty("to_id")]
		public long? ToId { get; set; }

		/// <summary>
		/// Состояние статуса набора текста.
		/// </summary>
		[JsonProperty("state")]
		public string State { get; set; }


		#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static MessageTypingState FromJson(VkResponse response)
		{
			return new MessageTypingState
			{
				FromId = response["from_id"],
				ToId = response["to_id"],
				State = response["state"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="MessageTypingState" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="MessageTypingState" /></returns>
		public static implicit operator MessageTypingState(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

		#endregion
	}

}