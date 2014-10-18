---
layout: default
title: Метод Video.Search
permalink: video/search/
comments: true
---
# Метод Video.Search
Возвращает список видеозаписей в соответствии с заданным критерием поиска.

## Синтаксис
```csharp
public ReadOnlyCollection<Video> Search(
	string query, 
	VideoSort sort, 
	bool isHd, 
	bool isAdult, 
	VideoFilters filters, 
	bool isSearchOwn, 
	int? count = null, 
	int? offset = null
)
```

## Параметры
+ **query** - строка поискового запроса.
+ **sort** - вид сортировки.
+ **isHd** - если true, то поиск производится только по видеозаписям высокого качества.
+ **isAdult** - фильтр «Безопасный поиск»
+ **filters** - список критериев, по которым требуется отфильтровать видео.
+ **isSearchOwn** - искать по видеозаписям пользователя.
+ **count** - количество возвращаемых видеозаписей.
+ **offset** - смещение относительно первой найденной видеозаписи для выборки определенного подмножества.

## Результат
После успешного выполнения возвращает список объектов видеозаписей.

## Исключения

## Пример
```csharp
// TODO: 
```