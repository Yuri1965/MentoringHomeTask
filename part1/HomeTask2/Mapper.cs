using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeTask2
{
    public class MapperException : Exception
    {
        public MapperException()
        {
        }

        public MapperException(string message) : base(message)
        {
        }

        public MapperException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MapperException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class Mapper<TSource, TDestination>
    {
        Func<TSource, TDestination> mapFunction;

        internal Mapper(Func<TSource, TDestination> func)
        {
            mapFunction = func;
        }

        public TDestination Map(TSource source)
        {
            return mapFunction(source);
        }
    }

    public class MappingGenerator
    {
        public Mapper<TSource, TDestination> Generate<TSource, TDestination>()
        {
            var sourceType = typeof(TSource);
            var targetType = typeof(TDestination);

            var sourceParam = Expression.Parameter(sourceType);
            var targetParam = Expression.Parameter(targetType);

            var statements = new List<Expression>();
            // Create new object, i.e.
            // target = new TargetType
            statements.Add(Expression.Assign(targetParam, Expression.New(targetType)));

            // Assign all fields and properties, i.e. 
            // target.Property1 = source.Property1;
            // target.Property2 = source.Property2;
            // ...
            var members = GetMappingMembers(sourceType);
            foreach (var sourceMemberInfo in members)
            {
                var targetMemberInfo = GetMappingMember(targetType, sourceMemberInfo.Name);
                
                if (targetMemberInfo == null)
                    continue; 

                var targetMemberAccess = Expression.MakeMemberAccess(targetParam, targetMemberInfo);
                var sourceMemberAccess = Expression.MakeMemberAccess(sourceParam, sourceMemberInfo);

                if (targetMemberAccess.Member.GetType().Equals(sourceMemberAccess.Member.GetType()) &&
                    targetMemberAccess.Type.Name.Equals(sourceMemberAccess.Type.Name))
                    statements.Add(Expression.Assign(targetMemberAccess, sourceMemberAccess));
            }

            // Return result (Expression.Block return the result of the last expression in the block)
            statements.Add(targetParam);

            var mapFunction = Expression.Lambda<Func<TSource, TDestination>>(
                    Expression.Block(new [] { targetParam }, statements),
                    sourceParam);
            
            return new Mapper<TSource, TDestination>(mapFunction.Compile());
        }

        public bool MemberwiseEqual<TSource, TTarget>(TSource source, TTarget target)
        {
            var sourceParam = Expression.Parameter(typeof(TSource));
            var targetParam = Expression.Parameter(typeof(TTarget));

            var compareBody = Expression.Constant(true);
            Expression equalityTestBody = Expression.Constant(true);

            var sourceMembers = GetMappingMembers(typeof(TSource));
            foreach (var sourceMember in sourceMembers)
            {
                var targetMember = GetMappingMember(typeof(TTarget), sourceMember.Name);

                if (targetMember == null)
                    continue;

                var sourceRef = Expression.MakeMemberAccess(sourceParam, sourceMember);
                var targetRef = Expression.MakeMemberAccess(targetParam, targetMember);

                if (targetRef.Member.GetType().Equals(sourceRef.Member.GetType()) &&
                    targetRef.Type.Name.Equals(sourceRef.Type.Name))
                    equalityTestBody = Expression.AndAlso(equalityTestBody, Expression.Equal(sourceRef, targetRef));
            }

            var equalityTest = Expression.Lambda<Func<TSource, TTarget, bool>>(equalityTestBody, sourceParam, targetParam);
            
            return equalityTest.Compile().Invoke(source, target);
        }

        private static MemberInfo[] GetMappingMembers(Type type)
        {
            return type.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(member => member.MemberType.HasFlag(MemberTypes.Field) || 
                                 member.MemberType.HasFlag(MemberTypes.Property)).ToArray();
        }

        private static MemberInfo GetMappingMember(Type type, string name)
        {
            return type.GetMember(name, MemberTypes.Field | MemberTypes.Property, 
                                        BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic).SingleOrDefault();
        }
    }
}
