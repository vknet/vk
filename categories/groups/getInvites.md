---
layout: default
title: Метод Groups.GetInvites
permalink: groups/getInvites/
comments: true
---
# Метод Groups.GetInvites
Данный метод возвращает список приглашений в сообщества и встречи.

## Синтаксис
```csharp
public ReadOnlyCollection<Group> GetInvites(int? count = null, int? offset = null)
```

## Параметры
+ **count** - количество приглашений, которое необходимо вернуть.
+ **offset** - смещение, необходимое для выборки определённого подмножества приглашений.

## Результат
После успешного выполнения возвращает список объектов сообществ с дополнительным полем InvitedBy, содержащим идентификатор пользователя, который отправил приглашение.

## Исключения

## Пример
```csharp
// TODO:
```
