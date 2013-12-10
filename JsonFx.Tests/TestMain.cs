using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinding.Serialization.JsonFx.Test.UnitTests;
using System.Diagnostics;

namespace JsonFx.Tests
{
    [TestClass]
    public class TestMain
    {
        public string TestFolder { get; set; }
        public string OutputFolder { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            TestFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(TestFolder);

            OutputFolder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(OutputFolder);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Directory.Exists(TestFolder))
                Directory.Delete(TestFolder, true);
            if (Directory.Exists(OutputFolder))
                Directory.Delete(OutputFolder, true);
        }

        [TestMethod]
        public void CyclicTest()
        {
            Cyclic.RunTest(Console.Out, TestFolder, OutputFolder);
        }

        [TestMethod]
        public void JsonTextTest()
        {
            JsonText.RunTest(Console.Out, TestFolder, OutputFolder);
        }

        [TestMethod]
        public void StronglyTypedTest()
        {
            StronglyTyped.RunTest(Console.Out, TestFolder, OutputFolder);
        }
    }
}
