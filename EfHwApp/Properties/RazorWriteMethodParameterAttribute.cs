using System;

namespace EfHwApp.Annotations
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class RazorWriteMethodParameterAttribute : Attribute { }
}