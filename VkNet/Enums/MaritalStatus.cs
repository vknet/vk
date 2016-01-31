using System.ComponentModel.DataAnnotations;
using VkNet.Properties;

namespace VkNet.Enums
{
	/// <summary>
	/// Семейное положение: 1 — Не женат, 2 — Встречается, 3 — Помолвлен, 4 — Женат, 7 — Влюблён, 5 — Всё сложно, 6 — В активном поиске.
	/// </summary>
	public enum MaritalStatus
	{
		/// <summary>
		/// Не женат
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "MaritalStatus_Single")]
		Single = 1,
		/// <summary>
		/// Встречается
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "MaritalStatus_Meets")]
		Meets,
		/// <summary>
		/// Помолвлен
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "MaritalStatus_Engaged")]
		Engaged,
		/// <summary>
		/// Женат
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "MaritalStatus_Married")]
		Married,
		/// <summary>
		/// Всё сложно
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "MaritalStatus_ItsComplicated")]
		ItsComplicated,
		/// <summary>
		/// В активном поиске
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "MaritalStatus_TheActiveSearch")]
		TheActiveSearch,
		/// <summary>
		/// Влюблён
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "MaritalStatus_InLove")]
		InLove
	}
}