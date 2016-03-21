---
layout: default
title: Метод Messages.DeleteChatPhoto
permalink: messages/deleteChatPhoto/
comments: true
---
# Метод Messages.DeleteChatPhoto
Позволяет удалить фотографию мультидиалога.

Страница документации ВКонтакте [messages.deleteChatPhoto](https://vk.com/dev/messages.deleteChatPhoto).

## Синтаксис
``` csharp
public Chat DeleteChatPhoto(out ulong messageId, ulong chatId)
```

## Параметры
+ **messageId** - Идентификатор отправленного системного сообщения
+ **chatId** - Идентификатор беседы. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает объект, содержащий следующие поля: 
+ **message_id** — идентификатор отправленного системного сообщения; 
+ **chat** — объект мультидиалога.

## Пример
``` csharp
var deleteChatPhoto = _api.Messages.DeleteChatPhoto(chatId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
