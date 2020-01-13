---
layout: default
title: Метод Friends.GetByPhones
permalink: friends/getByPhones/
comments: true
---
# Метод Friends.GetByPhones
Возвращает список друзей пользователя, у которых завалидированные или указанные в профиле телефонные номера входят в заданный список.

Страница документации ВКонтакте [friends.getByPhones](https://vk.com/dev/friends.getByPhones).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetByPhones(IEnumerable<string> phones, ProfileFields fields)
```

## Параметры
+ **phones** — Список телефонных номеров в формате MSISDN, разделеннных запятыми. Например
+79219876543,+79111234567
Максимальное количество номеров в списке — 1000. список строк, разделенных через запятую
+ **fields** — Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую

## Результат
После успешного выполнения возвращает список объектов пользователей с дополнительным полем  phone, в котором содержится номер из списка заданных для поиска номеров.

## Пример
``` csharp
var getByPhones = _api.Friends.GetByPhones();
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
