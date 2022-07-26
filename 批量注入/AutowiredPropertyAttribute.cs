using System;

namespace 批量注入
{
    [AttributeUsage(AttributeTargets.Property)]//为了支持属性注入，只能打到属性上
    public class AutowiredPropertyAttribute : Attribute
    {
    }
}
