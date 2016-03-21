---
layout: default
title: Метод Fave.AddUser
permalink: fave/addUser/
comments: true
---
# Метод Fave.AddUser
Добавляет пользователя в закладки.

Страница документации ВКонтакте [fave.addUser](https://vk.com/dev/fave.addUser).

## Синтаксис
``` csharp
public bool AddUser(long userId)
```

## Параметры
+ **userId** - Идентификатор пользователя, которого нужно добавить в закладки. положительное число, обязательный параметр

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
var addUser = _api.Fave.AddUser(userId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 13:59:16
