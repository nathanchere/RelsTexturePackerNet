using System.Drawing;
using RelTexPacNet.Calculators;

namespace RelTexPacNet
{
    public interface ITextureAtlasCalculator
    {
        TextureAtlas Calculate(TextureAtlasInput input);
    }
}