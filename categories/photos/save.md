---
layout: default
title: Метод Photos.Save
permalink: photos/save/
comments: true
---
# Метод Photos.Save
Сохраняет фотографии после успешной загрузки.

Страница документации ВКонтакте [photos.save](https://vk.com/dev/photos.save).

## Синтаксис
``` csharp
public ReadOnlyCollection<Photo> Save(PhotoSaveParams @params)
```
## Параметры
Класс PhotoSaveParams содержит следующие свойства:

+ **AlbumId** — Идентификатор альбома, в который необходимо сохранить фотографии. целое число (Обязательный параметр)
+ **SaveFileResponse** — Параметр, возвращаемый в результате загрузки фотографий на сервер. (Обязательный параметр)
+ **GroupId** — Идентификатор сообщества, в которое необходимо сохранить фотографии. целое число
+ **Latitude** — Географическая широта, заданная в градусах (от -90 до 90); дробное число
+ **Longitude** — Географическая долгота, заданная в градусах (от -180 до 180); дробное число
+ **Caption** — Текст описания фотографии (максимум 2048 символов). строка

## Результат
После успешного выполнения возвращает список объектов фотографий.

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

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
