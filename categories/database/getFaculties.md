---
layout: default
title: Метод Database.GetFaculties
permalink: database/getFaculties/
comments: true
---
# Метод Database.GetFaculties
Возвращает список факультетов.

## Синтаксис
```csharp
public ReadOnlyCollection<Faculty> GetFaculties(long universityId, int? count = null, int? offset = null)
```

## Параметры
+ **universityId** - Идентификатор университета, факультеты которого необходимо получить.
+ **count** - Отступ, необходимый для получения определенного подмножества факультетов.
+ **offset** - Количество факультетов которое необходимо получить.

## Результат
Cписок факультетов.

## Исключения

## Пример
```csharp
ReadOnlyCollection<Faculty> faculties = api.Database.GetFaculties(431, 3, 2);
```