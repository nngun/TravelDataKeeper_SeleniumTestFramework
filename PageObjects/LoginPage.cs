using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TravelDataKeeperTestFramework.PageObjects
{
	public class LoginPage
	{
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
		{
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page object factory for username
        [FindsBy(How = How.CssSelector, Using = "#loginFieldID")]
        private IWebElement username;

        //page object factory for password
        [FindsBy(How = How.CssSelector, Using = "#passwordFieldID")]
        private IWebElement password;

        //page object factory for signIn Button
        [FindsBy(How = How.XPath, Using = "//div[@class='h6 my-auto']")]
        private IWebElement signIn;

        //page object factory for invalid login alert
        [FindsBy(How = How.XPath, Using = "//div[@role='alert']")]
        private IWebElement invalidLoginAlert;

        //page object factory for login title
        [FindsBy(How = How.XPath, Using = "//h2[normalize-space()='LOGIN']")]
        private IWebElement loginTitle;



        public void waitForSigninPageDisplay()

        {
            //wait until Sign In button is available
            //if Sign In button is available, it means that sign in page appears

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='h6 my-auto']")));
        }

        //reusable method whenever you need proper valid login
        public TravelerOptionsPage validLogin(string user, string pass)
        {

            //this is loging in and also give us new object for the directed page
            username.SendKeys(user);
            password.SendKeys(pass);
            signIn.Click();
            return new TravelerOptionsPage(driver);

        }

        //reusable method whenever you need invalid login
        public IWebElement invalidLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            signIn.Click();
            return invalidLoginAlert;

        }

        public IWebElement getUsername()
        {
            
            return username;

        }


        public IWebElement getPassword()
        {

            return password;

        }

        public IWebElement getSignInButton()
        {

            return signIn;

        }

        public IWebElement getLoginTitle()
        {

            return loginTitle;

        }


    }
}

