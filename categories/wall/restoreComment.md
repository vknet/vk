---
layout: default
title: Метод Wall.RestoreComment
permalink: wall/restoreComment/
comments: true
---
# Метод Wall.RestoreComment
Восстанавливает комментарий текущего пользователя к записи на своей или чужой стене.

Страница документации ВКонтакте [wall.restoreComment](https://vk.com/dev/wall.restoreComment).

## Синтаксис
``` csharp
public bool RestoreComment(long commentId, long? ownerId)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, на стене которого находится комментарий к записи. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** — Идентификатор комментария на стене. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var restoreComment = _api.Wall.RestoreComment(commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 17:04:31
