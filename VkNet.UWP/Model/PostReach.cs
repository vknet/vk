using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Статистика для записи на стене.
	/// </summary>
	public class PostReach
	{
		/// <summary>
		/// Охват подписчиков.
		/// </summary>
		public long ReachSubscribers
		{ get; set; }

		/// <summary>
		/// Суммарный охват.
		/// </summary>
		public long ReachTotal
		{ get; set; }

		/// <summary>
		/// Переходы по ссылке.
		/// </summary>
		public long Links
		{ get; set; }

		/// <summary>
		/// Переходы в сообщество.
		/// </summary>
		public long ToGroup
		{ get; set; }

		/// <summary>
		/// Вступления в сообщество.
		/// </summary>
		public long JoinGroup
		{ get; set; }

		/// <summary>
		/// Количество жалоб на запись.
		/// </summary>
		public long Report
		{ get; set; }

		/// <summary>
		/// Количество скрытий записи.
		/// </summary>
		public long Hide
		{ get; set; }

		/// <summary>
		/// Количество отписавшихся участников.
		/// </summary>
		public long Unsubscribe
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static PostReach FromJson(VkResponse response)
		{
			var postReach = new PostReach
			{
				ReachSubscribers = response["reach_subscribers"],
				ReachTotal = response["reach_total"],
				Links = response["links"],
				ToGroup = response["to_group"],
				JoinGroup = response["join_group"],
				Report = response["report"],
				Hide = response["hide"],
				Unsubscribe = response["unsubscribe"]
			};

			return postReach;
		}
	}
}