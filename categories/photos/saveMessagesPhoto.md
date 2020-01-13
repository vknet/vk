---
layout: default
title: Метод Photos.SaveMessagesPhoto
permalink: photos/saveMessagesPhoto/
comments: true
---
# Метод Photos.SaveMessagesPhoto
Сохраняет фотографию после успешной загрузки на URI, полученный методом photos.getMessagesUploadServer.

Страница документации ВКонтакте [photos.saveMessagesPhoto](https://vk.com/dev/photos.saveMessagesPhoto).

## Синтаксис
``` csharp
public ReadOnlyCollection<Photo> SaveMessagesPhoto(string response)
```

## Параметры
+ **response** — Параметр, возвращаемый в результате загрузки фотографии на сервер. строка, обязательный параметр

## Результат
После успешного выполнения возвращает массив с загруженной фотографией, возвращённый объект имеет поля id, pid, aid, owner_id, src, src_big, src_small, created. В случае наличия фотографий в высоком разрешении также будут возвращены адреса с названиями src_xbig и src_xxbig.

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
