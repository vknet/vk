---
layout: default
title: Метод Messages.SearchDialogs
permalink: messages/searchDialogs/
comments: true
---
# Метод Messages.SearchDialogs
Возвращает список найденных диалогов текущего пользователя по введенной строке поиска.

## Синтаксис
```csharp
public SearchDialogsResponse SearchDialogs(string query, ProfileFields fields)
```

## Параметры
+ **query** - Подстрока, по которой будет производиться поиск.
+ **fields** - Поля профилей собеседников, которые необходимо вернуть.

## Результат
В результате выполнения данного метода будет возвращён массив объектов профилей, бесед и email.

## Исключения

## Пример
```csharp
// TODO:
```