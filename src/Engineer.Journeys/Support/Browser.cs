using System;
using OpenQA.Selenium;

namespace Engineer.Journeys.Support
{
    public class Browser : IDisposable
    {
        private readonly IWebDriver driver;
        
        private Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static Browser Initialise(IWebDriver driver)
        {
            Current = new Browser(driver);
            return Current; 
        }

        public static Browser Current { get; private set; }


        public SpecificPage GoTo<SpecificPage>() where SpecificPage : Page<SpecificPage>
        {
            return Page<SpecificPage>.Open(driver);
        }

        public SpecificPage Get<SpecificPage>() where SpecificPage : Page<SpecificPage>
        {
            return Page<SpecificPage>.Create(driver);
        }

        public static void Close()
        {
            Current.Quit();
        }

        public void Quit()
        {
            driver.Dispose();
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public void Back()
        {
            driver.Navigate().Back();
        }

        public string Location()
        {
            return driver.Url;
        }
    }
}
