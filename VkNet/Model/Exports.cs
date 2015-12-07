using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Внешние сервисы, в которые настроен экспорт из ВК
	/// </summary>
	public class Exports
	{
		/// <summary>
		/// Twitter
		/// </summary>
		public bool Twitter;
		/// <summary>
		/// Facebook
		/// </summary>
		public bool Facebook;
		/// <summary>
		/// LiveJournal
		/// </summary>
		public bool Livejournal;
		/// <summary>
		/// Instagram
		/// </summary>
		public bool Instagram;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Exports FromJson(VkResponse response)
		{
			var exports = new Exports
			{
				Twitter = response["twitter"],
				Facebook = response["facebook"],
				Livejournal = response["livejournal"],
				Instagram = response["instagram"]
			};

			return exports;
		}
	}
}