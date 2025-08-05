using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// ShortVideo В этой секции представлены методы,
/// предназначенные для работы с Клипами
/// </summary>
public interface IShortVideoCategoryAsync
{
	/// <summary>
	/// Получает ссылку для загрузки Клипа
	/// </summary>
	/// <param name="description">Описание клипа</param>
	/// <param name="token">Токен отмены</param>
	/// <param name="fileSize">Размер файла в КБ, если файл меньше 16384 кб, то указывать не обязательно</param>
	/// <param name="groupId">ID группы, если нужно выкладывать от имени группы</param>
	/// <param name="wallPost">Нужно ли выкладывать клип на стену</param>
	/// <returns>
	/// В случае успеха возвращает ссылку для загрузки
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/shortVideo.create
	/// </remarks>
	Task<ShortVideoUploadServer> CreateAsync(string description,
											ulong fileSize = 16384,
											long? groupId = null,
											bool? wallPost = null,
											CancellationToken token = default);
}