---
layout: default
title: Метод Market.RemoveFromAlbum
permalink: market/removeFromAlbum/
comments: true
---
# Метод Market.RemoveFromAlbum
Удаляет товар из одной или нескольких выбранных подборок.

Страница документации ВКонтакте [market.removeFromAlbum](https://vk.com/dev/market.removeFromAlbum).

## Синтаксис
``` csharp
public bool RemoveFromAlbum(long ownerId, long itemId, IEnumerable<string> albumIds)
```

## Параметры
+ **ownerId** — Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **itemId** — Идентификатор товара. положительное число, обязательный параметр
+ **albumIds** — Идентификаторы подборок, из которых нужно удалить товар. список положительных чисел, разделенных запятыми, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var removeFromAlbum = _api.Market.RemoveFromAlbum(ownerId: 0, itemId: 0, albumIds: );
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
