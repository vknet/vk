---
layout: default
title: Метод Friends.Edit
permalink: friends/edit/
comments: true
---
# Метод Friends.Edit
Редактирует списки друзей для выбранного друга.

## Синтаксис
```csharp
public bool Edit(long userId, IEnumerable<long> listIds)
```

## Параметры
+ **userId** - идентификатор пользователя (из числа друзей), для которого необходимо отредактировать списки друзей.
+ **listIds** - идентификаторы списков друзей, в которые нужно добавить пользователя.

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```
