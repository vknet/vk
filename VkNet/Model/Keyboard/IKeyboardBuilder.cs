using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.Keyboard
{
	/// <summary>
	/// Конструктор клавиатур
	/// </summary>
	public interface IKeyboardBuilder
	{
		/// <summary>
		/// Добавить кнопку
		/// </summary>
		/// <param name="label">Надписть на кнопке</param>
		/// <param name="extra">Дополнительная информация о кнопке</param>
		/// <param name="type">Основная информация о кнопке</param>
		/// <param name="color">Цвет кнопки</param>
		/// <param name="actionType">Тип клавиши</param>
		/// <param name="intent">Любой из интентов, требующий подписки.</param>
		/// <param name="subscribeId">Дополнительное поле для confirmed_notification.</param>
		/// <param name="peerId">user_id: 1-2e9</param>
		/// <returns>Конструктор клавиатур</returns>
		IKeyboardBuilder AddButton(string label, string extra, KeyboardButtonColor color = default, string type = null,
									KeyboardButtonActionType? actionType = null, Intent? intent = null, byte? subscribeId = null,
									long? peerId = null);

		/// <summary>
		/// Добавить кнопку
		/// </summary>
		/// <param name="buttonAction">Действие при нажатии на кнопку</param>
		/// <param name="color">Цвет кнопки</param>
		/// <returns>Конструктор клавиатур</returns>
		IKeyboardBuilder AddButton(MessageKeyboardButtonAction buttonAction, KeyboardButtonColor color = default(KeyboardButtonColor));

		/// <summary>
		/// Добавить строку в клавиатуру
		/// </summary>
		/// <returns>Конструктор клавиатур</returns>
		IKeyboardBuilder AddLine();

		/// <summary>
		/// Сделать клавиатуру одноразовой
		/// </summary>
		/// <returns>Конструктор клавиатур</returns>
		IKeyboardBuilder SetOneTime();

		/// <summary>
		/// Сделать отображение клавиатуры внутри сообщения
		/// </summary>
		/// <returns>Конструктор клавиатур</returns>
		IKeyboardBuilder SetInline(bool inline = true);

		/// <summary>
		/// Удалить все добавленные кнопки и строки из клавиатуры
		/// </summary>
		/// <returns>Конструктор клавиатур</returns>
		IKeyboardBuilder Clear();

		/// <summary>
		/// Построить
		/// </summary>
		/// <returns>Клавиатура</returns>
		MessageKeyboard Build();
	}
}