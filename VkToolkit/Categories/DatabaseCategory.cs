using System;
using System.Collections.Generic;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    public class DatabaseCategory
    {
        private readonly VkApi _vk;

        public DatabaseCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает список стран.
        /// </summary>
        /// <param name="needAll">Флаг - вернуть список всех стран</param>
        /// <param name="codes">Перечисленные через запятую двухбуквенные коды стран в стандарте ISO 3166-1 alpha-2 <see cref="http://vk.com/dev/country_codes" /></param>
        /// <param name="offset">Отступ, необходимый для выбора определенного подмножества стран. </param>
        /// <param name="count">Количество стран, которое необходимо вернуть. </param>
        /// <remarks>
        /// Если не заданы параметры needAll и code, то возвращается краткий список стран, расположенных наиболее близко к стране текущего пользователя. Если задан параметр needAll, то будет возвращен список всех стран. Если задан параметр code, то будут возвращены только страны с перечисленными ISO 3166-1 alpha-2 кодами.
        /// </remarks>
        public List<Country> GetCountries(bool needAll, string codes, int offset, int count)
        {
            // TODO: Сделать проверки вход. значений
            // TODO: Сделать этот метод с необязательными параметрами
            var parameters = new VkParameters { { "code", codes }, { "offset", offset }, { "count", count }, { "need_all", needAll } };

            VkResponseArray response = _vk.Call("database.getCountries", parameters, true);

            return response.ToListOf<Country>(x => x);
        }

        public void GetRegions(int countryId, string query, int offset, int count)
        {
            // TODO: DatabaseCategory.GetRegions
            throw new NotImplementedException();
        }

        public void GetStreetsById(params int[] streetIds)
        {
            // TODO: DatabaseCategory.GetStreetsById
            throw new NotImplementedException();
        }

        public void GetCountriesById(params int[] countryIds)
        {
            // TODO: DatabaseCategory.GetCountriesById
            throw new NotImplementedException();
        }

        public void GetCities(int countryId, int regionId, string query, bool needAll, int offset, int count)
        {
            // TODO: DatabaseCategory.GetCities
            throw new NotImplementedException();
        }

        public void GetCitiesById(params int[] cityIds)
        {
            // TODO: DatabaseCategory.GetCitiesById
            throw new NotImplementedException();
        }

        // http://vk.com/dev/database.getUniversities
        public void GetUniversities(string query, int countryId, int cityId, int offset, int count)
        {
            // TODO Database.GetUniversities
            throw new NotImplementedException();
        }

        // http://vk.com/dev/database.getSchools
        public void GetSchools(string query, int countryId, int cityId, int offset, int count)
        {
            // TODO: Database.GetSchools
            throw new NotImplementedException();
        }

        // http://vk.com/dev/database.getFaculties
        public void GetFaculties(int universityId, int offset, int count)
        {
            // TODO: Database.GetFaculties
            throw new NotImplementedException();
        }
    }
}