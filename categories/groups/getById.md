---
layout: default
title: Метод Groups.GetById
permalink: groups/getById/
comments: true
---
# Метод Groups.GetById
Возвращает информацию о заданной группе.

# Синтаксис
```csharp
public Group GetById(long gid, GroupsFields fields = null)
```

## Параметры
+ **gid** - ID группы информацию о которой необходимо получить.
+ **fields** - Список полей из информации о группах, которые необходимо получить.

## Результат
Возвращает информацию о группах в виде списка объектов.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - Неправильный идентификатор группы.

## Пример
```csharp
// Получаем основную информацию о группе с id равным 2.
var groups = vk.Groups.GetById(2);

// Получаем всю информацию о группе с id равным 2.
var groups = vk.Groups.GetById(2, GroupsFields.All);

// Получаем основную информацию о трех группах
var gids = new long[] {1, 2, 3};
var groups = vk.Groups.GetById(gids);

// Получаем всю информацию о трех группах
var gids = new long[] {1, 2, 3};
var groups = vk.Groups.GetById(gids, GroupsFields.All);
```
