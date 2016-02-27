---
layout: default
title: Метод Photos.GetMarketAlbumUploadServer
permalink: photos/getMarketAlbumUploadServer/
comments: true
---
# Метод Photos.GetMarketAlbumUploadServer
Возвращает адрес сервера для загрузки фотографии подборки товаров в сообществе.

Страница документации ВКонтакте [photos.getMarketAlbumUploadServer](https://vk.com/dev/photos.getMarketAlbumUploadServer).

## Синтаксис
``` csharp
public UploadServerInfo GetMarketAlbumUploadServer(long groupId)
```

## Параметры
+ **groupId** - Идентификатор сообщества, для которого необходимо загрузить фотографию подборки товаров. целое число

## Результат
После успешного выполнения возвращает объект с единственным полем **UploadUrl**.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
