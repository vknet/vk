---
layout: default
title: Метод Photos.RemoveTag
permalink: photos/removeTag/
comments: true
---
# Метод Photos.RemoveTag
Удаляет отметку с фотографии.

Страница документации ВКонтакте [photos.removeTag](https://vk.com/dev/photos.removeTag).

## Синтаксис
``` csharp
public bool RemoveTag(ulong tagId, ulong photoId, long? ownerId = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **photoId** — Идентификатор фотографии. целое число, обязательный параметр
+ **tagId** — Идентификатор отметки. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает 1.

## Пример
``` csharp
var removeTag = _api.Photos.RemoveTag(photoId: 0, tagId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
