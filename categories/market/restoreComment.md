---
layout: default
title: Метод Market.RestoreComment
permalink: market/restoreComment/
comments: true
---
# Метод Market.RestoreComment
Восстанавливает удаленный комментарий к товару.

Страница документации ВКонтакте [market.restoreComment](https://vk.com/dev/market.restoreComment).

## Синтаксис
``` csharp
public bool RestoreComment(long ownerId, long commentId)
```

## Параметры
+ **ownerId** — Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **commentId** — Идентификатор удаленного комментария. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true** (0, если комментарий с таким идентификатором не является удаленным).

## Пример
``` csharp
var restoreComment = _api.Market.RestoreComment(ownerId: 0, commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
