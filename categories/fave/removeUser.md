---
layout: default
title: Метод Fave.RemoveUser
permalink: fave/removeUser/
comments: true
---
# Метод Fave.RemoveUser
Удаляет пользователя из закладок.

Страница документации ВКонтакте [fave.removeUser](https://vk.com/dev/fave.removeUser).

## Синтаксис
``` csharp
public bool RemoveUser(long userId)
```

## Параметры
+ **userId** — Идентификатор пользователя, которого нужно удалить из закладок. положительное число, обязательный параметр

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
var removeUser = _api.Fave.RemoveUser(userId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 13:59:16
