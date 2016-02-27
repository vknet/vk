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
// Пример кода
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
