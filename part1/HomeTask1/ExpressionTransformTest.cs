using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace ExprTransform
{
    [TestClass]
    public class ExpressionTransformTest
    {
        // This region for tests of transformation +1 and -1 to Increment and Decrement
        #region RegionIncrementAndDecrementTransformTest
        private void DoIncrementAndDecrementTransformTest(Expression<Func<int, int>> sourceExp, int paramValue)
        {
            ExpressionTransform expTrans = new ExpressionTransform();

            //expression output to the console without transformation
            Console.WriteLine("Expression {0} return Result = {1} for Parameter a = {2}",
                            sourceExp, sourceExp.Compile().Invoke(paramValue), paramValue);
            Console.WriteLine("\n");
            expTrans.IsExprTreePrint = true;
            var result_exp = expTrans.VisitAndConvert(sourceExp, "");
            Console.WriteLine("\n");

            //expression output to the console after transformation
            expTrans.IsExprTreePrint = false;
            expTrans.IsExprConvertIncrDecr = true;
            result_exp = expTrans.VisitAndConvert(sourceExp, "");
            Console.WriteLine("Expression {0} return Result = {1} for Parameter a = {2}",
                            result_exp, result_exp.Compile().Invoke(paramValue), paramValue);
            Console.WriteLine("\n");
            //this call just for a output to the console of a tree of expressions, 
            //transformation is turned off by IsExprConvertIncrDecr sign = false
            expTrans.IsExprTreePrint = true;
            expTrans.IsExprConvertIncrDecr = false;
            result_exp = expTrans.VisitAndConvert(result_exp, "");
        }

        [TestMethod]
        public void IncrementAndDecrementTransformTest1()
        {
            int myConst = 3;
            Expression<Func<int, int>> sourceExp = (a) => (a - 1) + (4 - a);

            DoIncrementAndDecrementTransformTest(sourceExp, myConst);
        }

        [TestMethod]
        public void IncrementAndDecrementTransformTest2()
        {
            int myConst = 3;
            Expression<Func<int, int>> sourceExp = (a) => (1 - a) * (a - 1);

            DoIncrementAndDecrementTransformTest(sourceExp, myConst);
        }

        [TestMethod]
        //method for the test of transformation +1 and -1 to Increment and Decrement
        public void IncrementAndDecrementTransformTest3()
        {
            int myConst = 3;
            Expression<Func<int, int>> sourceExp = (a) => (a - 1) + (a + 1) * (a + 5) * (a - 1) + (1 - a);

            DoIncrementAndDecrementTransformTest(sourceExp, myConst);
        }
        
        #endregion 
        
        // This region for tests of transformation with replacement parameters from array a "key-value"
        #region RegionReplacementParameterTransformTest

        //метод вызывается для преобразования дерева выражений (подставляются инкременты и декременты, 
        //а также вместо параметров подставляются их значения)
        public Expression<T> ReplacementLambdaParameters<T>(Expression<T> expression, IEnumerable<KeyValuePair<string, Expression>> replaceParamList,
                                                            bool outputExprToConsole = false, bool exprReplaceParamFromList = true,
                                                            bool exprConvertIncrDecr = true)
        {
            var replaceParamListDict = replaceParamList.ToDictionary(pair => pair.Key, pair => pair.Value);
            
            return (new ExpressionTransform(replaceParamListDict) 
                                            {
                                             IsExprTreePrint = outputExprToConsole,
                                             IsExprConvertIncrDecr = exprConvertIncrDecr,
                                             IsExprReplaceParamFromList = exprReplaceParamFromList
                                            }).VisitAndConvert(expression, "");
        }

        private void DoTestParameterReplacement<T>(Expression<T> source, IEnumerable<KeyValuePair<string, Expression>> replaceParam,
                                               bool outputExprToConsole = false, bool exprReplaceParamFromList = true,
                                               bool exprConvertIncrDecr = true)
        {
            //лишние вызовы используются для наглядности изменений в дереве выражений
            Console.WriteLine(source);
            Console.WriteLine("\n");

            var result = ReplacementLambdaParameters(source, replaceParam, outputExprToConsole, false, false);
            Console.WriteLine("\n");

            replaceParam.ToList().ForEach(x => Console.WriteLine("Parameter = {0} Value = {1}", x.Key, x.Value));
            Console.WriteLine("\n");

            result = ReplacementLambdaParameters(source, replaceParam, false, exprReplaceParamFromList, exprConvertIncrDecr);
            Console.WriteLine(result);
            Console.WriteLine("\n");

            result = ReplacementLambdaParameters(result, replaceParam, outputExprToConsole, false, false);
            Console.WriteLine("\n");
        }

        [TestMethod]
        public void ReplaceParametersTest1()
        {
            int myConst = 10;

            var replParamList = new List<KeyValuePair<string, Expression>>();
            replParamList.Add(new KeyValuePair<string, Expression>("a", Expression.Constant(myConst)));

            Expression<Func<int, int>> sourceExp = a => a + 1;

            DoTestParameterReplacement<Func<int, int>>(sourceExp, replParamList, true);

            var result = ReplacementLambdaParameters<Func<int, int>>(sourceExp, replParamList);

            Console.WriteLine(result.Compile().DynamicInvoke(myConst));
        }

        [TestMethod]
        public void ReplaceParametersTest2()
        {
            var replParamList = new List<KeyValuePair<string, Expression>>();
            
            var aVal = 15;
            var bVal = 13;
            var cVal = 14;

            replParamList.Add(new KeyValuePair<string, Expression>("a", Expression.Constant(aVal)));
            replParamList.Add(new KeyValuePair<string, Expression>("b", Expression.Constant(bVal)));
            replParamList.Add(new KeyValuePair<string, Expression>("c", Expression.Constant(cVal)));

            Expression<Func<int, int, int, int>> sourceExp = (a, b, c) => c * (b - 1) + a * (a + 1);

            DoTestParameterReplacement<Func<int, int, int, int>>(sourceExp, replParamList, true);

            var result = ReplacementLambdaParameters<Func<int, int, int, int>>(sourceExp, replParamList);

            Console.WriteLine(result.Compile().Invoke(aVal, bVal, cVal));
        }

        #endregion

    }
}
