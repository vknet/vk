---
layout: default
title: Метод Messages.Delete
permalink: messages/delete/
comments: true
---
# Метод Messages.Delete
Удаляет сообщения пользователя.

## Синтаксис
```csharp
public IDictionary<long, bool> Delete(IEnumerable<long> messageIds)
```

## Параметры
+ **messageIds** - Идентификаторы удаляемых сообщений.

## Результат
Возвращает словарь (идентификатор сообщения --> признак было ли удаление сообщения успешным).

## Исключения

## Пример
```csharp
// TODO:
```