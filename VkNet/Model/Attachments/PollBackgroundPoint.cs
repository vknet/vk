using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Точки градиента фона опроса.
	/// </summary>
	[Serializable]
	public class PollBackgroundPoint
	{
		/// <summary>
		/// Положение точки
		/// </summary>
		public int Position { get; set; }

		/// <summary>
		/// HEX-код цвета точки
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PollBackgroundPoint FromJson(VkResponse response)
		{
			return new PollBackgroundPoint
			{
				Color = response["color"],
				Position = response["position"]
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PollBackgroundPoint(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}