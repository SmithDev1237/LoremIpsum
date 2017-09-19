using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoremIpsumGenerator.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Generate_Returns_String()
        {
            var data = LoremIpsum.Generate(5);
            Assert.IsInstanceOfType(data, typeof(String));
        }
    }
}
