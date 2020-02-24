
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.PageObjects;


namespace GraphTest
{
    public class Browser
    {
        private static IWebDriver driver;

        public static IWebDriver Driver()
        {
            if (driver == null)
            { driver = new ChromeDriver(); }
            //driver = driver ?? new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return driver;
        }
    }
}
