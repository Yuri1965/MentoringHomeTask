using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinqProviderTelescope.E3SClient
{	
	public class E3SQueryClient
	{
		private string UserName;
		private string Password;
		private Uri BaseAddress = new Uri("https://e3s.epam.com/eco/rest/e3s-eco-scripting-impl/0.1.0");

		public E3SQueryClient(string user, string password)
		{
			UserName = user;
			Password = password;
		}

        public IEnumerable<T> SearchFTS<T>(string query, int start = 0, int limit = 10) where T : E3SEntity
        {
            return (IEnumerable<T>) SearchFTS(typeof(T), query, start, limit);
        }


        private IEnumerable SearchFTSWithUriRequest(Type type, Uri request, int start = 0, int limit = 10)
        {
            HttpClient client = CreateClient();
            var resultString = client.GetStringAsync(request).Result;
            var endType = typeof(FTSResponse<>).MakeGenericType(type);
            var result = JsonConvert.DeserializeObject(resultString, endType);

            var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type)) as IList;

            foreach (object item in (IEnumerable)endType.GetProperty("items").GetValue(result))
            {
                list.Add(item.GetType().GetProperty("data").GetValue(item));
            }
            return list;
        }

        public IEnumerable SearchFTS(Type type, string query, int start = 0, int limit = 10)
        {
            var requestGenerator = new FTSRequestGenerator(BaseAddress);
            Uri request = requestGenerator.GenerateRequestUrl(type, query, start, limit);
            return SearchFTSWithUriRequest(type, request, start, limit);
        }

        /// <summary>
        /// Метод для формирования и отправки запроса к Telescope на получение данных
        /// </summary>
        /// <param name="type">тип выражения - запроса</param>
        /// <param name="queryList">список запросов с параметрами</param>
        /// <param name="start">с какой записи вернуть</param>
        /// <param name="limit">сколько записей вернуть</param>
        /// <returns></returns>
        public IEnumerable SearchFTS(Type type, List<string> queryList, int start = 0, int limit = 10)
        {
            var requestGenerator = new FTSRequestGenerator(BaseAddress);
            Uri request = requestGenerator.GenerateRequestUrl(type, queryList, start, limit);
            return SearchFTSWithUriRequest(type, request, start, limit);
        }
        
        private HttpClient CreateClient()
		{
			var client = new HttpClient(new HttpClientHandler
			{
				AllowAutoRedirect = true,
				PreAuthenticate = true
			});

			var encoding = new ASCIIEncoding();
			var authHeader = new AuthenticationHeaderValue("Basic",
				Convert.ToBase64String(encoding.GetBytes(string.Format("{0}:{1}", UserName, Password))));
			client.DefaultRequestHeaders.Authorization = authHeader;

			return client;
		}
	}
}
