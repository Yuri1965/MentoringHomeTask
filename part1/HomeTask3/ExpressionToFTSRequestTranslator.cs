using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqProviderTelescope
{
	public class ExpressionToFTSRequestTranslator : ExpressionVisitor
	{
		private StringBuilder resultString;
        private List<string> statementList;

        /// <summary>
        /// Преобразоване входного выражения в набор данных для обработки E3SLinqProvider
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<string> Translate(Expression exp)
        {
            resultString = new StringBuilder();
            statementList = new List<string>();

			Visit(exp);

            statementList.Add(resultString.ToString());

            return statementList;
		}

        /// <summary>
        /// Обработка и преобразование входного выражения для MethodCallExpression
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
            if (node.Method.DeclaringType == typeof(Queryable)
                && node.Method.Name == "Where")
            {
                var predicate = node.Arguments[1];
                Visit(predicate);

                return node;
            }

            if (node.Method.DeclaringType == typeof(String))
            {
       			switch (node.Method.Name)
    			{
	    			case "StartsWith":
                        Visit(node.Object);
                        resultString.Append("(");
                        Visit(node.Arguments[0]);
                        resultString.Append("*)");
                        return node;

	    			case "EndsWith":
                        Visit(node.Object);
                        resultString.Append("(*");
                        Visit(node.Arguments[0]);
                        resultString.Append(")");
                        return node;

	    			case "Contains":
                        Visit(node.Object);
                        resultString.Append("(*");
                        Visit(node.Arguments[0]);
                        resultString.Append("*)");
                        return node;

                    default: break;
			    };
            }
  
            return base.VisitMethodCall(node);
		}

		/// <summary>
        /// Обработка и преобразование входного выражения для BinaryExpression
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression node)
		{
            switch (node.NodeType)
			{
                case ExpressionType.Equal:
			        var leftIsMemberAccess = node.Left.NodeType == ExpressionType.MemberAccess;
                    var rightIsMemberAccess = node.Right.NodeType == ExpressionType.MemberAccess;

                    if (!leftIsMemberAccess && !rightIsMemberAccess)
                        throw new NotSupportedException("One of the arguments should be member access");

                    if (leftIsMemberAccess && node.Right.NodeType != ExpressionType.Constant)
                        throw new NotSupportedException("Right operand should be a constant if left is member access");
                    if (rightIsMemberAccess && node.Left.NodeType != ExpressionType.Constant)
                        throw new NotSupportedException("Left operand should be a constant if right is member access");

                    var memAccess = leftIsMemberAccess ? node.Left : node.Right;
                    var constant = leftIsMemberAccess ? node.Right : node.Left;

                    Visit(memAccess);
                    resultString.Append("(");
                    Visit(constant);
                    resultString.Append(")");
                    break;

                case ExpressionType.AndAlso:
                    Visit(node.Left);
                    statementList.Add(resultString.ToString());

                    resultString.Clear();
                    Visit(node.Right);

                    break;

                case ExpressionType.And:
                    Visit(node.Left);
                    statementList.Add(resultString.ToString());

                    resultString.Clear();
                    Visit(node.Right);

                    break;

                default: throw new NotSupportedException(string.Format("Operation {0} is not supported", node.NodeType));
			};

			return node;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			resultString.Append(node.Member.Name).Append(":");

			return base.VisitMember(node);
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			resultString.Append(node.Value);

			return node;
		}
	}
}
