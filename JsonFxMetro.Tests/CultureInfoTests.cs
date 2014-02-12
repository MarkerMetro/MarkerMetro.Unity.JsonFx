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
using System.Diagnostics;

namespace JsonFxMetro.Tests
{
    [TestClass]
    public class CultureInfoTests
    {
        public class Test
        {
            public double Value { get; set; }
        }

        [TestMethod, Ignore]
        public void Serializing_From_English_To_French_Should_Produce_SameResult()
        {
            //var original = new Test { Value = 3.14 };

            //var sb = new StringBuilder();

            //new Pathfinding.Serialization.JsonFx.JsonWriter(sb).Write(original);

            //Debug.WriteLine(sb.ToString());

            //var read = new Test();
            //new Pathfinding.Serialization.JsonFx.JsonReader(sb.ToString()).PopulateObject(read);

            //Assert.AreEqual(original.Value, read.Value);
        }
    }
}
