using Pathfinding.Serialization.JsonFx;
using System.Collections.Generic;
public class SimpleValueObject
{

    public string file;
    public string textureId;
    public string type;

    [JsonName("data")]
    public List<SimpleValueObject> SimpleValueObjects { get; set; }
}
