---
layout: default
title: Метод Database.GetSchools
permalink: database/getSchools/
comments: true
---
# Метод Database.GetSchools
Возвращает список школ.

Страница документации ВКонтакте [database.getSchools](https://vk.com/dev/database.getSchools).
## Синтаксис
``` csharp
public ReadOnlyCollection<School> GetSchools(
	int cityId,
	string query = "",
	int? offset = null,
	int? count = null
)
```

## Параметры
+ **query** - Строка поискового запроса. Например, гимназия. строка
+ **cityId** - Идентификатор города, школы которого необходимо вернуть. положительное число, обязательный параметр
+ **offset** - Отступ, необходимый для получения определенного подмножества школ. положительное число
+ **count** - Количество школ, которое необходимо вернуть. положительное число, по умолчанию 100, максимальное значение 10000

## Результат
Метод возвращает список школ, содержащих поля id и title.

## Пример
```csharp
ReadOnlyCollection<School> schools = db.GetSchools(1, 10, count: 3);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
