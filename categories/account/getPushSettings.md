---
layout: default
title: Метод Account.GetPushSettings
permalink: account/getPushSettings/
comments: true
---
# Метод Account.GetPushSettings
Позволяет получать настройки Push уведомлений.

Страница документации ВКонтакте [account.getPushSettings](https://vk.com/dev/account.getPushSettings).

## Синтаксис
``` csharp
public AccountPushSettings GetPushSettings(string deviceId)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства. строка, доступен начиная с версии 5.31

## Результат
Возвращает объект, содержащий поля: 

+ **disabled** — отключены ли уведомления. 
+ **disabled_until** — unixtime-значение времени, до которого временно отключены уведомления. 
+ **conversations** — список, содержащий настройки конкретных диалогов, и их количество первым элементом. 
+ **settings** — объект с настройками Push-уведомлений в специальном формате.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
