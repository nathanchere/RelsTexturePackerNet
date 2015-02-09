using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace RelTexPacNet.Calculators
{
    public class TextureAtlasInput
    {
        public CalculatorSettings Settings { get; private set; }
        public Dictionary<string, TextureAtlasNode> Nodes { get; private set; }
        

        public TextureAtlasInput(CalculatorSettings settings)
        {
            Settings = settings;
            Nodes = new Dictionary<string, TextureAtlasNode>();
        }

        public void AddSprite(Image image, string reference)
        {
            ValidateInput(image, reference);

            Nodes.Add(reference, new TextureAtlasNode
            {
                Texture = image,
                Reference = reference,
            });
        }

        private void ValidateInput(Image image, string reference)
        {
            if (image == null) throw new ArgumentNullException("image", @"Cannot add null images");
            if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException("reference", @"reference cannot be empty");

            int maxLength = Math.Max(
                Settings.Size.Width - Settings.Padding * 2,
                Settings.Size.Height - Settings.Padding * 2
                );

            if (image.Width > maxLength)
                throw new ArgumentOutOfRangeException("image", @"Image width excees atlas working area");
            if (image.Height > maxLength)
                throw new ArgumentOutOfRangeException("image", @"Image height excees atlas working area");
        }
    }
}