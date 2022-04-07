using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject3.Features
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private ChromeDriver chromeDriver;
        private string searchKeyWord;
        public SpecFlowFeature1Steps() => chromeDriver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);

        [Given(@"Opened Google search")]
        public void GivenGoGoogle()
        {
            chromeDriver.Navigate().GoToUrl("https://www.google.ru/");
        }

        [Given(@"Opened Yandex search")]
        public void GivenGoYandex()
        {
            chromeDriver.Navigate().GoToUrl("https://yandex.ru/");
        }

        [When(@"Input (.*) in google searh bar")]
        public void WhenInputInGoogleSearhBar(string searchKeyWord)
        {
            IWebElement searchBox = chromeDriver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchKeyWord);
            searchBox.SendKeys(Keys.Enter);
        }

        [When(@"Input (.*) in yandex searh bar")]
        public void WhenInputInYandexSearhBar(string searchKeyWord)
        {
            IWebElement searchBox = chromeDriver.FindElement(By.Id("text"));
            searchBox.SendKeys(searchKeyWord);
            IWebElement searchButton = chromeDriver.FindElement(By.XPath("//div[2]/button"));
            searchButton.Click();
        }

        [Then(@"First link in google contains rowi\.com")]
        public void ThenFirstgoogleLinkContainsRowi_Com()
        {
            IWebElement searchResult = chromeDriver.FindElement(By.XPath("//div[1]/div/div/div/div/div/div[1]/a/div/cite"));
            String getText = searchResult.Text;
            Assert.AreEqual("https://rowi.com", getText);
        }

        [Then(@"First link in yandex contains rowi\.com")]
        public void ThenFirstyandexLinkContainsRowi_Com()
        {
            IWebElement searchResult = chromeDriver.FindElement(By.XPath("//li[1]/div/div[1]/div[2]/div[1]/a/b"));
            String getText = searchResult.Text;
            Assert.AreEqual("rowi.com", getText);
        }

        [When(@"Close browser")]
        public void WhenCloseBrowser()
        {
            chromeDriver.Quit();
        }

    }
}
