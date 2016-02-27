---
layout: default
title: Метод Database.GetUniversities
permalink: database/getUniversities/
comments: true
---
# Метод Database.GetUniversities
Возвращает список высших учебных заведений.

Страница документации ВКонтакте [database.getUniversities](https://vk.com/dev/database.getUniversities).

## Синтаксис
``` csharp
public ReadOnlyCollection<University> GetUniversities(
	int countryId,
	int cityId,
	string query = "",
	int? count = null,
	int? offset = null
)
```

## Параметры
+ **query** - Строка поискового запроса. Например, СПБ. строка
+ **countryId** - Идентификатор страны, учебные заведения которой необходимо вернуть. положительное число
+ **cityId** - Идентификатор города, учебные заведения которого необходимо вернуть. положительное число
+ **offset** - Отступ, необходимый для получения определенного подмножества учебных заведений. положительное число
+ **count** - Количество учебных заведений, которое необходимо вернуть. положительное число, по умолчанию 100, максимальное значение 10000

## Результат
Метод возвращает список объектов университетов, содержащих поля id и title.

## Пример
```csharp
var universities = api.Database.GetUniversities(1, 10, "ВолгГТУ");
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
