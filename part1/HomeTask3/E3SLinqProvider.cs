using LinqProviderTelescope.E3SClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqProviderTelescope
{
	/// <summary>
    /// Класс провайдер для получения данных с E3SClient (Telescope)
	/// </summary>
    public class E3SLinqProvider : IQueryProvider
	{
		private E3SQueryClient e3sClient;

		public E3SLinqProvider(E3SQueryClient client)
		{
			e3sClient = client;
		}

		public IQueryable CreateQuery(Expression expression)
		{
			throw new NotImplementedException();
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new E3SQuery<TElement>(expression, this);
		}

		public object Execute(Expression expression)
		{
			throw new NotImplementedException();
		}

        /// <summary>
        /// Этот метод транслирует запрос и передает его в E3SClient (Telescope), возвращает полученный набор данных
        /// </summary>
        /// <typeparam name="TResult">Возвращаемый набор данных из Telescope</typeparam>
        /// <param name="expression">Запрос на получение данных из Telescope</param>
        /// <returns></returns>
		public TResult Execute<TResult>(Expression expression)
		{
			var itemType = TypeHelper.GetElementType(expression.Type);

			var translator = new ExpressionToFTSRequestTranslator();
			List<string> queryList = translator.Translate(expression);

            return (TResult)(e3sClient.SearchFTS(itemType, queryList));
		}
	}
}
