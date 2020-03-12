using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace GraphTest
{
    class GraphPage : BasePage
    {
        public Dictionary<string, string> Expectedpoints = new Dictionary<string, string>();

        private string Path = "ToolTips.csv";

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Toggle visibility of Revenue']")]
        private IWebElement GraphRevenueButton;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Toggle visibility of Highsoft employees']")]
        private IWebElement GraphEmployeesButton;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Toggle visibility of Google search for highcharts']")]
        private IWebElement GraphGoogleButton;

        [FindsBy(How = How.CssSelector, Using = "g.highcharts-tooltip text")]
        private IWebElement ToolTipText;

        [FindsBy(How = How.CssSelector, Using = "*.highcharts-markers.highcharts-flags-series.highcharts-tracker")]
        private IList<IWebElement> Aditionalmarkers;

        private void TurnOffAllGraps()
        {
            GraphRevenueButton.Click();
            GraphEmployeesButton.Click();
            GraphGoogleButton.Click();
        }

        public void TurnOnGoogleGraph()
        {
            GraphGoogleButton.Click();
        }

        public void TurnOnEmployeesGraph()
        {
            GraphEmployeesButton.Click();
        }

        public void TurnOnRevenueGraph()
        {
            GraphRevenueButton.Click();
        }
        public void TurnOffAditionalmarkers()
        {
            foreach (IWebElement marker in Aditionalmarkers)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.visibility='hidden'", marker);
        }
        
        public void OpenGraphPage()
        {
            driver.Navigate().GoToUrl("https://www.highcharts.com/demo/combo-timeline?__cf_chl_jschl_tk__=ef2cf32e3aba4d8a07eb77d98e342af21cd1fec5-1582547443-0-Ac4jESMS57PpuUpNFK0fcdcsyrL0wOaARb0xrJBPdGADsFyKrqLNLHj3pJZuGr0tV6K3ExgpJDL49Zggx_nubhVP4MxGmiWf98NAFjziC4D2-w53n4v_qpQSoqQIzA80jvqC2sLDQ97YHxJE7KH6uurPqy7ro1o3x1GLa16RX1a_Q9WIDZDLnNo4JJJ5uGGwtGEradWrGv0VZViqh9KX1xCzUQKSC79vvDF8fFxpe8lHUrwc9Q7iQoUgEeGDw2dp0mg5hJHqWDeZCp2JqkLOuFHUCTPAr-iawlO5aTClUPq83vBNsoC1CyxAks5CZr_ttVRifKhWunEBYsZow4GyvOFIPJXJXB_FcWIXnfFdf_ri");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            TurnOffAllGraps();
        }
        public Dictionary<string, string> GetDataForTest(string CSV)
        {
            var dictGoogle = File.ReadLines(@"C:\Users\YK\Desktop\EPAM\Lab\ToolTipsGoogle.csv").Select(line => line.Split(',')).ToDictionary(line => line[0], line => line[1]);
            var dictRevenue = File.ReadLines(@"C:\Users\YK\Desktop\EPAM\Lab\ToolTipsRevenue.csv").Select(line => line.Split(',')).ToDictionary(line => line[0], line => line[1]);
            var dictEmployees = File.ReadLines(@"C:\Users\YK\Desktop\EPAM\Lab\ToolTipsEmployees.csv").Select(line => line.Split(',')).ToDictionary(line => line[0], line => line[1]);
            if (CSV == "ToolTipsRevenue.csv")
            {
                return dictRevenue;
            }
            else {
                if (CSV == "ToolTipsEmployees.csv")
                { return dictRevenue; }
                else
                    { return dictGoogle; }
            }
            
        }
        public void ToolTipsTextToDictionary(Dictionary<String, String> tooltips)
        {
                               
            for (int i = 1; i < 61; i++)
            {

                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.XPath("//*[@fill='#7cb5ec'][" + i + "]"))).Click().Build().Perform();
                Thread.Sleep(200);
                //IWebElement ToolTipDate = driver.FindElement(By.CssSelector("g.highcharts-tooltip text"));
                Console.WriteLine(ToolTipText.Text);
                //tooltips.Add(i.ToString(), ToolTipDate.Text);
            }


        }
        public bool CheckGraph(Dictionary<String, String> points)
        {
            bool res = true;
            for (int i = 1; i < 61; i++)
            {
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(By.XPath("//*[@fill='#7cb5ec'][" + i + "]"))).Perform();
                Thread.Sleep(200);
                //IWebElement ToolTipDate = driver.FindElement(By.CssSelector("g.highcharts-tooltip text"));
                if (points[i.ToString()] != ToolTipText.Text)
                {
                    res = false;
                    break;
                }

            }
            return res;
        }
    }
}
