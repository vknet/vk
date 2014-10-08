---
layout: default
title: Метод Database.GetCountries
permalink: database/getCountries/
comments: true
---
# Метод Database.GetCountries
Возвращает список стран.

## Синтаксис
```csharp
public ReadOnlyCollection<Country> GetCountries(bool needAll, string codes, int? offset = null, int? count = null)
```

## Параметры
+ **needAll** - Флаг - вернуть список всех стран.
+ **codes** - Перечисленные через запятую двухбуквенные коды стран в стандарте ISO 3166-1 alpha-2.
+ **offset** - Отступ, необходимый для выбора определенного подмножества стран.
+ **count** - Количество стран, которое необходимо вернуть.

## Результат
Возвращает список стран.

## Замечания
+ Если не заданы параметры needAll и code, то возвращается краткий список стран, расположенных наиболее близко к стране текущего пользователя. Если задан параметр needAll, то будет возвращен список всех стран. Если задан параметр code, то будут возвращены только страны с перечисленными ISO 3166-1 alpha-2 кодами.

## Исключения

## Пример
```csharp
// Россия и Германия
var countries = api.Database.GetCountries(codes: "ru, de");
```