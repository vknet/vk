---
layout: default
title: Метод Account.SetNameInMenu
permalink: account/setNameInMenu/
comments: true
---
# Метод Account.SetNameInMenu
Устанавливает короткое название приложения (до 17 символов), которое выводится пользователю в левом меню.

Страница документации ВКонтакте [account.setNameInMenu](https://vk.com/dev/account.setNameInMenu).

## Синтаксис
``` csharp
public bool SetNameInMenu([NotNull] string name, long? userId = null)
```

## Параметры
+ **userId** - Идентификатор пользователя. положительное число, по умолчанию идентификатор текущего пользователя, обязательный параметр
+ **name** - Короткое название приложения. строка

## Результат
Возвращает 1 в случае успешной установки короткого названия. 
Если пользователь не установил приложение в левое меню, метод вернет ошибку 148 (Access to the menu of the user denied). Избежать этой ошибки можно с помощью метода account.getAppPermissions.

## Пример
``` csharp
var setNameInMenu = _api.Account.SetNameInMenu("name", userId: 0);
            Console.WriteLine(setNameInMenu.ToString());
            Console.ReadKey();
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 23:05:10
