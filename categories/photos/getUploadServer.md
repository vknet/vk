---
layout: default
title: Метод Photos.GetUploadServer
permalink: photos/getUploadServer/
comments: true
---
# Метод Photos.GetUploadServer
Возвращает адрес сервера для загрузки фотографий.

Страница документации ВКонтакте [photos.getUploadServer](https://vk.com/dev/photos.getUploadServer).

## Синтаксис
``` csharp
public UploadServerInfo GetUploadServer(long albumId, long? groupId = null)
```

## Параметры
+ **albumId** — Идентификатор альбома. целое число
+ **groupId** — Идентификатор сообщества, которому принадлежит альбом (если необходимо загрузить фотографию в альбом сообщества). целое число

## Результат
После успешного выполнения возвращает объект, содержащий следующие поля: 

+ **UploadUrl** — адрес для загрузки фотографий; 
+ **AlbumId** — идентификатор альбома, в который будет загружена фотография; 
+ **UserId** — идентификатор пользователя, от чьего имени будет загружено фото.

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
