﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Moq;
using Xunit;

namespace RelTexPacNet
{
    public class TextureAtlasRendererTests
    {
        [Fact]
        private void Render_output_matches_input_size()
        {
            const int width = 512;
            const int height = 256;

            var renderer = new TextureAtlasRenderer();
            var result = renderer.Render(new TextureAtlas {                 
                Size = new Size(width,height),
            });

            Assert.Equal(width, result.Width);
            Assert.Equal(height, result.Height);
        }

        [Fact]
        private void Render_output_uses_matte_color()
        {
            var color = Color.FromArgb(255,192,127,90);
            var renderer = new TextureAtlasRenderer();
            var result = renderer.Render(new TextureAtlas
            {
                MatteColor = color,
            });

            Assert.Equal(color, result.GetPixel(0, 0));
            Assert.Equal(color, result.GetPixel(result.Width - 1, result.Height -1));
        }        

        [Fact(Skip="No reference images yet")]
        private void Render_produces_expected_output()
        {            
            Assert.True(false);
            //TODO: needs reference images to compare
        }

        [Fact]
        private void Render_produces_expected_output_2()
        {
            var atlas = new TextureAtlas
            {
                MatteColor = Color.Fuchsia,
                Size = new Size(512, 512),
                Nodes = new[]{
                    new TextureAtlasNode{
                        Texture = Properties.Resources.boss3,
                        X = 1, Y = 1,
                    }, new TextureAtlasNode{
                        Texture = Properties.Resources.boss4,
                        X = 1, Y = 130,
                    }, new TextureAtlasNode{
                        Texture = Properties.Resources.boss2,
                        X = 258, Y = 1,
                    }, new TextureAtlasNode{
                        Texture = Properties.Resources.boss1,
                        X = 258, Y = 98,
                    }, new TextureAtlasNode{
                        Texture = Properties.Resources.ghost1,
                        X = 379, Y = 1,
                    }, new TextureAtlasNode{
                        Texture = Properties.Resources.ghost2,
                        X = 379, Y = 44,
                    }, 
                    new TextureAtlasNode{
                        Texture = Properties.Resources.La_Funk,
                        X = 415, Y = 87,
                    },
                },
            };

            var renderer = new TextureAtlasRenderer();
            var result = renderer.Render(atlas);
            
        }

        private void Dump(Bitmap bitmap)
        {
            bitmap.Save("C:\\" + DateTime.Now.Ticks + ".png");
        }
    }
}