---
layout: default
title: Метод Fave.GetUsers
permalink: fave/getUsers/
comments: true
---
# Метод Fave.GetUsers
Возвращает список пользователей, добавленных текущим пользователем в закладки.

## Синтаксис
```csharp
public ReadOnlyCollection<User> GetUsers(int? count = null, int? offset = null)
```

## Параметры
+ **count** - Количество пользователей, информацию о которых необходимо вернуть.
+ **offset** - Смещение, необходимое для выборки определенного подмножества пользователей.

## Результат
После успешного выполнения возвращает список объектов пользователей.

## Исключения

## Пример
```csharp
// TODO:
```