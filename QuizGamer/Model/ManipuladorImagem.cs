using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QuizGamer.Model
{
    class ManipuladorImagem
    {
        public ManipuladorImagem()
        {

        }

        public byte[] transformaImagemByte(Image image)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                var byteArray = new byte[stream.Length];
                stream.Read(byteArray, 0, Convert.ToInt32(stream.Length));
                return byteArray;
            }
        }

        public bool comparaImagem(Image imagem1, Image imagem2)
        {
            return Enumerable.SequenceEqual(transformaImagemByte(imagem1), transformaImagemByte(imagem2));
        }
    }
}
