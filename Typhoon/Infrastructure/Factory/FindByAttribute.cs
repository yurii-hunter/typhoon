using System;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure.Factory
{
    public class FindByAttribute : Attribute
    {
        public How How { get;}

        public string Using { get;}

        public FindByAttribute(How how, string @using)
        {
            How = how;
            Using = @using;
        }
    }
}
