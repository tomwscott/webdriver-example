using OpenQA.Selenium;

namespace Engineer.Journeys.Support.Pages
{
    public class PersonalDetailsQuestionsPage : Page<PersonalDetailsQuestionsPage>
    {
        public PersonalDetailsQuestionsPage(IWebDriver driver) : base(driver, Resource.PersonalDetailsQuestion)
        {
        }

        public IWebElement FirstName
        {
            get { return driver.FindElement(By.Id("first-name")); }
        }
        
        public IWebElement LastName
        {
            get { return driver.FindElement(By.Id("last-name")); }
        }

        public IWebElement DateOfBirth
        {
            get { return driver.FindElement(By.Id("date-of-birth")); }
        }

        public PreferencesPage ClickNext()
        {
            driver.FindElement(By.Id("next-button")).Click();
            return Browser.Current.Get<PreferencesPage>();
        }
    }

    public class PreferencesPage : Page<PreferencesPage>
    {
        public PreferencesPage(IWebDriver driver) : base(driver, Resource.PreferencesPage)
        {
        }

        public IWebElement DotNet
        {
            get { return driver.FindElement(By.Id("dot-net")); }
        }
    }
}