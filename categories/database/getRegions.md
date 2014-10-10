---
layout: default
title: Метод Database.GetRegions
permalink: database/getRegions/
comments: true
---
# Метод Database.GetRegions
Возвращает список регионов.

## Синтаксис
```csharp
public ReadOnlyCollection<Region> GetRegions(
	int countryId, 
	string query, 
	int? count = null, 
	int? offset = null
)
```

## Параметры
+ **countryId** - Идентификатор страны.
+ **query** - Строка поискового запроса.
+ **count** - Количество регионов, которое необходимо вернуть.
+ **offset** - Отступ, необходимый для выбора определенного подмножества регионов.

## Результат
Список регионов.

## Исключения

## Пример
```csharp
ReadOnlyCollection<Region> regions = api.Database.GetRegions(1, count: 3, offset: 5);
```
