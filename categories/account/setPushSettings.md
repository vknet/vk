---
layout: default
title: Метод Account.SetPushSettings
permalink: account/setPushSettings/
comments: true
---
# Метод Account.SetPushSettings
Изменяет настройку Push-уведомлений.

Страница документации ВКонтакте [account.setPushSettings](https://vk.com/dev/account.setPushSettings).

## Синтаксис
``` csharp
public bool SetPushSettings(string deviceId, PushSettings settings, string key, List<string> value)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства. строка, обязательный параметр
+ **settings** - Сериализованный JSON-объект, описывающий настройки уведомлений в специальном формате данные в формате JSON
+ **key** - Ключ уведомления. строка
+ **value** - Новое значение уведомления в специальном формате. список слов, разделенных через запятую

## Результат
Возвращает **true** в случае успешного выполнения метода.

## Пример
``` csharp
var setPushSettings = _api.Account.SetPushSettings(deviceId: "device_id");
```

## Версия Вконтакте API v.5.50
Дата обновления: 10.02.2016 13:55:10
