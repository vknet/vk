---
layout: default
title: Метод Database.GetStreetsById
permalink: database/getStreetsById/
comments: true
---
# Метод Database.GetStreetsById
Возвращает информацию об улицах по их идентификаторам.

## Синтаксис
```csharp
public ReadOnlyCollection<Street> GetStreetsById(params int[] streetIds)
```

## Параметры
+ **streetIds** - Идентификаторы улиц.

## Результат
Информация об улицах.

## Исключения

## Пример
```csharp
ReadOnlyCollection<Street> streets = api.Database.GetStreetsById(1, 89, 437);
```