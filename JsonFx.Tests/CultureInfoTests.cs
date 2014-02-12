using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace JsonFx.Tests
{
    [TestClass]
    public class CultureInfoTests
    {
        public class Test
        {
            public double Value { get; set; }
        }

        [TestMethod]
        public void Serializing_In_Same_Culture_Should_Produce_SameResult()
        {
            var original = new Test { Value = 3.14 };

            var sb = new StringBuilder();

            new Pathfinding.Serialization.JsonFx.JsonWriter(sb).Write(original);

            Debug.WriteLine(sb.ToString());

            var read = new Test();
            new Pathfinding.Serialization.JsonFx.JsonReader(sb.ToString()).PopulateObject(read);

            Assert.AreEqual(original.Value, read.Value);
        }

        [TestMethod]
        public void Serializing_From_English_To_French_Should_Produce_SameResult()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var original = new Test { Value = 3.14 };

            var sb = new StringBuilder();

            new Pathfinding.Serialization.JsonFx.JsonWriter(sb).Write(original);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            Debug.WriteLine(sb.ToString());

            var read = new Test();
            new Pathfinding.Serialization.JsonFx.JsonReader(sb.ToString()).PopulateObject(read);

            Assert.AreEqual(original.Value, read.Value);
        }
    }
}
