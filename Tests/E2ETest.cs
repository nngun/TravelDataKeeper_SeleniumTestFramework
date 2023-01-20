using System;
using TravelDataKeeperTestFramework.PageObjects;
using TravelDataKeeperTestFramework.utilities;

namespace TravelDataKeeperTestFramework.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class E2ETest : Base
	{

        [Test, TestCaseSource("AddTestDataConfigforValidLogin"), Category("Regression")]
        [Parallelizable(ParallelScope.All)]

        public void E2ETestFlow(String username, String password)
		{

            //go to the website
            MainPage mainPage = new MainPage(getDriver());


            //check inspiration, sign in and sign up buttons are available on top navigation
            Boolean ExpectedResult = true;
            Assert.AreEqual(ExpectedResult, mainPage.getInspirationButton().Displayed);
            Assert.AreEqual(ExpectedResult, mainPage.getSignInButton().Displayed);
            Assert.AreEqual(ExpectedResult, mainPage.getSignUpButton().Displayed);


            //go to inspiration page
            InspirationPage inspirationPage = mainPage.clickInspirationButton();
            //check if Istanbul image is displayed in inspiration page
            Assert.AreEqual(ExpectedResult, inspirationPage.getIstanbulImage().Displayed);

            //check that Travel Data Keeper title is directing user to main page when clicked
            MainPage mainPage2 = inspirationPage.clickTravelDataKeeper();

            //click on sign in button
            LoginPage loginPage = mainPage2.signInButton();

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


        public static IEnumerable<TestCaseData> AddTestDataConfigforValidLogin()

        {

            yield return new TestCaseData(getDataParser().extractData("valid_username"), getDataParser().extractData("valid_password"));
        }
    }
}

