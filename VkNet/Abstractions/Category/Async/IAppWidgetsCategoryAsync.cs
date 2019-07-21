using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Abstractions.Category
{
	/// <summary>
	/// Список методов секции appWidgets
	/// </summary>
	public interface IAppWidgetsCategoryAsync
	{
		/// <summary>
		/// Позволяет получить адрес для загрузки фотографии в коллекцию приложения для виджетов приложений сообществ.
		/// </summary>
		/// <param name = "imageType">
		/// Тип изображения. Возможные значения:
		/// 24x24;
		/// 50x50;
		/// 160x160;
		/// 160x240;
		/// 510x128.
		/// обязательный параметр
		/// </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Возвращает объект с единственным полем upload_url, содержащим URL для загрузки изображения.
		/// Для загрузки изображения сгенерируйте POST-запрос с файлом в поле image на полученный адрес, а затем вызовите метод appWidgets.saveAppImage.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.getAppImageUploadServer
		/// </remarks>
		Task<Uri> GetAppImageUploadServerAsync(AppWidgetImageType imageType, CancellationToken cancellationToken = default);

		/// <summary>
		/// Позволяет получить коллекцию изображений, загруженных для приложения, в виджетах приложений сообществ.
		/// </summary>
		/// <param name="offset">Смещение для получения определённого подмножества результатов.</param>
		/// <param name="count">Максимальное число результатов для получения.</param>
		/// <param name="imageType">Тип изображения.</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Возвращает общее число результатов в поле count (integer) и массив объектов, описывающих изображения, в поле items (array).
		/// Каждый объект массива  items содержит следующие поля:
		/// id (string) — идентификатор изображения. Обратите внимание,
		/// идентификаторы изображений для виджетов отличаются от обычных фотографий,
		/// и НЕ представляют собой сочетание owner_id+"_"+photo_id. Полученный идентификатор нужно использовать в коде виджета «как есть».
		/// type (string) — тип изображения. Возможные значения:
		/// 160x160,
		/// 160x240,
		/// 24x24,
		/// 510x128,
		/// 50x50.
		/// images  (array) — массив копий изображения. Каждый объект в массиве содержит следующие поля:
		/// url (string) — URL копии;
		/// width (integer) — ширина в px;
		/// height (integer) — высота в px.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.getAppImages
		/// </remarks>
		Task<Uri> GetAppImagesAsync(int offset, int count, AppWidgetImageType imageType, CancellationToken cancellationToken = default);

		/// <summary>
		/// Позволяет получить адрес для загрузки фотографии в коллекцию сообщества для виджетов приложений сообществ.
		/// </summary>
		/// <param name="imageType">Тип изображения.</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Возвращает объект с единственным полем upload_url, содержащим URL для загрузки изображения.
		/// Для загрузки изображения сгенерируйте POST-запрос с файлом в поле image на полученный адрес, а затем вызовите метод appWidgets.saveGroupImage.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.getGroupImageUploadServer
		/// </remarks>
		Task<Uri> GetGroupImageUploadServerAsync(AppWidgetImageType imageType, CancellationToken cancellationToken = default);

		/// <summary>
		/// Позволяет получить коллекцию изображений, загруженных для приложения, в виджетах приложений сообществ.
		/// </summary>
		/// <param name="offset">Смещение для получения определённого подмножества результатов.</param>
		/// <param name="count">Максимальное число результатов для получения.</param>
		/// <param name="imageType">Тип изображения.</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Возвращает общее число результатов в поле count (integer) и массив объектов, описывающих изображения, в поле items (array).
		/// Каждый объект массива  items содержит следующие поля:
		/// id (string) — идентификатор изображения.
		/// Обратите внимание, идентификаторы изображений для виджетов отличаются от обычных фотографий,
		/// и НЕ представляют собой сочетание owner_id+"_"+photo_id. Полученный идентификатор нужно использовать в коде виджета «как есть».
		/// type (string) — тип изображения. Возможные значения:
		/// 160x160,
		/// 160x240,
		/// 24x24,
		/// 510x128,
		/// 50x50.
		/// images  (array) — массив копий изображения. Каждый объект в массиве содержит следующие поля:
		/// url (string) — URL копии;
		/// width (integer) — ширина в px;
		/// height (integer) — высота в px.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.getGroupImages
		/// </remarks>
		Task<Uri> GetGroupImagesAsync(int offset, int count, AppWidgetImageType imageType, CancellationToken cancellationToken = default);

		/// <summary>
		/// Позволяет получить изображение для виджетов приложений сообществ по его идентификатору.
		/// </summary>
		/// <param name="images">список идентификаторов изображений для получения.</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// id (string) — идентификатор изображения.
		/// Обратите внимание, идентификаторы изображений для виджетов отличаются от обычных фотографий,
		/// и НЕ представляют собой сочетание owner_id+"_"+photo_id. Полученный идентификатор нужно использовать в коде виджета «как есть».
		/// type (string) — тип изображения. Возможные значения:
		/// 160x160,
		/// 160x240,
		/// 24x24,
		/// 510x128,
		/// 50x50.
		/// images  (array) — массив копий изображения. Каждый объект в массиве содержит следующие поля:
		/// url (string) — URL копии;
		/// width (integer) — ширина в px;
		/// height (integer) — высота в px.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.getImagesById
		/// </remarks>
		Task<Uri> GetImagesByIdAsync(string images, CancellationToken cancellationToken = default);

		/// <summary>
		/// Позволяет сохранить изображение в коллекцию приложения для виджетов приложений сообществ после загрузки на сервер.
		/// </summary>
		/// <param name = "hash">
		/// Параметр hash, полученный после загрузки на сервер. строка, обязательный параметр
		/// </param>
		/// <param name = "image">
		/// Параметр image, полученный после загрузки на сервер. строка, обязательный параметр
		/// </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// id (string) — идентификатор изображения.
		/// type (string) — тип изображения. Возможные значения:
		/// 160x160,
		/// 160x240,
		/// 24x24,
		/// 510x128,
		/// 50x50.
		/// images  (array) — массив копий изображения. Каждый объект в массиве содержит следующие поля:
		/// url (string) — URL копии;
		/// width (integer) — ширина в px;
		/// height (integer) — высота в px.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.saveAppImage
		/// </remarks>
		Task<Uri> SaveAppImageAsync(string hash, string image, CancellationToken cancellationToken = default);

		/// <summary>
		/// Позволяет сохранить изображение в коллекцию сообщества для виджетов приложений сообществ. после загрузки на сервер.
		/// </summary>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// id (string) — идентификатор изображения.
		/// type (string) — тип изображения. Возможные значения:
		/// 160x160,
		/// 160x240,
		/// 24x24,
		/// 510x128,
		/// 50x50.
		/// images  (array) — массив копий изображения. Каждый объект в массиве содержит следующие поля:
		/// url (string) — URL копии;
		/// width (integer) — ширина в px;
		/// height (integer) — высота в px.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.saveGroupImage
		/// </remarks>
		Task<Uri> SaveGroupImageAsync(CancellationToken cancellationToken = default);

		/// <summary>
		/// Позволяет обновить виджет приложения сообщества.
		/// </summary>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/appWidgets.update
		/// </remarks>
		Task<bool> UpdateAsync(CancellationToken cancellationToken = default);
	}
}