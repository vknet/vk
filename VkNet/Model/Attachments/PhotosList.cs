using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.UWP.Model.Attachments
{
	/// <summary>
	/// </summary>
	[Obsolete("Для версии API ниже 5.0")]
	[Serializable]
	public class PhotosList : MediaAttachment
	{
		protected override string Alias => "photos_list";

	#region Private Methods

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static PhotosList FromJson(VkResponse response)
		{
			return new PhotosList();
		}

		/// <summary>
		/// Преобразование класса <see cref="PhotosList" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="PhotosList" /></returns>
		public static implicit operator PhotosList(VkResponse response)
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