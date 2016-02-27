---
layout: default
title: Метод Market.DeleteAlbum
permalink: market/deleteAlbum/
comments: true
---
# Метод Market.DeleteAlbum
Удаляет подборку с товарами.

Страница документации ВКонтакте [market.deleteAlbum](https://vk.com/dev/market.deleteAlbum).

## Синтаксис
``` csharp
public bool DeleteAlbum(long ownerId, long albumId)
```

## Параметры
+ **ownerId** - Идентификатор владельца подборки. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **albumId** - Идентификатор подборки. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
