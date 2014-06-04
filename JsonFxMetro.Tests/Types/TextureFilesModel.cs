public class TextureFilesModel : ITextureFilesModel
{

    public string file;
    public string textureId;
    public string type;


    public string File { get { return file; } }
    public string TextureId { get { return textureId; } }
    public string Type { get { return type; } }

    public override string ToString()
    {
        return "TextureFilesModel:" + "\n" +
            ".file - " + file + "\n" +
                ".textureId - " + textureId + "\n" +
                ".type - " + type + "\n";
    }
}
