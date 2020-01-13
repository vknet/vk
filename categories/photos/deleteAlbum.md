---
layout: default
title: Метод Photos.DeleteAlbum
permalink: photos/deleteAlbum/
comments: true
---
# Метод Photos.DeleteAlbum
Удаляет указанный альбом для фотографий у текущего пользователя

Страница документации ВКонтакте [photos.deleteAlbum](https://vk.com/dev/photos.deleteAlbum).

## Синтаксис
``` csharp
public bool DeleteAlbum(long albumId, long? groupId = null)
```

## Параметры
+ **albumId** — Идентификатор альбома. целое число, положительное число, обязательный параметр
+ **groupId** — Идентификатор сообщества, в котором размещен альбом. целое число, положительное число

## Результат
После успешного выполнения возвращает 1.

## Пример
``` csharp
var deleteAlbum = _api.Photos.DeleteAlbum(albumId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
