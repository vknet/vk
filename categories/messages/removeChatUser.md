---
layout: default
title: Метод Messages.RemoveChatUser
permalink: messages/removeChatUser/
comments: true
---
# Метод Messages.RemoveChatUser
Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.

Страница документации ВКонтакте [messages.removeChatUser](https://vk.com/dev/messages.removeChatUser).

## Синтаксис
``` csharp
public bool RemoveChatUser(long chatId, long userId)
```

## Параметры
+ **chatId** - Идентификатор беседы. целое число, обязательный параметр
+ **userId** - Идентификатор пользователя, которого необходимо исключить из беседы. Может быть меньше нуля в случае, если пользователь приглашён по email. обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var removeChatUser = _api.Messages.RemoveChatUser(chatId: 0, userId: "user_id");
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
