---
layout: default
title: Метод Account.UnregisterDevice
permalink: account/unregisterDevice/
comments: true
---
# Метод Account.UnregisterDevice
Отписывает устройство от Push уведомлений.

Страница документации ВКонтакте [account.unregisterDevice](https://vk.com/dev/account.unregisterDevice).

## Синтаксис
``` csharp
public bool UnregisterDevice(string deviceId, bool? sandbox)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства. строка, доступен начиная с версии 5.31
+ **sandbox** - Флаг предназначен для iOS устройств. 1 — отписать устройство, использующего sandbox сервер для отправки push-уведомлений, 0 — отписать устройство, не использующее sandbox сервер флаг, может принимать значения 1 или 0, по умолчанию 0

## Результат
Возвращает **true** в случае успешного выполнения метода.

## Пример
``` csharp
var unregisterDevice = _api.Account.UnregisterDevice();
```

## Версия Вконтакте API v.5.50
Дата обновления: 21.03.2016 16:13:21
