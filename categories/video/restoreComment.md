---
layout: default
title: Метод Video.RestoreComment
permalink: video/restoreComment/
comments: true
---
# Метод Video.RestoreComment
Восстанавливает удаленный комментарий к видеозаписи.

Страница документации ВКонтакте [video.restoreComment](https://vk.com/dev/video.restoreComment).

## Синтаксис
``` csharp
public bool RestoreComment(long commentId, long? ownerId = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит видеозапись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** — Идентификатор удаленного комментария. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает **true** (0, если комментарий с таким идентификатором не является удаленным).

## Пример
``` csharp
var restoreComment = _api.Video.RestoreComment(commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
