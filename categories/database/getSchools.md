---
layout: default
title: Метод Database.GetSchools
permalink: database/getSchools/
comments: true
---
# Метод Database.GetSchools
Возвращает список школ.

## Синтаксис
```csharp
public ReadOnlyCollection<School> GetSchools(
	int countryId, 
	int cityId, 
	string query, 
	int? offset = null, 
	int? count = null
)
```

## Параметры
+ **countryId** - Идентификатор страны, школы которой необходимо вернуть.
+ **cityId** - Идентификатор города, школы которого необходимо вернуть.
+ **query** - Строка поискового запроса. Например, гимназия.
+ **offset** - Отступ, необходимый для получения определенного подмножества школ.
+ **count** - Количество школ, которое необходимо вернуть.

## Результат
Cписок школ.

## Исключения

## Пример
```csharp
ReadOnlyCollection<School> schools = db.GetSchools(1, 10, count: 3);
```
