---
layout: default
title: Метод Account.UnbanUser
permalink: account/unbanUser/
comments: true
---
# Метод Account.UnbanUser
Убирает пользователя или группу из черного списка.

Страница документации ВКонтакте [account.unbanUser](https://vk.com/dev/account.unbanUser).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public bool UnbanUser(long ownerId)
```

## Параметры
+ **ownerId** - Идентификатор пользователя, которого нужно убрать из черного списка. Обязательный параметр

## Результат
В случае успеха метод вернет **true**.

## Пример
``` csharp
            var unbanUser = _api.Account.UnbanUser(ownerId: 1);
            Console.WriteLine(unbanUser.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:22
