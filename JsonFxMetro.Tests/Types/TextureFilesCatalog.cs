using Pathfinding.Serialization.JsonFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class TextureFilesCatalog
    {
        [JsonName("data")]
        public List<TextureFilesModel> textureFiles;

    }
