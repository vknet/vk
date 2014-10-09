---
layout: default
title: Метод Status.Set
permalink: status/set/
comments: true
---
# Метод Status.Set
Устанавливает новый статус текущему пользователю.

# Синтаксис
```csharp

```

## Параметры
+ **text** - Текст статуса, который необходимо установить текущему пользователю.
+ **audio** - Текущая аудиозапись, которую необходимо транслировать в статус, задается в формате oid_aid (идентификатор владельца и идентификатор аудиозаписи, разделенные знаком подчеркивания).

## Результат
В случае успешной установки или очистки статуса возвращает true.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **AccessDeniedException** - нет доступа для выполнение данного метода.

## Пример
```csharp
// Устанавливаем простой статус "test test test".
bool result = vk.Status.Set("test test test");

// Устанавливаем аудиозапись в статус.
var audio = new Audio { Id = 158073513, OwnerId = 4793858 };
bool result = vk.Status.Set("test test test", audio);
```
