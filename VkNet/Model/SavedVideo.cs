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
	[DebuggerDisplay("Id = {Id}, Title = {Title}")]
	[Serializable]
	public class SavedVideo
	{
		/// <summary>
		/// Поле с ответом
		/// </summary>
		public SavedVideoResponse Response { get; set; }

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