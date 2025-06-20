﻿using Castle.DynamicProxy;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            if (!classAttributes.Any(x => x is LogAspect))
            {
                classAttributes.Add(new LogAspect(typeof(DatabaseLogger)));
            }
            if (!classAttributes.Any(x => x is PerformanceAspect))
            {
                classAttributes.Add(new PerformanceAspect(7));
            }

            if (!classAttributes.Any(x => x is ExceptionLogAspect))
            {
                classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            }

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
