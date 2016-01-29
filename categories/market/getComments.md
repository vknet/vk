---
layout: default
title: Метод Market.GetComments
permalink: market/getComments/
comments: true
---
# Метод Market.GetComments
Возвращает список комментариев к товару.

Страница документации ВКонтакте [market.getComments](https://vk.com/dev/market.getComments).
## Синтаксис
``` csharp
public ReadOnlyCollection<MarketComment> GetComments(MarketGetCommentsParams @params)
```

## Параметры
Класс **`MarketGetCommentsParams`** содержит следующие свойства:

+ **OwnerId** - Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **ItemId** - Идентификатор товара. положительное число, обязательный параметр
+ **NeedLikes** - 1 — возвращать информацию о лайках. флаг, может принимать значения 1 или 0
+ **StartCommentId** - Идентификатор комментария, начиная с которого нужно вернуть список (подробности см. ниже). положительное число
+ **Offset** - Сдвиг, необходимый для получения конкретной выборки результатов. положительное число, по умолчанию 0
+ **Count** - Число комментариев, которые необходимо получить. положительное число, по умолчанию 20, максимальное значение 100
+ **Sort** - Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к старым) строка, по умолчанию asc
+ **Extended** - 1 — комментарии в ответе будут возвращены в виде пронумерованных объектов, дополнительно будут возвращены списки объектов profiles, groups. флаг, может принимать значения 1 или 0
+ **Fields** - Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, photo_id, online, online_mobile, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters, screen_name, maiden_name, timezone, occupation,activities, interests, music, movies, tv, books, games, about, quotes, personal, friend_status, military, career список слов, разделенных через запятую

## Результат


## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
