---
layout: default
title: Метод Fave.GetMarketItems
permalink: fave/getMarketItems/
comments: true
---
# Метод Fave.GetMarketItems
Возвращает товары, добавленные в закладки текущим пользователем.

Страница документации ВКонтакте [fave.getMarketItems](https://vk.com/dev/fave.getMarketItems).

## Синтаксис
``` csharp
public VkCollection<Market> GetMarketItems(ulong? count = null, ulong? offset = null, bool? extended = null)
```

## Параметры
+ **count** — Число товаров, информацию о которых необходимо вернуть. положительное число, по умолчанию 50
+ **offset** — Смещение, необходимое для выборки определенного подмножества товаров. положительное число, по умолчанию 0
+ **extended** — 1 — будут возвращены дополнительные поля likes, can_comment, can_repost, photos. По умолчанию данные поля не возвращается. флаг, может принимать значения 1 или 0

## Результат
После успешного выполнения возвращает список объектов товаров.

## Пример
``` csharp
var getMarketItems = _api.Fave.GetMarketItems();
```

## Версия Вконтакте API v.5.50
Дата обновления: 24.03.2016 15:54:44
