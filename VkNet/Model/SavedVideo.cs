using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ от сервера после загрузки видеозаписи
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/video.save
	/// </remarks>
	[Serializable]
	public class SavedVideo
	{
		/// <summary>
		/// Ссылка по которой требуется перейти (GET запрос), чтобы подтвердить загрузку видео с внешнего источника
		/// </summary>
		[JsonProperty("upload_url")]
		public string UploadUrl { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи
		/// </summary>
		[JsonProperty("vid")]
		public int Vid { get; set; }

		/// <summary>
		/// Идентификатор владельца видеозаписи
		/// </summary>
		[JsonProperty("owner_id")]
		public int OwnerId { get; set; }

		/// <summary>
		/// Название видеозаписи
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Описание видеозаписи
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Ключ доступа
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static SavedVideo FromJson(VkResponse response)
		{
			return response != null
				? JsonConvert.DeserializeObject<SavedVideo>(response.ToString())
				: null;
		}

		/// <summary>
		/// Преобразование класса <see cref="SavedVideo" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="SavedVideo" /></returns>
		public static implicit operator SavedVideo(VkResponse response)
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