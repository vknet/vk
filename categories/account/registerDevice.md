---
layout: default
title: Метод Account.RegisterDevice
permalink: account/registerDevice/
comments: true
---
# Метод Account.RegisterDevice
Подписывает устройство на базе iOS, Android или Windows Phone на получение Push-уведомлений.

Страница документации ВКонтакте [account.registerDevice](https://vk.com/dev/account.registerDevice).

## Синтаксис
``` csharp
public bool RegisterDevice(AccountRegisterDeviceParams @params)
```

## Параметры
Класс **`AccountRegisterDeviceParams`** содержит следующие свойства:

+ **Token** - Идентификатор устройства, используемый для отправки уведомлений. (для mpns идентификатор должен представлять из себя URL для отправки уведомлений) строка, обязательный параметр
+ **DeviceModel** - Cтроковое название модели устройства. строка
+ **DeviceYear** - Год устройства целое число
+ **DeviceId** - Уникальный идентификатор устройства. строка, обязательный параметр
+ **SystemVersion** - Строковая версия операционной системы устройства. строка
+ **Settings** - Сериализованный JSON-объект, описывающий настройки уведомлений в специальном формате данные в формате JSON, доступен начиная с версии 5.31
+ **Sandbox** - Флаг предназначен для iOS устройств. 1 — использовать sandbox сервер для отправки push-уведомлений, 0 — не использовать флаг, может принимать значения 1 или 0, по умолчанию 0

## Результат
Возвращает 1 в случае успешного выполнения метода. 
На iOS и Windows Phone push-уведомления будут отображены без какой либо обработки. 
На Android будут приходить события в следующем формате.

## Пример
``` csharp
var registerDevice = _api.Account.RegisterDevice(new AccountRegisterDeviceParams
{
	Token = "token",
	DeviceId = "deviceId"
});
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
