---
layout: default
title: Метод Account.SetOffline
permalink: account/setOffline/
comments: true
---
# Метод Account.SetOffline
Помечает текущего пользователя как offline (только в текущем приложении).

Страница документации ВКонтакте [account.setOffline](https://vk.com/dev/account.setOffline).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public bool SetOffline()
```

## Параметры
Метод не содержит входных параметров

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
            var setOffline = _api.Account.SetOffline();
            Console.WriteLine(setOffline);
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:11
