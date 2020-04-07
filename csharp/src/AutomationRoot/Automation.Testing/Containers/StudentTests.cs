using Automation.Testing.Cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation.Testing.Containers
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void SearchStudentUiTest()
        {
            var actual = new SearchStudents().Execute().Actual;
            
            Assert.IsTrue(actual);
        }
    }
}