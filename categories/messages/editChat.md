---
layout: default
title: Метод Messages.EditChat
permalink: messages/editChat/
comments: true
---
# Метод Messages.EditChat
Изменяет название беседы.

Страница документации ВКонтакте [messages.editChat](https://vk.com/dev/messages.editChat).

## Синтаксис
``` csharp
public bool EditChat(long chatId, [NotNull] string title)
```

## Параметры
+ **chatId** — Идентификатор беседы. целое число, обязательный параметр
+ **title** — Новое название для беседы. строка, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var editChat = _api.Messages.EditChat(chatId: 0, title: "title");
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
