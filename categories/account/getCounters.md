---
layout: default
title: Метод Account.GetCounters
permalink: account/getCounters/
comments: true
---
# Метод Account.GetCounters
Возвращает ненулевые значения счетчиков пользователя.

Страница документации ВКонтакте [account.getCounters](https://vk.com/dev/account.getCounters).

## Синтаксис
``` csharp
public Counters GetCounters(CountersFilter filter)
```

## Параметры
+ **filter** - Счетчики, информацию о которых нужно вернуть (friends, messages, photos, videos, notes, gifts, events, groups, notifications, sdk, app_requests). 
sdk - возвращает количество запросов в приложениях. 
app_requests - возвращает количество непрочитанных запросов в приложениях. список слов, разделенных через запятую

## Результат
Возвращает объект, который может содержать поля friends, messages, photos, videos, notes, gifts, events, groups, notifications, sdk, app_requests.

## Пример
``` csharp
            var counters = _api.Account.GetCounters(CountersFilter.All);
            Console.WriteLine(counters.Groups.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 08.12.2018 01:34:10
