---
layout: default
title: Метод Account.GetProfileInfo
permalink: account/getProfileInfo/
comments: true
---
# Метод Account.GetProfileInfo
Возвращает информацию о текущем профиле.

Страница документации ВКонтакте [account.getProfileInfo](https://vk.com/dev/account.getProfileInfo).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public AccountSaveProfileInfoParams GetProfileInfo()
```

## Параметры
Метод не содержит входных параметров

## Результат
Метод возвращает объект, содержащий информацию о пользователе, который содержит поля
+ **FirstName** - Имя пользователя.
+ **LastName** - Фамилия пользователя.
+ **MaidenName** - Девичья фамилия пользователя (только для женского пола).
+ **ScreenName** - Короткое имя страницы.
+ **Sex** - Пол пользователя.
+ **Relation** - Семейное положение.
+ **RelationPartner** - Идентификатор пользователя, с которым связано семейное положение. Положительное число
+ **BirthDate** - Дата рождения пользователя в формате DD.MM.YYYY, например "15.11.1984".
+ **BirthdayVisibility** - Видимость даты рождения.
+ **HomeTown** - Родной город пользователя.
+ **Country** - Страна пользователя.
+ **Status** - Статус пользователя. Может быть изменен методом [status.set](https://vknet.github.io/vk/status/set/).
+ **Phone** - Телефон. 


## Пример
``` csharp
            var profileInfo = _api.Account.GetProfileInfo();
            Console.WriteLine(profileInfo.FirstName);
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 18:13
