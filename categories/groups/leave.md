---
layout: default
title: Метод Groups.Leave
permalink: groups/leave/
comments: true
---
# Метод Groups.Leave
Данный метод позволяет выходить из группы, публичной страницы, или встречи.

# Синтаксис
```csharp
public bool Leave(long gid)
```

## Параметры
+ **gid** - Идентификатор группы, публичной страницы или встречи.

## Результат
В случае успешного вступления в группу метод вернёт true.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **AccessDeniedException** - нет доступа для выполнение данного метода.

## Пример
```csharp
// Выходим из группы с id равным 2.
bool result = vk.Groups.Leave(2);
```
