using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;
using Pathfinding.Serialization.JsonFx.Test.UnitTests;
using Pathfinding.Serialization.JsonFx;

namespace JsonFxMetro.Tests
{
    [TestClass]
    public class TestMetroMain
    {
        [TestClass]
        public class TestMain
        {
            public StorageFolder TestFolder { get; set; }
            public StorageFolder OutputFolder { get; set; }

            [TestInitialize]
            public async Task Initialize()
            {
                TestFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(Path.GetRandomFileName());
                OutputFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(Path.GetRandomFileName());
            }

            [TestCleanup]
            public async Task Cleanup()
            {
                await TestFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
                await OutputFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }

            [TestMethod]
            public void Metro_CyclicTest()
            {
                Cyclic.RunTest(new DebugWriter(), TestFolder.Path, OutputFolder.Path);
            }

            [TestMethod]
            public void Metro_JsonTextTest()
            {
                JsonText.RunTest(new DebugWriter(), TestFolder.Path, OutputFolder.Path);
            }

            [TestMethod]
            public void Metro_StronglyTypedTest()
            {
                StronglyTyped.RunTest(new DebugWriter(), TestFolder.Path, OutputFolder.Path);
            }

        }
    }
}
