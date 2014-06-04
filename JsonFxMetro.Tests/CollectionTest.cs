using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pathfinding.Serialization.JsonFx;
using Pathfinding.Serialization.JsonFx.Test.UnitTests;

namespace JsonFxMetro.Tests
{
     [TestClass]
    public class CollectionTest
    {

        

            [TestMethod]
            public void CollectionTest_sample()
            {
                //JsonReaderSettings readerSettings = new JsonReaderSettings();
                //readerSettings.TypeHintName = StronglyTyped.MyTypeHintName;
                //readerSettings.AllowNullValueTypes = true;
                //readerSettings.AllowUnquotedObjectKeys = true;

                string source = @"{""data"":[{""file"":""full"",""textureId"":""full"",""type"":""tshirt_pattern""},{""file"":""strip_diagonal"",""textureId"":""strip_diagonal"",""type"":""tshirt_pattern""}]}";

                //object obj = null;
                var reader  = new JsonReader(source);
                var test = reader.Deserialize();

                var output = JsonReader.Deserialize<TextureFilesCatalog>(source);


                //Deserialize((obj == null) ? null : obj.GetType());
                //writer.WriteLine("READ: " + unitTestFile);
                //writer.WriteLine("Result: {0}", (obj == null) ? "null" : obj.GetType().FullName);

            }

    }
}
