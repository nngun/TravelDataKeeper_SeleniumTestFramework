using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TravelDataKeeperTestFramework.PageObjects
{
	public class MainPage
	{
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //page object factory for sign in button
        [FindsBy(How = How.CssSelector, Using = ".text-secondary[routerlink='/login']")]
        private IWebElement signIn;


        //page object factory for inspiration button
        [FindsBy(How = How.CssSelector, Using = ".text-secondary[routerlink='/inspire']")]
        private IWebElement InspirationButton;

        //page object factory for sign up button
        [FindsBy(How = How.CssSelector, Using = ".text-light[routerlink='/register']")]
        private IWebElement signUp;

        public SignUpPage signUpButton()
        {
            signUp.Click();
            return new SignUpPage(driver);
        }

        public LoginPage signInButton()
        {
            signIn.Click();
            return new LoginPage(driver);
        }


        public InspirationPage clickInspirationButton()
        {
            InspirationButton.Click();
            return new InspirationPage(driver);
        }


        public IWebElement getInspirationButton()
        {

            return InspirationButton;

        }

        public IWebElement getSignInButton()
        {

            return signIn;

        }

        public IWebElement getSignUpButton()
        {

            return signUp;

        }

    }
}

