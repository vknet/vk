using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
    public partial class OrdersCategory : IOrdersCategory
    {
        /// <summary>
        /// API.
        /// </summary>
        private readonly IVkApiInvoke _vk;
        /// <inheritdoc/>
        /// <param name = "api">
        /// Api vk.com
        /// </param>
        public OrdersCategory(IVkApiInvoke api)
        {
            _vk = api;
		}

		/// <inheritdoc/>
		/// <summary>
		/// Отменяет подписку.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя. 
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name="subscriptionId">
		/// Идентификатор подписки. 
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name="pendingCancel">
		/// 1 — отключить подписку по истечении текущего оплаченного периода;
		/// 0 — отключить подписку сразу.
		/// флаг, может принимать значения 1 или 0, по умолчанию 0
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1. При отмене подписки на адрес обратного вызова будет отправлено платёжное уведомление с типом subscription_status_change.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.cancelSubscription
		/// </remarks>
		public bool CancelSubscription(ulong userId, ulong subscriptionId, bool? pendingCancel = null)
        {
            return _vk.Call<bool>("orders.cancelSubscription", new VkParameters{{"user_id", userId}, {"subscription_id", subscriptionId}, {"pending_cancel", pendingCancel}});
        }

		/// <inheritdoc/>
		/// <summary>
		/// Изменяет состояние заказа.
		/// </summary>
		/// <param name="orderId">
		/// Идентификатор заказа. 
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name="action">
		/// Действие, которое нужно произвести с заказом.
		/// строка, обязательный параметр
		/// Возможные действия:
		/// cancel — отменить неподтверждённый заказ.
		/// charge — подтвердить неподтверждённый заказ. Применяется только если не удалось обработать уведомление order_change_state.
		/// refund — отменить подтверждённый заказ.
		/// </param>
		/// <param name="appOrderId">
		/// Внутренний идентификатор заказа в приложении.
		/// положительное число
		/// </param>
		/// <param name="testMode">
		/// Если этот параметр равен 1, возвращается список заказов тестового режима. По умолчанию 0.
		/// флаг, может принимать значения 1 или 0
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает новый статус заказа. 
		/// Статусы заказа:
		/// chargeable — неподтверждённый заказ. В это состояние заказы попадают в случае, если магазин не обрабатывает уведомления.
		/// declined — отменённый заказ на этапе получения информации о товаре, например, была получена ошибка 20,
		/// "Товара не существует". В это состояние заказ может попасть из состояния chargeable.
		/// cancelled — отменённый заказ. В это состояние заказ может попасть из состояния chargeable.
		/// charged — оплаченный заказ. В это состояние заказ может попасть из состояния chargeable,
		/// либо сразу после оплаты, если приложение обрабатывает уведомления.
		/// refunded — отменённый после оплаты заказ, голоса возвращены пользователю.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.changeState
		/// </remarks>
		public object ChangeState(ulong orderId, string action, ulong? appOrderId = null, bool? testMode = null)
        {
            return _vk.Call<object>("orders.changeState", new VkParameters{{"order_id", orderId}, {"action", action}, {"app_order_id", appOrderId}, {"test_mode", testMode}});
        }

		/// <inheritdoc/>
		/// <summary>
		/// Возвращает список заказов.
		/// </summary>
		/// <param name="offset">
		/// Смещение относительно самого нового найденного заказа для выборки определенного подмножества.
		/// положительное число, по умолчанию 0
		/// </param>
		/// <param name="count">
		/// Количество возвращаемых заказов.
		/// положительное число, максимальное значение 1000, по умолчанию 100
		/// </param>
		/// <param name="testMode">
		/// Если этот параметр равен 1, возвращается список заказов тестового режима. По умолчанию 0.
		/// флаг, может принимать значения 1 или 0
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает массив найденных заказов, отсортированный по дате в обратном порядке (самый новый в начале).
		/// Статусы заказа:
		/// chargeable — неподтверждённый заказ. В это состояние заказы попадают в случае, если магазин не обрабатывает уведомления.
		/// declined — отменённый заказ на этапе получения информации о товаре, например, была получена ошибка 20,
		/// "Товара не существует". В это состояние заказ может попасть из состояния chargeable.
		/// cancelled — отменённый заказ. В это состояние заказ может попасть из состояния chargeable.
		/// charged — оплаченный заказ. В это состояние заказ может попасть из состояния chargeable,
		/// либо сразу после оплаты, если приложение обрабатывает уведомления.
		/// refunded — отменённый после оплаты заказ, голоса возвращены пользователю.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.get
		/// </remarks>
		public IEnumerable<object> Get(ulong? offset = null, ulong? count = null, bool? testMode = null)
        {
            return _vk.Call<IEnumerable<object>>("orders.get", new VkParameters{{"offset", offset}, {"count", count}, {"test_mode", testMode}});
        }

		/// <inheritdoc/>
		/// <summary>
		/// Возвращает ненулевые значения счетчиков пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, 
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name="votes"> Cписок голосов. Например: 1,7,77.
		/// Cписок слов, разделенных через запятую, обязательный параметр,
		/// количество элементов должно составлять не более 100
		/// </param>
		/// <returns>
		/// Возвращает валюту пользователя и массив результатов для каждого значения из votes.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.getAmount
		/// </remarks>
		public IEnumerable<VotesAmount> GetAmount(ulong userId, IEnumerable<string> votes)
        {
            return _vk.Call<IEnumerable<VotesAmount>>("orders.getAmount", new VkParameters{{"user_id", userId}, {"votes", votes}});
        }

		/// <inheritdoc/>
		/// <summary>
		/// Возвращает информацию об отдельном заказе.
		/// </summary>
		/// <param name="orderId">
		/// Идентификатор заказа.
		/// положительное число
		/// </param>
		/// <param name="orderIds">
		/// Идентификаторы заказов (при запросе информации о нескольких заказах).
		/// список положительных чисел, разделенных запятыми
		/// </param>
		/// <param name="testMode">
		/// Если этот параметр равен 1, возвращаются заказы тестового режима. По умолчанию 0.
		/// флаг, может принимать значения 1 или 0
		/// </param>
		/// <returns>
		/// Возвращается массив найденных заказов, отсортированный по дате в обратном порядке (самый новый в начале).
		/// Статусы заказа:
		/// chargeable — неподтверждённый заказ. В это состояние заказы попадают в случае, если магазин не обрабатывает уведомления.
		/// declined — отменённый заказ на этапе получения информации о товаре, например, была получена ошибка 20,
		/// "Товара не существует". В это состояние заказ может попасть из состояния chargeable.
		/// cancelled — отменённый заказ. В это состояние заказ может попасть из состояния chargeable.
		/// charged — оплаченный заказ. В это состояние заказ может попасть из состояния chargeable,
		/// либо сразу после оплаты, если приложение обрабатывает уведомления.
		/// refunded — отменённый после оплаты заказ, голоса возвращены пользователю.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.getById
		/// </remarks>
		public IEnumerable<object> GetById(ulong? orderId = null, IEnumerable<ulong> orderIds = null, bool? testMode = null)
        {
            return _vk.Call<IEnumerable<object>>("orders.getById", new VkParameters{{"order_id", orderId}, {"order_ids", orderIds}, {"test_mode", testMode}});
        }

		/// <inheritdoc/>
		/// <summary>
		/// Получает информацию о подписке по её идентификатору.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, 
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name="subscriptionId">
		/// Идентификатор подписки. 
		/// Положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// Возвращает объект, описывающий подписку. Содержит следующие поля:
		/// id — идентификатор подписки.
		/// item_id  — идентификатор товара в приложении.
		/// status  — статус подписки. Возможные значения:
		/// chargeable — неподтвержденная подписка;
		/// active — подписка активна;
		/// cancelled — подписка отменена.
		/// price  — стоимость подписки.
		/// period  — период подписки.
		/// create_time  — дата создания в Unixtime.
		/// update_time  — дата обновления в Unixtime.
		/// period_start_time  — дата начала периода в Unixtime.
		/// next_bill_time — дата следующего платежа в Unixtime (если status = active).
		/// trial_expire_time — дата истечения триал-периода (если есть).
		/// pending_cancel — true, если подписка ожидает отмены.
		/// cancel_reason — причина отмены (если есть). Возможные значения:
		/// user_decision — по инициативе пользователя;
		/// app_decision — по инициативе приложения;
		/// payment_fail — из-за проблемы с платежом;
		/// unknown — причина неизвестна.
		/// test_mode — true, если используется тестовый режим.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.getUserSubscriptionById
		/// </remarks>
		public SubscriptionItem GetUserSubscriptionById(ulong userId, ulong subscriptionId)
        {
            return _vk.Call<SubscriptionItem>("orders.getUserSubscriptionById", new VkParameters{{"user_id", userId}, {"subscription_id", subscriptionId}});
        }

		/// <inheritdoc/>
		/// <summary>
		/// Получает список активных подписок пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, подписки которого необходимо получить. 
		/// положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект,
		/// содержащий число результатов в поле count и массив объектов,
		/// описывающих подписку, в поле items.
		/// Каждый объект массива items содержит следующие поля: 
		/// id — идентификатор подписки.
		/// item_id  — идентификатор товара в приложении.
		/// status  — статус подписки. Возможные значения:
		/// chargeable — неподтвержденная подписка;
		/// active — подписка активна;
		/// cancelled — подписка отменена.
		/// price  — стоимость подписки.
		/// period  — период подписки.
		/// create_time  — дата создания в Unixtime.
		/// update_time  — дата обновления в Unixtime.
		/// period_start_time  — дата начала периода в Unixtime.
		/// next_bill_time — дата следующего платежа в Unixtime (если status = active).
		/// trial_expire_time — дата истечения триал-периода (если есть).
		/// pending_cancel — true, если подписка ожидает отмены.
		/// cancel_reason — причина отмены (если есть). Возможные значения:
		/// user_decision — по инициативе пользователя;
		/// app_decision — по инициативе приложения;
		/// payment_fail — из-за проблемы с платежом;
		/// unknown — причина неизвестна.
		/// test_mode — true, если используется тестовый режим.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.getUserSubscriptions
		/// </remarks>
		public IEnumerable<SubscriptionItem> GetUserSubscriptions(ulong userId)
        {
            return _vk.Call<IEnumerable<SubscriptionItem>>("orders.getUserSubscriptions", new VkParameters{{"user_id", userId}});
        }

		/// <inheritdoc/>
		/// <summary>
		/// Обновляет цену подписки для пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя.
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name="subscriptionId">
		/// идентификатор подписки. Подписка должна быть активна. 
		/// положительное число, обязательный параметр
		/// </param>
		/// <param name="price">
		/// Новая стоимость подписки (должна быть ниже, чем текущая). 
		/// положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 (true)
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/orders.updateSubscription
		/// </remarks>
		public bool UpdateSubscription(ulong userId, ulong subscriptionId, ulong price)
        {
            return _vk.Call<bool>("orders.updateSubscription", new VkParameters{{"user_id", userId}, {"subscription_id", subscriptionId}, {"price", price}});
        }
    }
}