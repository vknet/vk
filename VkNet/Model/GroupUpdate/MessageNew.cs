using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Объект, который содержит сообщение и информацию о доступных пользователю функциях.
	/// </summary>
	[Serializable]
	public class MessageNew : IGroupUpdate
	{
		/// <summary>
		/// Сообщение.
		/// </summary>
		[JsonProperty("message")]
		public Message Message { get; set; }

		/// <summary>
		/// Информация о доступных пользователю функциях.
		/// </summary>
		[JsonProperty("client_info")]
		public ClientInfo ClientInfo { get; set; }

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static MessageNew FromJson(VkResponse response)
		{
			return new MessageNew
			{
				Message = response["message"],
				ClientInfo = response["client_info"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="MessageNew" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="MessageNew" /></returns>
		public static implicit operator MessageNew(VkResponse response)
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