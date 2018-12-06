---
layout: default
title: Метод Account.SetInfo
permalink: account/setInfo/
comments: true
---
# Метод Account.SetInfo
Позволяет редактировать информацию о текущем аккаунте.

Страница документации ВКонтакте [account.setInfo](https://vk.com/dev/account.setInfo).

## Синтаксис
``` csharp
public bool SetInfo(string name, string value)
```

## Параметры
+ **name** - Имя настройки строка, доступен начиная с версии 5.49
+ **value** - Значение настройки строка, доступен начиная с версии 5.49

## Результат
В результате успешного выполнения возвращает **true**.

## Пример
``` csharp
            var own_posts_default = _api.Account.SetInfo("own_posts_default", "1");
            var no_wall_replies = _api.Account.SetInfo("no_wall_replies", "1");
            var intro = _api.Account.SetInfo("intro", "1");
            Console.WriteLine(intro.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 23:05:10
