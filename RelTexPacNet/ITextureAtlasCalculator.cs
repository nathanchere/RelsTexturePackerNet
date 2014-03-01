﻿using System.Drawing;

namespace RelTexPacNet
{
    public interface ITextureAtlasCalculator
    {
        void Add(Image image, string reference);
        TextureAtlas Calculate();
    }
}