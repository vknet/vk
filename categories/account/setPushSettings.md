---
layout: default
title: Метод Account.SetPushSettings
permalink: account/setPushSettings/
comments: true
---
# Метод Account.SetPushSettings
Изменяет настройку Push-уведомлений.

Страница документации ВКонтакте [account.setPushSettings](https://vk.com/dev/account.setPushSettings).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public bool SetPushSettings(string deviceId, PushSettings settings, string key, List<string> value)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства.
+ **settings** - Объект **PushSettings**, описывающий настройки уведомлений
+ **key** - Ключ уведомления. 
+ **value** - Новое значение уведомления в специальном формате. Список слов  
[Формат настроек](https://vk.com/dev/objects/push_settings)  
Должен быть обязательно передан token или deviceId.

## Результат
Возвращает **true** в случае успешного выполнения метода.

## Пример
``` csharp
var setPushSettings = _api.Account.SetPushSettings(deviceId: "device_id");
            Console.WriteLine(setPushSettings);
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:15
