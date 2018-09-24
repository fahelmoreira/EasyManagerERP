using System;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EasyManager.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal class VersionAttribute : Attribute
    {
        public string Version { get; }
        public VersionAttribute(int ver)
        {
            Version = ver.ToString();
        }
    }
}