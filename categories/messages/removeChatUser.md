---
layout: default
title: Метод Messages.RemoveChatUser
permalink: messages/removeChatUser/
comments: true
---
# Метод Messages.RemoveChatUser
Исключает из беседы пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.

## Синтаксис
```csharp
public bool RemoveChatUser(long chatId, long userId)
```

## Параметры
+ **chatId** - Идентификатор беседы.
+ **userId** - Идентификатор пользователя, которого необходимо исключить из беседы.

## Результат
После успешного выполнения возвращает true, false в противном случае.

## Исключения

## Пример
```csharp
// TODO:
```