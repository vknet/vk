using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Внешние сервисы, в которые настроен экспорт из ВК
	/// </summary>
	[DataContract]
	public class Exports
	{
		/// <summary>
		/// Twitter
		/// </summary>
		public bool Twitter { get; set; }
		/// <summary>
		/// Facebook
		/// </summary>
		public bool Facebook { get; set; }
		/// <summary>
		/// LiveJournal
		/// </summary>
		public bool Livejournal { get; set; }
		/// <summary>
		/// Instagram
		/// </summary>
		public bool Instagram { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Exports FromJson(VkResponse response)
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