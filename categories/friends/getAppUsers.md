---
layout: default
title: Метод Friends.GetAppUsers
permalink: friends/getAppUsers/
comments: true
---
# Метод Friends.GetAppUsers
Возвращает список идентификаторов друзей текущего пользователя, которые установили данное приложение.

Страница документации ВКонтакте [friends.getAppUsers](https://vk.com/dev/friends.getAppUsers).
## Синтаксис
``` csharp
public ReadOnlyCollection<long> GetAppUsers()
```

## Параметры
Данный метод не имеет входных параметров.

## Результат
После успешного выполнения возвращает список идентификаторов (id) друзей текущего пользователя, установивших приложение.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получение идентификторов друзей текущего пользователя, установивших приложение.
var ids = vk.Friends.GetAppUsers();
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
