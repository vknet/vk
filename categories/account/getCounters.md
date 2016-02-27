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
// Пример кода
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
