---
layout: default
title: Метод Groups.IsMember
permalink: groups/isMember/
comments: true
---
# Метод Groups.IsMember
Возвращает информацию о том является ли пользователь участником заданной группы.

# Синтаксис
```csharp
public bool IsMember(long gid, long uid)
```

## Параметры
+ **gid** - ID группы.
+ **uid** - ID пользователя.

## Результат
Возвращает true в случае, если пользователь uid является участником группы с идентификатором gid, иначе false.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - Неправильный идентификатор группы.

## Пример
```csharp
// Проверяем состоит ли Павел Дуров в группе с id равным 2.
bool isMember = vk.Groups.IsMember(2, 1);
```
