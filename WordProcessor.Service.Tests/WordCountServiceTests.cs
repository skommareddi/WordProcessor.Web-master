using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace WordProcessor.Service.Tests
{
    [TestClass]
    public class WordCountServiceTests
    {
        private WordCountService wordCountService;
        public WordCountServiceTests()
        {
            wordCountService = new WordCountService();
        }

        [TestMethod]
        public void Result_Should_Not_Be_Null()
        {
            var result= wordCountService.Process(new Models.WordCountInput { Text= "Test Input" });
            Assert.IsNotNull(result, "Result Should not be null");
            Assert.IsNotNull(result.WordCounts, "WordCounts should not be null");
        }

        [TestMethod]
        public void Result_Should_Have_Word_Count()
        {
            var result = wordCountService.Process(new Models.WordCountInput { Text = @"ASP NET Core is the open-source version of ASP NET, that runs on macOS, Linux, and Windows. " });
            Assert.AreEqual(15,result.WordCounts.Count(), "Result Should have 15 unique words");
            Assert.AreEqual(2,result.WordCounts.FirstOrDefault(p=>p.Word=="ASP").Count, "ASP Count should be 2");
            Assert.AreEqual(2, result.WordCounts.FirstOrDefault(p => p.Word == "NET").Count, "NET Count should be 2");
            Assert.AreEqual(1, result.WordCounts.FirstOrDefault(p => p.Word == "Windows").Count, "NET Count should be 1");
        }
    }
}
