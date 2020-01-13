---
layout: default
title: Метод Users.Report
permalink: users/report/
comments: true
---
# Метод Users.Report
Позволяет пожаловаться на пользователя.

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

Страница документации ВКонтакте [users.report](https://vk.com/dev/users.report).

## Синтаксис
``` csharp
public bool Report(long userId, string type, string comment)
```

## Параметры
+ **userId** — Идентификатор пользователя, на которого нужно подать жалобу. Обязательный параметр.
+ **type** — Тип жалобы, может принимать следующие значения: *porn* — порнография, *spam* — рассылка спама, *insult* — оскорбительное поведение, *advertisment* — рекламная страница, засоряющая поиск, обязательный параметр
+ **comment** — Комментарий к жалобе на пользователя.

## Результат
В случае успешной отправки жалобы метод вернет **true**.

## Исключения
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/objects/user).

## Пример
``` csharp
vk.Users.Report(243663122, ReportType.Insult, "комментарий");
```

## Версия Вконтакте API v.5.103
Дата обновления: 19.01.2016 12:44:46
