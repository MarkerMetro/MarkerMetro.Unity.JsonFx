using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Diagnostics;
using Windows.Storage;
using System.Threading.Tasks;
using Pathfinding.Serialization.JsonFx.Test.UnitTests;
using System.IO;

namespace JsonFxWP8.Tests
{
    [TestClass]
    public class TestMainWP8
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
        public void WP8_CyclicTest()
        {
            Cyclic.RunTest(new DebugWriter(), TestFolder.Path, OutputFolder.Path);
        }

        [TestMethod]
        public void WP8_JsonTextTest()
        {
            JsonText.RunTest(new DebugWriter(), TestFolder.Path, OutputFolder.Path);
        }

        [TestMethod]
        public void WP8_StronglyTypedTest()
        {
            StronglyTyped.RunTest(new DebugWriter(), TestFolder.Path, OutputFolder.Path);
        }
    }
}
