using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Keyboard
{
	/// <summary>
	/// Параметры для создания кнопки в билдере
	/// </summary>
	[Serializable]
	public class AddButtonParams
	{
		/// <summary>
		/// Надписть на кнопке
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// Дополнительная информация о кнопке
		/// </summary>
		public string Extra { get; set; }

		/// <summary>
		/// Цвет кнопки
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public KeyboardButtonColor Color { get; set; } = default;

		/// <summary>
		/// Основная информация о кнопке
		/// </summary>
		public string? Type { get; set; } = null;

		/// <summary>
		/// Тип клавиши
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public KeyboardButtonActionType ActionType { get; set; }

		/// <summary>
		/// Любой из интентов, требующий подписки.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public Intent Intent { get; set; }

		/// <summary>
		/// Дополнительное поле для confirmed_notification.
		/// </summary>
		public byte? SubscribeId { get; set; }

		/// <summary>
		/// user_id: 1-2e9
		/// </summary>
		public long? PeerId { get; set; }
	}
}