using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace RelTexPacNet.Calculators
{
    public class TextureAtlasInput
    {
        public CalculatorSettings Settings { get; private set; }

        private readonly Dictionary<string, TextureAtlasNode> _nodes;
        public TextureAtlasNode[] Nodes
        {
            get { return _nodes.Values.ToArray(); }
        }

        public TextureAtlasInput(CalculatorSettings settings)
        {
            ValidateSettings(settings);

            Settings = settings;
            _nodes = new Dictionary<string, TextureAtlasNode>();
        }

        private void ValidateSettings(CalculatorSettings settings)
        {
            if (settings.Size.Height <= 0) throw new ArgumentOutOfRangeException("Size.Height", settings.Size.Height, "Output texture height cannot be 0 or less");
            if (settings.Size.Width <= 0) throw new ArgumentOutOfRangeException("Size.Width", settings.Size.Width, "Output texture width cannot be 0 or less");
            if (settings.Padding < 0) throw new ArgumentOutOfRangeException("Padding", settings.Padding, "Output texture padding cannot be less than 0");
            if ((settings.Padding * 2 >= settings.Size.Height) || (settings.Padding * 2 >= settings.Size.Width)) 
                throw new ArgumentOutOfRangeException("Padding", settings.Padding, "Padding cannot be more than half of the output texture height and/or width");
        }

        public void AddSprite(Image image, string reference)
        {
            ValidateInput(image, reference);

            _nodes.Add(reference, new TextureAtlasNode
            {
                Texture = image,
                Reference = reference,
            });
        }

        private void ValidateInput(Image image, string reference)
        {
            if (image == null) throw new ArgumentNullException("image", @"Cannot add null images");
            if (reference == null) throw new ArgumentNullException("reference", @"Cannot add null references");
            if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentOutOfRangeException("reference", @"reference cannot be empty");

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