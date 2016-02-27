---
layout: default
title: Метод Database.GetCountriesById
permalink: database/getCountriesById/
comments: true
---
# Метод Database.GetCountriesById
Возвращает информацию о странах по их идентификаторам

Страница документации ВКонтакте [database.getCountriesById](https://vk.com/dev/database.getCountriesById).

## Синтаксис
``` csharp
public ReadOnlyCollection<Country> GetCountriesById(params int[] countryIds)
```

## Параметры
+ **countryIds** - Идентификаторы стран. список положительных чисел, разделенных запятыми, количество элементов должно составлять не более 1000

## Результат
Возвращает массив объектов country, каждый из которых имеет поля id и title.

## Пример
```csharp
ReadOnlyCollection<Country> countries = api.Database.GetCountriesById(1, 65);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
