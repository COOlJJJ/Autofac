﻿using Autofac.Core;
using System.Linq;
using System.Reflection;

namespace 批量注入
{
    /// <summary>
    /// IPropertySelector:查看属性上是否标记某一个特性
    /// </summary>
    public class AutowiredPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            //判断属性的特性是否包含自定义的属性,标记有返回true
            return propertyInfo.CustomAttributes.Any(s => s.AttributeType == typeof(AutowiredPropertyAttribute));
        }
    }
}
