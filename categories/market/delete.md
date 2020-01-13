---
layout: default
title: Метод Market.Delete
permalink: market/delete/
comments: true
---
# Метод Market.Delete
Удаляет товар.

Страница документации ВКонтакте [market.delete](https://vk.com/dev/market.delete).

## Синтаксис
``` csharp
public bool Delete(long ownerId, long itemId)
```

## Параметры
+ **ownerId** — Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **itemId** — Идентификатор товара. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var delete = _api.Market.Delete(ownerId: 0, itemId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
