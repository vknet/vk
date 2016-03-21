---
layout: default
title: Метод Messages.SetActivity
permalink: messages/setActivity/
comments: true
---
# Метод Messages.SetActivity
Изменяет статус набора текста пользователем в диалоге.

Страница документации ВКонтакте [messages.setActivity](https://vk.com/dev/messages.setActivity).

## Синтаксис
``` csharp
public bool SetActivity(long userId, long? peerId = null)
```

## Параметры
+ **userId** - Идентификатор пользователя. строка
+ **peerId** - Идентификатор назначения. 
Для групповой беседы: 
2000000000 + id беседы. 
Для сообщества: 
-id сообщества. 
 целое число, доступен начиная с версии 5.38

## Результат
После успешного выполнения возвращает **true**. 
Текст «N набирает сообщение...» отображается в течение 10 секунд после вызова метода, либо до момента отправки сообщения.

## Пример
``` csharp
var setActivity = _api.Messages.SetActivity();
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
