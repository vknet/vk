---
layout: default
title: Метод Account.SetOnline
permalink: account/setOnline/
comments: true
---
# Метод Account.SetOnline
Помечает текущего пользователя как online на 5 минут.

Страница документации ВКонтакте [account.setOnline](https://vk.com/dev/account.setOnline).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public bool SetOnline(bool? voip = null)
```

## Параметры
+ **voip** - Возможны ли видеозвонки для данного устройства.

## Результат
В случае успешного выполнения метода будет возвращён код **true**.

## Пример
``` csharp
            var setOnline = _api.Account.SetOnline();
            Console.WriteLine(setOnline);
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:12
