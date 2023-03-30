﻿using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Leads;

namespace VkNet.Abstractions;

/// <summary>
/// Leads При подключении к сервису рекламных акций партнёр получает доступ в
/// специальный раздел для создания и
/// управления рекламными акциями (офферами).
/// </summary>
public interface ILeadsCategoryAsync
{
	/// <summary>
	/// Проверяет, доступна ли рекламная акция пользователю.
	/// </summary>
	/// <param name="checkUserParams">
	/// Входные параметры запроса.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает объект, содержащий поля:
	/// result — признак того, может ли пользователь начать акцию (true/false), а
	/// также, в случае auto_start=1, признак
	/// успешного старта акции,
	/// reason — в случае result=false, описание причины, по которой пользователь не
	/// может начать акцию,
	/// start_link — в случае result=true и auto_start=0, ссылка, по которой должен
	/// перейти пользователь для начала акции.
	/// sid — в случае result=true и auto_start=1, идентификатор сессии начатой акции.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/leads.checkUser
	/// </remarks>
	Task<Checked> CheckUserAsync(CheckUserParams checkUserParams,
								CancellationToken token = default);

	/// <summary>
	/// Завершает начатую пользователем рекламную акцию, используя сессию и секретный
	/// ключ.
	/// </summary>
	/// <param name="vkSid">
	/// Cессия, полученная GET параметром при старте акции. строка, обязательный
	/// параметр
	/// </param>
	/// <param name="secret">
	/// Секретный ключ, доступный в интерфейсе тестирования рекламной акции. строка,
	/// обязательный параметр
	/// </param>
	/// <param name="comment">
	/// Комментарий строка
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// При успешном завершении оффера будет возвращен объект, содержащий следующие
	/// поля:
	/// limit — ограничение, установленное у текущего оффера;
	/// spent — количество потраченных на акцию голосов;
	/// cost — стоимость одной выполненной акции;
	/// test_mode — режим транзакции (1 — тестовый, 0 — реальный);
	/// success — результат выполнения транзакции (всегда равно 1).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/leads.complete
	/// </remarks>
	Task<LeadsComplete> CompleteAsync(string vkSid,
									string secret,
									string comment,
									CancellationToken token = default);

	/// <summary>
	/// Возвращает статистику по рекламной акции.
	/// </summary>
	/// <param name="leadId">
	/// Идентификатор рекламной акции, доступный в интерфейсе тестирования рекламных
	/// акций. положительное число,
	/// обязательный параметр
	/// </param>
	/// <param name="secret">
	/// Секретный ключ, доступный в интерфейсе тестирования рекламной акции. строка
	/// </param>
	/// <param name="dateStart">
	/// Идентификатор дня, начиная с которого необходимо вернуть статистику в формате
	/// Y-m-d (8-и значное число). Например,
	/// 2011-09-17. строка
	/// </param>
	/// <param name="dateEnd">
	/// Идентификатор дня, до которого необходимо вернуть статистику в формате Y-m-d
	/// (8-и значное число). Например,
	/// 2011-09-19. строка
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// При успешном завершении оффера будет возвращен объект, содержащий следующие
	/// поля:
	/// limit — ограничения в голосах на текущую рекламную акцию;
	/// spent — количество голосов, уже потраченных на рекламную акцию;
	/// cost — стоимость (в голосах) одного прохождения;
	/// impressions — количество показов акций;
	/// started — количество начатых акций;
	/// completed — количество пройденных акций;
	/// days — данное поле возвращается, только если переданы входные параметры
	/// date_start и date_end.
	/// Параметр days Объект days содержит следующие поля:
	/// impressions — показы;
	/// started — начатые акции;
	/// completed — законченные акции;
	/// spent — потрачено голосов.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/leads.getStats
	/// </remarks>
	Task<Lead> GetStatsAsync(ulong leadId,
							string secret,
							string dateStart,
							string dateEnd,
							CancellationToken token = default);

	/// <summary>
	/// Возвращает список последних действий пользователей по рекламной акции.
	/// </summary>
	/// <param name="getUsersParams">
	/// Входные параметры запроса.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает массив объектов entry, каждый из которых
	/// содержит поля:
	/// uid — идентификатор пользователя;
	/// aid — идентификатор приложения, из которого было выполнено действие;
	/// sid — идентификатор сессии;
	/// date — время действия в формате unixtime;
	/// start_date — время начала действия в формате unixtime для status = 1;
	/// status — 0 - начало действия, 1 - завершение действия, 2 - блокирование
	/// пользователя;
	/// test_mode — 0 - рабочий режим, 1 - тестовый режим;
	/// comment — текст комментария.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/leads.getUsers
	/// </remarks>
	Task<ReadOnlyCollection<Entry>> GetUsersAsync(GetUsersParams getUsersParams,
												CancellationToken token = default);

	/// <summary>
	/// Засчитывает событие метрики.
	/// </summary>
	/// <param name="data">
	/// Данные метрики, полученные в личном кабинете рекламной акции. обязательный
	/// параметр
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает объект, содержащий поля:
	/// result - равен true в случае успеха, и false в обратном случае,
	/// redirect_link - возвращается в случае, когда пользователя нужно перенаправить
	/// по указанной ссылке.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/leads.metricHit
	/// </remarks>
	Task<MetricHitResponse> MetricHitAsync(string data,
											CancellationToken token = default);

	/// <summary>
	/// Создаёт новую сессию для прохождения рекламной акции для пользователя.
	/// </summary>
	/// <param name="startParams">
	/// Входные параметры запроса.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// При успешном старте рекламной акции будет возвращен объект содержащий следующие
	/// поля:
	/// test_mode — режим транзакции (1 — тестовый, 0 — реальный);
	/// vk_sid — сессия рекламной акции.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/leads.start
	/// </remarks>
	Task<Start> StartAsync(StartParams startParams,
							CancellationToken token = default);
}