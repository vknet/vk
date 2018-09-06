using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Подарок.
	/// </summary>
	[Serializable]
	public class Gift : MediaAttachment
	{
		/// <summary>
		/// Подарок.
		/// </summary>
		static Gift()
		{
			RegisterType(type: typeof(Gift), match: "gift");
		}

		/// <summary>
		/// Изображение 48х48.
		/// </summary>
		public Uri Thumb48 { get; set; }

		/// <summary>
		/// Изображение 96х96.
		/// </summary>
		public Uri Thumb96 { get; set; }

		/// <summary>
		/// Изображение 256х256.
		/// </summary>
		public Uri Thumb256 { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Gift FromJson(VkResponse response)
		{
			var gift = new Gift
			{
					Id = response[key: "id"]
					, Thumb48 = response[key: "thumb_48"]
					, Thumb96 = response[key: "thumb_96"]
					, Thumb256 = response[key: "thumb_256"]
			};

			return gift;
		}
	}
}