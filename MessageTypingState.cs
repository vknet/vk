﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Объект, который содержит сообщение и информацию о доступных пользователю функциях.
	/// </summary>
	[Serializable]
	public class MessageTypingState
	{
		/// <summary>
		/// Идентификатор пользователя.
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор чата.
		/// </summary>
		[JsonProperty("peer_id")]
		public long? PeerId { get; set; }


		#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static MessageTypingState FromJson(VkResponse response)
		{
			return new MessageTypingState
			{
				UserId = response["user_id"],
				PeerId = response["peer_id"]
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