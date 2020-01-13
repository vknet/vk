---
layout: default
title: Метод Market.GetCategories
permalink: market/getCategories/
comments: true
---
# Метод Market.GetCategories
Возвращает список категорий для товаров.

Страница документации ВКонтакте [market.getCategories](https://vk.com/dev/market.getCategories).

## Синтаксис
``` csharp
public ReadOnlyCollection<MarketCategory> GetCategories(long? count, long? offset)
```

## Параметры
+ **count** — Количество категорий, информацию о которых необходимо вернуть. положительное число, максимальное значение 1000, по умолчанию 10
+ **offset** — Смещение, необходимое для выборки определенного подмножества категорий. положительное число

## Результат
После успешного выполнения возвращает список объектов category. 
Объект category — категория товара.  
id идентификатор категории. 
 положительное число name название метки. 
 строка section секция. Объект, содержащий поля: 

id — идентификатор секции; 

положительное число 

name — название секции. 

строка

## Пример
``` csharp
var getCategories = _api.Market.GetCategories();
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
