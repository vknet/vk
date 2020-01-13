---
layout: default
title: Метод Market.EditAlbum
permalink: market/editAlbum/
comments: true
---
# Метод Market.EditAlbum
Редактирует подборку с товарами.

Страница документации ВКонтакте [market.editAlbum](https://vk.com/dev/market.editAlbum).

## Синтаксис
``` csharp
public bool EditAlbum(long ownerId, long albumId, string title, long? photoId)
```

## Параметры
+ **ownerId** — Идентификатор владельца подборки. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **albumId** — Идентификатор подборки. положительное число, обязательный параметр
+ **title** — Название подборки. строка, обязательный параметр, максимальная длина 128
+ **photoId** — Идентификатор фотографии-обложки подборки. 
Фотография должна быть загружена с помощью метода photos.getMarkeAlbumUploadServer. См. подробную информацию о загрузке фотографии товаров. положительное число

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var editAlbum = _api.Market.EditAlbum(ownerId: 0, albumId: 0, title: "title");
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
