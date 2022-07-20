using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с каруселями.
	/// <remarks>
	/// Карусель — набор карточек, которые прикрепляются к записи.
	/// К каждой карточке можно добавить название и короткое описание, изображение, кнопку.
	/// Также можно установить две цены — старую и новую — например, чтобы показать скидку.
	/// На текущий момент карусель поддерживается только в скрытых рекламных записях (см. wall.postAdsStealth).
	/// </remarks>
	/// </summary>
	public interface IPrettyCardsCategoryAsync
	{
		/// <summary>
		/// Метод создаёт карточку карусели.
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/prettyCards.create
		/// </remarks>
		Task<PrettyCardsCreateResult> CreateAsync(PrettyCardsCreateParams @params);

		/// <summary>
		/// Метод удаляет карточку карусели.
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/prettyCards.delete
		/// </remarks>
		Task<PrettyCardsDeleteResult> DeleteAsync(PrettyCardsDeleteParams @params);

		/// <summary>
		/// Метод редактирует карточку карусели.
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/prettyCards.edit
		/// </remarks>
		Task<PrettyCardsEditResult> EditAsync(PrettyCardsEditParams @params);

		/// <summary>
		/// Метод возвращает неиспользованные карточки владельца.
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/prettyCards.get
		/// </remarks>
		Task<VkCollection<PrettyCardsGetByIdResult>> GetAsync(PrettyCardsGetParams @params);

		/// <summary>
		/// Метод возвращает информацию о карточке.
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/prettyCards.getById
		/// </remarks>
		Task<ReadOnlyCollection<PrettyCardsGetByIdResult>> GetByIdAsync(PrettyCardsGetByIdParams @params);

		/// <summary>
		/// Метод возвращает URL для загрузки фотографии для карточки.
		/// Для карточек используются квадратные изображения минимальным размером 400х400.
		/// В случае загрузки неквадратного изображения, оно будет обрезано до квадратного.
		/// Загрузка изображения для карточки на сервер ВКонтакте осуществляется в 3 этапа:
		/// 1. С помощью метода prettyCards.getUploadURL приложение узнает HTTP-адрес для загрузки изображения.
		/// Один адрес можно использовать только для загрузки одного изображения.
		/// 2. Приложение формирует POST-запрос на полученный адрес для сохранения изображения на сервере ВКонтакте.
		/// Запрос должен содержать поле file, которое содержит файл с изображением (JPG, PNG, BMP, TIFF или GIF).
		/// Максимальный объем файла: 5 Мб.
		/// Результат загрузки изображения возвращается приложению в формате JSON.
		/// </summary>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/prettyCards.getUploadURL
		/// </remarks>
		Task<Uri> GetUploadUrlAsync();
	}
}