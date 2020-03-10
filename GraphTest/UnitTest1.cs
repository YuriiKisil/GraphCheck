using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GraphTest
{
    [TestClass]
    public class UnitTest1
    {
        public Dictionary<string, string> Expectedpoints = new Dictionary<string, string>();
      //  public Dictionary<string, string> Actualpoints = new Dictionary<string, string>();
        public bool result = true;
        private object driver;

        [TestInitialize]

        public void TestInitialize()
        {
            new GraphPage().OpenGraphPage();
            Expectedpoints = new GraphPage().GetDataForTest();
            new GraphPage().TurnOffAllflags();
           // new GraphPage().ToolTipsTextToDictionary(Actualpoints);
        }   

        [TestMethod]
        public void TestMethod1()
        {    
            result = new GraphPage().CheckGraph(Expectedpoints);
            Assert.IsTrue(result);
        }
    }
}
