using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Collections;
using System.Reflection;
using System.Text;

namespace ImageMerger
{
    [PSerializable]
    public sealed class LogMethodParams : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Method started:");
            AppendCallInformation(args, stringBuilder);
            LoggerUtil.logger.Info(stringBuilder.ToString());
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Method executed:");
            AppendCallInformation(args, stringBuilder);

            if (!args.Method.IsConstructor && ((MethodInfo)args.Method).ReturnType != typeof(void))
            {
                stringBuilder.Append(string.Format(" with return Value ({0}) = ", ((MethodInfo)args.Method).ReturnType.ToString()));
                stringBuilder.Append(string.Join(", ", args.ReturnValue));
            }

            LoggerUtil.logger.Info(stringBuilder.ToString());
        }


        private static void AppendCallInformation(MethodExecutionArgs args, StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine();
            var declaringType = args.Method.DeclaringType;
            MethodParamFormatter.AppendTypeName(stringBuilder, declaringType);
            stringBuilder.Append('.');
            stringBuilder.Append(args.Method.Name);

            if (args.Method.IsGenericMethod)
            {
                var genericArguments = args.Method.GetGenericArguments();
                MethodParamFormatter.AppendGenericArguments(stringBuilder, genericArguments);
            }

            var arguments = args.Arguments;
            var paramsMethod = args.Method.GetParameters();
            MethodParamFormatter.AppendArguments(stringBuilder, arguments, paramsMethod);
        }
    }
}
