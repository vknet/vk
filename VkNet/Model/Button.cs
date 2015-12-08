using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Кнопка.
	/// </summary>
	public class Button
	{
		/// <summary>
		/// Название кнопки.
		/// </summary>
		public string Title;

		/// <summary>
		/// Ссылка на которую ведет кнопка.
		/// </summary>
		public Uri Url;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Button FromJson(VkResponse response)
		{
			var button = new Button
			{
				Title = response["title"],
				Url = response["url"]
			};

			return button;
		}
	}
}