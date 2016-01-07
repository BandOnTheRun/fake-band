using System.IO;

namespace FakeBand.Utils
{
    public static class Exts
    {
        public static byte[] GetPixelArrayBgr565(this Stream stream)
        {
            byte[] bgr565Array;
            using (Bgr565Pbgra32ConversionStream bgr565Pbgra32ConversionStream = new Bgr565Pbgra32ConversionStream((int)stream.Length))
            {
                stream.CopyTo(bgr565Pbgra32ConversionStream, 8192);
                bgr565Array = bgr565Pbgra32ConversionStream.Bgr565Array;
            }
            return bgr565Array;
        }
    }
}
