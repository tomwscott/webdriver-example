using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Engineer.Journeys.Support
{
    public abstract class Page<SpecificPage> where SpecificPage : Page<SpecificPage>
    {
        protected readonly IWebDriver driver;
        private readonly Resource resource;

        protected Page(IWebDriver driver, Resource resource)
        {
            this.driver = driver;
            this.resource = resource;
        }

        public string Title
        {
            get { return driver.Title; }
        }

        public void Back()
        {
            driver.Navigate().Back();
        }

        public string Source
        {
            get { return driver.PageSource; }
        }

        public string Url
        {
            get { return driver.Url; }
        }

        public IList<IWebElement> LinkedStyleSheets
        {
            get { return driver.FindElements(By.XPath("//link[@rel=\"stylesheet\"]")); }
        }

        public IList<IWebElement> LinkedJsScripts
        {
            get { return driver.FindElements(By.XPath("//script")); }
        }

        public string MetaDescription
        {
            get { return driver.FindElement(By.XPath("/html/head/meta[@name=\"description\"]")).GetAttribute("content"); }
        }

        public static SpecificPage Open(IWebDriver driver)
        {
            var page = Create(driver);

            page.driver.Navigate().GoToUrl(page.resource.ToUri("http://localhost/engineer/"));

            return page;
        }

        public static SpecificPage Create(IWebDriver driver)
        {
            return (SpecificPage)Activator.CreateInstance(typeof(SpecificPage), driver);
        }
    }

    public class Resource
    {
        private readonly string path;
        public static readonly Resource Root = new Resource("/");
        public static readonly Resource PersonalDetailsQuestion = new Resource("/questions/personaldetails");
        public static readonly Resource PreferencesPage = new Resource("/questions/preferences");

        private Resource(string path)
        {
            this.path = path;
        }

        public Uri ToUri(string root)
        {
            return new Uri(root + path);
        }
    }
}