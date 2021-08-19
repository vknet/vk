using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры для метода SavePhoto
	/// </summary>
	[Serializable]
	public class SavePhotoParams
	{
		/// <summary>
		/// Строка полученная в результате загрузки фотографии.
		/// </summary>
		public string Photo { get; set; }

		/// <summary>
		/// Хеш полученный в результате загрузки фотографии.
		/// </summary>
		public string Hash { get; set; }
	}
}