using System.Drawing;

namespace RelTexPacNet
{
    public interface ITextureAtlasRenderer
    {
        Bitmap Render(TextureAtlas atlas);
    }
}