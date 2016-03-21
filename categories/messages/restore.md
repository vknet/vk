---
layout: default
title: Метод Messages.Restore
permalink: messages/restore/
comments: true
---
# Метод Messages.Restore
Восстанавливает удаленное сообщение.

Страница документации ВКонтакте [messages.restore](https://vk.com/dev/messages.restore).

## Синтаксис
``` csharp
public bool Restore(long messageId)
```

## Параметры
+ **messageId** - Идентификатор сообщения, которое нужно восстановить. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var restore = _api.Messages.Restore(messageId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
