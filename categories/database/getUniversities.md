---
layout: default
title: Метод Database.GetUniversities
permalink: database/getUniversities/
comments: true
---
# Метод Database.GetUniversities
Возвращает список высших учебных заведений.

## Синтаксис
```csharp
public ReadOnlyCollection<University> GetUniversities(
	int countryId, 
	int cityId, 
	string query, 
	int? offset = null, 
	int? count = null
)
```

## Параметры
+ **countryId** - Идентификатор страны, учебные заведения которой необходимо вернуть.
+ **cityId** - Идентификатор города, учебные заведения которого необходимо вернуть.
+ **query** - Строка поискового запроса. Например, СПБ.
+ **offset** - Отступ, необходимый для получения определенного подмножества учебных заведений.
+ **count** - Количество учебных заведений, которое необходимо вернуть.

## Результат
Список высших учебных заведений, удовлетворяющих заданным условиям.

## Исключения

## Пример
```csharp
var universities = api.Database.GetUniversities(1, 10, "ВолгГТУ");
```
