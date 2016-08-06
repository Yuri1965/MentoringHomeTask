using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProviderTelescope.E3SClient
{
	public class FTSRequestGenerator
	{
		private readonly UriTemplate FTSSearchTemplate = new UriTemplate(@"data/searchFts?metaType={metaType}&query={query}&fields={fields}");
		private readonly Uri BaseAddress;

		public FTSRequestGenerator(string baseAddres) : this(new Uri(baseAddres))
		{
		}

		public FTSRequestGenerator(Uri baseAddress)
		{
			BaseAddress = baseAddress;
		}

		public Uri GenerateRequestUrl<T>(string query = "*", int start = 0, int limit = 10)
		{
			return GenerateRequestUrl(typeof(T), query, start, limit);
		}

        public Uri GenerateRequestUrl(Type type, string query = "*", int start = 0, int limit = 10)
        {
            var statements = new List<Statement> {new Statement {Query = query}};
            return GenerateRequestUrlWithStatements(type, statements, start, limit);
        }

        /// <summary>
        /// Метод подготовки данных для http-запрос
        /// </summary>
        /// <param name="type"></param>
        /// <param name="queryList"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns>http-запрос</returns>
        public Uri GenerateRequestUrl(Type type, List<string> queryList, int start = 0, int limit = 10)
        {
            List<Statement> statementsList = new List<Statement>();
            queryList.ForEach(x => statementsList.Add(new Statement { Query = x }));

            return GenerateRequestUrlWithStatements(type, statementsList, start, limit);
        }

        private Uri GenerateRequestUrlWithStatements(Type type, List<Statement> statementsList, int start, int limit)
        {
            string metaTypeName = GetMetaTypeName(type);

            var ftsQueryRequest = new FTSQueryRequest
            {
                Statements = statementsList,
                Start = start,
                Limit = limit
            };

            var ftsQueryRequestString = JsonConvert.SerializeObject(ftsQueryRequest);

            var uri = FTSSearchTemplate.BindByName(BaseAddress,
                new Dictionary<string, string>()
                {
                    {"metaType", metaTypeName},
                    {"query", ftsQueryRequestString}
                });

            return uri;
        }

	    private string GetMetaTypeName(Type type)
		{
			var attributes = type.GetCustomAttributes(typeof(E3SMetaTypeAttribute), false);

			if (attributes.Length == 0)
				throw new Exception(string.Format("Entity {0} do not have attribute E3SMetaType", type.FullName));

			return ((E3SMetaTypeAttribute)attributes[0]).Name;
		}

	}
}
