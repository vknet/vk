---
layout: default
title: Метод Photos.GetMessagesUploadServer
permalink: photos/getMessagesUploadServer/
comments: true
---
# Метод Photos.GetMessagesUploadServer
Возвращает адрес сервера для загрузки фотографии в личное сообщение пользователю.

Страница документации ВКонтакте [photos.getMessagesUploadServer](https://vk.com/dev/photos.getMessagesUploadServer).
## Синтаксис
``` csharp
public UploadServerInfo GetMessagesUploadServer()
```

## Результат
После успешного выполнения возвращает объект с полями **UploadUrl**, aid (id альбома)  и mid (id текущего пользователя).

## Пример
``` csharp
// Получить адрес сервера для загрузки.
var uploadServer = _api.Photo.GetMessagesUploadServer();
// Загрузить фотографию.
var wc = new WebClient();
var responseImg = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, @"vk.png"));
// Сохранить загруженную фотографию
var photo = _api.Photo.SaveMessagesPhoto(responseImg);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
