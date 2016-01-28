---
layout: default
title: Метод Messages.CreateChat
permalink: messages/createChat/
comments: true
---
# Метод Messages.CreateChat
Создаёт беседу с несколькими участниками.

Страница документации ВКонтакте [messages.createChat](https://vk.com/dev/messages.createChat).
## Синтаксис
``` csharp
public long CreateChat(IEnumerable<ulong> userIds, [NotNull] string title)
```

## Параметры
+ **userIds** - Идентификаторы пользователей, которых нужно включить в мультидиалог. список положительных чисел, разделенных запятыми, обязательный параметр
+ **title** - Название беседы. строка

## Результат
После успешного выполнения возвращает  идентификатор созданного чата (chat_id).

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
