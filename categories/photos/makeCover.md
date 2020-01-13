---
layout: default
title: Метод Photos.MakeCover
permalink: photos/makeCover/
comments: true
---
# Метод Photos.MakeCover
Делает фотографию обложкой альбома.

Страница документации ВКонтакте [photos.makeCover](https://vk.com/dev/photos.makeCover).

## Синтаксис
``` csharp
public bool MakeCover(ulong photoId, long? ownerId = null, long? albumId = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **photoId** — Идентификатор фотографии. Фотография должна находиться в альбоме album_id. целое число, обязательный параметр
+ **albumId** — Идентификатор альбома. целое число

## Результат
После успешного выполнения возвращает 1.

## Пример
``` csharp
var makeCover = _api.Photos.MakeCover(photoId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
