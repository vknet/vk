---
layout: default
title: Метод Database.GetCountriesById
permalink: database/getCountriesById/
comments: true
---
# Метод Database.GetCountriesById
Возвращает информацию о странах по их идентификаторам.

## Синтаксис
```csharp
public ReadOnlyCollection<Country> GetCountriesById(params int[] countryIds)
```

## Параметры
+ **countryIds** - Идентификаторы стран.

## Результат
Информация о странах.

## Исключения

## Пример
```csharp
ReadOnlyCollection<Country> countries = api.Database.GetCountriesById(1, 65);
```