---
layout: default
title: Метод Database.GetCities
permalink: database/getCities/
comments: true
---
# Метод Database.GetCities
Возвращает список городов.

## Синтаксис
```csharp
public ReadOnlyCollection<City> GetCities(int countryId, int? regionId = null, string query, Nullable<bool> needAll, int? count = null, int? offset = null)
```

## Параметры
+ **countryId** - Идентификатор страны.
+ **regionId** - Идентификатор региона.
+ **query** - Строка поискового запроса. Например, Санкт.
+ **needAll** - true – возвращать все города. false – возвращать только основные города.
+ **count** - Количество городов, которые необходимо вернуть.
+ **offset** - Отступ, необходимый для получения определенного подмножества городов.

## Результат
Cписок городов.

## Замечания
+ Если не задан параметр query, то будет возвращен список самых крупных городов в заданной стране.
+ Если задан параметр query то будет возвращен список городов, которые релевантны поисковому запросу.

## Исключения

## Пример
```csharp
ReadOnlyCollection<City> cities = api.Database.GetCities(1, count: 3);
```