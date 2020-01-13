---
layout: default
title: Метод Photos.SaveMarketAlbumPhoto
permalink: photos/saveMarketAlbumPhoto/
comments: true
---
# Метод Photos.SaveMarketAlbumPhoto
Сохраняет фотографии после успешной загрузки на URI, полученный методом photos.getMarketAlbumUploadServer.

Страница документации ВКонтакте [photos.saveMarketAlbumPhoto](https://vk.com/dev/photos.saveMarketAlbumPhoto).

## Синтаксис
``` csharp
public ReadOnlyCollection<Photo> SaveMarketAlbumPhoto(long groupId, string response)
```

## Параметры
+ **groupId** — Идентификатор группы, для которой нужно загрузить фотографию. положительное число, обязательный параметр
+ **response** — Параметр, возвращаемый в результате загрузки фотографии на сервер. строка, обязательный параметр

## Результат
После успешного выполнения возвращает массив, содержащий объект с загруженной фотографией.

## Пример
``` csharp
var saveMarketAlbumPhoto = _api.Photos.SaveMarketAlbumPhoto(groupId: 0, photo: "photo", server: 0, hash: "hash");
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
