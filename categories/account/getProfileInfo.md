---
layout: default
title: Метод Account.GetProfileInfo
permalink: account/getProfileInfo/
comments: true
---
# Метод Account.GetProfileInfo
Возвращает информацию о текущем профиле.

Страница документации ВКонтакте [account.getProfileInfo](https://vk.com/dev/account.getProfileInfo).

## Синтаксис
``` csharp
public AccountSaveProfileInfoParams GetProfileInfo()
```

## Параметры
Метод не содержит входных параметров

## Результат
Метод возвращает объект, содержащий информацию о пользователе

## Пример
``` csharp
            var profileInfo = _api.Account.GetProfileInfo();
            Console.WriteLine(profileInfo.FirstName.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 23:00:10
