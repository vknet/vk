---
layout: default
title: Метод Users.GetUserSettings
permalink: users/getUserSettings/
comments: true
---
# Метод Users.GetUserSettings

## Параметры
+ **uid** - id пользователя

## Результат
Возвращает битовую маску настроек текущего пользователя в данном приложени. 
Например, если метод возвращает 3, это означает, что пользователь разрешил отправлять ему уведомления и получать список его друзей.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем настройки Павла Дурова в нашем приложении.

int settings = vk.Users.GetUserSettings(1);
```
