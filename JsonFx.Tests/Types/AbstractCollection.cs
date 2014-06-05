using Pathfinding.Serialization.JsonFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class AbstractCollection
    {
        [JsonName("data")]
        public List<TextureFilesModel> textureFiles;

    }
