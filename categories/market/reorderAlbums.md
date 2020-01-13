---
layout: default
title: Метод Market.ReorderAlbums
permalink: market/reorderAlbums/
comments: true
---
# Метод Market.ReorderAlbums
Изменяет положение подборки с товарами в списке.

Страница документации ВКонтакте [market.reorderAlbums](https://vk.com/dev/market.reorderAlbums).

## Синтаксис
``` csharp
public bool ReorderAlbums(long ownerId, long albumId, long? before, long? after)
```

## Параметры
+ **ownerId** — Идентификатор владельца альбома. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **albumId** — Идентификатор подборки. целое число, обязательный параметр
+ **before** — Идентификатор подборки, перед которой следует поместить текущую. положительное число
+ **after** — Идентификатор подборки, после которой следует поместить текущую. положительное число

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var reorderAlbums = _api.Market.ReorderAlbums(ownerId: 0, albumId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
