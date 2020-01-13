---
layout: default
title: Метод Database.GetStreetsById
permalink: database/getStreetsById/
comments: true
---
# Метод Database.GetStreetsById
Возвращает информацию об улицах по их идентификаторам (id).

Страница документации ВКонтакте [database.getStreetsById](https://vk.com/dev/database.getStreetsById).

## Синтаксис
``` csharp
public ReadOnlyCollection<Street> GetStreetsById(params int[] streetIds)
```

## Параметры
+ **streetIds** — Идентификаторы улиц. список положительных чисел, разделенных запятыми, обязательный параметр, количество элементов должно составлять не более 1000

## Результат
Возвращает массив объектов street,  каждый из которых имеет поля id и title.

## Пример
```csharp
ReadOnlyCollection<Street> streets = api.Database.GetStreetsById(1, 89, 437);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
