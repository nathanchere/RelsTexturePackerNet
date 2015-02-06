using System.Drawing;

namespace RelTexPacNet
{
    public interface ITextureAtlasCalculator
    {
        void Add(Image image, string reference);
        void Clear();
        TextureAtlas Calculate();
    }
}