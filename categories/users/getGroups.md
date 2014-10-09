---
layout: default
title: Метод Users.GetGroups
permalink: users/getGroups/
comments: true
---
# Метод Users.GetGroups
Возвращает список id групп пользователя.

# Синтаксис
```csharp

```

## Параметры
+ **uid** - id пользователя

## Результат
Возвращает список идентификаторов (id) групп текущего пользователя.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **AccessDeniedException** - приложение не имеет доступа для выполнения этой метода.

## Пример
```csharp
// Получаем идентификаторы групп в которых состоит Павел Дуров
var groups = vk.Users.GetGroups(1);
```
