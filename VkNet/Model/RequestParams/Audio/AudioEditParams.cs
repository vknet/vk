using System;
using VkNet.Enums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода audio.edit
	/// </summary>
	[Serializable]
	public class AudioEditParams
	{
		/// <summary>
		/// Идентификатор владельца аудиозаписи (пользователь или сообщество). ID
		/// сообщества должен быть отрицательным.
		/// owner_id=1 — пользователь;
		/// owner_id=-1 — сообщество.  целое число, обязательный параметр.
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор аудиозаписи. положительное число, обязательный параметр.
		/// </summary>
		public long AudioId { get; set; }

		/// <summary>
		/// Новое название исполнителя. строка.
		/// </summary>
		public string Artist { get; set; }

		/// <summary>
		/// Новое название композиции. строка.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Новый текст аудиозаписи. строка.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Идентификатор жанра из списка аудио жанров. положительное число.
		/// </summary>
		public AudioGenre? GenreId { get; set; }

		/// <summary>
		/// 1 — аудиозапись не будет доступна в поиске. По умолчанию — 0. флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? NoSearch { get; set; }
	}
}