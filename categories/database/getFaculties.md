---
layout: default
title: Метод Database.GetFaculties
permalink: database/getFaculties/
comments: true
---
# Метод Database.GetFaculties
Возвращает список факультетов.

Страница документации ВКонтакте [database.getFaculties](https://vk.com/dev/database.getFaculties).

## Синтаксис
``` csharp
public ReadOnlyCollection<Faculty> GetFaculties(
	long universityId,
	int? count = null,
	int? offset = null
)
```

## Параметры
+ **universityId** - Идентификатор университета, факультеты которого необходимо получить. положительное число, обязательный параметр
+ **offset** - Отступ, необходимый для получения определенного подмножества факультетов. положительное число
+ **count** - Количество факультетов которое необходимо получить. положительное число, по умолчанию 100, максимальное значение 10000

## Результат
Метод возвращает список факультетов, содержащих поля id и title.

## Пример
```csharp
ReadOnlyCollection<Faculty> faculties = api.Database.GetFaculties(431, 3, 2);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
