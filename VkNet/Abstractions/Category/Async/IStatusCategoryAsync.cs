﻿using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы со статусом пользователя или сообщества.
/// </summary>
public interface IStatusCategoryAsync
{
	/// <summary>
	/// Получает статус пользователя или сообщества.
	/// </summary>
	/// <param name="userId">
	/// Идентификатор пользователя или сообщества, информацию о статусе которого нужно
	/// получить.
	/// </param>
	/// <param name="groupId">
	/// Идентификатор сообщества, статус которого необходимо получить. положительное
	/// число (Положительное
	/// число).
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// В случае успеха возвращается статус пользователдя или сообщества.
	/// </returns>
	/// <remarks>
	/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
	/// содержащей Settings.Status
	/// Страница документации ВКонтакте http://vk.com/dev/status.get
	/// </remarks>
	Task<Status> GetAsync(long userId,
						long? groupId = null,
						CancellationToken token = default);

	/// <summary>
	/// Устанавливает новый статус текущему пользователю.
	/// </summary>
	/// <param name="text">
	/// Текст статуса, который необходимо установить текущему пользователю. Если
	/// параметр
	/// равен пустой строке, то статус текущего пользователя будет очищен.
	/// </param>
	/// <param name="groupId">
	/// Идентификатор сообщества, в котором будет установлен статус. По умолчанию
	/// статус устанавливается
	/// текущему пользователю.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает true, если статус был успешно установлен, false в
	/// противном случае.
	/// </returns>
	/// <remarks>
	/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
	/// содержащей Settings.Status
	/// Страница документации ВКонтакте http://vk.com/dev/status.set
	/// </remarks>
	Task<bool> SetAsync(string text,
						long? groupId = null,
						CancellationToken token = default);
}