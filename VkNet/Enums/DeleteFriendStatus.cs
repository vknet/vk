using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Возвращаемый статус после удаления пользователя из списка друзей
	/// </summary>
	public enum DeleteFriendStatus
	{
		/// <summary>
		/// Неопределенный статус ответа
		/// </summary>
		[DefaultValue]
		Unknown = 0

		, /// <summary>
		/// Пользователь удален из списка друзей
		/// </summary>
		UserIsDeleted = 1

		, /// <summary>
		/// Заявка на добавление в друзья от данного пользователя отклонена
		/// </summary>
		RequestRejected = 2

		, /// <summary>
		/// Рекомендация добавить в друзья данного пользователя удалена
		/// </summary>
		RecommendationDeleted = 3
	}
}