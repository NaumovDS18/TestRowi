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
        private string searchEngine;
        private string searchBar;
        private string Response;


        public SpecFlowFeature1Steps() => chromeDriver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);

        [When(@"Close browser")]
        public void WhenCloseBrowser()
        {
            chromeDriver.Quit();
        }


        [Given(@"Opened (.*)")]
        public void GivenOpenSearchEngine(string searchEngine)
        {
            switch (searchEngine)
            {
                case "Google":
                    chromeDriver.Navigate().GoToUrl("https://www.google.ru/");
                    break;
                case "Yandex":
                    chromeDriver.Navigate().GoToUrl("https://yandex.ru/");
                    break;

            }
        }
        [When(@"Input (.*) in (.*) search bar")]
        public void WhenInputInSearhBar(string searchKeyWord, string SearchBar)
        {

            switch (SearchBar)
            {
                case "Google":
                    IWebElement GooglesearchBox = chromeDriver.FindElement(By.Name("q"));
                    GooglesearchBox.SendKeys(searchKeyWord);
                    GooglesearchBox.SendKeys(Keys.Enter); ;
                    break;
                case "Yandex":
                    IWebElement YandexsearchBox = chromeDriver.FindElement(By.Id("text"));
                    YandexsearchBox.SendKeys(searchKeyWord);
                    IWebElement searchButton = chromeDriver.FindElement(By.XPath("//div[2]/button"));
                    searchButton.Click();
                    break;

            }
        }
            [Then(@"First link in (.*) contains rowi\.com")]
            public void ThenFirstLinkContainsRowi_Com(string Response)
            {
            switch (Response)
            {
                case "Google":

                    IWebElement GooglesearchResult = chromeDriver.FindElement(By.XPath("//div[1]/div/div/div/div/div/div[1]/a/div/cite"));
                    String GooglegetText = GooglesearchResult.Text;
                    Assert.AreEqual("https://rowi.com", GooglegetText);
                break;


                case "Yandex":
                IWebElement YandexsearchResult = chromeDriver.FindElement(By.XPath("//li[1]/div/div[1]/div[2]/div[1]/a/b"));
                String YandexgetText = YandexsearchResult.Text;
                Assert.AreEqual("rowi.com", YandexgetText);
                break;

            }

        }
        }

    }

