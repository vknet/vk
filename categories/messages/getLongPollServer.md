---
layout: default
title: Метод Messages.GetLongPollServer
permalink: messages/getLongPollServer/
comments: true
---
# Метод Messages.GetLongPollServer
Возвращает данные, необходимые для подключения к Long Poll серверу.

Страница документации ВКонтакте [messages.getLongPollServer](https://vk.com/dev/messages.getLongPollServer).
## Синтаксис
``` csharp
public LongPollServerResponse GetLongPollServer(bool useSsl = false, bool needPts = false)
```

## Параметры
+ **useSsl** - 1 — использовать SSL. флаг, может принимать значения 1 или 0
+ **needPts** - 1 — возвращать поле pts, необходимое для работы метода messages.getLongPollHistory флаг, может принимать значения 1 или 0

## Результат
Возвращает объект, который содержит поля key, server, ts. 
Используя эти данные, Вы можете подключиться к серверу быстрых сообщений для мгновенного получения приходящих сообщений и других событий. 
Формат взаимодействия с LongPoll сервером.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
