---
layout: default
title: Метод Account.UnbanUser
permalink: account/unbanUser/
comments: true
---
# Метод Account.UnbanUser
Убирает пользователя из черного списка.

Страница документации ВКонтакте [account.unbanUser](https://vk.com/dev/account.unbanUser).

## Синтаксис
``` csharp
public bool UnbanUser(long userId)
```

## Параметры
+ **userId** - Идентификатор пользователя, которого нужно убрать из черного списка. положительное число, обязательный параметр

## Результат
В случае успеха метод вернет **true**.

## Пример
``` csharp
            var unbanUser = _api.Account.UnbanUser(userId: 1);
            Console.WriteLine(unbanUser.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 23:21:10
