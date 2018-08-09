using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class SearchTests : BaseTest
	{
		[Test]
		public void GetHints()
		{
			Json = @"
            {
                'response': {
                    'count': 189,
                    'items': [
                        {
                            'type': 'group',
                            'group': {
                                'id': 1,
                                'name': 'ВКонтакте API',
                                'screen_name': 'apiclub',
                                'is_closed': 0,
                                'type': 'group',
                                'is_admin': 0,
                                'is_member': 1,
                                'photo_50': 'https://pp.userap...fc3/ei2DXpoO0h8.jpg',
                                'photo_100': 'https://pp.userap...fc2/nlmcXQP0V6c.jpg',
                                'photo_200': 'https://pp.userap...fc0/_QdFMmxSRyY.jpg'
                            },
                            'section': 'groups',
                            'description': 'Группа, 320 437 участников',
                            'global': 1
                        },
                        {
                            'type': 'profile',
                            'profile': {
                                'id': 72815776,
                                'first_name': 'Антон',
                                'last_name': 'Минаев'
                            },
                            'section': 'friends',
                            'description': 'ЮРГТУ (НПИ), Новочеркасск'
                        }
                    ]
                }
            }";

			Url = "https://api.vk.com/method/search.getHints";
			var result = Api.Search.GetHints(new SearchGetHintsParams());
			Assert.NotNull(result);
		}
	}
}