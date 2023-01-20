using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TravelDataKeeperTestFramework.PageObjects
{
	public class TravelerOptionsPage
	{

        IWebDriver driver;

        public TravelerOptionsPage(IWebDriver driver)
		{

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //page object factory for My World Travel Map
        [FindsBy(How = How.XPath, Using = "//h4[normalize-space()='My World Travel Map']")]
        private IWebElement myWorldTravelMap;

        //page object factory for My Wish List
        [FindsBy(How = How.XPath, Using = "//h4[normalize-space()='My Wish List']")]
        private IWebElement MyWishList;

        //page object factory for My Blog Posts
        [FindsBy(How = How.XPath, Using = "//h4[normalize-space()='My Blog Posts']")]
        private IWebElement MyBlogPosts;

        //page object factory for Sign Out Button
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Sign Out']")]
        private IWebElement signOutButton;

        public void waitForTravelerOptionPageDisplay()

        {
            //wait until Sign In button is available
            //if Sign In button is available, it means that sign in page appears

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[normalize-space()='Sign Out']']")));
        }

        public IWebElement getMyWorldTravelMap()
        {
            return myWorldTravelMap;

        }

        public IWebElement getMyWishList()
        {
            return MyWishList;

        }

        public IWebElement getMyBlogPosts()
        {
            return MyBlogPosts;

        }

        public IWebElement SignOutButton()
        {
            return signOutButton;

        }


    }
}

