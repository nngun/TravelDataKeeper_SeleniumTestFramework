using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TravelDataKeeperTestFramework.PageObjects
{
	public class InspirationPage
	{

        private IWebDriver driver;
        public InspirationPage(IWebDriver driver)
		{

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page object factory for Istanbul image
        [FindsBy(How = How.XPath, Using = "//app-root//div[@class='container']//div[1]//div[1]")]
        private IWebElement istanbulImage;

        //page object factory for Travel Data Keeper to be used to go back to main page
        [FindsBy(How = How.XPath, Using = "//body//app-root//h1[1]")]
        private IWebElement TravelDataKeeper;

        public IWebElement getIstanbulImage()
        {

            return istanbulImage;

        }

        public MainPage clickTravelDataKeeper()
        {
            TravelDataKeeper.Click();
            return new MainPage(driver);

        }


    }
}

