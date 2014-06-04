
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding.Serialization.JsonFx;
using Pathfinding.Serialization.JsonFx.Test.UnitTests;

#if NETFX_CORE || WINDOWS_PHONE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace JsonFxMetro.Tests
{
    [TestClass]

    public class CollectionTest
    {


        [TestMethod]
#if NETFX_CORE
        public void MetroCollectionTest_sample()
#elif WINDOWS_PHONE
        public void WP8CollectionTest_sample()
#else
        public void CollectionTest_sample()
#endif
        {
            //JsonReaderSettings readerSettings = new JsonReaderSettings();
            //readerSettings.TypeHintName = StronglyTyped.MyTypeHintName;
            //readerSettings.AllowNullValueTypes = true;
            //readerSettings.AllowUnquotedObjectKeys = false;

            //string source = @"{""data"":[{""file"":""full"",""textureId"":""full"",""type"":""tshirt_pattern""},{""file"":""strip_diagonal"",""textureId"":""strip_diagonal"",""type"":""tshirt_pattern""}]}";

            string source = @"{""file"":""full"",""textureId"":""full"",""type"":""tshirt_pattern"", ""data"":[{""file"":""full"",""textureId"":""full"",""type"":""tshirt_pattern""},{""file"":""strip_diagonal"",""textureId"":""strip_diagonal"",""type"":""tshirt_pattern""}]}";

            //object obj = null;
            //new JsonReader(value)).Deserialize(start, type)
            //var reader  = new JsonReader(source);
            //var test = reader.Deserialize(0, typeof(TextureFilesCatalog));

            var output = JsonReader.Deserialize<TextureFilesCatalog>(source);
            //var output = JsonReader.Deserialize<SimpleValueObject>(source);


            Assert.IsNotNull(output);
            Assert.IsNotNull(output.textureFiles);
            Assert.IsTrue(output.textureFiles.Count > 0);
            
            //Deserialize((obj == null) ? null : obj.GetType());
            //writer.WriteLine("READ: " + unitTestFile);
            //writer.WriteLine("Result: {0}", (obj == null) ? "null" : obj.GetType().FullName);

        }

    }
}
