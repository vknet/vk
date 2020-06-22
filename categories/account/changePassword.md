---
layout: default
title: Метод Account.ChangePassword
permalink: account/changePassword/
comments: true
---
# Метод Account.ChangePassword
Позволяет сменить пароль пользователя после успешного восстановления доступа к аккаунту через СМС, используя метод [auth.restore](https://vknet.github.io/vk/auth/restore/).

Страница документации ВКонтакте [account.changePassword](https://vk.com/dev/account.changePassword).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public AccountChangePasswordResult ChangePassword(
  string oldPassword,
  string newPassword,
  string restoreSid = null,
  string changePasswordHash = null
)
```

## Параметры
+ **restoreSid** - Идентификатор сессии, полученный при восстановлении доступа используя метод [auth.restore](https://vknet.github.io/vk/auth/restore/). (В случае если пароль меняется сразу после восстановления доступа)
Строка.
+ **changePasswordHash** - Хэш, полученный при успешной OAuth авторизации по коду полученному по СМС. (В случае если пароль меняется сразу после восстановления доступа)
Строка.
+ **oldPassword** - Текущий пароль пользователя.
Строка
+ **newPassword** - Новый пароль, который будет установлен в качестве текущего. 
Строка, минимальная длина строки **6**, **обязательный параметр**

## Результат
В результате выполнения этого метода будет возвращем объект с полем **token**, содержащим новый токен, и полем **secret** в случае, если токен был no https. 

## Пример
``` csharp
_api.Account.ChangePassword("oldPass", "newPass");
```

## Версия Вконтакте API v.5.110
Дата обновления: 19.06.2020 3:44
