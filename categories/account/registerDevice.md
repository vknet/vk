---
layout: default
title: Метод Account.RegisterDevice
permalink: account/registerDevice/
comments: true
---
# Метод Account.RegisterDevice
Подписывает устройство на базе iOS, Android, Mac или Windows Phone на получение Push-уведомлений.

Страница документации ВКонтакте [account.registerDevice](https://vk.com/dev/account.registerDevice).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).
Требуются [права доступа](https://vk.com/dev/permissions) messages.

## Синтаксис
``` csharp
public bool RegisterDevice(AccountRegisterDeviceParams @params)
```

## Параметры
Класс **`AccountRegisterDeviceParams`** содержит следующие свойства:

+ **Token** - Идентификатор устройства, используемый для отправки уведомлений. (для **mpns** идентификатор должен представлять из себя URL для отправки уведомлений) 
Обязательный параметр
+ **DeviceModel** - Cтроковое название модели устройства.
+ **DeviceYear** - Год устройства
+ **DeviceId** - Уникальный идентификатор устройства. 
Обязательный параметр
+ **SystemVersion** - Строковая версия операционной системы устройства.
+ **Settings** - Сериализованный JSON-объект, описывающий настройки уведомлений в специальном формате данные в формате **JSON**.
+ **Sandbox** - Флаг предназначен для iOS устройств. 
**true** — Использовать sandbox сервер для отправки push-уведомлений.
**false** — Не использовать флаг. По умолчанию 

При отсутствии поля **settings** в запросе будут применены текущие настройки.
Для нового идентификатора устройства **token** будут применены последние настройки для данного **device_id**.

## Результат
Возвращает **true** в случае успешного выполнения метода. 
На **iOS** и **Windows Phone** push-уведомления будут отображены без какой либо обработки. 
На **Android** будут приходить события в [следующем формате](https://vk.com/dev/android_push).

## Пример
``` csharp
var registerDevice = _api.Account.RegisterDevice(new AccountRegisterDeviceParams
{
	Token = "token",
	DeviceId = "deviceId"
});
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 18:50
