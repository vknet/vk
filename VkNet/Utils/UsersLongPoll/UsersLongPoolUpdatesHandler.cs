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
using VkNet.Utils.BotsLongPoll;

namespace VkNet.Utils.UsersLongPoll;

/// <summary>
/// Реализация лонгпула для пользователя
/// </summary>
[UsedImplicitly]
public class UsersLongPollUpdatesHandler : IUsersLongPollUpdatesHandler
{
	private readonly UsersLongPollUpdatesHandlerParams _params;

	private ulong? _currentTs;

	private ulong? _currentPts;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="BotsLongPollUpdatesHandler" />
	/// </summary>
	public UsersLongPollUpdatesHandler(UsersLongPollUpdatesHandlerParams @params) => _params = @params;

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
				await NextLongPollHistoryAsync(token: token);
			}

			await Task.Delay(_params.DelayBetweenUpdates, token);
		}
	}

	private async Task NextLongPollHistoryAsync(CancellationToken token = default)
	{
		try
		{
			if (_currentPts is null || _currentTs is null)
			{
				await InitCurrentTsAndPtsAsync(token);

				VkErrors.ThrowIfUlongIsNull(() => _currentTs);
			}

			var response = await _params.Api.Messages.GetLongPollHistoryAsync<LongPollHistoryResponse<JObject>>(new()
			{
				Pts = _currentPts,
				Ts = _currentTs!.Value,
			}, token);

			// если сообщений нет - игнорируем
			if (!response.Messages.Any())
			{
				return;
			}

			SetPts(response.NewPts);
			var userMessageEvents = UsersLongPollHelpers.GetUserMessageEvents(response.Messages);

			_params.OnUpdates?.Invoke(new()
			{
				Response = response,
				Messages = userMessageEvents
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
				await HandleLongPollExceptionAsync(longPollException, token);

				return;

			case JsonReaderException or JsonSerializationException:
				_params.OnException?.Invoke(exception);
				IncPts();

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
	private async Task HandleLongPollExceptionAsync(LongPollException exception, CancellationToken token)
	{
		switch (exception)
		{
			case LongPollOutdateException outdatedException:
				if (_currentTs is null)
				{
					throw new($"{nameof(_currentTs)} is null");
				}

				SetTs(outdatedException.Ts);

				break;

			default:
				try
				{
					await UpdateLongPollServerAsync(token);
				}
				catch (System.Exception ex)
				{
					await HandleExceptionAsync(ex, token);
				}

				break;
		}
	}

	private async Task InitCurrentTsAndPtsAsync(CancellationToken token)
	{
		try
		{
			var response = await _params.Api.Messages.GetLongPollServerAsync(groupId: _params.GroupId, token: token);
			SetTs(response.Ts);
			var pts = _params.Pts ?? response.Pts;

			if (pts is not null)
			{
				SetPts(pts.Value);
			}
		}
		catch (System.Exception ex)
		{
			await HandleExceptionAsync(ex, token);
		}
	}

	private async Task UpdateLongPollServerAsync(CancellationToken token)
	{
		try
		{
			var response = await _params.Api.Messages.GetLongPollServerAsync(groupId: _params.GroupId, token: token);
			_currentTs = response.Ts;
			_currentPts = response.Pts;

			if (_currentTs is null)
			{
				SetTs(response.Ts);
			}

			if (_currentPts is null && response.Pts is not null)
			{
				SetPts(response.Pts.Value);
			}
		}
		catch (System.Exception ex)
		{
			await HandleExceptionAsync(ex, token);
		}
	}

	private void SetTs(ulong ts)
	{
		_currentTs = ts;
		_params.OnTsChange?.Invoke(_currentTs.Value);
	}

	private void SetPts(ulong pts)
	{
		_currentPts = pts;
		_params.OnPtsChange?.Invoke(_currentPts.Value);
	}

	/// <summary>
	/// Увеличить текущий номер события на 1. Это нужно в том случае, если ВК чудит, например - присылает старый номер PTS.
	/// А так же это пригодится, если вылезет ошибка JsonSerializationException.
	/// В таком случае мы не сможем получить новый PTS и только прибавив 1 мы сможем получить следующий массив обновлений без текущей ошибки.
	/// </summary>
	/// <exception cref="Exception">Этот метод может быть вызван только после вызова InitCurrentTsAndPtsAsync</exception>
	private void IncPts()
	{
		if (_currentPts is null)
		{
			throw new($"{nameof(_currentPts)} is null");
		}

		SetPts(_currentPts.Value + 1);
	}
}