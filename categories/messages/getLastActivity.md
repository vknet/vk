---
layout: default
title: Метод Messages.GetLastActivity
permalink: messages/getLastActivity/
comments: true
---
# Метод Messages.GetLastActivity
Возвращает текущий статус и дату последней активности указанного пользователя.

Страница документации ВКонтакте [messages.getLastActivity](https://vk.com/dev/messages.getLastActivity).

## Синтаксис
``` csharp
public LastActivity GetLastActivity(long userId)
```

## Параметры
+ **userId** - Идентификатор пользователя, информацию о последней активности которого требуется получить. целое число, обязательный параметр

## Результат
Возвращает объект, содержащий следующие поля: 

+ **online** — текущий статус пользователя (1 — в сети, 0 — не в сети); 
+ **time** — дата последней активности пользователя в формате unixtime.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
