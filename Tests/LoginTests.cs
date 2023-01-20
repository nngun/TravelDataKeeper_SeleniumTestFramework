using TravelDataKeeperTestFramework.PageObjects;
using TravelDataKeeperTestFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using static System.Collections.Specialized.BitVector32;


namespace TravelDataKeeperTestFramework
{

    [Parallelizable(ParallelScope.Self)]
    public class LoginTests : Base
    {
        [Test, TestCaseSource("AddTestDataConfigforValidLogin"), Category("Regression")]
        [Parallelizable(ParallelScope.All)]

        public void validLoginTest(String username, String password)
        {

            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign in button
            LoginPage loginPage = mainPage.signInButton();

            //wait for sign in page to be displayed
            loginPage.waitForSigninPageDisplay();

            //call proper login method with test data
            TravelerOptionsPage travelerOptionsPage = loginPage.validLogin(username, password);

            Boolean expectedOutcome = true;

            //check that if My World Travel Map section is available 
            Assert.AreEqual(expectedOutcome, travelerOptionsPage.getMyWorldTravelMap().Displayed);

            //check that if My Wish List section is available 
            Assert.AreEqual(expectedOutcome, travelerOptionsPage.getMyWishList().Displayed);

            // check that if My Blog Posts section is available
            Assert.AreEqual(expectedOutcome, travelerOptionsPage.getMyBlogPosts().Displayed);

            //check button name is changed from Sign Up to Sign Out after proper login
            String buttonName = "Sign Out";
            Assert.AreEqual(buttonName, travelerOptionsPage.SignOutButton().Text);


        }

        [Test, TestCaseSource("AddTestDataConfigforInvalidLogin"), Category("Regression")]
        [Parallelizable(ParallelScope.All)]

        public void invalidLoginTest(String username_wrong, String password_wrong)
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign in button
            LoginPage loginPage = mainPage.signInButton();

            //wait for sign in page to be displayed
            loginPage.waitForSigninPageDisplay();

            //call invalid login method with test data and store alert message into the variable
            String invalidLoginAlert = loginPage.invalidLogin(username_wrong, password_wrong).Text;

            //check if alert message is shown correctly
            StringAssert.Contains("incorrect", invalidLoginAlert);

        }

        public static IEnumerable<TestCaseData> AddTestDataConfigforValidLogin()

        {

            yield return new TestCaseData(getDataParser().extractData("valid_username"), getDataParser().extractData("valid_password"));
            yield return new TestCaseData(getDataParser().extractData("valid_username2"), getDataParser().extractData("valid_password2"));
        }

        public static IEnumerable<TestCaseData> AddTestDataConfigforInvalidLogin()

        {
            yield return new TestCaseData(getDataParser().extractData("username_wrong"), getDataParser().extractData("password_wrong"));
        }


    }

}