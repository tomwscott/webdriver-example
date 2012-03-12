using OpenQA.Selenium.Firefox;

namespace Engineer.Journeys.Support
{
    public class FirefoxProfileBuilder
    {
        private readonly FirefoxProfile profile;

        public FirefoxProfileBuilder(string profilePath)
        {
            profile = new FirefoxProfile(profilePath);
        }

        public FirefoxProfile Build()
        {
            return profile;
        }

        public FirefoxProfileBuilder WithNewWindowsOpeningNotInTabs() // needed for webdriver window management
        {
            return WithPreference("browser.link.open_newwindow", 2);
        }

        public FirefoxProfileBuilder WithScriptsAllowedToCloseWindows()
        {
            return WithPreference("dom.allow_scripts_to_close_windows", true);
        }

        private FirefoxProfileBuilder WithPreference(string preferenceName, bool value)
        {
            profile.SetPreference(preferenceName, value);
            return this;
        }

        private FirefoxProfileBuilder WithPreference(string preferenceName, int value)
        {
            profile.SetPreference(preferenceName, value);
            return this;
        }

        private void WithPreference(string preferenceName, string value)
        {
            profile.SetPreference(preferenceName, value);
        }

        public FirefoxProfileBuilder WithProxy(string proxyHost, int proxyPort)
        {
            var manualProxySetting = 1;
            WithPreference("network.proxy.type", manualProxySetting);
            WithPreference("network.proxy.http", proxyHost);
            return WithPreference("network.proxy.http_port", proxyPort);
        }

    }
}