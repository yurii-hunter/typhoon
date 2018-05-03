using System;

namespace Typhoon.Infrastructure.Factory
{
    public class UrlAttribute : Attribute
    {
        public string Url { get; private set; }

        public UrlAttribute(string url)
        {
            Url = url;
        }
    }
}