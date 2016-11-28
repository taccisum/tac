using Practice.Controllers.Base.PhotoUpload.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.Controllers.Base.PhotoUpload
{
    internal static class ResolverFactory
    {
        private static Dictionary<ContextResolver, Type> _resolver = new Dictionary<ContextResolver, Type>()
        {
            {ContextResolver.Default, typeof(DefaultResolver)}
        };


        public static AbstractContextResolver Create(ContextResolver type)
        {
            if (_resolver.ContainsKey(type))
            {
                return Activator.CreateInstance(_resolver[type]) as AbstractContextResolver;
            }
            else
            {
                return Activator.CreateInstance(_resolver[ContextResolver.Default]) as AbstractContextResolver;
            }
        }
    }
}