using System;

namespace EfHwApp.Annotations
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RazorWriteMethodAttribute : Attribute { }
}