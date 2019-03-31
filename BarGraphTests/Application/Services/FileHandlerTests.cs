using Microsoft.VisualStudio.TestTools.UnitTesting;
using BarGraph.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BarGraph.Models;

namespace BarGraph.Application.Services.Tests
{
    [TestClass()]
    public class FileHandlerTests
    {
        public string ValidStringContents => @"#A:RED:5
            #B:BLUE:10
            #C:WHITE:15
            #D:GREEN:12";

        public string InValidStringContents => @"#_:RED:5
            #B:BLUE";

        [TestMethod()]
        public void Given_ValidContents_Expect_DataFile_Enumarator()
        {
            IFileHandler fileHandler = new FileHandler();
            var dataFiles = fileHandler.ParseRawString(ValidStringContents);
            Assert.IsTrue(typeof(IEnumerable<DataFile>).IsAssignableFrom(dataFiles.GetType()));
            Assert.AreEqual(dataFiles.Count(), 4);
        }

        [TestMethod()]
        public void Given_InValidContents_Expect_Exception()
        {
            IFileHandler fileHandler = new FileHandler();
            Assert.ThrowsException<Exception>(() => fileHandler.ParseRawString(InValidStringContents).Count());
        }
    }
}