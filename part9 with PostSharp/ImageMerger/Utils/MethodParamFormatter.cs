using System;
using System.Reflection;
using System.Text;
using PostSharp.Aspects;

namespace ImageMerger
{
    internal static class MethodParamFormatter
    {
        public static void AppendTypeName(StringBuilder stringBuilder, Type declaringType)
        {
            stringBuilder.Append(declaringType.FullName);
            if (declaringType.IsGenericType)
            {
                var genericArguments = declaringType.GetGenericArguments();
                AppendGenericArguments(stringBuilder, genericArguments);
            }
        }

        public static void AppendGenericArguments(StringBuilder stringBuilder, Type[] genericArguments)
        {
            stringBuilder.Append('<');
            for (var i = 0; i < genericArguments.Length; i++)
            {
                if (i > 0)
                {
                    stringBuilder.Append(", ");
                }

                stringBuilder.Append(genericArguments[i].Name);
            }
            stringBuilder.Append('>');
        }

        public static void AppendArguments(StringBuilder stringBuilder, Arguments arguments, ParameterInfo[] paramsMethod)
        {
            stringBuilder.Append('(');

            for (var i = 0; i < arguments.Count; i++)
            {
                if (i > 0)
                {
                    stringBuilder.AppendLine(";");
                }

                stringBuilder.Append(String.Format("[paramName = {0}, paramType = {1}, paramValue = {2}]", paramsMethod[i].Name, arguments[i].GetType(), arguments[i]));
            }

            stringBuilder.Append(')');
        }
    }


}
