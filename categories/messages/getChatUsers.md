---
layout: default
title: Метод Messages.GetChatUsers
permalink: messages/getChatUsers/
comments: true
---
# Метод Messages.GetChatUsers
Позволяет получить список пользователей беседы по ее идентификатору.

## Синтаксис
```csharp
public ReadOnlyCollection<User> GetChatUsers(long chatId, ProfileFields fields)
```

## Параметры
+ **chatId** - Идентификатор беседы.
+ **fields** - Список дополнительных полей профилей, которые необходимо вернуть.

## Результат
После успешного выполнения возвращает список идентификаторов участников беседы.

## Исключения

## Пример
```csharp
// TODO:
```