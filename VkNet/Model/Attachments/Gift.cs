using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Подарок.
	/// </summary>
	[Serializable]
	public class Gift : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "gift";

		/// <summary>
		/// Изображение 48х48.
		/// </summary>
		[JsonProperty("thumb_48")]
		public Uri Thumb48 { get; set; }

		/// <summary>
		/// Изображение 96х96.
		/// </summary>
		[JsonProperty("thumb_96")]
		public Uri Thumb96 { get; set; }

		/// <summary>
		/// Изображение 256х256.
		/// </summary>
		[JsonProperty("thumb_256")]
		public Uri Thumb256 { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Gift FromJson(VkResponse response)
		{
			return new Gift
			{
				Id = response["id"],
				Thumb48 = response["thumb_48"],
				Thumb96 = response["thumb_96"],
				Thumb256 = response["thumb_256"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Gift" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Gift" /></returns>
		public static implicit operator Gift(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}