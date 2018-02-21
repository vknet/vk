## Синтаксис
``` csharp
public ReadOnlyCollection<Group> Search(GroupsSearchParams @params)
## Пример
```csharp
// Поиск групп по запросу "Music".
var groups = vk.Groups.Search(new GroupsSearchParams {Query = "Music"});
// Количество найденных результатов
ulong totalCount = groups.TotalCount;

// Поиск трех групп, начиная с двадцатой, удовлетворяющих запросу "Music".
var groups = vk.Groups.Search(new GroupsSearchParams {Query = "Music", Offset = 20, Count = 3});

