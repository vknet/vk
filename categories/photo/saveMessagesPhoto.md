---
layout: default
title: Метод Photos.SaveMessagesPhoto
permalink: photo/saveMessagesPhoto/
comments: true
---
# Метод Photos.SaveMessagesPhoto
Сохраняет фотографию после успешной загрузки на URI, полученный методом `photos.getMessagesUploadServer`.
### Синтаксис
``` csharp
public Photo SaveMessagesPhoto(string response)
```
### Параметры
* response - После успешной загрузки возвращает необходимые данные для сохранения в формате JSON
### Результат
Возвращает объект фотографии.

### Пример
``` csharp
// Получить адрес сервера для загрузки.
var uploadServer = _api.Photo.GetMessagesUploadServer();
// Загрузить фотографию.
var wc = new WebClient();
var responseImg = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, @"vk.png"));
// Сохранить загруженную фотографию
var photo = _api.Photo.SaveMessagesPhoto(responseImg);
```
