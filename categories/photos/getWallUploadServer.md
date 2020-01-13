---
layout: default
title: Метод Photos.GetWallUploadServer
permalink: photos/getWallUploadServer/
comments: true
---
# Метод Photos.GetWallUploadServer
Возвращает адрес сервера для загрузки фотографии на стену пользователя или сообщества.

Страница документации ВКонтакте [photos.getWallUploadServer](https://vk.com/dev/photos.getWallUploadServer).

## Синтаксис
``` csharp
public UploadServerInfo GetWallUploadServer(long? groupId = null)
```

## Параметры
+ **groupId** — Идентификатор сообщества, на стену которого нужно загрузить фото (без знака «минус»). целое число

## Результат
После успешного выполнения возвращает объект с полями **UploadUrl, AlbumId, UserId**.

## Пример
``` csharp
var getWallUploadServer = _api.Photos.GetWallUploadServer();
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
