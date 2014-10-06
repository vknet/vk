---
layout: default
title: Метод Users.Get
permalink: users/get/
comments: true
---
# Метод Users.Get

## Параметры
+ **uid** - id пользователя.
+ **fields** - перечисленные поля анкет, необходимые для получения. Тип параметра - ProfileFields
или
+ **uids** - Список с id пользователе.
**fields** - перечисленные поля анкет, необходимые для получения. Тип параметра - ProfileFields

## Результат
Метод Get возвращает информацию о пользователе в виде объекта типа Profile.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем базовую информацию о Павле Дурове.
Profile p = vk.Users.Get(1);
Console.WriteLine(p.Uid);        // 1
Console.WriteLine(p.FirstName); // "Павел"
Console.WriteLine(p.LastName); // "Дуров"

// Получаем информацию о счетчиках различных объектов у пользователя
Profile p = users.Get(1, ProfileFields.Counters);
Console.WriteLine(p.Uid);                      // 1
Console.WriteLine(p.FirstName,);           // "Павел"
Console.WriteLine(p.LastName);            // "Дуров"
Console.WriteLine(p.Counters.Albums);  // 3
Console.WriteLine(p.Counters.Videos);   // 183
Console.WriteLine(p.Counters.Audios);   // 78
Console.WriteLinet(p.Counters.Notes);   // 5
Console.WriteLine(p.Counters.Photos);   // 783
Console.WriteLine(p.Counters.Groups);  // 24
Console.WriteLine(p.Counters.Friends);  // 641
...

// Получаем базовую информацию о трех пользователях.
var ids = new long[] {2, 3, 6};
var users = vk.Users.Get(ids);
foreach(Profile p in users)
{
   ....
}

// Получаем информацию о высшем образовании трех пользователей.
var ids = new long[] {2, 3, 6};
var users = vk.Users.Get(ids, ProfileFields.Education);
```
