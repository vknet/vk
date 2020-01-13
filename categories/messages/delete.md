---
layout: default
title: Метод Messages.Delete
permalink: messages/delete/
comments: true
---
# Метод Messages.Delete
Удаляет сообщение.

Страница документации ВКонтакте [messages.delete](https://vk.com/dev/messages.delete).

## Синтаксис
``` csharp
public IDictionary<ulong, bool> Delete(IEnumerable<ulong> messageIds)
```

## Параметры
+ **messageIds** — Список идентификаторов сообщений, разделённых через запятую. список положительных чисел, разделенных запятыми

## Результат
После успешного выполнения возвращает **true** для каждого удаленного сообщения.

## Пример
``` csharp
var delete = _api.Messages.Delete();
```

## Версия Вконтакте API v.5.44
Дата обновления: 27.01.2016 19:50:49
