using System;
using System.Collections.Generic;
using System.IO;
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
        
        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Toggle visibility of Revenue']")]
        private IWebElement Graph2;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Toggle visibility of Highsoft employees']")]
        private IWebElement Graph3;

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-tooltip text")]
        private IWebElement ToolTipText;

      

        private void TurnOffGraph2and3()
        {
            Graph2.Click();
            Thread.Sleep(200);
            Graph3.Click();
            Thread.Sleep(200);
        }

        public void TurnOffAllflags()
        {
            IWebElement flag1 = driver.FindElement(By.CssSelector("g.highcharts-markers.highcharts-series-6.highcharts-flags-series.highcharts-tracker"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility='hidden'", flag1);
            IWebElement flag2 = driver.FindElement(By.CssSelector("g.highcharts-markers.highcharts-series-5.highcharts-flags-series.highcharts-tracker"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility='hidden'", flag2);
        }
        
        public void OpenGraphPage()
        {
            driver.Navigate().GoToUrl("https://www.highcharts.com/demo/combo-timeline?__cf_chl_jschl_tk__=ef2cf32e3aba4d8a07eb77d98e342af21cd1fec5-1582547443-0-Ac4jESMS57PpuUpNFK0fcdcsyrL0wOaARb0xrJBPdGADsFyKrqLNLHj3pJZuGr0tV6K3ExgpJDL49Zggx_nubhVP4MxGmiWf98NAFjziC4D2-w53n4v_qpQSoqQIzA80jvqC2sLDQ97YHxJE7KH6uurPqy7ro1o3x1GLa16RX1a_Q9WIDZDLnNo4JJJ5uGGwtGEradWrGv0VZViqh9KX1xCzUQKSC79vvDF8fFxpe8lHUrwc9Q7iQoUgEeGDw2dp0mg5hJHqWDeZCp2JqkLOuFHUCTPAr-iawlO5aTClUPq83vBNsoC1CyxAks5CZr_ttVRifKhWunEBYsZow4GyvOFIPJXJXB_FcWIXnfFdf_ri");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public Dictionary<String,String> GetDataForTest()
        {
            var dict = File.ReadLines(@"D:\ToolTips.csv").Select(line => line.Split(',')).ToDictionary(line => line[0], line => line[1]);
            return dict;
        }
        public void ToolTipsTextToDictionary(Dictionary<String, String> tooltips)
        {
            //TurnOffAllflags();
            //TurnOffGraph2and3();
           
            for (int i = 1; i < 61; i++)
            {

                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.XPath("//*[@fill='#7cb5ec'][" + i + "]"))).Perform();
                Thread.Sleep(20000);
                //IWebElement ToolTipDate = driver.FindElement(By.CssSelector("g.highcharts-tooltip text"));
                Console.WriteLine(ToolTipText.Text);
                //tooltips.Add(i.ToString(), ToolTipDate.Text);
            }


        }
        public bool CheckGraph(Dictionary<String, String> points)
        {
            TurnOffAllflags();
            TurnOffGraph2and3();
            bool res = true;
            for (int i = 1; i < 61; i++)
            {
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.XPath("//*[@fill='#7cb5ec'][" + i + "]"))).Perform();
                Thread.Sleep(200);
                IWebElement ToolTipDate = driver.FindElement(By.CssSelector("g.highcharts-tooltip text"));

                Console.WriteLine(ToolTipDate.Text);

               
                if (points[i.ToString()] != ToolTipDate.Text)
                {
                    res = false;
                    break;
                }

            }
            return res;

          

        }
    }
}
