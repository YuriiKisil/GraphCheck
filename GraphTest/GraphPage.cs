using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace GraphTest
{
    class GraphPage : BasePage
    {
        public void OpenGraphPage()
        {
            driver.Navigate().GoToUrl("https://www.highcharts.com/demo/combo-timeline?__cf_chl_jschl_tk__=ef2cf32e3aba4d8a07eb77d98e342af21cd1fec5-1582547443-0-Ac4jESMS57PpuUpNFK0fcdcsyrL0wOaARb0xrJBPdGADsFyKrqLNLHj3pJZuGr0tV6K3ExgpJDL49Zggx_nubhVP4MxGmiWf98NAFjziC4D2-w53n4v_qpQSoqQIzA80jvqC2sLDQ97YHxJE7KH6uurPqy7ro1o3x1GLa16RX1a_Q9WIDZDLnNo4JJJ5uGGwtGEradWrGv0VZViqh9KX1xCzUQKSC79vvDF8fFxpe8lHUrwc9Q7iQoUgEeGDw2dp0mg5hJHqWDeZCp2JqkLOuFHUCTPAr-iawlO5aTClUPq83vBNsoC1CyxAks5CZr_ttVRifKhWunEBYsZow4GyvOFIPJXJXB_FcWIXnfFdf_ri");
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           
        }
        public void CheckGraph()
        {
            for (int i = 2; i<61; i++) 
            {
                
                Actions action = new Actions(driver);
               // Actions actions = action.MoveToElement(driver.FindElement(By.CssSelector("g[class='highcharts - markers highcharts - series - 0 highcharts - spline - series highcharts - color - 0 highcharts - tracker'] path:nth-child()")))
                action.MoveToElement(driver.FindElement(By.XPath("//*[@fill='#7cb5ec']["+i+"]"))).Perform(); 
                Thread.Sleep(1000);
                // tooltip xpath = "//*[@class='highcharts-label highcharts-tooltip highcharts-color-undefined                                                                                                                                                             highcharts-color-2']"
            }

        }

    }
}
