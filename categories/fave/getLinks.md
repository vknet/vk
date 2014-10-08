---
layout: default
title: Метод Fave.GetLinks
permalink: fave/getLinks/
comments: true
---
# Метод Fave.GetLinks
Возвращает ссылки, добавленные в закладки текущим пользователем.

## Синтаксис
```csharp
public ReadOnlyCollection<Link> GetLinks(int? count = null, int? offset = null)
```

## Параметры
+ **count** - Количество пользователей, информацию о которых необходимо вернуть.
+ **offset** - Смещение, необходимое для выборки определенного подмножества пользователей.

## Результат
После успешного выполнения возвращает общее количество ссылок и массив объектов Link.

## Исключения

## Пример
```csharp
// TODO:
```