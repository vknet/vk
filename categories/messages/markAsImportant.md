---
layout: default
title: Метод Messages.MarkAsImportant
permalink: messages/markAsImportant/
comments: true
---
# Метод Messages.MarkAsImportant
Помечает сообщения как важные либо снимает отметку.

Страница документации ВКонтакте [messages.markAsImportant](https://vk.com/dev/messages.markAsImportant).
## Синтаксис
``` csharp
public ReadOnlyCollection<long> MarkAsImportant(IEnumerable<long> messageIds, bool important = true)
```

## Параметры
+ **messageIds** - Список идентификаторов сообщений, которые необходимо пометить.список положительных чисел, разделенных запятыми
+ **important** - &#39;&#39;1&#39;&#39;, если сообщения необходимо пометить, как важные;&#39;&#39;0&#39;&#39;, если необходимо снять пометку.положительное число

## Результат
Возвращает список идентификаторов успешно помеченных сообщений.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
