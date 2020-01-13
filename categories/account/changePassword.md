---
layout: default
title: Метод Account.ChangePassword
permalink: account/changePassword/
comments: true
---
# Метод Account.ChangePassword
Позволяет сменить пароль пользователя после успешного восстановления доступа к аккаунту через СМС, используя метод auth.restore.

Страница документации ВКонтакте [account.changePassword](https://vk.com/dev/account.changePassword).

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
+ **restoreSid** — Идентификатор сессии, полученный при восстановлении доступа используя метод auth.restore. (В случае если пароль меняется сразу после восстановления доступа) строка
+ **changePasswordHash** — Хэш, полученный при успешной OAuth авторизации по коду полученному по СМС (В случае если пароль меняется сразу после восстановления доступа) строка
+ **oldPassword** — Текущий пароль пользователя. строка
+ **newPassword** — Новый пароль, который будет установлен в качестве текущего. строка, минимальная длина 6, обязательный параметр

## Результат
В результате выполнения этого метода будет возвращем объект с полем token, содержащим новый токен, и полем secret в случае, если токен был nohttps.

## Пример
``` csharp
_api.Account.ChangePassword("oldPass", "newPass");
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 22:17:10
