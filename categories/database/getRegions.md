---
layout: default
title: Метод Database.GetRegions
permalink: database/getRegions/
comments: true
---
# Метод Database.GetRegions
Возвращает список регионов.

Страница документации ВКонтакте [database.getRegions](https://vk.com/dev/database.getRegions).

## Синтаксис
``` csharp
public ReadOnlyCollection<Region> GetRegions(
	int countryId,
	string query = "",
	int? count = null,
	int? offset = null
)
```

## Параметры
+ **countryId** — Идентификатор страны, полученный в методе database.getCountries. положительное число, обязательный параметр
+ **query** — Строка поискового запроса. Например, Лен. строка
+ **offset** — Отступ, необходимый для выбора определенного подмножества регионов. положительное число
+ **count** — Количество регионов, которое необходимо вернуть. положительное число, по умолчанию 100, максимальное значение 1000

## Результат
Возвращает массив регионов, каждый из объектов которого содержит поля region_id и title. Если не задан параметр query, то будет возвращен список всех регионов в заданной стране. Если задан параметр query, то будет возвращен список регионов, которые релевантны поисковому запросу.

## Пример
```csharp
ReadOnlyCollection<Region> regions = api.Database.GetRegions(1, count: 3, offset: 5);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
