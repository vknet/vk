using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с местами.
	/// </summary>
	public interface IPlacesCategoryAsync
	{
		/// <summary>
		/// Добавляет новое место в базу географических мест.
		/// </summary>
		/// <param name="placesAddParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного места (pid).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/places.add
		/// </remarks>
		Task<long> AddAsync(PlacesAddParams placesAddParams);

		/// <summary>
		/// Отмечает пользователя в указанном месте.
		/// </summary>
		/// <param name="placesCheckinParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданной отметки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/places.checkin
		/// </remarks>
		Task<long> CheckinAsync(PlacesCheckinParams placesCheckinParams);

		/// <summary>
		/// Возвращает информацию о местах по их идентификаторам.
		/// </summary>
		/// <param name="places">
		/// Перечисленные через запятую идентификаторы мест список положительных чисел,
		/// разделенных запятыми, обязательный
		/// параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает массив объектов place, каждый из которых
		/// имеет следующие поля:
		/// id — идентификатор места;
		/// title — название места;
		/// latitude — географическая широта, заданная в градусах (от -90 до 90);
		/// longitude — географическая долгота, заданная в градусах (от -180 до 180);
		/// created — дата добавления места в формате unixtime.
		/// Также, при наличии соответствующей информации, в объект могут включаться поля
		/// checkins, updated, type, country,
		/// city, address.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/places.getById
		/// </remarks>
		Task<ReadOnlyCollection<Place>> GetByIdAsync(IEnumerable<ulong> places);

		/// <summary>
		/// Возвращает список отметок пользователей в местах согласно заданным параметрам.
		/// </summary>
		/// <param name="placesGetCheckinsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает количество отметок и массив объектов
		/// chekin, каждый из которых имеет
		/// следующие поля:
		/// id — идентификатор отметки;
		/// user_id — идентификатор отметившегося пользователя;
		/// date — дата добавления отметки в формате unixtime;
		/// latitude — географическая широта, заданная в градусах (от -90 до 90);
		/// longitude — географическая долгота, заданная в градусах (от -180 до 180);
		/// place_id — идентификатор места;
		/// text — текст сопроводительного сообщения;
		/// distance — расстояние от места до заданной точки.
		/// Если в запросе был задан параметр need_places, то в объекте могут дополнительно
		/// содержаться следующие поля:
		/// place_title — наименование места;
		/// place_country — идентификатор страны;
		/// place_city — идентификатор города;
		/// place_address — адрес;
		/// place_type — тип места;
		/// place_icon.
		/// Если не заданы параметры latitude и longitude или параметр place, то будет
		/// возвращена лента обновлений отметок
		/// друзей. При указании параметра timestamp будут возвращены только те отметки из
		/// ленты обновлений, которые были
		/// созданы после указанного значения timestamp. Если timestamp не указан, то
		/// отметки из ленты будут возвращены с
		/// учетом параметров offset и count (если они заданы).
		/// Если заданы параметры latitude и longitude, то будут возвращены все отметки,
		/// сделанные за последние 24 часа,
		/// координаты которых находятся недалеко от Вас. Если задан параметр friends_only,
		/// то будут возвращены только
		/// последние ближайшие отметки Ваших друзей.
		/// Если задан параметр place, то будут возвращены последние 20 отметок, сделанные
		/// в месте с идентификатором, указанном
		/// в параметре place.
		/// Если задан параметр uid, то будут возвращены последние 20 отметок, сделанные
		/// пользователем с идентификатором,
		/// указанном в параметре uid.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/places.getCheckins
		/// </remarks>
		Task<VkCollection<Checkin>> GetCheckinsAsync(PlacesGetCheckinsParams placesGetCheckinsParams);

		/// <summary>
		/// Возвращает список всех возможных типов мест.
		/// </summary>
		/// <returns>
		/// Возвращает массив всех возможных типов мест, каждый из объектов которого
		/// содержит поля tid, title и icon.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/places.getTypes
		/// </remarks>
		Task<ReadOnlyCollection<PlaceType>> GetTypesAsync();

		/// <summary>
		/// Возвращает список мест, найденных по заданным условиям поиска.
		/// </summary>
		/// <param name="placesSearchParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает общее количество найденных мест и массив
		/// объектов place, каждый из которых
		/// имеет следующие поля:
		/// id — идентификатор места;
		/// title — название места;
		/// latitude — географическая широта, заданная в градусах (от -90 до 90);
		/// longitude — географическая долгота, заданная в градусах (от -180 до 180);
		/// created — дата добавления места;
		/// type — тип места;
		/// icon — иконка (url изображения);
		/// checkins — количество чекинов;
		/// updated — дата последнего чекина;
		/// type — идентификатор типа места;
		/// country — идентификатор страны;
		/// city — идентификатор города;
		/// address — адрес;
		/// distance — расстояние от исходной точки.
		/// Если место прикреплено к сообществу, дополнительно возвращаются поля group_id и
		/// group_photo.
		/// Если не задан параметр radius, то по умолчанию он будет иметь значение 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/places.search
		/// </remarks>
		Task<VkCollection<Place>> SearchAsync(PlacesSearchParams placesSearchParams);
	}
}