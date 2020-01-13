---
layout: default
title: Метод Database.GetSchoolClasses
permalink: database/getSchoolClasses/
comments: true
---
# Метод Database.GetSchoolClasses
Возвращает список классов, характерных для школ определенной страны.

Страница документации ВКонтакте [database.getSchoolClasses](https://vk.com/dev/database.getSchoolClasses).

## Синтаксис
``` csharp
public ReadOnlyCollection<SchoolClass> GetSchoolClasses(long countryId)
```

## Параметры
+ **countryId** — Идентификатор страны, доступные классы в которой необходимо вернуть. положительное число

## Результат
Возвращает массив, каждый элемент которого представляет собой пару: идентификатор и строковое обозначение класса.

## Пример
``` csharp
var getSchoolClasses = _api.Database.GetSchoolClasses();
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
