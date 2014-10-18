---
layout: default
title: Метод Groups.BanUser
permalink: groups/banUser/
comments: true
---
# Метод Groups.BanUser
Добавляет пользователя в черный список группы

## Синтаксис
```csharp
public bool BanUser(
	long groupId, 
	long userId,
	DateTime? endDate, 
	BanReason? reason, 
	string comment, 
	bool commentVisible
)
```

## Параметры
+ **groupId** - идентификатор группы.
+ **userId** - идентификатор пользователя, которого нужно добавить в черный список.
+ **endDate** - дата завершения срока действия бана. Если параметр не указан пользователь будет заблокирован навсегда.
+ **reason** - причина бана.
+ **comment** - текст комментария к бану.
+ **commentVisible** - true – текст комментария будет отображаться пользователю. false – текст комментария не доступен пользователю. (по умолчанию).

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```
