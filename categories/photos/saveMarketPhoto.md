---
layout: default
title: Метод Photos.SaveMarketPhoto
permalink: photos/saveMarketPhoto/
comments: true
---
# Метод Photos.SaveMarketPhoto
Сохраняет фотографии после успешной загрузки на URI, полученный методом photos.getMarketUploadServer.

Страница документации ВКонтакте [photos.saveMarketPhoto](https://vk.com/dev/photos.saveMarketPhoto).

## Синтаксис
``` csharp
public ReadOnlyCollection<Photo> SaveMarketPhoto(long groupId, string response)
```

## Параметры
+ **groupId** — Идентификатор группы, для которой нужно загрузить фотографию. положительное число
+ **response** — Параметр, возвращаемый в результате загрузки фотографии на сервер. строка, обязательный параметр

## Результат
После успешного выполнения возвращает массив, содержащий объект с загруженной фотографией.

## Пример
``` csharp
// Получить адрес сервера для загрузки.
var uploadServer = Api.Photo.GetMarketUploadServer(123, true, 5, 5, 200);
// Загрузить фотографию.
var wc = new WebClient();
var responseImg = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, @"test.jpg"));
// Сохранить загруженную фотографию
var photo = Api.Photo.SaveMarketPhoto(123, responseImg);
Api.Market.Add(new MarketProductParams
{
    OwnerId = -123,
    CategoryId = 200,
    MainPhotoId = photo.FirstOrDefault().Id.Value,
    Deleted = false,
    Name = "Телефон",
    Description = "Описание товара",
    Price = 10000
});
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
