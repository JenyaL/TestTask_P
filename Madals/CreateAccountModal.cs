using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Allure.Steps;
using TestProject.Core;

namespace TestProject.Madals
{
    class CreateAccountModal : Init
    {
        //locators
        private By acceptButton = By.CssSelector($"[data-qa-entity='form.privacyAgreement.confirm']");

        //Methods
        private WebdriverCore webDriver = new WebdriverCore();

        [AllureStep("Check [Accept] button is displayed")]
        public void AcceptButtonIsDisplayed(bool state)
        {
            bool ActualResult;
            if (state)
            {
                webDriver.ExplicitWait(acceptButton);
            }

            ActualResult = webDriver.ElementDisplayed(acceptButton);
            Assert.AreEqual(ActualResult, state, "[Accept] button is displayed");
        }
    }
}
