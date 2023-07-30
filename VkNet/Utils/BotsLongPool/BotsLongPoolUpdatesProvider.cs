#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils.BotsLongPool;

/// <summary>
/// Реализация лонгпула для бота в сообществе
/// </summary>
public class BotsLongPoolUpdatesProvider
{
	private readonly BotsLongPoolUpdatesProviderParams _params;

	private LongPollServerResponse? _lpResponse;

	/// <param name="params">Параметры группового лонгпула</param>
	public BotsLongPoolUpdatesProvider(BotsLongPoolUpdatesProviderParams @params)
	{
		_params = @params;
	}

	/// <summary>
	/// Запуск отслеживания событий
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	public async Task RunAsync(CancellationToken token = default)
	{
		while (true)
		{
			while (_params.GetPause?.Invoke() is not true)
			{
				token.ThrowIfCancellationRequested();
				await NextLongPoolHistoryAsync(token: token);
			}
		}
	}

	private async Task NextLongPoolHistoryAsync(CancellationToken token = default)
	{
		try
		{
			if (_lpResponse is null)
			{
				await UpdateLongPoolServerAsync(true, token);

				if (_lpResponse is null)
				{
					throw new($"{nameof(_lpResponse)} is null");
				}
			}

			var response = await _params.Api.Groups.GetBotsLongPollHistoryAsync<BotsLongPollHistoryResponse<JObject>>(new()
			{
				Key = _lpResponse.Key,
				Server = _lpResponse.Server,
				Ts = _lpResponse.Ts,
				Wait = 25
			}, token);

			var prevTs = long.Parse(_lpResponse.Ts);
			var currentTs = long.Parse(response.Ts);

			// если ВК внезапно пришлёт старый номер события, то мы его проигнорим и прибавим 1 к ts
			if (currentTs <= prevTs && Math.Abs(currentTs - prevTs) <= 500_000)
			{
				IncTs();
			} else
			{
				_lpResponse.Ts = response.Ts;
			}

			var updates = BotsLongPoolHelpers.GetGroupUpdateEvents(response.Updates)
				.ToList();

			if (!updates.Any())
			{
				return;
			}

			_params.OnUpdates?.Invoke(response, updates);
		}
		catch (System.Exception ex)
		{
			await HandleException(ex, token);
		}
	}

	private async Task HandleException(System.Exception ex, CancellationToken token = default)
	{
		switch (ex)
		{
			case LongPollException longPollException:
				await HandleLongPoolException(longPollException, token);

				return;

			case JsonReaderException or JsonSerializationException:
				_params.OnException?.Invoke(ex);
				IncTs();

				return;

			case HttpRequestException or PublicServerErrorException:
				_params.OnWarn?.Invoke(ex);

				return;

			case System.Net.Sockets.SocketException or TaskCanceledException or IOException or WebException:
				return;

			default:
				_params.OnException?.Invoke(ex);

				break;
		}
	}

	/// <summary>
	/// Обработать ошибку, связанную с лонгпулом
	/// </summary>
	/// <param name="exception">Ошибка, связанная с лонгпулом</param>
	/// <param name="token">Токен отмены операции</param>
	private async Task HandleLongPoolException(LongPollException exception, CancellationToken token = default)
	{
		switch (exception)
		{
			case LongPollOutdateException outdatedException:
				if (_lpResponse is null)
				{
					throw new($"{nameof(_lpResponse)} is null");
				}

				_lpResponse.Ts = outdatedException.Ts;

				break;

			default:
				try
				{
					await UpdateLongPoolServerAsync(false, token);
				}
				catch (System.Exception ex)
				{
					await HandleException(ex, token);
				}

				break;
		}
	}

	private void IncTs()
	{
		if (_lpResponse is null)
		{
			throw new($"{nameof(_lpResponse)} is null");
		}

		_lpResponse.Ts = $"{long.Parse(_lpResponse.Ts) + 1}";
	}

	private async Task UpdateLongPoolServerAsync(bool isInit, CancellationToken token = default)
	{
		try
		{
			var prevTs = _lpResponse?.Ts;
			_lpResponse = await _params.Api.Groups.GetLongPollServerAsync(_params.GroupId, token);

			if (!isInit && prevTs is not null)
			{
				_lpResponse.Ts = prevTs;
			} else if (_params.Ts is not null)
			{
				_lpResponse.Ts = _params.Ts;
			}
		}
		catch (System.Exception ex)
		{
			await HandleException(ex, token);
		}
	}
}