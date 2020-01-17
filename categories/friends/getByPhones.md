---
layout: default
title: Метод Friends.GetByPhones
permalink: friends/getByPhones/
comments: true
---
# Метод Friends.GetByPhones
Возвращает список друзей пользователя, у которых завалидированные или указанные в профиле телефонные номера входят в заданный список.
Использование данного метода возможно только если у текущего пользователя завалидирован номер мобильного телефона. Для проверки этого условия можно использовать метод users.get c параметрами **user_ids=API_USER** и **fields=has_mobile**, где **API_USER** равен идентификатору текущего пользователя. Для доступа к этому методу приложение должно быть доверенным.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.getByPhones](https://vk.com/dev/friends.getByPhones).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetByPhones(IEnumerable<string> phones, ProfileFields fields)
```

## Параметры
+ **phones** — Список телефонных номеров в формате MSISDN, разделеннных запятыми. Например:
    +79219876543, +79111234567.
    Максимальное количество номеров в списке — *1000*.
+ **fields** — Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: *nickname*, *screen_name*, *sex*, *bdate*, *city*, *country*, *timezone*, *photo_50*, *photo_100*, *photo_200_orig*, *has_mobile*, *contacts*, *education*, *online*, *counters*, *relation*, *last_seen*, *status*, *can_write_private_message*, *can_see_all_posts*, *can_post*, *universities*.

## Результат
После успешного выполнения возвращает список объектов [пользователей](https://vk.com/dev/objects/user) с дополнительным полем **phone**, в котором содержится номер из списка заданных для поиска номеров.

## Исключения
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var getByPhones = _api.Friends.GetByPhones();
```

## Версия Вконтакте API v.5.103
Дата обновления: 17.01.2020 16:28.
