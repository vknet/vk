---
layout: default
title: Метод Account.BanUser
permalink: account/banUser/
comments: true
---
# Метод Account.BanUser
Добавляет пользователя в черный список.

Страница документации ВКонтакте [account.banUser](https://vk.com/dev/account.banUser).

## Синтаксис
``` csharp
public bool BanUser(long userId)
```

## Параметры
+ **userId** - Идентификатор пользователя, которого нужно добавить в черный список. положительное число, обязательный параметр

## Результат
В случае успеха метод вернет **true**.

## Пример
``` csharp
_api.Account.BanUser(1); // Забаним Пашу
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
