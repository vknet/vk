using VkNet.Model;

namespace VkNet.Enums
{
	/// <summary>
	/// Статус заявки на изменение имени
	/// </summary>
	public enum ChangeNameStatus
	{
		/// <summary>
		/// Заявка рассматривается
		/// </summary>
		Processing,
		/// <summary>
		/// Заявка отклонена
		/// </summary>
		Declined,
		/// <summary>
		/// Имя было успешно изменено
		/// </summary>
		Success,
		/// <summary>
		/// Недавно уже была одобрена заявка, повторную заявку можно подать не раньше даты, указанной в поле <see cref="ChangeNameRequest.RepeatDate"/>
		/// </summary>
		WasAccepted,
		/// <summary>
		/// Предыдущая заявка была отклонена, повторную заявку можно подать не раньше даты, указанной в поле <see cref="ChangeNameRequest.RepeatDate"/>
		/// </summary>
		WasDeclined
	}

}