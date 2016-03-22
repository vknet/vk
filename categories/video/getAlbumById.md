---
layout: default
title: Метод Video.GetAlbumById
permalink: video/getAlbumById/
comments: true
---
# Метод Video.GetAlbumById
Позволяет получить информацию об альбоме с видео.

Страница документации ВКонтакте [video.getAlbumById](https://vk.com/dev/video.getAlbumById).

## Синтаксис
``` csharp
public ReadOnlyCollection<Video> GetAlbumById(long albumId, long? ownerId = null)
```

## Параметры
+ **ownerId** - Идентификатор пользователя или сообщества, которому принадлежит альбом. целое число, по умолчанию идентификатор текущего пользователя
+ **albumId** - Идентификатор альбома. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает объект, который содержит следующие поля: 

+ **id** — идентификатор альбома; 
+ **owner_id** — идентификатор владельца альбома; 
+ **title** — название альбома; 
+ **count** — число видеозаписей в альбоме; 
+ **photo_320** — url обложки альбома с шириной 320px; 
+ **photo_160** — url обложки альбома с шириной 160px; 
+ **updated_time** — время последнего обновления в формате unixtime.

## Пример
``` csharp
var getAlbumById = _api.Video.GetAlbumById(albumId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
