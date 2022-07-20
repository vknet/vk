using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Keyboard;

namespace VkNet.Model.Template.Carousel
{
	/// <summary>
	/// Конструктор элемента карусели
	/// </summary>
	public interface ICarouselElementBuilder
	{
		/// <summary>
		/// Заголовок карусели
		/// </summary>
		string Title { get; }

		/// <summary>
		/// Подзаголовок карусели
		/// </summary>
		string Description { get; }

		/// <summary>
		/// ID прикрепленного фото
		/// </summary>
		string PhotoId { get; }

		/// <summary>
		/// Действие при нажатии на элемент карусели
		/// </summary>
		CarouselElementAction Action { get; }

		/// <summary>
		/// Список кнопок в карусели
		/// </summary>
		List<MessageKeyboardButton> Buttons { get; }

		/// <summary>
		/// Добавить кнопку
		/// </summary>
		/// <param name="label">Надпись на кнопке</param>
		/// <param name="extra">Дополнительная информация о кнопке</param>
		/// <param name="type">Основная информация о кнопке</param>
		/// <param name="color">Цвет кнопки</param>
		/// <exception cref="TooMuchButtonsException">Максимальное число кнопок не больше трех</exception>
		/// <exception cref="VkKeyboardPayloadMaxLengthException">Максимальная длина payload 255 символов для одной кнопки
		/// и 1000 символов для всех кнопок вместе</exception>
		/// <returns>Конструктор элемента карусели</returns>
		ICarouselElementBuilder AddButton(string label,
										string extra,
										KeyboardButtonColor color = default(KeyboardButtonColor),
										string type = null);

		/// <summary>
		/// Установить заголовок элемента карусели
		/// </summary>
		/// <param name="title">Заголовок, максимум 80 символов</param>
		/// <returns>Конструктор элемента карусели</returns>
		ICarouselElementBuilder SetTitle(string title);

		/// <summary>
		/// Установить подзаголовок элемента карусели
		/// </summary>
		/// <param name="description">Подзаголовок, максимум 80 символов</param>
		/// <returns>Конструктор элемента карусели</returns>
		ICarouselElementBuilder SetDescription(string description);

		/// <summary>
		/// Установить прикрепленное изображение
		/// </summary>
		/// <param name="photoId">
		/// Id изображения, которое надо прикрепить.
		/// Пропорции изображения: 13/8.
		/// Минимальный размер: 221х136.
		/// Пример: -123218_50548844
		/// </param>
		/// <returns>Конструктор элемента карусели</returns>
		ICarouselElementBuilder SetPhotoId(string photoId);

		/// <summary>
		/// Установить действие при нажатии
		/// </summary>
		/// <param name="action">Объект, описывающий действие, которое необходимо выполнить при нажатии на элемент карусели</param>
		/// <returns>Конструктор элемента карусели</returns>
		ICarouselElementBuilder SetAction(CarouselElementAction action);

		/// <summary>
		/// Удалить все добавленные кнопки
		/// </summary>
		/// <returns>Конструктор элемента карусели</returns>
		ICarouselElementBuilder ClearButtons();

		/// <summary>
		/// Построить элемент карусели
		/// </summary>
		/// <returns>Элемент карусели</returns>
		CarouselElement Build();
	}
}
