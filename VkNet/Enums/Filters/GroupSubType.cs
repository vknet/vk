namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Вид публичной страницы: (учитывается только при создании публичных страниц)
	/// </summary>
	public enum GroupSubType
	{
		/// <summary>
		/// 1 – Место или небольшая компания
		/// </summary>
		PlaceOrSmallCompany = 1

		, /// <summary>
		/// 2 – Компания, организация или веб-сайт
		/// </summary>
		OrganizationOrWebsite

		, /// <summary>
		/// 3 – Известная личность или коллектив
		/// </summary>
		PersonOrTeam

		, /// <summary>
		/// 4 – Произведение или продукция
		/// </summary>
		ProductOrProducts
	}
}