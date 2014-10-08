---
layout: default
title: Метод Messages.CreateChat
permalink: messages/createChat/
comments: true
---
# Метод Messages.CreateChat
Создаёт беседу с несколькими участниками.

## Синтаксис
```csharp
public long CreateChat(IEnumerable<long> userIds, string title)
```

## Параметры
+ **userIds** - Идентификаторы пользователей, которых нужно включить в беседу (мультидиалог).
+ **title** - Название беседы.

## Результат
После успешного выполнения возвращает идентификатор созданной беседы.

## Исключения

## Пример
```csharp
// TODO: 
```