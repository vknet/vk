using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация об артисте/группе.
	/// </summary>
	[Serializable]
	public class AudioArtist
	{
		/// <summary>
		/// Идентификатор артиста/группы.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// Имя артиста/название группы.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Неизвестно (получено экспериментально).
		/// </summary>
		[JsonProperty("domain")]
		public string Domain { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioArtist FromJson(VkResponse response)
		{
			var artist = new AudioArtist
			{
				Id = response["id"],
				Name = response["name"],
				Domain = response["domain"]
			};

			return artist;
		}

		/// <summary>
		/// Преобразование класса <see cref="AudioArtist" /> в
		/// <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>
		/// Результат преобразования в <see cref="AudioArtist" />
		/// </returns>
		public static implicit operator AudioArtist(VkResponse response)
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