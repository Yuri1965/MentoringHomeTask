using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace ExprTransform
{
    public class ExpressionTransform : ExpressionVisitor
    {
        //for an expression tree conclusion in the console - spaces for knots
        private int spaceBlankCount = 0;

        //information output sign about knots in the console
        public bool IsExprTreePrint = false;
        //sign for transformation +1 and-1 to Increment or Decrement in expression
        public bool IsExprConvertIncrDecr = false;

        //array a "key-value" for replacement of parameters in expression
        private Dictionary<string, Expression> replaceParamList;
        //sign of replacement of parameters of expression from the array a key-value
        public bool IsExprReplaceParamFromList = false;

        public ExpressionTransform()
        {
        }

        public ExpressionTransform(Dictionary<string, Expression> replaceParamList)
        {
            this.replaceParamList = replaceParamList;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node == null)
                return base.VisitBinary(node);

            //we will transform operations +1 and -1 to Increment or Decrement if IsExprConvertIncrDecr = true
            if ((IsExprConvertIncrDecr) && (node.NodeType == ExpressionType.Add || node.NodeType == ExpressionType.Subtract))
            {
                ParameterExpression param = null;
                ConstantExpression constant = null;

                if (node.Left.NodeType == ExpressionType.Parameter || node.Right.NodeType == ExpressionType.Parameter)
                {
                    param = node.Left.NodeType == ExpressionType.Parameter ? (ParameterExpression)node.Left : (ParameterExpression)node.Right;
                }

                if (node.Left.NodeType == ExpressionType.Constant || node.Right.NodeType == ExpressionType.Constant)
                {
                    constant = node.Left.NodeType == ExpressionType.Constant ? (ConstantExpression)node.Left : (ConstantExpression)node.Right;
                }

                //replacement by Increment or Decrement
                if (param != null && constant != null && constant.Type == typeof(int) && (int)constant.Value == 1)
                {
                    if (node.NodeType == ExpressionType.Add)                 // (a + 1) and (1 + a)
                        return base.VisitUnary(Expression.Increment(param));
                    else if (node.Right.NodeType == ExpressionType.Constant) // (a - 1), but not (1 - a)
                        return base.VisitUnary(Expression.Decrement(param));
                         else 
                            return node;
                }
            }

            return base.VisitBinary(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == null)
                return base.VisitParameter(node);

            //search and replacement of parameter with value if IsExprReplaceParamFromList = true
            if (IsExprReplaceParamFromList)
            {
                Expression replExp;

                if (replaceParamList.TryGetValue(node.Name, out replExp))
                    return replExp;
            }

            return base.VisitParameter(node);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (node == null)
                return base.VisitLambda(node);

            // Do not visit node. Parameters, this will cause exceptions
            return node.Update(VisitAndConvert(node.Body, ""), node.Parameters);
        }

        public override Expression Visit(Expression node)
        {
            if (node == null)
                return base.Visit(node);

            // output expression tree knot in the console if IsExprTreePrint = true
            if (IsExprTreePrint)
                Console.WriteLine("{0}{1} - {2}", new String(' ', spaceBlankCount * 4), node.NodeType, node.GetType());

            spaceBlankCount++;
            Expression result = base.Visit(node);
            spaceBlankCount--;

            return result;
        }
    }
}
