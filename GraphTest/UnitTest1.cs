using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraphTest
{
    [TestClass]
    public class UnitTest1
    {
        public Dictionary<string, string> points = new Dictionary<string, string>();
        [TestInitialize]
        
        
        public void TestInitialize()
        {
            new GraphPage().OpenGraphPage();
            //new GraphPage().ToolTipsTextToDictionary(points); 
            points = new GraphPage().GetDataForTest();
        }

        [TestMethod]
        public void TestMethod1()
        {
            
            //new GraphPage().OpenGraphPage();
            //new GraphPage().CheckGraph(points);
            bool res = new GraphPage().CheckGraph(points);
            Assert.IsTrue(res);
        }
    }
}
