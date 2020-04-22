using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Альбом с фотографиями пользователя.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[Serializable]
	public class Album : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "album";

		/// <summary>
		/// Обложка альбома.
		/// </summary>
		public Photo Thumb { get; set; }

		/// <summary>
		/// Название альбома.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Описание альбома.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Дата и время создания альбома.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// Дата и время последнего обновления альбома.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// Количество фотографий в альбоме.
		/// </summary>
		public int Size { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из JSON
		/// </summary>
		/// <param name="response"> Ответ сервера </param>
		/// <returns> </returns>
		public static Album FromJson(VkResponse response)
		{
			return new Album
			{
				Id = response["album_id"] ?? response["aid"] ?? response["id"],
				Thumb = response["thumb"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Description = response["description"],
				CreateTime = response["created"],
				UpdateTime = response["updated"],
				Size = response["size"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Album" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Album" /></returns>
		public static implicit operator Album(VkResponse response)
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