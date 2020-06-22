---
layout: default
title: Метод Account.SetSilenceMode
permalink: account/setSilenceMode/
comments: true
---
# Метод Account.SetSilenceMode
Отключает push-уведомления на заданный промежуток времени.

Страница документации ВКонтакте [account.setSilenceMode](https://vk.com/dev/account.setSilenceMode).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).
Требуются [права доступа](https://vk.com/dev/permissions) messages.

## Синтаксис
``` csharp
public bool SetSilenceMode(string deviceId, long? time, long? peerId, long? sound)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства.
+ **time** - Время в секундах на которое требуется отключить уведомления, -1 отключить навсегда.
+ **peerId** - Идентификатор назначения.  
Для пользователя: id пользователя. 
Для групповой беседы: 2000000000 + id беседы. 
Для сообщества: -id сообщества. 
+ **sound**
**true** - включить звук в данном диалоге. 
**false** - отключить звук (параметр работает только если указан в peer_id передан идентификатор групповой беседы или пользователя).

## Результат
Возвращает **true** в случае успешного выполнения метода.

## Пример
``` csharp
var setSilenceMode = _api.Account.SetSilenceMode();
            Console.WriteLine(setSilenceMode);
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:21
