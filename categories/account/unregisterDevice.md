---
layout: default
title: Метод Account.UnregisterDevice
permalink: account/unregisterDevice/
comments: true
---
# Метод Account.UnregisterDevice
Отписывает устройство от Push уведомлений.

Страница документации ВКонтакте [account.unregisterDevice](https://vk.com/dev/account.unregisterDevice).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).
Требуются [права доступа](https://vk.com/dev/permissions) messages.

## Синтаксис
``` csharp
public bool UnregisterDevice(string deviceId, bool? sandbox)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства.
+ **sandbox** - Флаг предназначен для iOS устройств. 
**true** — отписать устройство, использующего sandbox сервер для отправки push-уведомлений. 
**false** — отписать устройство, не использующее sandbox сервер флаг. По умолчанию.

## Результат
Возвращает **true** в случае успешного выполнения метода.

## Пример
``` csharp
var unregisterDevice = _api.Account.UnregisterDevice();
            Console.WriteLine(unregisterDevice.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:24
