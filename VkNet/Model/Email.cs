using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// E-Mail.
	/// </summary>
	[Serializable]
	public class Email
	{
		/// <summary>
		/// Идентификатор e-mail
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public int Id { get; set; }

		/// <summary>
		/// Адрес e-mail
		/// </summary>
		[JsonProperty(propertyName: "address")]
		public string Address { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Email FromJson(VkResponse response)
		{
			return new Email
			{
					Id = response[key: "id"]
					, Address = response[key: "address"]
			};
		}

	#endregion
	}
}