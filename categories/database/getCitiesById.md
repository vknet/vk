---
layout: default
title: Метод Database.GetCitiesById
permalink: database/getCitiesById/
comments: true
---
# Метод Database.GetCitiesById
Возвращает информацию о городах по их идентификаторам.

Страница документации ВКонтакте [database.getCitiesById](https://vk.com/dev/database.getCitiesById).

## Синтаксис
``` csharp
public ReadOnlyCollection<City> GetCitiesById(params int[] cityIds)
```

## Параметры
+ **cityIds** - Идентификаторы городов. список положительных чисел, разделенных запятыми, количество элементов должно составлять не более 1000

## Результат
Возвращает массив объектов city, каждый из которых имеет поля id и title.

## Пример
```csharp
var cities = api.Database.GetCitiesById(1, 2, 10);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
