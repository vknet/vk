---
layout: default
title: Метод Market.GetAlbumById
permalink: market/getAlbumById/
comments: true
---
# Метод Market.GetAlbumById
Возвращает данные подборки с товарами.

Страница документации ВКонтакте [market.getAlbumById](https://vk.com/dev/market.getAlbumById).

## Синтаксис
``` csharp
public ReadOnlyCollection<MarketAlbum> GetAlbumById(long ownerId, IEnumerable<long> albumIds)
```

## Параметры
+ **ownerId** — Идентификатор владельца подборки. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **albumIds** — Идентификаторы подборок, данные о которых нужно получить. список положительных чисел, разделенных запятыми, обязательный параметр

## Результат
Возвращает список объектов album. 
Объект album — подборка с товарами.  
id идентификатор подборки. 
 положительное число owner_id идентификатор владельца подборки. 
 int (числовое значение) title название подборки. 
 строка photo обложка подборки, объект photo. count число товаров в подборке; 
 int (числовое значение) updated_time дата обновления подборки в формате unixtime. 
 положительное число

## Пример
``` csharp
var getAlbumById = _api.Market.GetAlbumById(ownerId: 0, albumIds: );
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
