---
layout: default
title: Метод Groups.GetBanned
permalink: groups/getBanned/
comments: true
---
# Метод Groups.GetBanned
Возвращает список забаненных пользователей в сообществе

## Синтаксис
```csharp
public ReadOnlyCollection<User> GetBanned(
	long groupId, 
	int? count = null, 
	int? offset = null
)
```

## Параметры
+ **groupId** - идентификатор сообщества.
+ **count** - количество записей, которое необходимо вернуть.
+ **offset** - смещение, необходимое для выборки определенного подмножества черного списка.

## Результат
После успешного выполнения возвращает список объектов пользователей с дополнительным полем BanInfo.

## Исключения

## Пример
```csharp
// TODO:
```
