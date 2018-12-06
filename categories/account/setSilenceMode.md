---
layout: default
title: Метод Account.SetSilenceMode
permalink: account/setSilenceMode/
comments: true
---
# Метод Account.SetSilenceMode
Отключает push-уведомления на заданный промежуток времени.

Страница документации ВКонтакте [account.setSilenceMode](https://vk.com/dev/account.setSilenceMode).

## Синтаксис
``` csharp
public bool SetSilenceMode(string deviceId, long? time, long? peerId, long? sound)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства. строка, доступен начиная с версии 5.31
+ **time** - Время в секундах на которое требуется отключить уведомления, -1 отключить навсегда целое число
+ **peerId** - Идентификатор назначения.  Для пользователя: 
id  пользователя. 
Для групповой беседы: 
2000000000 + id беседы. 
Для сообщества: 
-id сообщества. 
 целое число, доступен начиная с версии 5.46
+ **sound** - 1 - включить звук в данном диалоге, 0 - отключить звук (параметр работает только если указан в peer_id передан идентификатор групповой беседы или пользователя) целое число

## Результат
Возвращает **true** в случае успешного выполнения метода.

## Пример
``` csharp
var setSilenceMode = _api.Account.SetSilenceMode();
            Console.WriteLine(setSilenceMode.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 23:20:37
