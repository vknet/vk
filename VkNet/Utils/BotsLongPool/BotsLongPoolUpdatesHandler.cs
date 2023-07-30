#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.BotsLongPool;

/// <summary>
/// Реализация лонгпула для бота в сообществе
/// </summary>
[UsedImplicitly]
public class BotsLongPoolUpdatesHandler : IBotsLongPoolUpdatesHandler
{
	private readonly BotsLongPoolUpdatesHandlerParams _params;

	private ulong? _currentTs;

	private string? _currentSessionKey;

	private string? _currentServer;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="BotsLongPoolUpdatesHandler" />
	/// </summary>
	public BotsLongPoolUpdatesHandler(BotsLongPoolUpdatesHandlerParams @params) => _params = @params;

	/// <summary>
	/// Запуск отслеживания событий
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	[UsedImplicitly]
	public async Task RunAsync(CancellationToken token = default)
	{
		while (!token.IsCancellationRequested)
		{
			while (_params.GetPause?.Invoke() is not true)
			{
				token.ThrowIfCancellationRequested();
				await NextLongPoolHistoryAsync(token: token);
			}

			await Task.Delay(_params.DelayBetweenUpdates, token);
		}
	}

	private async Task NextLongPoolHistoryAsync(CancellationToken token = default)
	{
		try
		{
			if (_currentTs is null)
			{
				await InitCurrentTsAsync(token);

				if (_currentTs is null)
				{
					throw new($"{nameof(_currentTs)} is null");
				}

				VkErrors.ThrowIfNullOrEmpty(() => _currentServer);
				VkErrors.ThrowIfNullOrEmpty(() => _currentSessionKey);
			}

			var response = await _params.Api.Groups.GetBotsLongPollHistoryAsync<BotsLongPollHistoryResponse<JObject>>(new()
			{
				Key = _currentSessionKey,
				Server = _currentServer,
				Ts = _currentTs.Value,
				Wait = _params.WaitTimeout
			}, token);

			var previousTs = _currentTs;
			var currentTs = response.Ts;

			// если ВК внезапно пришлёт старый номер события, то мы его проигнорим и прибавим 1 к ts
			if (currentTs <= previousTs && Math.Abs((long) (currentTs - previousTs.Value)) <= _params.MaxDifferenceTs)
			{
				_params.OnWarn?.Invoke(new($"ВКонтакте прислал устаревший ts. Текущий ts: {_currentTs}. Прошлый ts: {previousTs}."));

				IncTs();
			} else
			{
				_currentTs = currentTs;
			}

			var updates = BotsLongPoolHelpers.GetGroupUpdateEvents(response.Updates);

			if (!updates.Any())
			{
				return;
			}

			_params.OnUpdates?.Invoke(new()
			{
				Response = response,
				Updates = updates
			});
		}
		catch (System.Exception ex)
		{
			await HandleExceptionAsync(ex, token);
		}
	}

	private async Task HandleExceptionAsync(System.Exception exception, CancellationToken token)
	{
		switch (exception)
		{
			case LongPollException longPollException:
				await HandleLongPoolExceptionAsync(longPollException, token);

				return;

			case JsonReaderException or JsonSerializationException:
				_params.OnException?.Invoke(exception);
				IncTs();

				return;

			case HttpRequestException or PublicServerErrorException:
				_params.OnWarn?.Invoke(exception);

				return;

			case SocketException or TaskCanceledException or IOException or WebException:
				return;

			default:
				_params.OnException?.Invoke(exception);

				break;
		}
	}

	/// <summary>
	/// Обработать ошибку, связанную с лонгпулом
	/// </summary>
	/// <param name="exception">Ошибка, связанная с лонгпулом</param>
	/// <param name="token">Токен отмены операции</param>
	private async Task HandleLongPoolExceptionAsync(LongPollException exception, CancellationToken token)
	{
		switch (exception)
		{
			case LongPollOutdateException outdatedException:
				if (_currentTs is null)
				{
					throw new($"{nameof(_currentTs)} is null");
				}

				_currentTs = outdatedException.Ts;

				break;

			default:
				try
				{
					await UpdateLongPoolServerAsync(token);
				}
				catch (System.Exception ex)
				{
					await HandleExceptionAsync(ex, token);
				}

				break;
		}
	}

	private async Task InitCurrentTsAsync(CancellationToken token)
	{
		try
		{
			var response = await _params.Api.Groups.GetLongPollServerAsync(_params.GroupId, token);

			_currentSessionKey = response.Key;
			_currentServer = response.Server;
			_currentTs = _params.Ts ?? response.Ts;
		}
		catch (System.Exception ex)
		{
			await HandleExceptionAsync(ex, token);
		}
	}

	private async Task UpdateLongPoolServerAsync(CancellationToken token)
	{
		try
		{
			var response = await _params.Api.Groups.GetLongPollServerAsync(_params.GroupId, token);
			_currentSessionKey = response.Key;
			_currentServer = response.Server;
			_currentTs ??= response.Ts;
		}
		catch (System.Exception ex)
		{
			await HandleExceptionAsync(ex, token);
		}
	}

	/// <summary>
	/// Увеличить текущий номер события на 1. Это нужно в том случае, если ВК чудит, например - присылает старый номер TS.
	/// А так же это пригодится, если вылезет ошибка JsonSerializationException.
	/// В таком случае мы не сможем получить новый TS и только прибавив 1 мы сможем получить следующий массив обновлений без текущей ошибки.
	/// </summary>
	/// <exception cref="Exception">Этот метод может быть вызван только после вызова InitCurrentTsAsync</exception>
	private void IncTs()
	{
		if (_currentTs is null)
		{
			throw new($"{nameof(_currentTs)} is null");
		}

		_currentTs++;
	}
}