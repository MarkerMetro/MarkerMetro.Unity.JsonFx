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
#else
        public void CollectionTest_sample()
#endif
        {


            string source = @"{""data"":[{""file"":""full"",""textureId"":""full"",""type"":""tshirt_pattern""},{""file"":""strip_diagonal"",""textureId"":""strip_diagonal"",""type"":""tshirt_pattern""}]}";
            var output = JsonReader.Deserialize<TextureFilesCatalog>(source);
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.textureFiles);
            Assert.IsTrue(output.textureFiles.Count > 0);
        }

        [TestMethod]
#if NETFX_CORE
        public void MetroAbstractCollectionTest_sample()
#else
        public void AbstractCollectionTest_sample()
#endif
        { 
            string source = @"{""data"":[{""file"":""full"",""textureId"":""full"",""type"":""tshirt_pattern""},{""file"":""strip_diagonal"",""textureId"":""strip_diagonal"",""type"":""tshirt_pattern""}]}";
            var output = JsonReader.Deserialize<InheritingCollection>(source);
            Assert.IsNotNull(output);
            Assert.IsNotNull(output.textureFiles);
            Assert.IsTrue(output.textureFiles.Count > 0);
        }

    }
}
