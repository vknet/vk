---
layout: default
title: Метод Users.GetFollowers
permalink: users/getFollowers/
comments: true
---
# Метод Users.GetFollowers
Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.

Этот метод можно вызвать с [сервисным ключом доступа](https://vk.com/dev/access_token?f=3.%20Сервисный%20ключ%20доступа). Возвращаются только общедоступные данные.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). 

Страница документации ВКонтакте [users.getFollowers](https://vk.com/dev/users.getFollowers).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields = null, NameCase nameCase = null)
```

## Параметры
+ **userId** — Идентификатор пользователя. положительное число, по умолчанию идентификатор текущего пользователя
+ **offset** — Смещение, необходимое для выборки определенного подмножества подписчиков. 
+ **count** — Количество подписчиков, информацию о которых нужно получить. По умолчанию *100*, максимальное значение *1000*.
+ **Fields** — Список дополнительных полей профилей, которые необходимо вернуть. См. [подробное описание.](https://vk.com/dev/objects/user) Доступные значения: *photo_id*, *verified, *sex*, *bdate*, *city*, *country*, *home_town*, *has_photo*, *photo_50*, *photo_100*, *photo_200_orig*, *photo_200*, *photo_400_orig*, *photo_max*, *photo_max_orig*, *online*, *lists*, *domain*, *has_mobile*, *contacts*, *site*, *education*, *universities*, *schools*, *status*, *last_seen*, *followers_count*, *common_count*, *occupation*, *nickname*, *relatives*, *relation*, *personal*, *connections*, *exports*, *wall_comments*, activities, *interests*, *music*, *movies*, *tv*, *books*, *games*, *about*, *quotes*, *can_post*, *can_see_all_posts*, *can_see_audio*, *can_write_private_message*, *can_send_friend_request*, *is_favorite*, *is_hidden_from_feed*, *timezone*, *screen_name*, *maiden_name*, *crop_photo*, *is_friend*, *friend_status*, *career*, *military*, *blacklisted*, *blacklisted_by_me*.
+ **NameCase** — Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – *nom*, родительный – *gen*, дательный – *dat*, винительный – *acc*, творительный – *ins*, предложный – *abl*. По умолчанию *nom* строка.

## Результат
После успешного выполнения возвращает объект, содержащий число результатов в поле TotalCount и массив [объектов, описывающих пользователей](https://vk.com/dev/objects/user).
Идентификаторы пользователей в списке отсортированы в порядке убывания времени их добавления.

## Исключения
+ Код ошибки 30 — This profile is private.
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/objects/user)

## Пример
``` csharp
var getFollowers = _api.Users.GetFollowers();
```

## Версия Вконтакте API v.5.103
Дата обновления: 14.01.2020 12:44:46
