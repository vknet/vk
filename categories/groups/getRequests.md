---
layout: default
title: Метод Groups.GetRequests
permalink: groups/getRequests/
comments: true
---
# Метод Groups.GetRequests
Возвращает список заявок на вступление в сообщество.

Страница документации ВКонтакте [groups.getRequests](https://vk.com/dev/groups.getRequests).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetRequests(long groupId, long? offset, long? count, UsersFields fields)
```

## Параметры
+ **groupId** - Идентификатор сообщества (указывается без знака «минус»). положительное число, обязательный параметр
+ **offset** - Смещение, необходимое для выборки определенного подмножества результатов. По умолчанию — 0. положительное число
+ **count** - Число результатов, которые необходимо вернуть. положительное число, по умолчанию 20, максимальное значение 200
+ **fields** - Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters, screen_name, maiden_name, timezone, occupation,activities, interests, music, movies, tv, books, games, about, quotes список строк, разделенных через запятую

## Результат
Возвращает список идентификаторов пользователей, отправивших заявки на вступление в сообщество. 
Если было передано значение в параметре fields, возвращается список объектов пользователей.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
