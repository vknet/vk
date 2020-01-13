---
layout: default
title: Метод Messages.GetById
permalink: messages/getById/
comments: true
---
# Метод Messages.GetById
Возвращает сообщения по их id.

Страница документации ВКонтакте [messages.getById](https://vk.com/dev/messages.getById).

## Синтаксис
``` csharp
public ReadOnlyCollection<Message> GetById(
	out int totalCount,
	[NotNull] IEnumerable<ulong> messageIds,
	uint? previewLength = null
)
```

## Параметры
+ **totalCount** — Общее количество сообщений.
+ **messageIds** — Идентификаторы сообщений. список положительных чисел, разделенных запятыми
+ **previewLength** — Количество символов, по которому нужно обрезать сообщение. Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются). положительное число, по умолчанию 0

## Результат
После успешного выполнения возвращает список объектов сообщений.

## Пример
``` csharp
var getById = _api.Messages.GetById(messageIds: );
```

## Версия Вконтакте API v.5.44
Дата обновления: 27.01.2016 19:50:49
