---
layout: default
title: Метод Photos.Save
permalink: photo/save/
comments: true
---
# Метод Photos.Save
Сохраняет фотографии после успешной загрузки.

## Синтаксис
``` csharp
public ReadOnlyCollection<Photo> Save(PhotoSaveParams @params)
```
## Параметры
Класс PhotoSaveParams содержит следующие свойства:

* AlbumId - Идентификатор альбома, в который необходимо сохранить фотографии. (Обязательный параметр)
* SaveFileResponse - Параметр, возвращаемый в результате загрузки фотографий на сервер. (Обязательный параметр)
* GroupId - Идентификатор сообщества, в которое необходимо сохранить фотографии.
* Latitude - Географическая широта, заданная в градусах (от -90 до 90);
* Longitude - Географическая долгота, заданная в градусах (от -180 до 180);
* Caption - Текст описания фотографии.

## Результат
Возвращает массив фотографий.

## Пример
``` csharp
// Получить адрес сервера для загрузки.
var uploadServer = Api.Photo.GetUploadServer(123);
// Загрузить файл.
var wc = new WebClient();
var responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, @"test.jpg"));
// Сохранить загруженный файл
var photos = Api.Photo.Save(new PhotoSaveParams
{
	SaveFileResponse = responseFile,
	AlbumId = 123
});
```
