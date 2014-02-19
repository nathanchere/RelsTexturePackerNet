using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RelTexPacNet
{
    public interface ITexture
    {
        byte[] Bitmap { get; }
        int Width { get; }
        int Height { get; set; }

    }
}
