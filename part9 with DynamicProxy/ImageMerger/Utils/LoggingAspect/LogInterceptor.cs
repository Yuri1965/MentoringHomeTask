using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace ImageMerger
{
    [Serializable]
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation) 
        {
            var stringBuilder = new StringBuilder();

            try
            {
                stringBuilder.AppendLine();
                stringBuilder.Append("Method started:");
                stringBuilder.Append(invocation.TargetType.FullName)
                    .Append(".")
                    .Append(invocation.Method)
                    .Append("(");
                stringBuilder.Append(JsonConvert.SerializeObject(invocation.Arguments));
                stringBuilder.Append(")");
                
                LoggerUtil.logger.Info(stringBuilder.ToString());
                stringBuilder.Clear();

                invocation.Proceed();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                stringBuilder.Append("Method executed:");

                if (!invocation.Method.IsConstructor && ((MethodInfo)invocation.Method).ReturnType != typeof(void))
                {
                    stringBuilder.AppendLine();
                    stringBuilder.Append(invocation.TargetType.FullName)
                        .Append(".")
                        .Append(invocation.Method);
                    stringBuilder.Append(string.Format(" with return Value ({0}) = ", ((MethodInfo)invocation.Method).ReturnType.ToString()));
                    stringBuilder.Append(JsonConvert.SerializeObject(invocation.ReturnValue));
                }
                
                LoggerUtil.logger.Info(stringBuilder.ToString());
            }
        }

    }
}
