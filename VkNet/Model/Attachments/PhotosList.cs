using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.UWP.Model.Attachments
{
	/// <inheritdoc />
	/// <summary>
	/// Список фото
	/// </summary>
	[Obsolete("Для версии API ниже 5.0")]
	[Serializable]
	public class PhotosList : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "photos_list";

	#region Private Methods

		/// <summary>
		/// Преобразование класса <see cref="PhotosList" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="PhotosList" /> </returns>
		public static implicit operator PhotosList(VkResponse response)
		{
			return response == null ? null : new PhotosList();
		}

	#endregion
	}
}