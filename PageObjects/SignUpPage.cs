using System;
using System.Xml.Linq;
using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using WebDriverManager.DriverConfigs.Impl;


namespace TravelDataKeeperTestFramework.PageObjects
{
    public class SignUpPage
    {
        IWebDriver driver;

        public SignUpPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page object factory for firstname
        [FindsBy(How = How.XPath, Using = "(//input[@id='loginFieldID'])[1]")]
        private IWebElement firstname;

        //page object factory for lastname
        [FindsBy(How = How.XPath, Using = "(//input[@id='loginFieldID'])[2]")]
        private IWebElement lastname;

        //page object factory for username
        [FindsBy(How = How.XPath, Using = "(//input[@id='loginFieldID'])[3]")]
        private IWebElement username;

        //page object factory for password
        [FindsBy(How = How.CssSelector, Using = "#passwordFieldID")]
        private IWebElement password;

        //page object factory for registerButton
        [FindsBy(How = How.XPath, Using = "//body/app-root[1]/div[1]/app-register[1]/section[1]/div[1]/section[1]/div[1]/div[1]/div[1]/form[1]/div[5]/button[1]")]
        private IWebElement RegisterButton;

        //page object factory for alert
        [FindsBy(How = How.CssSelector, Using = "div[role='alert']")]
        private IWebElement alertMessage;

        public void waitForSignUpPageDisplay()

        {
            //wait until register button is available
            //if register button is available, it means that sign up page appears

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".h6.my-auto")));
        }

        public IWebElement getRegisterButton()
        {
            
            return RegisterButton;

        }


        //this is an invalid SignUp with already existing user
        public IWebElement SignUpwithExistingUser(string fname, string lname, string user, string pass)
        {
            firstname.SendKeys(fname);
            lastname.SendKeys(lname);
            username.SendKeys(user);
            password.SendKeys(pass);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", RegisterButton);

            //not using below code because it gives “Element is not clickable at point” error
            //RegisterButton.Click();
            return alertMessage;

        }

        //this is a valid SignUp without typing first name
        public LoginPage SignUpwithoutFname(string lname, string user, string pass)
        {
            lastname.SendKeys(lname);
            username.SendKeys(user);
            password.SendKeys(pass);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", RegisterButton);

            //not using below code because it gives “Element is not clickable at point” error
            //RegisterButton.Click();
            return new LoginPage(driver);

        }

        //this is a valid SignUp without typing last name
        public LoginPage SignUpwithoutlname(string fname, string user, string pass)
        {
            firstname.SendKeys(fname);
            username.SendKeys(user);
            password.SendKeys(pass);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", RegisterButton);

            //not using below code because it gives “Element is not clickable at point” error
            //RegisterButton.Click();
            return new LoginPage(driver);

        }

        //this is an invalid SignUp without typing username
        public IWebElement SignUpwithoutUsername(string fname, string lname, string pass)
        {
            firstname.SendKeys(fname);
            lastname.SendKeys(lname);
            password.SendKeys(pass);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", RegisterButton);

            //not using below code because it gives “Element is not clickable at point” error
            //RegisterButton.Click();
            return alertMessage;

        }

        //this is an invalid SignUp without typing password
        public IWebElement SignUpwithoutPassword(string fname, string lname, string user)
        {
            firstname.SendKeys(fname);
            lastname.SendKeys(lname);
            username.SendKeys(user);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", RegisterButton);

            //not using below code because it gives “Element is not clickable at point” error
            //RegisterButton.Click();
            return alertMessage;

        }

        //this is an invalid SignUp without typing in existing fields
        public IWebElement SignUpwithNoInfo()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", RegisterButton);

            //not using below code because it gives “Element is not clickable at point” error
            //RegisterButton.Click();
            return alertMessage;

        }

        //this is a valid SignUp with all existing details
        public LoginPage SignUpwithNewUser(string fname, string lname, string user, string pass)
        {
            firstname.SendKeys(fname);
            lastname.SendKeys(lname);
            username.SendKeys(user);
            password.SendKeys(pass);


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", RegisterButton);

            //not using below code because it gives “Element is not clickable at point” error
            //RegisterButton.Click();
            return new LoginPage(driver);

        }


    }
}
