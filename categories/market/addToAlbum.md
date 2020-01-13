---
layout: default
title: Метод Market.AddToAlbum
permalink: market/addToAlbum/
comments: true
---
# Метод Market.AddToAlbum
Добавляет товар в одну или несколько выбранных подборок.

Страница документации ВКонтакте [market.addToAlbum](https://vk.com/dev/market.addToAlbum).

## Синтаксис
``` csharp
public bool AddToAlbum(long ownerId, long itemId, IEnumerable<string> albumIds)
```

## Параметры
+ **ownerId** — Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **itemId** — Идентификатор товара. положительное число, обязательный параметр
+ **albumIds** — Идентификаторы подборок, в которые нужно добавить товар. список положительных чисел, разделенных запятыми, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var addToAlbum = _api.Market.AddToAlbum(ownerId: 0, itemId: 0, albumIds: );
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
