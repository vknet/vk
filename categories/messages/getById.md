---
layout: default
title: Метод Messages.GetById
permalink: messages/getById/
comments: true
---
# Метод Messages.GetById
Возвращает сообщения по их идентификаторам.

## Синтаксис
```csharp
public ReadOnlyCollection<Message> GetById(IEnumerable<long> messageIds, out int totalCount, int? previewLength = null)
```

## Параметры
+ **messageIds** - Идентификаторы сообщений, которые необходимо вернуть (не более 100).
+ **totalCount** - Общее количество сообщений.
+ **previewLength** - Количество слов, по которому нужно обрезать сообщение. Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).

## Результат
Запрошенные сообщения.

## Исключения

## Пример
```csharp
// TODO:
```