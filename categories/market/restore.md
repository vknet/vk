---
layout: default
title: Метод Market.Restore
permalink: market/restore/
comments: true
---
# Метод Market.Restore
Восстанавливает удаленный товар.

Страница документации ВКонтакте [market.restore](https://vk.com/dev/market.restore).

## Синтаксис
``` csharp
public bool Restore(long ownerId, long itemId)
```

## Параметры
+ **ownerId** - Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **itemId** - Идентификатор товара. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true** (0, если товар не найден среди удаленных).

## Пример
``` csharp
var restore = _api.Market.Restore(ownerId: 0, itemId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
