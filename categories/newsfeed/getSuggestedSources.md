---
layout: default
title: Метод Newsfeed.GetSuggestedSources
permalink: newsfeed/getSuggestedSources/
comments: true
---
# Метод Newsfeed.GetSuggestedSources
Возвращает сообщества и пользователей, на которые текущему пользователю рекомендуется подписаться.

Страница документации ВКонтакте [newsfeed.getSuggestedSources](https://vk.com/dev/newsfeed.getSuggestedSources).

## Синтаксис
``` csharp
public NewsSuggestions GetSuggestedSources(
	long? offset = null,
	long? count = null,
	bool? shuffle = null,
	UsersFields fields = null
)
```

## Параметры
+ **offset** — Отступ, необходимый для выборки определенного подмножества сообществ или пользователей. положительное число
+ **count** — Количество сообществ или пользователей, которое необходимо вернуть. положительное число, максимальное значение 1000, по умолчанию 20
+ **shuffle** — Перемешивать ли возвращаемый список. флаг, может принимать значения 1 или 0
+ **fields** — Список дополнительных полей, которые необходимо вернуть. См. возможные поля для пользователей и сообществ. список слов, разделенных через запятую

## Результат
Список объектов пользователей и групп.

## Пример
``` csharp
var getSuggestedSources = _api.Newsfeed.GetSuggestedSources();
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 13:09:42
