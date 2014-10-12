---
layout: default
title: Метод Friends.EditList
permalink: friends/editList/
comments: true
---
# Метод Friends.EditList
Редактирует существующий список друзей текущего пользователя.

## Синтаксис
```csharp
public bool EditList(
	long listId, 
	string name, 
	IEnumerable<long> userIds, 
	IEnumerable<long> addUserIds, 
	IEnumerable<long> deleteUserIds
)
```

## Параметры
+ **listId** - идентификатор списка друзей
+ **name** - название списка друзей
+ **userIds** - идентификаторы пользователей, включенных в список
+ **addUserIds** - идентификаторы пользователей, которых необходимо добавить в список. (в случае если не передан user_ids)
+ **deleteUserIds** - идентификаторы пользователей, которых необходимо изъять из списка. (в случае если не передан user_ids)

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO: 
```
