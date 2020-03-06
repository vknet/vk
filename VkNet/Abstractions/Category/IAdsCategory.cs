﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы этого класса позволяют производить действия с рекламными кабинетам
	/// пользователя.
	/// </summary>
	public interface IAdsCategory : IAdsCategoryAsync
	{
		/// <summary>
		/// Добавляет администраторов и/или наблюдателей в рекламный кабинет.
		/// </summary>
		/// <param name = "adsDataSpecification">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает массив значений - ответов на каждый запрос в массиве data. Соответствующее значение в выходном массиве равно true, если администратор успешно добавлен, и false в другом случае.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.addOfficeUsers
		/// </remarks>
		ReadOnlyCollection<bool> AddOfficeUsers(AdsDataSpecificationParams<UserSpecification> adsDataSpecification);

		/// <summary>
		/// Проверяет ссылку на рекламируемый объект.
		/// </summary>
		/// <param name="checkLinkParams"></param>
		/// <returns>
		/// Возвращается структура со следующими полями:
		/// status — статус ссылки:
		/// allowed — ссылку допустимо использовать в рекламных объявлениях;
		/// disallowed — ссылку недопустимо использовать для указанного вида рекламируемого объекта;
		/// in_progress — ссылка проверяется, необходимо немного подождать.
		/// description (если status равен disallowed, необязательное поле) — описание причины недопустимости использования ссылки.
		/// redirect_url (если конечная ссылка отличается от исходной и если status равен allowed) — конечная ссылка.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.checkLink
		/// </remarks>
		LinkStatus CheckLink(CheckLinkParams checkLinkParams);

		/// <summary>
		/// Создает рекламные объявления.
		/// </summary>
		/// <param name="adsDataSpecification"></param>
		/// <returns>
		/// Возвращает массив объектов - ответов на каждый запрос в массиве data. Соответствующий объект в выходном массиве имеет свойство id, соответствующее id созданного объявления (или 0 в случае неудачи), а также, возможно, поля error_code и error_desc, описывающие ошибку, при ее возникновении. Наличие одновременно ненулевого id и error_code говорит о том, что объявление было создано, однако, возможно, не все параметры установлены (например, объявление не запущено).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.createAds
		/// </remarks>
		ReadOnlyCollection<CreateAdsResult> CreateAds(AdsDataSpecificationParams<AdSpecification> adsDataSpecification);

		/// <summary>
		/// Создает рекламные кампании.
		/// </summary>
		/// <param name="campaignsDataSpecification"></param>
		/// <returns>
		/// Возвращает массив ответов на запросы в массиве data. Соответствующий объект в выходном массиве содержит id созданной кампании (ноль в случае неудачи), и поля error_code и error_desc в случае возникновения ошибки. Ненулевой id и наличие error_code 602 говорит о том, что кампания создана, но, возможно, некоторые поля не были ей присвоены по причине их некорректности.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.createCampaigns
		/// </remarks>
		ReadOnlyCollection<CreateCampaignResult> CreateCampaigns(AdsDataSpecificationParams<CampaignSpecification> campaignsDataSpecification);

		/// <summary>
		/// Создаёт клиентов рекламного агентства.
		/// </summary>
		/// <param name="clientDataSpecification"></param>
		/// <returns>
		/// Возвращает массив ответов на запросы в массиве data. Соответствующий объект в выходном массиве содержит id созданного клиента (ноль в случае неудачи), и поля error_code и error_desc в случае возникновения ошибки. Ненулевой id и наличие error_code 602 говорит о том, что клиент создан, но, возможно, некоторые поля не были ему присвоены по причине их некорректности.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.createClients
		/// </remarks>
		ReadOnlyCollection<CreateClientResult> CreateClients(AdsDataSpecificationParams<ClientSpecification> clientDataSpecification);

		/// <summary>
		/// Создаёт запрос на поиск похожей аудитории.
		/// </summary>
		/// <param name="createLookALikeRequestParams"></param>
		/// <returns>
		/// Поле request_id, в котором указан идентификатор созданного запроса на поиск похожей аудитории.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.createLookalikeRequest
		/// </remarks>
		CreateLookALikeRequestResult CreateLookalikeRequest(CreateLookALikeRequestParams createLookALikeRequestParams);

		/// <summary>
		/// Создает аудиторию для ретаргетинга рекламных объявлений на пользователей, которые посетили сайт рекламодателя (просмотрели информации о товаре, зарегистрировались и т.д.).
		/// </summary>
		/// <param name = "createTargetGroupParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает объект со следующими полями:
		/// id — идентификатор аудитории.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.createTargetGroup
		/// </remarks>
		CreateTargetGroupResult CreateTargetGroup(CreateTargetGroupParams createTargetGroupParams);

		/// <summary>
		/// Создаёт пиксель ретаргетинга.
		/// </summary>
		/// <param name="createTargetPixelParams"></param>
		/// <returns>
		/// Возвращает объект со следующими полями:
		/// id — идентификатор пикселя
		/// pixel — код для размещения на сайте рекламодателя
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.createTargetPixel
		/// </remarks>
		CreateTargetPixelResult CreateTargetPixel(CreateTargetPixelParams createTargetPixelParams);

		/// <summary>
		/// Архивирует рекламные объявления.
		/// </summary>
		/// <param name="deleteAdsParams"></param>
		/// <returns>
		/// Возвращает массив ответов на каждый запрос. Каждый ответ является либо 0, что означает успешное удаление, либо код ошибки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.deleteAds
		/// </remarks>
		ReadOnlyCollection<bool> DeleteAds(DeleteAdsParams deleteAdsParams);

		/// <summary>
		/// Архивирует рекламные кампании.
		/// </summary>
		/// <param name="deleteCampaignsParams"></param>
		/// <returns>
		/// Возвращает массив ответов на каждый запрос. Каждый ответ является либо 0, что означает успешное удаление, либо код ошибки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.deleteCampaigns
		/// </remarks>
		ReadOnlyCollection<bool> DeleteCampaigns(DeleteCampaignsParams deleteCampaignsParams);

		/// <summary>
		/// Архивирует клиентов рекламного агентства.
		/// </summary>
		/// <param name="deleteClientsParams"></param>
		/// <returns>
		/// Возвращает массив ответов на каждый запрос. Каждый ответ является либо 0, что означает успешное удаление, либо код ошибки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.deleteClients
		/// </remarks>
		ReadOnlyCollection<bool> DeleteClients(DeleteClientsParams deleteClientsParams);

		/// <summary>
		/// Удаляет аудиторию ретаргетинга.
		/// </summary>
		/// <param name="deleteTargetGroupParams"></param>
		/// <returns>
		/// В случае успеха метод возвратит 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.deleteTargetGroup
		/// </remarks>
		bool DeleteTargetGroup(DeleteTargetGroupParams deleteTargetGroupParams);

		/// <summary>
		/// Удаляет пиксель ретаргетинга.
		/// </summary>
		/// <param name="deleteTargetPixelParams"></param>
		/// <returns>
		/// В случае успеха метод возвратит 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.deleteTargetPixel
		/// </remarks>
		bool DeleteTargetPixel(DeleteTargetPixelParams deleteTargetPixelParams);

		/// <summary>
		/// Возвращает список рекламных кабинетов.
		/// </summary>
		/// <returns>
		/// Возвращает массив объектов, описывающих рекламные кабинеты. Каждый объект содержит следующие поля:
		/// account_id
		/// integerидентификатор рекламного кабинета. account_type
		/// stringтип рекламного кабинета. Возможные значения:
		/// general — обычный;
		/// agency — агентский. account_status
		/// integer, [0,1]статус рекламного кабинета. Возможные значения:
		/// 1 — активен;
		/// 0 — неактивен. access_role
		/// stringправа пользователя в рекламном кабинете. Возможные значения:
		/// admin — главный администратор;
		/// manager — администратор;
		/// reports — наблюдатель.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getAccounts
		/// </remarks>
		ReadOnlyCollection<AdsAccount> GetAccounts();

		/// <summary>
		/// Возвращает список рекламных объявлений.
		/// </summary>
		/// <param name = "getAdsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает массив объектов, описывающих объявления. Каждый объект содержит следующие поля:
		/// id
		/// integerидентификатор объявления. campaign_id
		/// integerидентификатор кампании. ad_format
		/// integerформат объявления. Возможные значения:
		/// 1 — изображение и текст;
		/// 2 — большое изображение;
		/// 3 — эксклюзивный формат;
		/// 4 — продвижение сообществ или приложений, квадратное изображение;
		/// 5 — приложение в новостной ленте (устаревший);
		/// 6 — мобильное приложение;
		/// 9 — запись в сообществе. cost_type
		/// integer, [0,1]тип оплаты. Возможные значения:
		/// 0 — оплата за переходы;
		/// 1 — оплата за показы. cpc
		/// integer(если cost_type = 0) цена за переход в копейках. cpm
		/// integer(если cost_type = 1) цена за 1000 показов в копейках. impressions_limit
		/// integer(если задано) ограничение количества показов данного объявления на одного пользователя. Может присутствовать для некоторых форматов объявлений, для которых разрешена установка точного значения. impressions_limited
		/// integer, [1](если задано) признак того, что количество показов объявления на одного пользователя ограничено. Может присутствовать для некоторых объявлений, для которых разрешена установка ограничения, но не разрешена установка точного значения. 1 — не более 100 показов на одного пользователя. ad_platform(если значение применимо к данному формату объявления) рекламные площадки, на которых будет показываться объявление. Возможные значения:
		/// (если ad_format равен 1)
		/// 0 — ВКонтакте и сайты-партнёры;
		/// 1 — только ВКонтакте.
		/// (если ad_format равен 9)
		/// all — все площадки;
		/// desktop — полная версия сайта;
		/// mobile — мобильный сайт и приложения. ad_platform_no_wall
		/// integer, [1]1 — для объявления задано ограничение «Не показывать на стенах сообществ». all_limit
		/// integerобщий лимит объявления в рублях. 0 — лимит не задан. category1_id
		/// integerID тематики или подраздела тематики объявления. См. ads.getCategories. category2_id
		/// integerID тематики или подраздела тематики объявления. Дополнительная тематика. status
		/// integerстатус объявления. Возможные значения:
		/// 0 — объявление остановлено;
		/// 1 — объявление запущено;
		/// 2 — объявление удалено. name
		/// stringназвание объявления. approved
		/// integerстатус модерации объявления. Возможные значения:
		/// 0 — объявление не проходило модерацию;
		/// 1 — объявление ожидает модерации;
		/// 2 — объявление одобрено;
		/// 3 — объявление отклонено. video
		/// integer, [1]1 — объявление является видеорекламой. disclaimer_medical
		/// integer, [1]1 — включено отображение предупреждения:
		/// «Есть противопоказания. Требуется консультация специалиста.» disclaimer_specialist
		/// integer, [1]1 — включено отображение предупреждения:
		/// «Необходима консультация специалистов.» disclaimer_supplements
		/// integer, [1]1 — включено отображение предупреждения:
		/// «БАД. Не является лекарственным препаратом.» events_retargeting_groups
		/// arrayТолько для ad_format = 9. Описание событий, собираемых в группы ретаргетинга. Массив объектов, где ключом является id группы ретаргетинга, а значением - массив событий. Допустимые значений для событий:
		/// 1 — просмотр промопоста;
		/// 2 — переход по ссылке или переход в сообщество;
		/// 3 — переход в сообщество;
		/// 4 — подписка на сообщество;
		/// 5 — отписка от новостей сообщества;
		/// 6 — скрытие или жалоба;
		/// 10 — запуск видео;
		/// 11 — досмотр видео до 3с;
		/// 12 — досмотр видео до 25%;
		/// 13 — досмотр видео до 50%;
		/// 14 — досмотр видео до 75%;
		/// 15 — досмотр видео до 100%;
		/// 20 — лайк продвигаемой записи;
		/// 21 — репост продвигаемой записи.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getAds
		/// </remarks>
		ReadOnlyCollection<Ad> GetAds(GetAdsParams getAdsParams);

		/// <summary>
		/// Возвращает описания внешнего вида рекламных объявлений.
		/// </summary>
		/// <param name = "getAdsLayoutParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает массив объектов, описывающих объявления. Каждый объект содержит следующие поля:
		/// id
		/// integer&gt;идентификатор объявления. campaign_id
		/// integer&gt;идентификатор кампании. ad_format
		/// integerформат объявления. Возможные значения:
		/// 1 — изображение и текст;
		/// 2 — большое изображение;
		/// 3 — эксклюзивный формат;
		/// 4 — продвижение сообществ или приложений, квадратное изображение;
		/// 5 — приложение в новостной ленте (устаревший);
		/// 6 — мобильное приложение;
		/// 7 — специальный формат приложений;
		/// 8 — специальный формат сообществ;
		/// 9 — запись в сообществе;
		/// 10 — витрина приложений. cost_type
		/// integer, [0,1]тип оплаты. Возможные значения:
		/// 0 — оплата за переходы;
		/// 1 — оплата за показы. video
		/// integer, [1]1 — объявление является видеорекламой. title
		/// stringзаголовок объявления. description
		/// stringописание объявления. link_url
		/// stringссылка на рекламируемый объект. link_domain
		/// stringдомен рекламируемого сайта. preview_link
		/// stringссылка, перейдя по которой можно просмотреть рекламное объявление так, как оно выглядит на сайте. Ссылка доступна в течение 30 минут после выполнения метода ads.getAdsLayout. image_src
		/// stringurl изображения объявления. image_src_2x
		/// stringurl изображения двойного разрешения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getAdsLayout
		/// </remarks>
		ReadOnlyCollection<Layout> GetAdsLayout(GetAdsLayoutParams getAdsLayoutParams);

		/// <summary>
		/// Возвращает параметры таргетинга рекламных объявлений
		/// </summary>
		/// <param name = "getAdsTargetingParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает массив объектов - описаний таргетинга объявлений.
		/// Отрицательные id в поле cities означают id регионов, взятых с обратным знаком.
		/// Поле count содержит размер целевой аудитории на момент сохранения объявления.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getAdsTargeting
		/// </remarks>
		ReadOnlyCollection<AdsTargetingResult> GetAdsTargeting(GetAdsTargetingParams getAdsTargetingParams);

		/// <summary>
		/// Возвращает текущий бюджет рекламного кабинета.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает единственное число — оставшийся бюджет в указанном рекламном кабинете.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getBudget
		/// </remarks>
		double GetBudget(long accountId);

		/// <summary>
		/// Возвращает список кампаний рекламного кабинета.
		/// </summary>
		/// <param name="adsGetCampaignsParams"></param>
		/// <returns>
		/// Возвращает массив объектов campaign, каждый из которых содержит следующие поля:
		/// id — идентификатор кампании
		/// type — тип кампании
		/// normal — обычная кампания, в которой можно создавать любые объявления, кроме мобильной рекламы и записей в сообществе
		/// vk_apps_managed — кампания, в которой можно рекламировать только администрируемые Вами приложения и у которой есть отдельный бюджет
		/// mobile_apps — кампания, в которой можно рекламировать только мобильные приложения
		/// promoted_posts — кампания, в которой можно рекламировать только записи в сообществе
		/// name — название кампании
		/// status — статус кампании
		/// 0 — кампания остановлена
		/// 1 — кампания запущена
		/// 2 — кампания удалена
		/// day_limit — дневной лимит кампании в рублях
		/// 0 — лимит не задан
		/// all_limit — общий лимит кампании в рублях
		/// 0 — лимит не задан
		/// start_time — время запуска кампании в формате unixtime
		/// 0 — время не задано
		/// stop_time — время остановки кампании в формате unixtime
		/// 0 — время не задано
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getCampaigns
		/// </remarks>
		ReadOnlyCollection<AdsCampaign> GetCampaigns(AdsGetCampaignsParams adsGetCampaignsParams);

		/// <summary>
		/// Позволяет получить возможные тематики рекламных объявлений.
		/// </summary>
		/// <param name = "lang">
		/// Язык, на котором нужно вернуть результаты. Список поддерживаемых языков Вы можете найти на странице Запросы к API. строка
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает два массива объектов — v1 и v2, каждый из которых содержит объекты, описывающие тематики в следующем формате:
		/// id — идентификатор тематики;
		/// name — название тематики;
		/// subcategories[subcategory] (если есть хотя бы один подраздел) — список подразделов. Массив объектов, каждый из которых содержит следующие поля:
		/// id — идентификатор подраздела;
		/// name — название подраздела.
		/// Массив v1 включает устаревшие тематики. Актуальный список содержится в массиве v2.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getCategories
		/// </remarks>
		GetCategoriesResult GetCategories(Language lang);

		/// <summary>
		/// Возвращает список клиентов рекламного агентства.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает массив объектов client — клиентов агентства с номером account_id, каждый из которых содержит следующие поля:
		/// id — идентификатор клиента;
		/// name — название клиента;
		/// day_limit — дневной лимит клиента в рублях;
		/// all_limit — общий лимит клиента в рублях.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getClients
		/// </remarks>
		ReadOnlyCollection<GetClientsResult> GetClients(long accountId);

		/// <summary>
		/// Возвращает демографическую статистику по рекламным объявлениям или кампаниям.
		/// </summary>
		/// <param name = "getDemographicsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Каждый запрашиваемый объект имеет следующие поля:
		/// id — id объекта из параметра ids
		/// type — тип объекта из параметра ids_type
		/// stats — список структур описывающих статистику объекта за один временной период (конкретный временной период присутствует в списке, если по нему есть какая-то статистика)
		/// Структура в списке stats имеет следующие поля:
		/// day (если period равен day) — день в формате YYYY-MM-DD
		/// month (если period равен month) — месяц в формате YYYY-MM
		/// overall (если period равен overall) — 1
		/// sex — список структур, описывающих статистику по полу
		/// age — список структур, описывающих статистику по возрасту
		/// sex_age — список структур, описывающих статистику по полу и возрасту
		/// cities — список структур, описывающих статистику по городам
		/// Структура в списках sex, age, sex_age, cities имеет следующие поля:
		/// impressions_rate — часть аудитории, просмотревшая объявление, от 0 до 1
		/// clicks_rate — часть аудитории, кликнувшая по объявлению, от 0 до 1
		/// value — значение демографического показателя, имеет разные возможные значения для разных показателей
		/// sex (f — женщины, m — мужчины)
		/// age — один из следующих промежутков: 12-18, 18-21, 21-24, 24-27, 27-30, 30-35, 35-45, 45-100
		/// sex_age — комбинация значений sex и age, разделённых точкой с запятой, пример: m;21-24
		/// cities — id города или other для остальных городов
		/// name — наглядное название значения указанного в value (только для городов)
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getDemographics
		/// </remarks>
		ReadOnlyCollection<GetDemographicsResult> GetDemographics(GetDemographicsParams getDemographicsParams);

		/// <summary>
		/// Возвращает информацию о текущем состоянии счетчика — количество оставшихся запусков методов и время до следующего обнуления счетчика в секундах.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает объект, содержащий следующие поля:
		/// left — количество оставшихся методов;
		/// refresh — время до следующего обновления в секундах.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getFloodStats
		/// </remarks>
		GetFloodStatsResult GetFloodStats(long accountId);

		/// <summary>
		/// Возвращает список запросов на поиск похожей аудитории.
		/// </summary>
		/// <param name = "getLookalikeRequestsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Если limit не равен 0, то возвращается объект с двумя полями:
		///
		/// count — количество запросов на поиск похожей аудитории в данном кабинете.
		/// items — список объектов-запросов на поиск похожей аудитории запрошенного размера с запрошенным сдвигом.
		/// При limit равном 0, возвращается только поле count.
		/// Описание запроса на поиск похожей аудитории – объект со следующими полями:
		/// id — идентификатор запроса на поиск похожей аудитории. Является уникальным только в рамках конкретного кабинета (клиента в случае агентства).
		/// create_time — timestamp даты создания запроса.
		/// update_time — timestamp даты последнего обновления статуса запроса.
		/// status — текущий статус запроса, может принимать следующие значения: search_in_progress, search_done, search_failed, save_in_progress, save_done, save_failed.
		/// scheduled_delete_time —  timestamp даты запланированного удаления запроса.
		/// source_type — тип источника исходной аудитории для поиска похожей аудитории. Может принимать только значение retargeting_group.
		/// source_retargeting_group_id — при source_type равном retargeting_group в данном поле указан идентификатор аудитории ретаргетинга с исходной аудиторией.
		/// source_name — имя источника исходной аудитории. При source_type равном retargeting_group в данном поле указано название аудитории ретаргетинга на момент создания запроса.
		/// audience_count — размер исходной аудитории.
		/// save_audience_levels — Список доступных размеров аудитории для сохранения. Присутствует только после успешного поиска похожей аудитории. Поля:
		/// level — используется в качестве параметра level в ads.saveLookalikeRequestResult
		/// audience_count — размер похожей аудитории в данной опции.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getLookalikeRequests
		/// </remarks>
		GetLookalikeRequestsResult GetLookalikeRequests(GetLookalikeRequestsParams getLookalikeRequestsParams);

		/// <summary>
		/// Возвращает список администраторов и наблюдателей рекламного кабинета.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает массив объектов - описаний пользователей рекламного кабинета. Каждый объект содержит массив описаний прав доступа к конкретным клиентам. Описание содержит два поля: client_id — id клиента и role — строка admin, manager или reports. Для admin client_id не указывается.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getOfficeUsers
		/// </remarks>
		ReadOnlyCollection<GetOfficeUsersResult> GetOfficeUsers(long accountId);

		/// <summary>
		/// Возвращает подробную статистику по охвату рекламных записей из объявлений и кампаний для продвижения записей сообщества.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <param name = "idsType">
		/// Тип запрашиваемых объектов, которые перечислены в параметре ids:
		/// ad — объявления;
		/// campaign — кампании.
		/// обязательный параметр, строка
		/// </param>
		/// <param name = "ids">
		/// Перечисленные через запятую id запрашиваемых объявлений или кампаний, в зависимости от того, что указано в параметре ids_type. Максимум 100 объектов. обязательный параметр, строка
		/// </param>
		/// <returns>
		/// Возвращает массив объектов, описывающих охват. Каждый объект содержит следующие поля:
		/// id
		/// integerID объекта из параметра ids. reach_subscribers
		/// integerохват подписчиков. reach_total
		/// integerсуммарный охват. links
		/// integerпереходы по ссылке. to_group
		/// integerпереходы в сообщество. join_group
		/// integerвступления в сообщество. report
		/// integerколичество жалоб на запись. hide
		/// integerколичество скрытий записи. unsubscribe
		/// integerколичество отписавшихся участников. video_views_start*
		/// integerколичество стартов просмотра видео. video_views_3s*
		/// integerколичество досмотров видео до 3 секунд. video_views_25p*
		/// integerколичество досмотров видео до 25 процентов. video_views_50p*
		/// integerколичество досмотров видео до 50 процентов. video_views_75p*
		/// integerколичество досмотров видео до 75 процентов. video_views_100p*
		/// integerколичество досмотров видео до 100 процентов.
		/// * — поля с данными по статистике видео возвращаются только для объявлений или кампаний с видео, созданных после 26 января 2017 года.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getPostsReach
		/// </remarks>
		ReadOnlyCollection<GetPostsReachResult> GetPostsReach(long accountId, IdsType idsType, string ids);

		/// <summary>
		/// Возвращает причину, по которой указанному объявлению было отказано в прохождении премодерации.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <param name = "adId">
		/// Идентификатор рекламного объявления. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает объект, который может содержать поле comment, содержащее текстовый комментарий модератора, и/или массив rules, содержащий описание нарушенных объявлением правил. Ответ обязательно содержит хотя бы одно из полей comment или rules. Каждый элемент массива rules состоит из поля title (текстового пояснения) и массива paragraphs, каждый элемент которого содержит отдельный пункт правил. Элементы массива paragraphs могут содержать простую html-разметку.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getRejectionReason
		/// </remarks>
		GetRejectionReasonResult GetRejectionReason(long accountId, long adId);

		/// <summary>
		/// Возвращает статистику показателей эффективности по рекламным объявлениям, кампаниям, клиентам или всему кабинету.
		/// </summary>
		/// <param name = "getStatisticsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Каждый запрашиваемый объект имеет следующие поля:
		/// id — id объекта из параметра ids
		/// type — тип объекта из параметра ids_type
		/// stats — список структур описывающих статистику объекта за один временной период (конкретный временной период присутствует в списке, если по нему есть какая-то статистика)
		/// Структура в списке stats имеет следующие поля:
		/// day (если period равен day) — день в формате YYYY-MM-DD
		/// month (если period равен month) — день в формате YYYY-MM
		/// overall (если period равен overall) — 1
		/// spent — потраченные средства
		/// impressions — просмотры
		/// clicks — клики
		/// reach (если ids_type равен ad или campaign и period равен day или month) — охват
		/// video_views (если ids_type равен ad) — просмотры видеоролика (для видеорекламы)
		/// video_views_half (если ids_type равен ad) — просмотры половины видеоролика (для видеорекламы)
		/// video_views_full (если ids_type равен ad) — просмотры целого видеоролика (для видеорекламы)
		/// video_clicks_site (если ids_type равен ad) — переходы на сайт рекламодателя из видеорекламы (для видеорекламы)
		/// join_rate (если ids_type равен ad или campaign) — вступления в группу, событие, подписки на публичную страницу или установки приложения (только если в объявлении указана прямая ссылка на соответствующую страницу ВКонтакте)
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getStatistics
		/// </remarks>
		ReadOnlyCollection<GetStatisticsResult> GetStatistics(GetStatisticsParams getStatisticsParams);

		/// <summary>
		/// Возвращает набор подсказок для различных параметров таргетинга.
		/// </summary>
		/// <param name = "getSuggestionsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает список объектов (подсказок), удовлетворяющих запросу.
		/// Для разделов countries, positions, interest_categories, religions, user_devices, user_os, user_browsers ответ возвращается в виде массива объектов со следующими полями:
		/// id — идентификатор объекта
		/// name — название объекта
		/// Для раздела regions ответ возвращается в виде массива объектов со следующими полями:
		/// id — идентификатор региона
		/// name — название региона
		/// type (необязательное) — название типа региона (область, автономный округ, край)
		/// Для разделов cities, districts, streets ответ возвращается в виде массива объектов со следующими полями:
		/// id — идентификатор объекта
		/// name — название объекта
		/// parent — название города или страны, в котором находится объект
		/// Для раздела schools ответ возвращается в виде массива объектов со следующими полями:
		/// id — идентификатор учебного заведения
		/// name — название учебного заведения
		/// desc — полное название учебного заведения
		/// type — тип учебного заведения
		/// school — школа
		/// university — университет
		/// faculty — факультет
		/// chair — кафедра
		/// parent — название города, в котором находится учебное заведение
		/// Для раздела interests ответ возвращается в виде массива строк.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getSuggestions
		/// </remarks>
		ReadOnlyCollection<GetSuggestionsResult> GetSuggestions(GetSuggestionsParams getSuggestionsParams);

		/// <summary>
		/// Возвращает список аудиторий ретаргетинга.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <param name = "clientId">
		/// Только для рекламных агентств.
		/// id клиента, в рекламном кабинете которого находятся аудитории. целое число
		/// </param>
		/// <param name = "extended">
		/// Если 1, в результатах будет указан код для размещения на сайте.
		/// Устаревший параметр. Используется только для старых групп ретаргетинга, которые пополнялись без помощи пикселя. Для новых аудиторий его следует опускать. флаг, может принимать значения 1 или 0
		/// </param>
		/// <returns>
		/// Возвращает массив объектов, описывающих группы ретаргетинга. Каждый объект содержит следующие поля:
		/// id (integer) — идентификатор аудитории;
		/// name (string) — название аудитории ретаргетинга;
		/// last_updated (integer) — дата и время последнего пополнения аудитории в формате Unixtime;
		/// is_audience (integer, 1) — 1, если группа является аудиторией (т.е.может быть пополнена при помощи пикселя);
		/// is_shared (integer, 1) — 1, если группа является копией (см. метод ads.shareTargetGroup);
		/// audience_count (integer) — приблизительное количество пользователей, входящих в аудиторию;
		/// lifetime (integer) — количество дней, через которое пользователи, добавляемые в аудиторию ретаргетинга, будут автоматически исключены из неё;
		/// file_source (integer, 1) — признак пополнения аудитории через файл;
		/// api_source (integer, 1) — признак пополнения аудитории через метод ads.importTargetContacts;
		/// lookalike_source (integer, 1) — признак аудитории, полученной при помощи Look-a-Like.
		/// pixel (string) — код для размещения на сайте рекламодателя. Возвращается, если параметр extended = 1 (только для старых групп).
		/// domain (string) — домен сайта, где размещен код учета пользователей (только для старых групп).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getTargetGroups
		/// </remarks>
		ReadOnlyCollection<GetTargetGroupsResult> GetTargetGroups(long accountId, long? clientId = null, bool? extended = null);

		/// <summary>
		/// Возвращает список пикселей ретаргетинга.
		/// </summary>
		/// <param name = "accountId">
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </param>
		/// <param name = "clientId">
		/// Только для рекламных агентств.
		/// id клиента, в рекламном кабинете которого находятся пиксели. целое число
		/// </param>
		/// <returns>
		/// Возвращает массив объектов, каждый из которых содержит следующие поля:
		/// target_pixel_id (integer) — идентификатор пикселя;
		/// name (string) — название пикселя;
		/// last_updated (integer) — дата и время последнего использования пикселя в формате Unixtime;
		/// domain (string) — домен сайта, где размещен пиксель;
		/// category_id (integer) — идентификатор категории сайта, где размещён пиксель (см. раздел interest_categories метода ads.getSuggestions);
		/// pixel (string) — код для размещения на сайте рекламодателя.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getTargetPixels
		/// </remarks>
		ReadOnlyCollection<GetTargetPixelsResult> GetTargetPixels(long accountId, long? clientId = null);

		/// <summary>
		/// Возвращает размер целевой аудитории таргетинга, а также рекомендованные значения CPC и CPM.
		/// </summary>
		/// <param name = "getTargetingStatsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает объект, описывающий целевую аудиторию и содержащий следующие поля:
		/// audience_count (integer) — размер целевой аудитории
		/// recommended_cpc (number) — рекомендованная цена для объявлений за клики, указана в рублях с копейками в дробной части.
		/// recommended_cpm (number)— рекомендованная цена для объявлений за показы, указана в рублях с копейками в дробной части.
		/// Обратите внимание, минимальный размер целевой аудитории — 100 человек. Если заданным критериям соответствует меньшее количество пользователей, размер аудитории будет считаться равным нулю.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getTargetingStats
		/// </remarks>
		GetTargetingStatsResult GetTargetingStats(GetTargetingStatsParams getTargetingStatsParams);

		/// <summary>
		/// Возвращает URL-адрес для загрузки фотографии рекламного объявления.
		/// </summary>
		/// <param name="getUploadUrlParams"></param>
		/// <returns>
		/// Возвращает url-адрес для загрузки изображения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getUploadURl
		/// </remarks>
		Uri GetUploadUrl(GetUploadUrlParams getUploadUrlParams);

		/// <summary>
		/// Возвращает URL-адрес для загрузки видеозаписи рекламного объявления.
		/// </summary>
		/// <returns>
		/// Возвращает url-адрес для загрузки видеоролика.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.getVideoUploadURl
		/// </remarks>
		Uri GetVideoUploadUrl();

		/// <summary>
		/// Импортирует список контактов рекламодателя для учета зарегистрированных во ВКонтакте пользователей в аудитории ретаргетинга.
		/// </summary>
		/// <param name="importTargetContactsParams"></param>
		/// <returns>
		/// Возвращает количество обработанных контактов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.importTargetContacts
		/// </remarks>
		long ImportTargetContacts(ImportTargetContactsParams importTargetContactsParams);

		/// <summary>
		/// Удаляет администраторов и/или наблюдателей из рекламного кабинета.
		/// </summary>
		/// <param name="removeOfficeUsersParams"></param>
		/// <returns>
		/// Возвращает массив значений - ответов на каждый запрос в массиве data. Соответствующее значение в выходном массиве равно true, если администратор успешно удален, и false в другом случае.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.removeOfficeUsers
		/// </remarks>
		ReadOnlyCollection<bool> RemoveOfficeUsers(RemoveOfficeUsersParams removeOfficeUsersParams);

		/// <summary>
		/// Принимает запрос на исключение контактов рекламодателя из аудитории ретаргетинга.
		/// </summary>
		/// <param name="removeTargetContactsParams"></param>
		/// <returns>
		/// Возвращает 1 в случае успешного принятия заявки на исключение аудитории.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.removeTargetContacts
		/// </remarks>
		RemoveTargetContactsResult RemoveTargetContacts(RemoveTargetContactsParams removeTargetContactsParams);

		/// <summary>
		/// Сохраняет результат поиска похожей аудитории.
		/// </summary>
		/// <param name="saveLookalikeRequestResultParams"></param>
		/// <returns>
		/// Возвращает объект с полями:
		///
		/// retargeting_group_id – идентификатор группы ретаргетинга, в которую будет сохранена запрошенная похожая аудитория.
		/// audience_count – размер запрошенной похожей аудитории.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.saveLookalikeRequestResult
		/// </remarks>
		SaveLookALikeRequestResultResult SaveLookalikeRequestResult(SaveLookalikeRequestResultParams saveLookalikeRequestResultParams);

		/// <summary>
		/// Предоставляет доступ к аудитории ретаргетинга другому рекламному кабинету. В результате выполнения метода возвращается идентификатор аудитории для указанного кабинета.
		/// </summary>
		/// <param name="shareTargetGroupParams"></param>
		/// <returns>
		/// Возвращает объект со следующими полями:
		/// id — идентификатор аудитории.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.shareTargetGroup
		/// </remarks>
		ShareTargetGroupResult ShareTargetGroup(ShareTargetGroupParams shareTargetGroupParams);

		/// <summary>
		/// Редактирует рекламные объявления.
		/// </summary>
		/// <param name="adEditDataSpecification"></param>
		/// <returns>
		/// Возвращает массив ответов на каждый запрос в массиве data. Соответствующий объект в выходном массиве содержит идентификатор изменяемого объявления и, в случае возникновения ошибки, поля error_code и error_desc.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.updateAds
		/// </remarks>
		ReadOnlyCollection<UpdateAdsResult> UpdateAds(AdsDataSpecificationParams<AdEditSpecification> adEditDataSpecification);

		/// <summary>
		/// Редактирует рекламные кампании.
		/// </summary>
		/// <param name="campaignModDataSpecification"></param>
		/// <returns>
		/// Возвращает массив ответов на каждый запрос в массиве data. Соответствующий объект в выходном массиве содержит идентификатор изменяемого клиента и, в случае возникновения ошибки, поля error_code и error_desc.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.updateCampaigns
		/// </remarks>
		ReadOnlyCollection<UpdateCampaignsResult> UpdateCampaigns(AdsDataSpecificationParams<CampaignModSpecification> campaignModDataSpecification);

		/// <summary>
		/// Редактирует клиентов рекламного агентства.
		/// </summary>
		/// <param name="clientModDataSpecification"></param>
		/// <returns>
		/// Возвращает массив ответов на каждый запрос в массиве data. Соответствующий объект в выходном массиве содержит id изменяемого клиента и, в случае возникновения ошибки, поля error_code и error_desc.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.updateClients
		/// </remarks>
		ReadOnlyCollection<UpdateClientsResult> UpdateClients(AdsDataSpecificationParams<ClientModSpecification> clientModDataSpecification);

		/// <summary>
		/// Редактирует аудиторию ретаргетинга.
		/// </summary>
		/// <param name = "updateTargetGroupParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// В случае успеха метод возвратит 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.updateTargetGroup
		/// </remarks>
		bool UpdateTargetGroup(UpdateTargetGroupParams updateTargetGroupParams);

		/// <summary>
		/// Редактирует пиксель ретаргетинга.
		/// </summary>
		/// <param name = "updateTargetPixelParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/ads.updateTargetPixel
		/// </remarks>
		bool UpdateTargetPixel(UpdateTargetPixelParams updateTargetPixelParams);
	}
}