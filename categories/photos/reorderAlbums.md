---
layout: default
title: Метод Photos.ReorderAlbums
permalink: photos/reorderAlbums/
comments: true
---
# Метод Photos.ReorderAlbums
Меняет порядок альбома в списке альбомов пользователя.

Страница документации ВКонтакте [photos.reorderAlbums](https://vk.com/dev/photos.reorderAlbums).

## Синтаксис
``` csharp
public bool ReorderAlbums(long albumId, long? ownerId = null, long? before = null, long? after = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит альбом. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **albumId** — Идентификатор альбома. целое число, обязательный параметр
+ **before** — Идентификатор альбома, перед которым следует поместить альбом. целое число
+ **after** — Идентификатор альбома, после которого следует поместить альбом. целое число

## Результат
После успешного выполнения возвращает 1.

## Пример
``` csharp
var reorderAlbums = _api.Photos.ReorderAlbums(albumId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
