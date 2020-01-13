---
layout: default
title: Метод Video.RemoveTag
permalink: video/removeTag/
comments: true
---
# Метод Video.RemoveTag
Удаляет отметку с видеозаписи.

Страница документации ВКонтакте [video.removeTag](https://vk.com/dev/video.removeTag).

## Синтаксис
``` csharp
public bool RemoveTag(long tagId, long videoId, long? ownerId)
```

## Параметры
+ **tagId** — Идентификатор отметки. целое число, обязательный параметр
+ **ownerId** — Идентификатор владельца видеозаписи (пользователь или сообщество). По умолчанию — идентификатор текущего пользователя. положительное число, по умолчанию идентификатор текущего пользователя
+ **videoId** — Идентификатор видеозаписи. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var removeTag = _api.Video.RemoveTag(tagId: 0, videoId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
