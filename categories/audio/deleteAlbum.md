---
layout: default
title: Метод Audio.DeleteAlbum
permalink: audio/deleteAlbum/
comments: true
---
# Метод Audio.DeleteAlbum
Удаляет альбом аудиозаписей.

Страница документации ВКонтакте [audio.deleteAlbum](https://vk.com/dev/audio.deleteAlbum).

## Синтаксис
``` csharp
public bool DeleteAlbum(long albumId, long? groupId = null)
```

## Параметры
+ **groupId** - Идентификатор сообщества, которому принадлежит альбом. положительное число
+ **albumId** - Идентификатор альбома. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var deleteAlbum = _api.Audio.DeleteAlbum(albumId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
