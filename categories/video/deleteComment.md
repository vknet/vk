---
layout: default
title: Метод Video.DeleteComment
permalink: video/deleteComment/
comments: true
---
# Метод Video.DeleteComment
Удаляет комментарий к видеозаписи.

Страница документации ВКонтакте [video.deleteComment](https://vk.com/dev/video.deleteComment).
## Синтаксис
``` csharp
public bool DeleteComment(long commentId, long? ownerId = null)
```

## Параметры
+ **ownerId** - Идентификатор пользователя или сообщества, которому принадлежит видеозапись. целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** - Идентификатор комментария. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
