---
layout: default
title: Метод Messages.MarkAsRead
permalink: messages/markAsRead/
comments: true
---
# Метод Messages.MarkAsRead
Помечает сообщения как прочитанные.

Страница документации ВКонтакте [messages.markAsRead](https://vk.com/dev/messages.markAsRead).

## Синтаксис
``` csharp
public bool MarkAsRead(IEnumerable<string> messageIds, string peerId, long? startMessageId)
```

## Параметры
+ **messageIds** - Идентификаторы сообщений. список положительных чисел, разделенных запятыми
+ **peerId** - Идентификатор чата или пользователя, если это диалог. строка
+ **startMessageId** - При передаче этого параметра будут помечены как прочитанные все сообщения, начиная с данного. положительное число

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var markAsRead = _api.Messages.MarkAsRead();
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
