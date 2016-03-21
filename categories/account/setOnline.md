---
layout: default
title: Метод Account.SetOnline
permalink: account/setOnline/
comments: true
---
# Метод Account.SetOnline
Помечает текущего пользователя как online на 15 минут.

Страница документации ВКонтакте [account.setOnline](https://vk.com/dev/account.setOnline).

## Синтаксис
``` csharp
public bool SetOnline(bool? voip = null)
```

## Параметры
+ **voip** - Возможны ли видеозвонки для данного устройства флаг, может принимать значения 1 или 0

## Результат
В случае успешного выполнения метода будет возвращён код **true**.

## Пример
``` csharp
var setOnline = _api.Account.SetOnline();
```

## Версия Вконтакте API v.5.50
Дата обновления: 15.02.2016 14:14:52
