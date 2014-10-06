---
layout: default
title: Метод Users.GetSubscription
permalink: users/getSubscription/
comments: true
---
# Метод Users.GetSubscription
Возвращает список идентификаторов пользователей и групп, которые входят в список подписок пользователя.

## Синтаксис
```csharp
public ReadOnlyCollection<Group> GetSubscriptions(long? userId = null, int? count = null, int? offset = null)
```

## Параметры
+ **userId** - Идентификатор пользователя, подписки которого необходимо получить.
+ **count** - Количество подписок, которые необходимо вернуть.
+ **offset** - Смещение необходимое для выборки определенного подмножества подписок.

## Результат
Пока возвращается только список групп.

## Исключения

## Пример
```csharp
// TODO:
```
