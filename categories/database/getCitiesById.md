---
layout: default
title: Метод Database.GetCitiesById
permalink: database/getCitiesById/
comments: true
---
# Метод Database.GetCitiesById
Возвращает информацию о городах по их идентификаторам.

## Синтаксис
```csharp
public ReadOnlyCollection<City> GetCitiesById(params int[] cityIds)
```

## Параметры
+ **cityIds** - Идентификаторы городов.

## Результат
Информация о городах.

## Исключения

## Пример
```csharp
var cities = api.Database.GetCitiesById(1, 2, 10);
```