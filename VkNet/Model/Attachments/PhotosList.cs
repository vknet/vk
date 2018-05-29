using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.UWP.Model.Attachments
{
	/// <summary>
	/// </summary>
	[Obsolete(message: "Для версии API ниже 5.0")]
	[Serializable]
	public class PhotosList : MediaAttachment
	{
		static PhotosList()
		{
			RegisterType(type: typeof(PhotosList), match: "photos_list");
		}

	#region Private Methods

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static PhotosList FromJson(VkResponse response)
		{
			var list = new PhotosList();

			return list;
		}

	#endregion
	}
}