---
layout: default
title: Метод Photos.DeleteComment
permalink: photos/deleteComment/
comments: true
---
# Метод Photos.DeleteComment
Удаляет комментарий к фотографии.

Страница документации ВКонтакте [photos.deleteComment](https://vk.com/dev/photos.deleteComment).

## Синтаксис
``` csharp
public bool DeleteComment(ulong commentId, long? ownerId = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** — Идентификатор комментария. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает 1 (0, если комментарий не найден).

## Пример
``` csharp
var deleteComment = _api.Photos.DeleteComment(commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
