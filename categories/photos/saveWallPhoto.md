---
layout: default
title: Метод Photos.SaveWallPhoto
permalink: photos/saveWallPhoto/
comments: true
---
# Метод Photos.SaveWallPhoto
Сохраняет фотографии после успешной загрузки на URI, полученный методом photos.getWallUploadServer.

Страница документации ВКонтакте [photos.saveWallPhoto](https://vk.com/dev/photos.saveWallPhoto).
## Синтаксис
``` csharp
public ReadOnlyCollection<Photo> SaveWallPhoto(string response, ulong? userId = null, ulong? groupId = null)
```

## Параметры
+ **response** - Параметр, возвращаемый в результате загрузки фотографии на сервер. строка, обязательный параметр
+ **userId** - Идентификатор пользователя, на стену которого нужно сохранить фотографию. положительное число
+ **groupId** - Идентификатор сообщества, на стену которого нужно сохранить фотографию. положительное число

## Результат
После успешного выполнения возвращает массив, содержащий объект с загруженной фотографией.

## Пример
``` csharp
// Пример кода
```
