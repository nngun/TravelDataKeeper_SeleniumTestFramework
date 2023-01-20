using System;
using OpenQA.Selenium;
using TravelDataKeeperTestFramework.PageObjects;
using TravelDataKeeperTestFramework.utilities;

namespace TravelDataKeeperTestFramework.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class SignUpTest : Base
	{

        [Test, Category("Regression")]
        public void invalidSignUpTest_NoDataEntered()
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign up button
            SignUpPage signupPage = mainPage.signUpButton();

            //wait for sign up page to be displayed
            signupPage.waitForSignUpPageDisplay();


            //call signup method with test data and store alert message text into the variable
            String alertWhenNoDataEntered = signupPage.SignUpwithNoInfo().Text;

            TestContext.Progress.WriteLine(alertWhenNoDataEntered);


            //check if alert message is shown correctly
            StringAssert.Contains("check your info", alertWhenNoDataEntered);


        }

        [Test, TestCaseSource("AddTestDataConfigforInvalidSignUp_ExistingUser"), Category("Regression")]


        public void invalidSignUpTest_ExistingUser(String existing_first_name, String existing_last_name, String existing_username, String existing_password)
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign up button
            SignUpPage signupPage = mainPage.signUpButton();

            //wait for sign up page to be displayed
            signupPage.waitForSignUpPageDisplay();


            //call signup method with test data and store alert message text into the variable
            String alertForExistingUser = signupPage.SignUpwithExistingUser(existing_first_name, existing_last_name, existing_username, existing_password).Text;
            TestContext.Progress.WriteLine(alertForExistingUser);

            //check if alert message is shown correctly
            StringAssert.Contains("already exists", alertForExistingUser);

        }

        [Test, TestCaseSource("AddTestDataConfigforInvalidSignUp_NoUsername"), Category("Regression")]


        public void invalidSignUpTests_NoUsername(String new_first_name, String new_last_name, String new_password)
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign up button
            SignUpPage signupPage = mainPage.signUpButton();

            //wait for sign up page to be displayed
            signupPage.waitForSignUpPageDisplay();


            //test error message when no username value is provided on sign up page
            //call signup method with test data and store alert message text into the variable
            String alertNoUsername = signupPage.SignUpwithoutUsername(new_first_name, new_last_name, new_password).Text;
            TestContext.Progress.WriteLine(alertNoUsername);

            //check if alert message is shown correctly
            StringAssert.Contains("check your info", alertNoUsername);

        }

        [Test, TestCaseSource("AddTestDataConfigforInvalidSignUp_NoPassword"), Category("Regression")]


        public void invalidSignUpTests_NoPassword(String new_first_name, String new_last_name, String new_username)
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign up button
            SignUpPage signupPage = mainPage.signUpButton();

            //wait for sign up page to be displayed
            signupPage.waitForSignUpPageDisplay();



            //test error message when no password value is provided on sign up page
            //call signup method with test data and store alert message text into the variable
            String alertNoPassword = signupPage.SignUpwithoutPassword(new_first_name, new_last_name, new_username).Text;
            TestContext.Progress.WriteLine(alertNoPassword);

            //check if alert message is shown correctly
            StringAssert.Contains("check your info", alertNoPassword);

        }

        [Test, TestCaseSource("AddTestDataConfigforInvalidSignUp_NoFname"), Category("Regression")]


        public void validSignUpTests_NoFName(String new_last_name, String new_username, String new_password)
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign up button
            SignUpPage signupPage = mainPage.signUpButton();

            //wait for sign up page to be displayed
            signupPage.waitForSignUpPageDisplay();


            //call signup method with test data and user will be directed to login page 
            LoginPage loginPage = signupPage.SignUpwithoutFname(new_last_name, new_username, new_password);


            //check button name is changed from Sign Up to Sign Out after proper login
            String expectedTitle = "LOGIN";
            Assert.AreEqual(expectedTitle, loginPage.getLoginTitle().Text);

        }


        [Test, TestCaseSource("AddTestDataConfigforInvalidSignUp_NoLname"), Category("Regression")]


        public void validSignUpTests_NoLName(String new_first_name, String new_username, String new_password)
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign up button
            SignUpPage signupPage = mainPage.signUpButton();

            //wait for sign up page to be displayed
            signupPage.waitForSignUpPageDisplay();



            //call signup method with test data and user will be directed to login page 
            LoginPage loginPage = signupPage.SignUpwithoutlname(new_first_name, new_username, new_password);


            //check button name is changed from Sign Up to Sign Out after proper login
            String expectedTitle = "LOGIN";
            Assert.AreEqual(expectedTitle, loginPage.getLoginTitle().Text);


        }

        [Test, TestCaseSource("AddTestDataConfigforValidSignUp"), Category("Regression")]


        public void validSignUpTests_AllFields(String new_first_name2, String new_last_name2, String new_username2, String new_password2)
        {
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //click on sign up button
            SignUpPage signupPage = mainPage.signUpButton();

            //wait for sign up page to be displayed
            signupPage.waitForSignUpPageDisplay();



            //call signup method with test data and user will be directed to login page 
            LoginPage loginPage = signupPage.SignUpwithNewUser(new_first_name2, new_last_name2,new_username2,new_password2);


            //check button name is changed from Sign Up to Sign Out after proper login
            String expectedTitle = "LOGIN";
            Assert.AreEqual(expectedTitle, loginPage.getLoginTitle().Text);


        }

        public static IEnumerable<TestCaseData> AddTestDataConfigforInvalidSignUp_ExistingUser()

        {
            yield return new TestCaseData(getDataParser().extractData("existing_first_name"),
                getDataParser().extractData("existing_last_name"), getDataParser().extractData("existing_username"),
                getDataParser().extractData("existing_password"));
        }

        public static IEnumerable<TestCaseData> AddTestDataConfigforValidSignUp()

        {
            yield return new TestCaseData(getDataParser().extractData("new_first_name2"),
                getDataParser().extractData("new_last_name2"), getDataParser().extractData("new_username2"),
                getDataParser().extractData("new_password2"));
        }


        public static IEnumerable<TestCaseData> AddTestDataConfigforInvalidSignUp_NoUsername()

        {
            yield return new TestCaseData(getDataParser().extractData("new_first_name"),
                getDataParser().extractData("new_last_name"),getDataParser().extractData("new_password"));
        }

        public static IEnumerable<TestCaseData> AddTestDataConfigforInvalidSignUp_NoPassword()

        {
            yield return new TestCaseData(getDataParser().extractData("new_first_name"),
                getDataParser().extractData("new_last_name"), getDataParser().extractData("new_username"));
        }

        public static IEnumerable<TestCaseData> AddTestDataConfigforInvalidSignUp_NoFname()

        {
            yield return new TestCaseData(getDataParser().extractData("noFname_lastname"), getDataParser().extractData("noFname_username"),
                getDataParser().extractData("noFname_password"));
        }

        public static IEnumerable<TestCaseData> AddTestDataConfigforInvalidSignUp_NoLname()

        {
            yield return new TestCaseData(getDataParser().extractData("noLname_firstname"), getDataParser().extractData("noLname_username"),
                getDataParser().extractData("noLname_password"));
        }

    }
}

