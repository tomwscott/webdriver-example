using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Web.Journeys.Motor
{
    public class HappyPathJourney
    {
        [Test]
        public void ShouldPopulateRiskAndQuote()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://www.google.co.uk");
                var searchBox = driver.FindElement(By.Id("gbqfq"));
                searchBox.Click();
                searchBox.SendKeys("compare motor insurance");

                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 10));
                var elements = driver.FindElements(By.ClassName("g"));
                Assert.That(elements.Count, Is.GreaterThan(0));
                elements.First(el => el.Text.Contains("Compare The Market")).FindElement(By.TagName("a")).Click();

                new WebDriverWait(driver, new TimeSpan(0, 0, 0, 10)).Until(d => d.FindElement(By.Id("aspnetForm")));
                Assert.That(driver.Url, Is.StringContaining("http://www.comparethemarket.com"));

                Thread.Sleep(1000);

                driver.FindElementByCssSelector(".flexi-button.large.clear").Click();
                
                new WebDriverWait(driver, new TimeSpan(0, 0, 0, 10)).Until(d => d.FindElement(By.Id("ctl00_CPH1_NewQuoteView_TitlesView_DropDownListTitles")));

                var titleSelect = new SelectElement(driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_TitlesView_DropDownListTitles")));
                titleSelect.SelectByText("Mr");

                driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_TextBoxFirstName")).SendKeys("Tom");
                driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_TextBoxSurname")).SendKeys("Scott");
                
                new SelectElement(driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_DateInputDateOfBirth_DropDownListDay"))).SelectByText("01");
                new SelectElement(driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_DateInputDateOfBirth_DropDownListMonth"))).SelectByText("Dec");
                new SelectElement(driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_DateInputDateOfBirth_DropDownListYear"))).SelectByText("1980");

                driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_PostcodeView_TextBoxHouseNumberName")).SendKeys("88");
                driver.FindElement(By.Id("ctl00_CPH1_NewQuoteView_PostcodeView_TextBoxPostcode")).SendKeys("EC1M 6BP");
                driver.FindElement(By.Id("ctl00_CPH1_ImageButtonContinue")).Click();
                driver.Close();
            }
        }
    }
}