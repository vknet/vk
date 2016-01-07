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
public bool GetMarketUploadServer(string groupId, string mainPhoto, string cropX, string cropY, string cropWidth)
```

## Параметры
+ **GroupId** - Идентификатор сообщества, для которого необходимо загрузить фотографию товара. целое число
+ **MainPhoto** - Является ли фотография обложкой товара  (1 — фотография для обложки, 0 — дополнительная фотография) флаг, может принимать значения 1 или 0
+ **CropX** - Координата x для обрезки фотографии. положительное число
+ **CropY** - Координата y для обрезки фотографии. положительное число
+ **CropWidth** - Ширина фотографии после обрезки в px. положительное число, минимальное значение 200

## Результат
После успешного выполнения возвращает объект с единственным полем upload_url.

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
