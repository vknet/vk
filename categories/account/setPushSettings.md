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
Возвращает 1 в случае успешного выполнения метода.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
