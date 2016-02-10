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
public bool ChangePassword(string restoreSid, string changePasswordHash, string oldPassword, string newPassword)
```

## Параметры
+ **restoreSid** - Идентификатор сессии, полученный при восстановлении доступа используя метод auth.restore. (В случае если пароль меняется сразу после восстановления доступа) строка
+ **changePasswordHash** - Хэш, полученный при успешной OAuth авторизации по коду полученному по СМС (В случае если пароль меняется сразу после восстановления доступа) строка
+ **oldPassword** - Текущий пароль пользователя. строка
+ **newPassword** - Новый пароль, который будет установлен в качестве текущего. строка, минимальная длина 6, обязательный параметр

## Результат
В результате выполнения этого метода будет возвращем объект с полем token, содержащим новый токен, и полем secret в случае, если токен был nohttps.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.45
Дата обновления: 10.02.2016 13:55:10
