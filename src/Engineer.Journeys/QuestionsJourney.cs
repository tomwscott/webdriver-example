using Engineer.Journeys.Support;
using Engineer.Journeys.Support.Pages;
using NUnit.Framework;

namespace Engineer.Journeys
{
    [TestFixture]
    public class QuestionsJourney
    {
        [Test]
        public void ShouldFillInQuestions()
        {
            var personalDetailsPage  = Browser.Current.GoTo<PersonalDetailsQuestionsPage>();
            personalDetailsPage.FirstName.SendKeys("Tom");
            personalDetailsPage.LastName.SendKeys("Scott");
            personalDetailsPage.DateOfBirth.SendKeys("20th February");

            var preferencesPage = personalDetailsPage.ClickNext();
            preferencesPage.DotNet.Click();
        }
    }
}