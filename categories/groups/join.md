---
layout: default
title: Метод Groups.Join
permalink: groups/join/
comments: true
---
# Метод Groups.Join
Данный метод позволяет вступить в группу, публичную страницу, а также подтвердить участие во встрече.

Страница документации ВКонтакте [groups.join](https://vk.com/dev/groups.join).

## Синтаксис
``` csharp
public bool Join(long? groupId, bool? notSure = null
```

## Параметры
+ **groupId** — Идентификатор сообщества. положительное число
+ **notSure** — Опциональный параметр, учитываемый, если group_id принадлежит встрече. 1 — Возможно пойду. 0 — Точно пойду. По умолчанию 0. строка

## Результат
В случае успешного вступления метод вернёт 1.

## Исключения
+ **AccessTokenInvalidException** — не задан или используется неверный AccessToken.
+ **AccessDeniedException** — нет доступа для выполнение данного метода.

## Пример
```csharp
// Возможно мы пойдем на встречу с id равным 2.
bool result = vk.Groups.Join(2, true);

// Нет, мы точно пойдем на эту встречу.
bool result = vk.Groups.Join(2);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
