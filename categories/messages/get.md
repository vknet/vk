---
layout: default
title: Метод Messages.Get
permalink: messages/get/
comments: true
---
# Метод Messages.Get
Возвращает список входящих либо исходящих личных сообщений текущего пользователя.

## Синтаксис
```csharp
public ReadOnlyCollection<Message> Get(MessageType type, out int totalCount, int? count = null, int? offset = null, MessagesFilter? filter = null, int? previewLength = null, DateTime? startDate = null)
```

## Параметры
+ **type** - Тип сообщений которые необходимо получить.
+ **totalCount** - Общее количество сообщений, удовлетворяющих условиям фильтрации.
+ **count** - Количество сообщений, которое необходимо получить (но не более 100).
+ **offset** - Смещение, необходимое для выборки определенного подмножества сообщений.
+ **filter** - Фильтр возвращаемых сообщений.
+ **previewLength** - Количество символов, по которому нужно обрезать сообщение.
+ **startDate** - Время, начиная с которого необходимо вернуть сообщения.

## Результат
Список сообщений, удовлетворяющий условиям фильтрации.

## Исключения

## Пример
```csharp
// TODO:
```