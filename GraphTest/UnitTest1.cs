using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraphTest
{
    [TestClass]
    public class UnitTest1
    {
        public Dictionary<string, string> Expectedpoints = new Dictionary<string, string>();
        public Dictionary<string, string> Actualpoints = new Dictionary<string, string>();
        public bool result = true;
        [TestInitialize]


        public void TestInitialize()
        {
            new GraphPage().OpenGraphPage();
            // new GraphPage().ToolTipsTextToDictionary(points); 
            Expectedpoints = new GraphPage().GetDataForTest();
        }

        [TestMethod]
        public void TestMethod1()
        {
            new GraphPage().ToolTipsTextToDictionary(Actualpoints);
            foreach (KeyValuePair<string, string>point  in Actualpoints)
            {
                
                if (point.Key != Expectedpoints[point.Key])
                {
                    result = false;
                    break;
                }
            }
            //new GraphPage().OpenGraphPage();
            //new GraphPage().CheckGraph(points);
            // bool res = new GraphPage().CheckGraph(points);
            Assert.IsTrue(result);
        }
    }
}
