using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Typhoon.Infrastructure.BaseTypes.Element;
using Typhoon.Infrastructure.Extensions;
using Typhoon.Infrastructure.Factory;
using Typhoon.Infrastructure.Locators;

namespace Typhoon.Infrastructure.BaseTypes.Collections
{
    public class HtmlElementsCollection<THtmlElement> : INative, IHtmlElementsCollection<THtmlElement> where THtmlElement : IHtmlElement, new()
    {
        private IWebElement[] _nativeElements;

        public HtmlElementsCollection(INative parent, Locator locator)
        {
            Parent = parent;
            Locator = locator;
        }

        private INative Parent { get; }
        private Locator Locator { get; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<THtmlElement> GetEnumerator()
        {
            InitCollection();
            for (var i = 0; i < _nativeElements.Length; i++)
            {
                var htmlElement = ElementFactory.Create<THtmlElement>(this, Locator, i);
                htmlElement.SetNativeElement(_nativeElements[i]);
                yield return htmlElement;
            }
        }

        private void InitCollection()
        {
            _nativeElements = Parent.FindElements(Locator).ToArray();
        }

        public IWebElement FindElement(Locator locator, int index)
        {
            if (CollectionRequiresReInitialization(_nativeElements, index))
                InitCollection();
            if(IndexOutOfRange(_nativeElements, index))
                throw new IndexOutOfRangeException($"Collection does not contain element with index {index}");
            return _nativeElements[index];
        }

        public IReadOnlyCollection<IWebElement> FindElements(Locator locator)
        {
            throw new NotImplementedException();
        }

        private static bool IndexOutOfRange(IWebElement[] collection, int index)
        {
            return collection.Length < index + 1;
        }

        private static bool CollectionRequiresReInitialization(IWebElement[] collection, int index)
        {
            return IndexOutOfRange(collection, index) || !collection[index].Exists();
        }
    }
}
