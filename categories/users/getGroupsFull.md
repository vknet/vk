---
layout: default
title: Метод Users.GetGroupsFull
permalink: users/getGroupsFull/
comments: true
---
# Метод Users.GetGroupsFull

## Параметры
+ **gids** - Список идентификаторов групп

## Результат
Возвращает базовую информацию о группах.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **ArgumentNullException** - параметр gids имеет значение null.

## Пример
```csharp
// Получение базовой информации о 3-х группах.
var gids = new long[] {1, 2, 3};
var groups = vk.Users.GetGroupsFull(gids);
```
