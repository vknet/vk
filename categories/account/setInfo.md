---
layout: default
title: Метод Account.SetInfo
permalink: account/setInfo/
comments: true
---
# Метод Account.SetInfo
Позволяет редактировать информацию о текущем аккаунте.

Страница документации ВКонтакте [account.setInfo](https://vk.com/dev/account.setInfo).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public bool SetInfo(string name, string value)
```

## Параметры
+ **name** - Имя настройки
+ **value** - Значение настройки строка

**Поддерживаемые настройки**

- **intro** - Битовая маска, отвечающая за прохождение обучения в мобильных клиентах  
- **own_posts_default** - Отображение записей на стене пользователя. Возможные значения:  
1 — на стене пользователя по умолчанию должны отображаться только собственные записи.  
0 — на стене пользователя должны отображаться все записи.  
- **no_wall_replies** - Отключение комментирования записей на стене. Возможные значения:  
1 — отключить комментирование записей на стене.  
0 — разрешить комментирование.  

## Результат
В результате успешного выполнения возвращает **true**.

## Пример
``` csharp
            var own_posts_default = _api.Account.SetInfo("own_posts_default", "1");
            var no_wall_replies = _api.Account.SetInfo("no_wall_replies", "1");
            var intro = _api.Account.SetInfo("intro", "1");
            Console.WriteLine(intro);
            Console.ReadKey();
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 19:06
