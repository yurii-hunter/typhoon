using NUnit.Framework;
using Typhoon.Infrastructure.Driver;
using Typhoon.Infrastructure.Factory;
using Typhoon.Infrastructure.Locators;
using Typhoon.Tests.Pages;

namespace Typhoon.Tests
{
    [TestFixture]
    class PageTests
    {
        private HomePage _homePage;

        [SetUp]
        public void SetUp()
        {
            _homePage = PageFactory.Get<HomePage>();
        }

        [TearDown]
        public void TearDown()
        {
            if (DriverService.Driver.IsRunning)
            {
                DriverService.Driver.Close();
            }
        }

        [Test]
        public void PageElement()
        {
            Assert.That(_homePage.CoverItem.SearchStrategy.Locator.How, Is.EqualTo(How.CssSelector));
        }
    }
}
