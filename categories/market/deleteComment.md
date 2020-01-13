---
layout: default
title: Метод Market.DeleteComment
permalink: market/deleteComment/
comments: true
---
# Метод Market.DeleteComment
Удаляет комментарий к товару.

Страница документации ВКонтакте [market.deleteComment](https://vk.com/dev/market.deleteComment).

## Синтаксис
``` csharp
public bool DeleteComment(long ownerId, long commentId)
```

## Параметры
+ **ownerId** — Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **commentId** — Идентификатор комментария. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true** (0, если комментарий не найден).

## Пример
``` csharp
var deleteComment = _api.Market.DeleteComment(ownerId: 0, commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
