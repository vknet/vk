---
layout: default
title: Метод Account.SetNameInMenu
permalink: account/setNameInMenu/
comments: true
---
# Метод Account.SetNameInMenu
Устанавливает короткое название приложения (до 17 символов), которое выводится пользователю в левом меню.  
Это происходит только в том случае, если пользователь добавил приложение в левое меню со страницы приложения, списка приложений или настроек.

Страница документации ВКонтакте [account.setNameInMenu](https://vk.com/dev/account.setNameInMenu).

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token).

## Синтаксис
``` csharp
public bool SetNameInMenu([NotNull] string name, long? userId = null)
```

## Параметры
+ **userId** - Идентификатор пользователя. По умолчанию идентификатор текущего пользователя. Обязательный параметр.
+ **name** - Короткое название приложения.

## Результат
Возвращает **true** в случае успешной установки короткого названия.   
Если пользователь не установил приложение в левое меню, метод вернет ошибку 148 (Access to the menu of the user denied).   
Избежать этой ошибки можно с помощью метода [account.getAppPermissions](https://vknet.github.io/vk/account/getAppPermissions/).  

## Пример
``` csharp
var setNameInMenu = _api.Account.SetNameInMenu("name", userId: 0);
            Console.WriteLine(setNameInMenu);
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:10
