---
layout: default
title: Метод Photos.GetMarketUploadServer
permalink: photos/getMarketUploadServer/
comments: true
---
# Метод Photos.GetMarketUploadServer
Возвращает адрес сервера для загрузки фотографии товаров сообщества.

Страница документации ВКонтакте [photos.getMarketUploadServer](https://vk.com/dev/photos.getMarketUploadServer).

## Синтаксис
``` csharp
public UploadServerInfo GetMarketUploadServer(long groupId, bool? mainPhoto = null, long? cropX = null, long? cropY = null, long? cropWidth = null)
```

## Параметры
+ **groupId** — Идентификатор сообщества, для которого необходимо загрузить фотографию товара. целое число
+ **mainPhoto** — Является ли фотография обложкой товара  (1 — фотография для обложки, 0 — дополнительная фотография) флаг, может принимать значения 1 или 0
+ **cropX** — Координата x для обрезки фотографии. положительное число
+ **cropY** — Координата y для обрезки фотографии. положительное число
+ **cropWidth** — Ширина фотографии после обрезки в px. положительное число, минимальное значение 200

## Результат
После успешного выполнения возвращает объект с единственным полем **UploadUrl**.

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
