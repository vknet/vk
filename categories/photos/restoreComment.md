---
layout: default
title: Метод Photos.RestoreComment
permalink: photos/restoreComment/
comments: true
---
# Метод Photos.RestoreComment
Восстанавливает удаленный комментарий к фотографии.

Страница документации ВКонтакте [photos.restoreComment](https://vk.com/dev/photos.restoreComment).

## Синтаксис
``` csharp
public long RestoreComment(ulong commentId, long? ownerId = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** — Идентификатор удаленного комментария. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает 1 (0, если комментарий с таким идентификатором не является удаленным).

## Пример
``` csharp
var restoreComment = _api.Photos.RestoreComment(commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
