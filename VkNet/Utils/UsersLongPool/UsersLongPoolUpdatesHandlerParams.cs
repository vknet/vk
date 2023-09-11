#nullable enable
using System;
using JetBrains.Annotations;
using VkNet.Abstractions;

namespace VkNet.Utils.UsersLongPool;

/// <summary>
/// Параметры для конструктора UsersLongPoolUpdatesHandler
/// </summary>
[UsedImplicitly]
public class UsersLongPoolUpdatesHandlerParams
{
	/// <summary>
	/// Айди группы, от которой получать данные
	/// </summary>
	public ulong? GroupId { get; set; }

	/// <summary>
	/// Номер, с которого начинать получать события.
	/// Рекомендуется помещать сюда значение из response.Pts в функции OnUpdates.
	/// </summary>
	public ulong? Pts { get; set; } = null;

	/// <summary>
	/// Авторизованный экземпляр VKApi.
	/// </summary>
	public IVkApi Api { get; set; }

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="UsersLongPoolUpdatesHandlerParams" />
	/// </summary>
	public UsersLongPoolUpdatesHandlerParams(IVkApi api)
	{
		Api = api;
	}

	/// <summary>
	/// Ожидание между обработкой событий при простое
	/// </summary>
	public TimeSpan DelayBetweenUpdates { get; set; } = TimeSpan.FromSeconds(1);

	/// <summary>
	/// Функция, которая возвращает true, если работа лонгпула должна быть приостановлена
	/// Понадобится, когда вы безопасно завершаете работу приложения или просто захотите временно остановить бота и не потерять последние события.
	/// </summary>
	public Func<bool>? GetPause { get; set; } = null;

	/// <summary>
	/// Функция, в которую будут отправлены полученные события.
	/// </summary>
	public Action<UsersLongPoolOnUpdatesEvent>? OnUpdates { get; set; } = null;

	/// <summary>
	/// Функция, в которую будет отправляться TS при каждом его обновлении.
	/// </summary>
	public Action<ulong>? OnTsChange { get; set; } = null;

	/// <summary>
	/// Функция, в которую будет отправляться PTS при каждом его обновлении.
	/// </summary>
	public Action<ulong>? OnPtsChange { get; set; } = null;

	/// <summary>
	/// Эта функция вызывается при критических ошибках в лонгпуле (например JsonSerializationException)
	/// </summary>
	public Action<System.Exception>? OnException { get; set; } = null;

	/// <summary>
	/// Функция, в которую будут отправлены незначительные или временные ошибки (например - SocketException или ошибки связанные с интернетом или с доступом к ВКонтакте)
	/// </summary>
	public Action<System.Exception>? OnWarn { get; set; } = null;
}