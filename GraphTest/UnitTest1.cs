using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new GraphPage().OpenGraphPage();
            new GraphPage().CheckGraph();
        }
    }
}
