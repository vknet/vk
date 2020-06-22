---
layout: default
title: Метод Account.GetPushSettings
permalink: account/getPushSettings/
comments: true
---
# Метод Account.GetPushSettings
Позволяет получать настройки Push уведомлений.

Страница документации ВКонтакте [account.getPushSettings](https://vk.com/dev/account.getPushSettings).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).
Требуются [права доступа](https://vk.com/dev/permissions) messages.

## Синтаксис
``` csharp
public AccountPushSettings GetPushSettings(string deviceId)
```

## Параметры
+ **deviceId** - Уникальный идентификатор устройства. 

## Результат
Возвращает объект, содержащий поля: 

+ **Disabled** — Отключены ли уведомления. 
+ **DisabledUntil** — Unixtime-значение времени, до которого временно отключены уведомления. 
+ **Conversations** — Список, содержащий настройки конкретных диалогов, и их количество первым элементом. 
+ **Settings** — Настройки Push-уведомлений

## Пример
``` csharp
var pushSettings = _api.Account.GetPushSettings("token");
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 18:22
