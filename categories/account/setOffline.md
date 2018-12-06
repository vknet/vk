---
layout: default
title: Метод Account.SetOffline
permalink: account/setOffline/
comments: true
---
# Метод Account.SetOffline
Помечает текущего пользователя как offline.

Страница документации ВКонтакте [account.setOffline](https://vk.com/dev/account.setOffline).

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
            Console.WriteLine(setOffline.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2016 23:18:52
