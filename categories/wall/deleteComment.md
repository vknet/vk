---
layout: default
title: Метод Wall.DeleteComment
permalink: wall/deleteComment/
comments: true
---
# Метод Wall.DeleteComment
Удаляет комментарий текущего пользователя к записи на своей или чужой стене.

Страница документации ВКонтакте [wall.deleteComment](https://vk.com/dev/wall.deleteComment).

## Синтаксис
``` csharp
public bool DeleteComment(long? ownerId, long commentId)
```

## Параметры
+ **ownerId** - Идентификатор пользователя, на чьей стене находится комментарий к записи. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** - Идентификатор комментария. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var deleteComment = _api.Wall.DeleteComment(commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 17:04:31
