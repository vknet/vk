using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Вырезанная фотография пользователя
	/// </summary>
	[Serializable]
	public class Rect
	{
		/// <summary>
		/// x
		/// </summary>
		public uint X { get; set; }

		/// <summary>
		/// x2
		/// </summary>
		public uint X2 { get; set; }

		/// <summary>
		/// y
		/// </summary>
		public uint Y { get; set; }

		/// <summary>
		/// y2
		/// </summary>
		public uint Y2 { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Rect FromJson(VkResponse response)
		{
			var crop = new Rect
			{
					X = response[key: "x"]
					, X2 = response[key: "x2"]
					, Y = response[key: "y"]
					, Y2 = response[key: "y2"]
			};

			return crop;
		}
	}
}